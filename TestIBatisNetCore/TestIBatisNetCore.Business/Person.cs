﻿using BP.Business;
using BP.Domain;
using TestIBatisNetCore.Domain.Criteriaes;
using TestIBatisNetCore.Domain.Models;
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
        public IList<Domain.Models.PersonModel> GetAllPersonList(PersonCriteria criteria)
        {
            return _personDao.QueryPerson(criteria);
        }

        public Pagination<PersonModel> QueryPaging(PersonCriteria criteria)
        {
            return _personDao.QueryPaging(criteria);
        }
    }
}