using Application.Contracts.Presistence;
using Dapper;
using Microsoft.Data.SqlClient;
using Persistence.Data;
using System.Data;

namespace Persistence.Repositories.Common
{
    /// <summary>
    /// Represents a class for executing stored procedures and handling data retrieval using Dapper.
    /// </summary>
    public sealed class SP_Call : ISP_Call
    {
        private readonly string _connectionString = DbConnection.DefaultConnection;

        /// <summary>
        /// Executes a stored procedure without returning any result.
        /// </summary>
        /// <param name="ProcedureName">The name of the stored procedure to execute.</param>
        /// <param name="Param">Optional parameters to pass to the stored procedure.</param>
        public void Execute(string ProcedureName, DynamicParameters Param = null!)
        {
            using (SqlConnection sqlConn = new SqlConnection(_connectionString))
            {
                sqlConn.Open();
                sqlConn.Execute(ProcedureName, Param, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Retrieves a list of entities from a stored procedure.
        /// </summary>
        /// <typeparam name="T">The type of entity to retrieve.</typeparam>
        /// <param name="ProcedureName">The name of the stored procedure to execute.</param>
        /// <param name="Param">Optional parameters to pass to the stored procedure.</param>
        /// <returns>A list of entities retrieved from the stored procedure.</returns>
        public IEnumerable<T> List<T>(string ProcedureName, DynamicParameters Param = null!)
        {
            using (SqlConnection sqlConn = new SqlConnection(_connectionString))
            {
                sqlConn.Open();
                return sqlConn.Query<T>(ProcedureName, Param, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        /// <summary>
        /// Retrieves multiple sets of entities from a stored procedure.
        /// </summary>
        /// <typeparam name="T1">The type of the first set of entities to retrieve.</typeparam>
        /// <typeparam name="T2">The type of the second set of entities to retrieve.</typeparam>
        /// <param name="ProcedureName">The name of the stored procedure to execute.</param>
        /// <param name="Param">Optional parameters to pass to the stored procedure.</param>
        /// <returns>A tuple containing the retrieved sets of entities.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1, T2>(string ProcedureName, DynamicParameters Param = null!)
        {
            using (SqlConnection sqlConn = new SqlConnection(_connectionString))
            {
                sqlConn.Open();
                var result = sqlConn.QueryMultiple(ProcedureName, Param, commandType: CommandType.StoredProcedure);
                var item1 = result.Read<T1>();
                var item2 = result.Read<T2>();
                if (item1 != null! && item2 != null!)
                {
                    return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(item1, item2);
                }
            }
            return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(new List<T1>(), new List<T2>());
        }

        /// <summary>
        /// Retrieves a single record of a specific type from a stored procedure.
        /// </summary>
        /// <typeparam name="T">The type of the record to retrieve.</typeparam>
        /// <param name="ProcedureName">The name of the stored procedure to execute.</param>
        /// <param name="Param">Optional parameters to pass to the stored procedure.</param>
        /// <returns>A single record of the specified type retrieved from the stored procedure.</returns>
        public T oneRecord<T>(string ProcedureName, DynamicParameters Param = null!)
        {
            using (SqlConnection sqlConn = new SqlConnection(_connectionString))
            {
                sqlConn.Open();
                var result = sqlConn.Query<T>(ProcedureName, Param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return (T)Convert.ChangeType(result!, typeof(T));
            }
        }

        /// <summary>
        /// Retrieves a single value from a stored procedure.
        /// </summary>
        /// <typeparam name="T">The type of the value to retrieve.</typeparam>
        /// <param name="ProcedureName">The name of the stored procedure to execute.</param>
        /// <param name="Param">Optional parameters to pass to the stored procedure.</param>
        /// <returns>A single value of the specified type retrieved from the stored procedure.</returns>
        public T Single<T>(string ProcedureName, DynamicParameters Param = null!)
        {
            using (SqlConnection sqlConn = new SqlConnection(_connectionString))
            {
                sqlConn.Open();
                var result = sqlConn.ExecuteScalar<T>(ProcedureName, Param, commandType: CommandType.StoredProcedure);
                return (T)Convert.ChangeType(result!, typeof(T));
            }
        }
    }
}
