using Domain.Entities;

namespace Domain.Services.Interfaces
{
    public interface IDataBaseService
    {
        int Save(Customer customer);
        string SaveMaterials(Material material);
        IEnumerable<Customer> GetAll();
        IEnumerable<Material> GetAllMaterials();
        Address Get(int id);
        Address DeleteCustomers(int id);
        Material DeleteMaterial(int id);
        Task<List<Customer>> Search(string searchString);
        Task<List<Material>> SearchMaterial(string searchString);
    }
}
