using Application.Model.EAVEngine;

namespace Application.Contracts.Persistence;
public interface IGetObjectMode<TCase, TCycle>
{
    TakeActionModel GetObjectModel(int id);
    int UpdateObjectModel(TakeActionModel reviewObjectModel, bool finalAction);
    int GetNextModel(TCase workflowCycle, TCycle wcase);
}
