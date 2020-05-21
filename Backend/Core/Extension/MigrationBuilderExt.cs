using Core.DataTypes;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Extension
{
    public static class MigrationBuilderExt
    {
        private static List<string> TablesCodeBooks => new List<string>()
        {
            "Cb_AddressType","Cb_Country","Cb_CourseStatus","Cb_CourseType","Cb_Culture","Cb_Email","Cb_GalleryItemType","Cb_License","Cb_TimeTable","Cb_AnswerMode","Cb_NotificationType"
        };
        private static List<string> TablesEdu => new List<string>()
        {
            "Edu_Branch","Edu_Category","Edu_ClassRoom","Edu_Course","Edu_CourseItem","Edu_CourseLesson","Edu_CourseRate","Edu_CourseTerm","Edu_CourseTest",
            "Edu_Inquiry","Edu_Job","Edu_LectorRate","Edu_Organization","Edu_OrganizationRole","Edu_OrganizationRolePermition","Edu_Person","Edu_Slider","Edu_StudentTestSummary","Edu_TestQuestion",
            "Edu_TestQuestionAnswer","Edu_TestStudentResult","Edu_User","Edu_UserRole","Edu_BankOfQuestion","Edu_Notification"
        };
        private static List<string> TablesLink => new List<string>()
        {
            "Link_CourseCategory","Link_CourseLector","Link_CourseStudent","Link_UserInOrganization","Link_UserInRole"
        };
        private static List<string> TablesShared => new List<string>()
        {
            "Shared_Address","Shared_BasicInformation","Shared_ContactInformation","Shared_CoursePrice","Shared_Gallery","Shared_StudentCount"
        };
        private static List<string> TablesSystem => new List<string>()
        {
            "System_DataMigration","System_ObjectHistory"
        };
        private static List<string> AllTables => TablesCodeBooks.Concat(TablesEdu).Concat(TablesLink).Concat(TablesShared).Concat(TablesSystem).ToList();
        public static List<string> GetAllTables(this MigrationBuilder migrationBuilder)
        {
            return AllTables;
        }

        public static void CreateSqlProcedure(this MigrationBuilder migrationBuilder, string name, string query)
        {
            migrationBuilder.CreateSqlProcedure(name, query, new Dictionary<string, string>());
        }
        public static void CreateSqlProcedure(this MigrationBuilder migrationBuilder, string name, string query, Dictionary<string, string> parametrs)
        {
            StringBuilder stringBuilder = new StringBuilder();
            migrationBuilder.Sql($"DROP PROCEDURE IF EXISTS  {name} ");
            stringBuilder.AppendLine($"CREATE PROCEDURE {name} ");
            if (parametrs.Count > 0)
            {
                stringBuilder.AppendLine(string.Join(",", parametrs.Select(x => $"{x.Key} {x.Value} \n").ToArray()));
            }
            stringBuilder.AppendLine("AS ");
            stringBuilder.AppendLine("BEGIN ");
            stringBuilder.AppendLine("SET NOCOUNT ON; ");
            stringBuilder.AppendLine("BEGIN TRY");
            stringBuilder.AppendLine("BEGIN TRANSACTION");
            stringBuilder.AppendLine(query);
            stringBuilder.AppendLine("COMMIT");
            stringBuilder.AppendLine("END TRY");
            stringBuilder.AppendLine("BEGIN CATCH");
            stringBuilder.AppendLine("ROLLBACK");
            stringBuilder.AppendLine("END CATCH");
            stringBuilder.AppendLine("END ");
            migrationBuilder.Sql(stringBuilder.ToString());
        }
        public static void DropSqlProcedure(this MigrationBuilder migrationBuilder, string name)
        {
            migrationBuilder.Sql($"DROP PROCEDURE {name}");
        }
        public static void CreateSqlFunctionAsTable(this MigrationBuilder migrationBuilder, string name, string query)
        {
            migrationBuilder.CreateSqlFunctionAsTable(name, query, null);
        }
        public static void CreateSqlFunctionAsTable(this MigrationBuilder migrationBuilder, string name, string query, Dictionary<string, string> parametrs)
        {
            List<string> param = new List<string>();
            if (parametrs != null)
            {
                foreach (KeyValuePair<string, string> item in parametrs)
                {
                    param.Add(string.Format("@{0} {1}", item.Key.TrimStart('@'), item.Value));
                }
            }
            StringBuilder stringBuilder = new StringBuilder();
            if (param.Count == 0)
            {
                stringBuilder.AppendLine($"CREATE FUNCTION {name}()");
            }
            else
            {
                stringBuilder.AppendLine($"CREATE FUNCTION {name}({string.Join(",", param)})");
            }
            stringBuilder.AppendLine("RETURNS TABLE  AS");
            stringBuilder.AppendLine("RETURN ");
            stringBuilder.AppendLine("( ");
            stringBuilder.AppendLine(query);
            stringBuilder.AppendLine(")");
            migrationBuilder.Sql(stringBuilder.ToString());
        }
        public static void DropSqlFunction(this MigrationBuilder migrationBuilder, string name)
        {
            migrationBuilder.Sql($"DROP FUNCTION {name}");
        }
        public static void AlterSqlFunctionAsTable(this MigrationBuilder migrationBuilder, string name, string query)
        {
            migrationBuilder.AlterSqlFunctionAsTable(name, query, null);
        }

        public static void AlterSqlFunctionAsTable(this MigrationBuilder migrationBuilder, string name, string query, Dictionary<string, string> parametrs)
        {
            migrationBuilder.DropSqlFunction(name);
            migrationBuilder.CreateSqlFunctionAsTable(name, query, parametrs);
        }
        public static void AddTriggerIsDeleted(this MigrationBuilder migrationBuilder, string name)
        {
            migrationBuilder.AddTriggerIsDeleted(name, new Dictionary<string, string>());
        }
        public static void AddTriggerIsDeleted(this MigrationBuilder migrationBuilder, string name, string query)
        {
            migrationBuilder.AddTriggerIsDeleted(name, new Dictionary<string, string>(), false, query);
        }
        public static void AddTriggerIsDeleted(this MigrationBuilder migrationBuilder, string name, Dictionary<string, string> cascade)
        {
            migrationBuilder.AddTriggerIsDeleted(name, cascade, false, string.Empty);
        }
        public static void AddTriggerIsDeleted(this MigrationBuilder migrationBuilder, string name, Dictionary<string, string> cascade, string query)
        {
            migrationBuilder.AddTriggerIsDeleted(name, cascade, false, query);
        }
        public static void AddTriggerIsDeleted(this MigrationBuilder migrationBuilder, string name, Dictionary<string, string> cascade, bool oneToMany)
        {
            migrationBuilder.AddTriggerIsDeleted(name, cascade, oneToMany, string.Empty);
        }

        public static void AddTriggerIsDeleted(this MigrationBuilder migrationBuilder, string name, Dictionary<string, string> cascade, bool oneToMany, string query)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"BEGIN ");
            stringBuilder.AppendLine($"SET NOCOUNT ON; ");
            stringBuilder.AppendLine($"DECLARE @oldData XML ");
            stringBuilder.AppendLine($"SET @oldData = ( ");
            stringBuilder.AppendLine($"SELECT * FROM {name} AS u ");
            stringBuilder.AppendLine($"INNER JOIN deleted AS d ");
            stringBuilder.AppendLine($"ON u.Id = d.Id ");
            stringBuilder.AppendLine($"WHERE u.Id = d.Id ");
            stringBuilder.AppendLine($"for xml path(''), root('Root'), binary base64 ");
            stringBuilder.AppendLine($") ");
            stringBuilder.AppendLine($"DECLARE @objectId uniqueidentifier ");
            stringBuilder.AppendLine($"SET @objectId = ( ");
            stringBuilder.AppendLine($"SELECT u.Id FROM {name} AS u ");
            stringBuilder.AppendLine($"INNER JOIN deleted AS d ");
            stringBuilder.AppendLine($"ON u.Id = d.Id ");
            stringBuilder.AppendLine($"WHERE u.Id = d.Id ");
            stringBuilder.AppendLine($") ");

            foreach (KeyValuePair<string, string> item in cascade)
            {
                if (oneToMany)
                {
                    stringBuilder.AppendLine($"DECLARE @result  uniqueidentifier; ");
                    stringBuilder.AppendLine($"DECLARE MY_CURSOR CURSOR ");
                    stringBuilder.AppendLine($"LOCAL STATIC READ_ONLY FORWARD_ONLY ");
                    stringBuilder.AppendLine($"FOR ");
                    stringBuilder.AppendLine($"SELECT Id FROM {item.Key} WHERE {item.Value} = (SELECT deleted.Id FROM deleted) ");
                    stringBuilder.AppendLine($"OPEN MY_CURSOR ");
                    stringBuilder.AppendLine($"FETCH NEXT FROM MY_CURSOR INTO @result ");
                    stringBuilder.AppendLine($"WHILE @@FETCH_STATUS = 0 ");
                    stringBuilder.AppendLine($"BEGIN ");
                    stringBuilder.AppendLine($"DELETE FROM {item.Key} WHERE Id = @result ");
                    stringBuilder.AppendLine($"FETCH NEXT FROM MY_CURSOR INTO @result ");
                    stringBuilder.AppendLine($"END ");
                    stringBuilder.AppendLine($"CLOSE MY_CURSOR ");
                    stringBuilder.AppendLine($"DEALLOCATE MY_CURSOR ");
                }
                else
                {
                    stringBuilder.AppendLine($"DELETE FROM {item.Key} WHERE Id = (SELECT deleted.{item.Value} FROM deleted)");
                }
            }
            if (!string.IsNullOrEmpty(query))
            {
                stringBuilder.AppendLine(query);
            }
            stringBuilder.AppendLine($"UPDATE u SET u.IsDeleted = 1 ");
            stringBuilder.AppendLine($"FROM {name} AS u ");
            stringBuilder.AppendLine($"INNER JOIN deleted AS d ");
            stringBuilder.AppendLine($"ON u.Id = d.Id AND u.IsSystemObject = 0 ");
            stringBuilder.AppendLine($"INSERT INTO System_ObjectHistory ");
            stringBuilder.AppendLine($"VALUES ");
            stringBuilder.AppendLine($"(NEWID(), 0, 0, 1, convert(nvarchar(50), NEWID()), @objectId, cast(@oldData as nvarchar(max)), null, '{name}', 'DELETE', SYSDATETIME(), null); ");
            migrationBuilder.AddDeleteTrigger(string.Format("SetIsDeleted_{0}", name), name, stringBuilder.ToString());
        }
        public static void AddDeleteTrigger(this MigrationBuilder migrationBuilder, string name, string tableName, string sql)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"CREATE TRIGGER {name} ");
            stringBuilder.AppendLine($"ON {tableName} ");
            stringBuilder.AppendLine($"INSTEAD OF DELETE ");
            stringBuilder.AppendLine($"AS ");
            stringBuilder.AppendLine(sql);
            stringBuilder.AppendLine($"END ");
            stringBuilder.AppendLine($"GO ");
            migrationBuilder.Sql(stringBuilder.ToString());
        }
        public static void AddInsertTrigger(this MigrationBuilder migrationBuilder, string name, string tableName, string sql)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"CREATE TRIGGER {name} ");
            stringBuilder.AppendLine($"ON {tableName} ");
            stringBuilder.AppendLine($"INSTEAD OF INSERT ");
            stringBuilder.AppendLine($"AS ");
            stringBuilder.AppendLine(sql);
            stringBuilder.AppendLine($"END ");
            stringBuilder.AppendLine($"GO ");
            migrationBuilder.Sql(stringBuilder.ToString());
        }

        public static void DropTrigger(this MigrationBuilder migrationBuilder, string name)
        {
            migrationBuilder.Sql($"DROP TRIGGER {name}");
        }

        public static void CreateDeleteProcedure(this MigrationBuilder migrationBuilder, string name)
        {
            migrationBuilder.CreateSqlProcedure($"Delete_{name}", $"DELETE FROM {name} WHERE Id =@Id AND IsDeleted = 0", new Dictionary<string, string>() { { "@Id", "uniqueidentifier" }, { "@UserId", "uniqueidentifier" } });
        }
        public static void CreateInsertProcedure(this MigrationBuilder migrationBuilder, string name, InsertProcedureTableConfig insertProcedureTableConfig)
        {
            List<string> insertColumns = new List<string>();
            List<object> values = new List<object>();
            StringBuilder procedureBody = new StringBuilder();
            string[] defaultColumns = new string[] { "Id", "IsDeleted", "IsSystemObject", "IsChanged", "SystemIdentificator" };
            object[] defaultValues = new object[] { $"@{insertProcedureTableConfig.TableName}_id", 0, 0, 1, "null" };
            foreach (string column in defaultColumns)
            {
                insertColumns.Add(column);
            }
            foreach (object value in defaultValues)
            {
                values.Add(value);
            }
            foreach (KeyValuePair<string, string> item in insertProcedureTableConfig.InsertColumns)
            {
                insertColumns.Add(item.Key.Replace("@", ""));
                values.Add($"{item.Key}");
            }
            procedureBody.AppendLine($"DECLARE @{insertProcedureTableConfig.TableName}_id uniqueidentifier ");
            procedureBody.AppendLine($"SET @{insertProcedureTableConfig.TableName}_id  = NEWID() ");
            if (insertProcedureTableConfig.SaveContactInformation)
            {
                insertColumns.Add("ContactInformationId");
                values.Add("@ContactInformationId");
                insertProcedureTableConfig.InsertColumns.Add("@ContactInformationEmail", "nvarchar(max)");
                insertProcedureTableConfig.InsertColumns.Add("@ContactInformationPhoneNumber", "nvarchar(max)");
                insertProcedureTableConfig.InsertColumns.Add("@ContactInformationWWW", "nvarchar(max)");
                procedureBody.AppendLine("DECLARE @ContactInformationId uniqueidentifier ");
                procedureBody.AppendLine("SET @ContactInformationId  = NEWID(); ");
                procedureBody.AppendLine($"INSERT INTO Shared_ContactInformation ({string.Join(", ", defaultColumns.ToArray())},Email,PhoneNumber,WWW) VALUES ");
                procedureBody.AppendLine($"(@ContactInformationId,0,0,1,null,@ContactInformationEmail,@ContactInformationPhoneNumber,@ContactInformationWWW);");
            }
            if (insertProcedureTableConfig.SaveBasicInformation)
            {
                insertColumns.Add("BasicInformationId");
                values.Add("@BasicInformationId");
                insertProcedureTableConfig.InsertColumns.Add("@BasicInformationName", "nvarchar(max)");
                insertProcedureTableConfig.InsertColumns.Add("@BasicInformationDescription", "nvarchar(max)");
                procedureBody.AppendLine("DECLARE @BasicInformationId uniqueidentifier ");
                procedureBody.AppendLine("SET @BasicInformationId  = NEWID(); ");
                procedureBody.AppendLine($"INSERT INTO Shared_BasicInformation ({string.Join(", ", defaultColumns.ToArray())},Name,Description) VALUES ");
                procedureBody.AppendLine($"(@BasicInformationId,0,0,1,null,@BasicInformationName,@BasicInformationDescription);");
            }

            if (insertProcedureTableConfig.SaveAddress)
            {
                insertColumns.Add("AddressId");
                values.Add("@AddressId");
                insertProcedureTableConfig.InsertColumns.Add("@AddressCountryId", "uniqueidentifier");
                insertProcedureTableConfig.InsertColumns.Add("@AddressRegion", "nvarchar(max)");
                insertProcedureTableConfig.InsertColumns.Add("@AddressCity", "nvarchar(max)");
                insertProcedureTableConfig.InsertColumns.Add("@AddressStreet", "nvarchar(max)");
                insertProcedureTableConfig.InsertColumns.Add("@AddressHouseNumber", "nvarchar(max)");
                insertProcedureTableConfig.InsertColumns.Add("@AddressZipCode", "nvarchar(max)");
                insertProcedureTableConfig.InsertColumns.Add("@AddressTypeId", "uniqueidentifier");
                procedureBody.AppendLine("DECLARE @AddressId uniqueidentifier ");
                procedureBody.AppendLine("SET @AddressId  = NEWID(); ");
                procedureBody.AppendLine($"INSERT INTO Shared_Address ({string.Join(", ", defaultColumns.ToArray())},CountryId,Region,City,Street,HouseNumber,ZipCode,AddressTypeId) VALUES ");
                procedureBody.AppendLine($"(@AddressId,0,0,1,null,@AddressCountryId,@AddressRegion,@AddressCity,@AddressStreet,@AddressHouseNumber,@AddressZipCode,@AddressTypeId);");
            }

            if (insertProcedureTableConfig.SaveCoursePrice)
            {
                insertColumns.Add("CoursePriceId");
                values.Add("@CoursePriceId");
                insertProcedureTableConfig.InsertColumns.Add("@CoursePrice", "float");
                insertProcedureTableConfig.InsertColumns.Add("@CoursePriceSale", "int");
                procedureBody.AppendLine("DECLARE @CoursePriceId uniqueidentifier ");
                procedureBody.AppendLine("SET @CoursePriceId  = NEWID(); ");
                procedureBody.AppendLine($"INSERT INTO Shared_CoursePrice ({string.Join(", ", defaultColumns.ToArray())},Price,Sale) VALUES ");
                procedureBody.AppendLine($"(@CoursePriceId,0,0,1,null,@CoursePrice,@CoursePriceSale);");
            }

            if (insertProcedureTableConfig.SaveStudentCount)
            {
                insertColumns.Add("StudentCountId");
                values.Add("@StudentCountId");
                insertProcedureTableConfig.InsertColumns.Add("@StudentCountMinimumStudent", "int");
                insertProcedureTableConfig.InsertColumns.Add("@StudentCountMaximumStudent", "int");
                procedureBody.AppendLine("DECLARE @StudentCountId uniqueidentifier ");
                procedureBody.AppendLine("SET @StudentCountId  = NEWID(); ");
                procedureBody.AppendLine($"INSERT INTO Shared_StudentCount ({string.Join(", ", defaultColumns.ToArray())},MinimumStudent,MaximumStudent) VALUES ");
                procedureBody.AppendLine($"(@StudentCountId,0,0,1,null,@StudentCountMinimumStudent,@StudentCountMaximumStudent);");
            }

            procedureBody.AppendLine($"INSERT INTO {insertProcedureTableConfig.TableName} ");
            procedureBody.AppendLine($"({string.Join(", ", insertColumns.ToArray())}) VALUES ");
            procedureBody.AppendLine($"({string.Join(", ", values.ToArray())}); ");
            foreach (KeyValuePair<string, string> item in insertProcedureTableConfig.CustomProcedureParametrs)
            {
                insertProcedureTableConfig.InsertColumns.Add(item.Key, item.Value);
            }
            foreach (CustomInsert item in insertProcedureTableConfig.CustomInsert)
            {
                foreach (string sql in item.BeforeQuery)
                {
                    procedureBody.AppendLine(sql);
                }
                if (!string.IsNullOrEmpty(item.TableName))
                {
                    procedureBody.AppendLine($"INSERT INTO {item.TableName} ");
                    procedureBody.AppendLine($"({string.Join(", ", item.Columns.Select(x => x.ColumnName).ToArray())}) VALUES ");
                    procedureBody.AppendLine($"({string.Join(", ", item.Columns.Select(x => x.ColumnValue).ToArray())}); ");
                }
            }
            foreach (CustomUpdate item in insertProcedureTableConfig.CustomUpdate)
            {
                foreach (string sql in item.BeforeQuery)
                {
                    procedureBody.AppendLine(sql);
                }
                if (!string.IsNullOrEmpty(item.TableName))
                {
                    procedureBody.AppendLine($"UPDATE {item.TableName} SET ");
                    procedureBody.AppendLine($"{string.Join(", ", item.Columns.Select(x => $"{x.ColumnName} = {x.ColumnValue}").ToArray())} ");
                    procedureBody.AppendLine($" WHERE {string.Join("AND ", item.WhereColumns.Select(x => $"{x.ColumnName} = {x.ColumnValue}").ToArray())} ");
                }
            }
            foreach (string item in insertProcedureTableConfig.CustomSql)
            {
                procedureBody.AppendLine(item);
            }
            migrationBuilder.CreateSqlProcedure(name, procedureBody.ToString(), insertProcedureTableConfig.InsertColumns);
        }
    }

}
