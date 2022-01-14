using BP.Domain;
using TestIBatisNetCore.Domain.Criteriaes;
using TestIBatisNetCore.Domain.Models;

namespace TestIBatisNetCore.Persistence.Implementations
{
    public class PersonDao : BP.Persistence.BaseDao, Interfaces.IPersonDao
    {
        public IList<Domain.Models.PersonModel> QueryPerson(Domain.Criteriaes.PersonCriteria criteria)
        {
            return base.QueryList<Domain.Models.PersonModel>("QueryPerson", criteria);  //这个"SelectAllPerson"就是xml映射文件的Id              ;
        }

        /// <summary>
        /// 分页查询记录
        /// </summary>
        public Pagination<PersonModel> QueryPaging(PersonCriteria criteria)
        {
            return base.QueryObject<Pagination<PersonModel>>("QueryPagingPerson", criteria);
        }

    }
}
