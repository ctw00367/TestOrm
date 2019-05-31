using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using TestORM.Models;

namespace TestORM
{
    public class InsertData
    {
        private readonly NorthwindContext _contex = null;

        public InsertData()
        {
            _contex = new NorthwindContext();
        }

        public void InsertBulkProducts(int toAdd)
        {
            var last = _contex.Products.Last();
            var random = new Random();

            for (var i = last.ProductId + 1; i <= last.ProductId + toAdd; i++)
            {
                var toInsert = new Products()
                {
                    ProductName = $"Product {i}",
                    SupplierId = random.Next(1,29),
                    CategoryId = random.Next(1,8),
                    QuantityPerUnit = $"{random.Next(1,16)}",
                    UnitPrice = Convert.ToDecimal(random.Next(10,100)),
                    UnitsInStock = Convert.ToInt16(random.Next(1,100)),
                    UnitsOnOrder = Convert.ToInt16(random.Next(0, 50)),
                    ReorderLevel = Convert.ToInt16(random.Next(0, 25)),
                    Discontinued = Convert.ToBoolean(random.Next(0,1))

                };
                _contex.Products.Add(toInsert);
                Console.WriteLine($" Add Product {i}");
            }

            _contex.SaveChanges();
            Console.WriteLine("Saved");

        }

        public void InsertBulkSuppliers(int toAdd)
        {
            var last = _contex.Suppliers.Last();
            var random = new Random();

            string[] countryArray =
            {
                "Australia", "Brazil", "Canada", "Denmark", "Finland", "France", "Germany", "Italy", "Japan",
                "Netherlands", "Norway", "Singapore", "Spain", "Sweden", "UK", "USA"
            };

            for (var i = last.SupplierId; i < last.SupplierId + toAdd; i++)
            {
                var toInsert = new Suppliers()
                {
                    CompanyName = $"Suppliers {i}",
                    ContactName = $"Contact Name {i}",
                    ContactTitle = $"ContactTitle {i}",
                    Address = $"Address {i}",
                    City = $"City { random.Next(10,100)}",
                    Region = $"Region { random.Next(100, 399)}",
                    PostalCode = random.Next(1000, 3599).ToString(CultureInfo.InvariantCulture),
                    Country = countryArray[random.Next(0, countryArray.Length - 1)],
                    Phone = random.Next(5000, 99999999).ToString(),
                    Fax = null,
                    HomePage = null
                };

                _contex.Suppliers.Add(toInsert);
                Console.WriteLine($" Add Suppliers {i}");
            }
            _contex.SaveChanges();
            Console.WriteLine("Saved");
        }
    }
}
