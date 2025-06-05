using Dapper;
namespace Application.Contracts.Persistence;
public interface ISP_Call
{
    T Single<T>(string ProcedureName, DynamicParameters Param = null!);
    void Execute(string ProcedureName, DynamicParameters Param = null!);
    T oneRecord<T>(string ProcedureName, DynamicParameters Param = null!);
    IEnumerable<T> List<T>(string ProcedureName, DynamicParameters Param = null!);
    Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1, T2>(string ProcedureName, DynamicParameters Param = null!);
}

