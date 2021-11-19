namespace TestIBatisNetCore.Persistence.Interfaces
{
    public interface IPersonDao
    {
        public IList<Domain.Models.PersonModel> GetAllPersonList();
    }
}
