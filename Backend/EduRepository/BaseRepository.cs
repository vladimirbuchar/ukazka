using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace EduRepository
{
    public abstract class BaseRepository : IBaseRepository
    {
        private readonly EduDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IMemoryCache _memoryCache;

        public BaseRepository(EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _memoryCache = memoryCache;
        }
        /// <summary>
        /// save entity to database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual T SaveEntity<T>(T obj) where T : TableModel
        {
            if (obj == null)
            {
                return null;
            }
            if (obj.IsDeleted || obj.IsSystemObject)
            {
                return obj;
            }
            if (obj.Id == Guid.Empty)
            {
                _dbContext.Add(obj);
                _dbContext.SaveChanges();
            }
            else
            {
                _dbContext.Update(obj);
                _dbContext.SaveChanges();
            }
            return obj;
        }

        /// <summary>
        /// delete entity from database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="guid"></param>
        public virtual void DeleteEntity<T>(Guid guid) where T : TableModel
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@p_Id", guid),
                new SqlParameter("@p_UserId", Guid.Empty)
            };
            CallSqlProcedure($"Delete_{GetTableName<T>()}", parameters);
        }
        private string GetTableName<T>()
        {
            if (typeof(T).GetCustomAttributes(
                typeof(TableAttribute), true).FirstOrDefault() is TableAttribute dnAttribute)
            {
                return dnAttribute.Name;
            }
            return null;
        }

        /// <summary>
        /// call sql function database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="functionName"></param>
        /// <returns></returns>
        protected List<T> CallSqlFunction<T>(string functionName) where T : SqlFunction
        {
            return CallSqlFunction<T>(functionName, new List<SqlParameter>());
        }
        /// <summary>
        /// call sql funtion database with parametrs
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="functionName"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        protected List<T> CallSqlFunction<T>(string functionName, List<SqlParameter> sqlParameters) where T : SqlFunction
        {
            return CallSqlFunction<T>(functionName, sqlParameters, false);
        }
        /// <summary>
        /// call sql function with parmetrs and cache
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="functionName"></param>
        /// <param name="sqlParameters"></param>
        /// <param name="cache"></param>
        /// <returns></returns>
        protected List<T> CallSqlFunction<T>(string functionName, List<SqlParameter> sqlParameters, bool cache) where T : SqlFunction
        {
            string cacheIdentificator = string.Empty;
            if (cache)
            {
                cacheIdentificator = string.Format("{0}_{1}", typeof(T).Name, functionName);
                if (sqlParameters.Count > 0)
                {
                    List<string> paramNames = sqlParameters.Select(x => $"{x.ParameterName}_{x.Value}").ToList();
                    cacheIdentificator = string.Format("{0}_{1}", cacheIdentificator, string.Join("_", paramNames));
                }
                List<T> data = GetDataFromCache<T>(cacheIdentificator).ToList();
                if (data != null)
                {
                    return data;
                }
            }
            SqlConnection conn = new SqlConnection(_connectionString);
            string sql = string.Empty;

            if (sqlParameters.Count == 0)
            {
                sql = string.Format("SELECT * FROM {0}()", functionName);
            }
            else
            {
                List<string> paramNames = sqlParameters.Select(x => x.ParameterName).ToList();
                sql = string.Format("SELECT * FROM {0}({1})", functionName, string.Join(",", paramNames));
            }

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using SqlCommand command = new SqlCommand(sql, conn);
            foreach (SqlParameter sqlParameter in sqlParameters)
            {
                command.Parameters.Add(sqlParameter);
            }
            SqlDataReader reader = command.ExecuteReader();
            using (DataTable dt = new DataTable())
            {
                dt.Load(reader);
                List<T> data = new List<T>();
                foreach (DataRow row in dt.Rows)
                {
                    T item = GetItem<T>(row);
                    data.Add(item);
                }
                conn.Close();
                if (cache)
                {
                    SaveDataToCache(cacheIdentificator, data, DateTime.Now.AddMinutes(20));
                }
                return data;
            }
        }
        protected void CallSqlProcedure(string procedureName, List<SqlParameter> sqlParameters)
        {
            Guid guid = Guid.Empty;
            CallSqlProcedure(procedureName, sqlParameters, false, ref guid);
        }
        /// <summary>
        /// call sql procedure in database
        /// </summary>
        /// <param name="procedureName"></param>
        protected void CallSqlProcedure(string procedureName, List<SqlParameter> sqlParameters, bool returnValue, ref Guid outGuid)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            string sql = string.Empty;
            if (sqlParameters.Count == 0)
            {
                sql = string.Format("EXEC {0}", procedureName);
            }
            else
            {
                List<string> paramNames = sqlParameters.Select(x => $"{x.ParameterName.Replace("@p_", "@")} = {x.ParameterName}").ToList();
                sql = string.Format("EXEC {0} {1}", procedureName, string.Join(",", paramNames));
            }
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            using SqlCommand command = new SqlCommand(sql, conn);
            foreach (SqlParameter sqlParameter in sqlParameters)
            {
                command.Parameters.Add(sqlParameter);
            }
            if (returnValue)
            {
                SqlDataReader reader = command.ExecuteReader();
                using (DataTable dt = new DataTable())
                {
                    dt.Load(reader);
                    outGuid = Guid.Parse(dt.Rows[0]["OutGuid"].ToString());
                }
            }
            else
            {
                command.ExecuteNonQuery();
            }
            conn.Close();
        }
        /// <summary>
        /// convert db result to entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dr"></param>
        /// <returns></returns>
        private T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                PropertyInfo pro = temp.GetProperties().FirstOrDefault(x => x.Name == column.ColumnName);
                if (pro?.Name == column.ColumnName)
                {
                    if (!(dr[column.ColumnName] is DBNull))
                    {
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    }
                }
            }
            return obj;
        }
        /// <summary>
        /// return all entities
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual HashSet<T> GetEntities<T>() where T : TableModel
        {
            return _dbContext.Set<T>().Where(x => !x.IsDeleted).ToHashSet();
        }
        /// <summary>
        /// get entity by id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T GetEntity<T>(Guid id) where T : TableModel
        {
            return _dbContext.Set<T>().FirstOrDefault(x => x.Id == id && !x.IsDeleted);
        }

        /// <summary>
        /// find entity by identificator
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="identificator"></param>
        /// <returns></returns>
        public virtual T GetEntity<T>(string identificator) where T : TableModel
        {
            return _dbContext.Set<T>().FirstOrDefault(x => x.SystemIdentificator == identificator && !x.IsDeleted);
        }
        /// <summary>
        /// save data to cache
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="identificator"></param>
        /// <param name="data"></param>
        /// <param name="expiration"></param>
        protected void SaveDataToCache<T>(string identificator, T data, DateTime expiration)
        {
            _memoryCache.Set(identificator, data, new MemoryCacheEntryOptions()
            {
                AbsoluteExpiration = expiration
            });
        }
        /// <summary>
        /// save data to cache
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="identificator"></param>
        /// <param name="data"></param>
        /// <param name="expiration"></param>
        protected void SaveDataToCache<T>(string identificator, List<T> data, DateTime expiration)
        {
            _memoryCache.Set(identificator, data, new MemoryCacheEntryOptions()
            {
                AbsoluteExpiration = expiration
            });
        }
        /// <summary>
        /// get data from cache
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="identificator"></param>
        /// <returns></returns>
        protected HashSet<T> GetDataFromCache<T>(string identificator)
        {
            return (HashSet<T>)_memoryCache.Get(identificator);
        }
    }
}
