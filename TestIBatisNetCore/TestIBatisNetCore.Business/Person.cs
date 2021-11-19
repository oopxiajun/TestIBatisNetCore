namespace TestIBatisNetCore.Business
{
    public class Person
    {
        public IList<Domain.Models.PersonModel> GetAllPersonList()
        {
            Persistence.Implementations.PersonDao personDao = new Persistence.Implementations.PersonDao();
            return personDao.GetAllPersonList();
        }
    }
}