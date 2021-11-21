using BP.Persistence;

namespace TestIBatisNetCore.Persistence.Interfaces
{
    public interface IPersonDao
    {
        public IList<Domain.Models.PersonModel> QueryPerson(Domain.Criteriaes.PersonCriteria criteria);
    }
}
