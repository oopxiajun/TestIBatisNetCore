using BP.Business;
using TestIBatisNetCore.Domain.Criteriaes;
using TestIBatisNetCore.Persistence.Interfaces;

namespace TestIBatisNetCore.Business
{
    public class Person : BP.Business.BusinessRule
    {
        Persistence.Interfaces.IPersonDao _personDao;
        public Person(BusinessRuleContext context) : base(context)
        {
            _personDao = GetDao<IPersonDao>();
        }
        public IList<Domain.Models.PersonModel> GetAllPersonList(  PersonCriteria criteria )
        {
            return _personDao.QueryPerson(criteria);
        }
    }
}