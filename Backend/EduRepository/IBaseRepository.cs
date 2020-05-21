using Model;
using System;
using System.Collections.Generic;

namespace EduRepository
{
    public interface IBaseRepository
    {
        /// <summary>
        /// save entity to database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        T SaveEntity<T>(T obj) where T : TableModel;
        /// <summary>
        /// delete entity from database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="guid"></param>
        void DeleteEntity<T>(Guid guid) where T : TableModel;
        /// <summary>
        /// get entity by Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Id"></param>
        /// <returns></returns>
        T GetEntity<T>(Guid Id) where T : TableModel;
        /// <summary>
        /// get entity by identificator
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="identificator"></param>
        /// <returns></returns>
        T GetEntity<T>(string identificator) where T : TableModel;
        /// <summary>
        /// get all entities
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        HashSet<T> GetEntities<T>() where T : TableModel;
    }
}
