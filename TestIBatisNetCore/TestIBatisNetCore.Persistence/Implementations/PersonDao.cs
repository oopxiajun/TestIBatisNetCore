using IBatisNet.DataMapper;

namespace TestIBatisNetCore.Persistence.Implementations
{
    public class PersonDao:Interfaces.IPersonDao
    {
        public IList<Domain.Models.PersonModel> GetAllPersonList()
        {
            ISqlMapper mapper = Mapper.Instance();
            IList<Domain.Models.PersonModel> ListPerson = mapper.QueryForList<Domain.Models.PersonModel>("SelectAllPerson", null);  //这个"SelectAllPerson"就是xml映射文件的Id
            return ListPerson;
        }
    }
}
