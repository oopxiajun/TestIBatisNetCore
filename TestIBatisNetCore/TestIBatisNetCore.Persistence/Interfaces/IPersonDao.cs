using BP.Domain;
using BP.Persistence;
using TestIBatisNetCore.Domain.Criteriaes;
using TestIBatisNetCore.Domain.Models;

namespace TestIBatisNetCore.Persistence.Interfaces
{
    public interface IPersonDao
    {
        public IList<Domain.Models.PersonModel> QueryPerson(Domain.Criteriaes.PersonCriteria criteria);
        public Pagination<PersonModel> QueryPaging(PersonCriteria criteria);
    }
}
