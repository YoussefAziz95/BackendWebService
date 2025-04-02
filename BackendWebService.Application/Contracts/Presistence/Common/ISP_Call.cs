using Dapper;

namespace Application.Contracts.Presistence
{
    /// <summary>
    /// Interface for executing stored procedures using Dapper.
    /// </summary>
    public interface ISP_Call
    {
        /// <summary>
        /// Executes a stored procedure and returns a single result of type T.
        /// </summary>
        /// <typeparam name="T">The type of the result.</typeparam>
        /// <param name="ProcedureName">The name of the stored procedure.</param>
        /// <param name="Param">The parameters for the stored procedure.</param>
        /// <returns>The result of the stored procedure.</returns>
        T Single<T>(string ProcedureName, DynamicParameters Param = null!);

        /// <summary>
        /// Executes a stored procedure without returning any result.
        /// </summary>
        /// <param name="ProcedureName">The name of the stored procedure.</param>
        /// <param name="Param">The parameters for the stored procedure.</param>
        void Execute(string ProcedureName, DynamicParameters Param = null!);

        /// <summary>
        /// Executes a stored procedure and returns a single record of type T.
        /// </summary>
        /// <typeparam name="T">The type of the record.</typeparam>
        /// <param name="ProcedureName">The name of the stored procedure.</param>
        /// <param name="Param">The parameters for the stored procedure.</param>
        /// <returns>A single record of type T.</returns>
        T oneRecord<T>(string ProcedureName, DynamicParameters Param = null!);

        /// <summary>
        /// Executes a stored procedure and returns a list of results of type T.
        /// </summary>
        /// <typeparam name="T">The type of the results.</typeparam>
        /// <param name="ProcedureName">The name of the stored procedure.</param>
        /// <param name="Param">The parameters for the stored procedure.</param>
        /// <returns>A list of results of type T.</returns>
        IEnumerable<T> List<T>(string ProcedureName, DynamicParameters Param = null!);

        /// <summary>
        /// Executes a stored procedure and returns two lists of results of types T1 and T2 respectively.
        /// </summary>
        /// <typeparam name="T1">The type of the first result list.</typeparam>
        /// <typeparam name="T2">The type of the second result list.</typeparam>
        /// <param name="ProcedureName">The name of the stored procedure.</param>
        /// <param name="Param">The parameters for the stored procedure.</param>
        /// <returns>A tuple containing two lists of results of types T1 and T2 respectively.</returns>
        Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1, T2>(string ProcedureName, DynamicParameters Param = null!);
    }
}
