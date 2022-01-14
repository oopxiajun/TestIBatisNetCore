using BP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestIBatisNetCore.Domain.Criteriaes
{
    public class PersonCriteria: SortingPagingCriteria
    {
        public int? Id
        {
            get;
            set;
        }

        public string? Name
        {
            get;
            set;
        }
    }
}
