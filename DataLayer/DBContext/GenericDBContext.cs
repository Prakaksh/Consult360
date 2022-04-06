using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static DataLayer.Utility.SqlUtility;

namespace DataLayer.DBContext
{
    public abstract class GenericDBContext
    {
        protected IDbConnection sqlCon;
        protected DynamicParameters com;
        protected List<T> Get<T>(DynamicParameters _parameter, string _spName)
        {
            List<T> result = new();
            try
            {
                using (sqlCon = GetConnection())
                {
                    result = sqlCon.Query<T>(_spName, _parameter, commandType: CommandType.StoredProcedure)
                        .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        protected string Delete(DynamicParameters _parameter, string _spName)
        {
            try
            {
                using (sqlCon = GetConnection())
                {
                    return sqlCon.Query<string>(_spName, _parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected string Create(DynamicParameters _parameter, string _spName)
        {
            try
            {
                using (sqlCon = GetConnection())
                {
                    return sqlCon.Query<string>(_spName, _parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }


            catch (Exception)
            {
                throw;

            }
        }

        protected void SaveChanges(DynamicParameters _parameter, string _spName)
        {
            try
            {
                using (sqlCon = GetConnection())
                {
                    sqlCon.Execute(_spName, _parameter, commandType: CommandType.StoredProcedure);
                }
            }


            catch (Exception)
            {
                throw;

            }
        }
        protected object GetByID(DynamicParameters _parameter, string _spName)
        {
            try
            {
                using (sqlCon = GetConnection())
                {
                    return sqlCon.Query<object>(_spName, _parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }


            catch (Exception)
            {
                throw;

            }
        }


       

    }
}
