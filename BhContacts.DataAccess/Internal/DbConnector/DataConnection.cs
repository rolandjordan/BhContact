using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using BhContacts.DataAccess.Internal.CustomException;
using BhContacts.DataAccess.Internal.Validation;
using BhContacts.WebUtils;
using Dapper;

namespace BhContacts.DataAccess.Internal.DbConnector
{
    internal static class DataConnection
    {
        public static List<TResponse> GetData<TRequest, TResponse>(string proc, TRequest request) where TRequest : class
        {
            if (request.IsValid())
            {
                using (var connection = new SqlConnection(AppConfiguration.Instance["ConnectionStrings:DefaultConnection"]))
                {
                    connection.Open();
                    try
                    {
                        return connection.Query<TResponse>(proc, request, commandType: CommandType.StoredProcedure).ToList();
                    }
                    catch (SqlException ex)
                    {
                        throw new DataResultException(ex.Message, ex);
                    }
                }
            }

            return null;
        }

        public static List<TResponse> GetData<TResponse>(string proc)
        {
            using (var connection = new SqlConnection(AppConfiguration.Instance["ConnectionStrings:DefaultConnection"]))
            {
                connection.Open();
                try
                {
                    return connection.Query<TResponse>(proc, commandType: CommandType.StoredProcedure).ToList();
                }
                catch (SqlException ex)
                {
                    throw new DataResultException(ex.Message, ex);
                }
            }
        }
    }
}
