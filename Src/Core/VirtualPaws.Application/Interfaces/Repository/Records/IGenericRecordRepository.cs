using VirtualPaws.Domain.Common;

namespace VirtualPaws.Application.Interfaces.Repository.Records
{
    public interface IGenericRecordRepository<T> where T : BaseRecordEntity
    {
        List<T> GetAll();
        T GetById(int id);
        void Create(T entity);
    }
}
