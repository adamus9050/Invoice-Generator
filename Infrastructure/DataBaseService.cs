using Microsoft.EntityFrameworkCore;
using System.Data;
using Domain.Entities;
using Domain.Services.Interfaces;
using System.Dynamic;
using System.Net;
using Infrastructure.Persistence;

namespace Infrastructure.Services
{
    public class DataBaseService : IDataBaseService
    {
        private readonly DbCustContext _context;
        public DataBaseService(DbCustContext dbContext)
        {
            _context = dbContext;
        }

        public Address DeleteCustomers(int id)
        {
            Address idDel = _context.Addresses.Find(id);
            _context.Addresses.Remove(idDel);
            _context.SaveChanges();
            return idDel;
        }

        public Material DeleteMaterial(int id)
        {

            //var idMat = _context.Materials.Where(x => x.Id == id).FirstOrDefault();
            Material idMat = _context.Materials.Find(id);
            _context.Materials.Remove(idMat);
            _context.SaveChanges();
            return idMat;
        }

        public Address Get(int id)
        {

            var customer = _context.Addresses.Find(id);
            return customer;
        }

        public IEnumerable<Customer> GetAll()
        {
            var klient = _context.Customers.ToList();
            return klient;
        }
        public IEnumerable<Material> GetAllMaterials()
        {
            var materials = _context.Materials.ToList();
            return materials;
        }

        public int Save(Customer customer)
        {
            _context.Customers.Add(customer);

            if (_context.SaveChanges() > 0)
            {
                Console.WriteLine("Udało się dodać klienta");
            };

            return customer.Id;
        }
        public string SaveMaterials(Material material)
        {
            _context.Materials.Add(material);

            if (_context.SaveChanges() > 0)
            {
                Console.WriteLine("Udało się dodać matrial");
            }
            var idmaterial = $"l.p{material.Id} Nazwa: {material.Name} Cena: {material.Price}";
            return idmaterial;
        }
        public async Task<List<Customer>> Search(string searchString)
        {
            var customer = from m in _context.Customers
                           select m;

            customer = customer.Where(x => x.Name!.Contains(searchString) || x.Surname!.Contains(searchString) || x.PhoneNumber!.Contains(searchString));

            var zmienna = await customer.ToListAsync();
            return zmienna;
        }
        public async Task<List<Material>> SearchMaterial(string searchString)
        {
            var material = from m in _context.Materials
                           select m;

            material = material.Where(x => x.Name!.Contains(searchString) || (x.Price!.ToString().Contains(searchString)));

            var zmienna1 = await material.ToListAsync();
            return zmienna1;
        }
    }
}
