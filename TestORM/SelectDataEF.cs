using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TestORM.Models;

namespace TestORM
{
    public class SelectDataEF : IDisposable
    {
        private readonly NorthwindContext _contex = null;
        private readonly DateTime _dateBegin;

        public SelectDataEF()
        {
            _contex = new NorthwindContext();
            _dateBegin = DateTime.Now;

            PingDb();
        }

        public void Dispose() => _contex?.Dispose();


        private void PingDb()
        {
            Console.WriteLine("Ping - SelectDataEF");
            _contex.Products.Take(10).ToList();
        }

        public Customers GetCustomer(string id) => _contex.Customers.FirstOrDefault(f => f.CustomerId.Equals(id));

        public IEnumerable<Customers> GetCustomers() => _contex.Customers;

        public IQueryable<Products> GetProducts() => _contex.Products;


        public (IEnumerable<Products> list, int totalMilliseconds) GetProducts(int take) => (_contex.Products.Take(take), DateTime.Now.Subtract(_dateBegin).Milliseconds);

        public (Products prod, int totalMilliseconds) GetProduct(int id) => 
            (_contex.
                Products.
                FirstOrDefault(f => f.ProductId == id), 
                DateTime.Now.Subtract(_dateBegin).Milliseconds);

        public (Products prod, int totalMilliseconds) GetProductByName(string name) => (_contex.Products.FirstOrDefault(f => f.ProductName.Equals(name)),DateTime.Now.Subtract(_dateBegin).Milliseconds);

        public (IList<Products> prods, int totalMilliseconds) GetProductsByName(string name) => (_contex.Products.Where(f => f.ProductName.Contains(name)).ToList(),DateTime.Now.Subtract(_dateBegin).Milliseconds);


        //Fk
        public (Products prod, int totalMilliseconds) GetProductWithFk(int id) => 
            (_contex
                    .Products
                    .Include(i=> i.Supplier)
                    .FirstOrDefault(f => f.ProductId == id), 
                DateTime.Now.Subtract(_dateBegin).Milliseconds);

        public (Products prod, int totalMilliseconds) GetProductByNameWithFk(string name) => 
            (_contex
                .Products
                .Include(i=> i.Supplier)
                .FirstOrDefault(f => f.ProductName.Equals(name)), 
                DateTime.Now.Subtract(_dateBegin).Milliseconds);

        public (IList<Products> prods, int totalMilliseconds) GetProductsByNameFk(string name) => 
            (_contex
                .Products
                .Include(i=>i.Supplier)
                .Where(f => f.ProductName.Contains(name))
                .ToList(), 
                DateTime.Now.Subtract(_dateBegin).Milliseconds);

        public (IList<Suppliers> list, int totalMilliseconds) GetSuppliersByCountryFK_OneToMany(string country) => 
            (_contex
                .Suppliers
                .Include(i => i.Products)
                .Where(w => w.Country.Equals(country) && w.Products.Count > 0)
                .ToList(),
                DateTime.Now.Subtract(_dateBegin).Milliseconds);



    }
}
