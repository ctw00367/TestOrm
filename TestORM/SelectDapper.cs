using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using TestORM.Models;
using Dapper;

namespace TestORM
{
    
    public class SelectDapper
    {
        private readonly DateTime _dateBegin;
        private readonly SqlConnection _conn;

        public SelectDapper()
        {
            _dateBegin = DateTime.Now;
            // "Server = (localdb)\\mssqllocaldb; Database = Northwind; Trusted_Connection = True;";
            _conn = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=Northwind;Trusted_Connection=true;");
            _conn.Open();

            PingDb();
        }

        public void Dispose()
        {
            _conn.Close();
            _conn?.Dispose();
        }

        private void PingDb()
        {
            Console.WriteLine("Ping - SelectDapper");
            _conn.Query<Products>("SELECT * FROM Products").Take(10).ToList();
        }

        internal int GetCount() => _conn.Query<int>($"SELECT * FROM Products").Count();

        internal (Products prod, int totalMilliseconds) GetProduct(int id) => 
            (_conn.QueryFirstOrDefault<Products>(
                "SELECT * FROM Products WHERE ProductID = @ProductID", 
                new { ProductID = id }), 
                DateTime.Now.Subtract(_dateBegin).Milliseconds);

        internal (Products prod, int totalMilliseconds) GetProductByName(string name) => 
            (_conn.QueryFirstOrDefault<Products>(
                    "SELECT * FROM Products WHERE ProductName = @ProductName",
                    new { ProductName = name }),
                DateTime.Now.Subtract(_dateBegin).Milliseconds);

        internal (IList<Products> prods, int totalMilliseconds) GetProductsByName(string name) =>
            (_conn.Query<Products>(
                    "SELECT * FROM Products WHERE ProductName like @ProductName",
                    new {ProductName = $"%{name}%"}).ToList(),
                DateTime.Now.Subtract(_dateBegin).Milliseconds);


        internal (Products prod, int totalMilliseconds) GetProductWithFk(int id)
        {
            Products result = null;

            var query = "SELECT * " +
                        "FROM Products p " +
                        "Inner JOIN Suppliers s ON s.SupplierID = p.SupplierID " +
                        "where p.ProductID = @ProductID";

            result = _conn.Query<Products, Suppliers, Products>(
                sql:query,
                map:(p, s) =>
                {
                    p.Supplier = s;
                    return p;
                },
                param:new { ProductID = id },
                splitOn: "SupplierID"   
            ).FirstOrDefault();

            return (result, DateTime.Now.Subtract(_dateBegin).Milliseconds);
        }
        
        internal (Products prod, int totalMilliseconds) GetProductByNameWithFk(string name)
        {
            var result = _conn.Query<Products, Suppliers, Products>(
                sql: "SELECT * FROM Products p JOIN Suppliers s ON s.SupplierID = p.SupplierID where ProductName = @ProductName",
                map: (p, s) =>
                {
                    p.Supplier = s;
                    return p;
                },
                param: new { ProductName = name },
                splitOn: "SupplierID"
            ).FirstOrDefault();

            return (result, DateTime.Now.Subtract(_dateBegin).Milliseconds);
        }

        internal (IList<Products> prods, int totalMilliseconds) GetProductsByNameWithFk(string name)
        {
            var result = _conn.Query<Products, Suppliers, Products>(
                sql: "SELECT * FROM Products p JOIN Suppliers s ON s.SupplierID = p.SupplierID where ProductName like @ProductName",
                map: (p, s) =>
                {
                    p.Supplier = s;
                    return p;
                },
                param: new { ProductName = $"%{name}%" },
                splitOn: "SupplierID"
            ).ToList();

            return (result, DateTime.Now.Subtract(_dateBegin).Milliseconds);
        }

        internal (IList<Suppliers> list, int totalMilliseconds) GetSuppliersByCountryFK_OneToMany(string country)
        {
            var suppliersDictionary = new Dictionary<int, Suppliers>();

            var result = _conn.Query<Suppliers, Products, Suppliers>(
                sql: "SELECT * FROM Suppliers s JOIN Products p ON p.SupplierID = s.SupplierID AND s.Country = @Country",
                map: (s, p) =>
                {
                    if (!suppliersDictionary.TryGetValue(s.SupplierId, out var supplierEntry))
                    {
                        supplierEntry = s;
                        supplierEntry.Products = new List<Products>();
                        suppliersDictionary.Add(supplierEntry.SupplierId, supplierEntry);
                    }
                    supplierEntry.Products.Add(p);

                    return supplierEntry;
                },
                param:new { Country =  country},
                splitOn: "SupplierID"
                )
                .Distinct()
                .ToList();

            return (result, DateTime.Now.Subtract(_dateBegin).Milliseconds);
        }

    }
}
