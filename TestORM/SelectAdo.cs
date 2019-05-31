using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TestORM.Models;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ComTypes;


namespace TestORM
{
    public class SelectAdo
    {
        private readonly DateTime _dateBegin;
        private readonly SqlConnection _conn;

        public SelectAdo() {
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
            Console.WriteLine("Ping - SelectAdo");

            using (var sqlCommand = new SqlCommand($"SELECT * FROM Products", _conn))
            {
                sqlCommand.CommandText = sqlCommand.CommandText;

                var ds = new DataSet();
                var da = new SqlDataAdapter(sqlCommand.CommandText, _conn);
                da.Fill(ds, "Products");

                var result = ds.Tables[0].AsEnumerable()
                    .Take(10)
                    .Select(s => new Products()
                    {
                        ProductId = (int) s["ProductID"],
                        ProductName = s["ProductName"].ToString(),
                        SupplierId = (int?) s["SupplierID"],
                        CategoryId = (int?) s["CategoryID"],
                        QuantityPerUnit = s["QuantityPerUnit"].ToString(),
                        UnitPrice = (decimal?) s["UnitPrice"],
                        UnitsInStock = (short?) s["UnitsInStock"],
                        UnitsOnOrder = (short?) s["UnitsOnOrder"],
                        ReorderLevel = (short?) s["ReorderLevel"],
                        Discontinued = (bool) s["Discontinued"]
                    }).ToList();
            }
        }

        internal int GetCount()
        {
            var count = 0;
            using (var sqlCommand = new SqlCommand($"SELECT Count(*) FROM Products", _conn))
            {
                count = (int)sqlCommand.ExecuteScalar();
            }

            return count;
        }

        internal (Products prod, int totalMilliseconds) GetProduct(int id)
        {
            Products result = null;

            using (var sqlCommand = new SqlCommand($"SELECT * FROM Products WHERE ProductID = {id}", _conn))
            {
                sqlCommand.CommandText = sqlCommand.CommandText;

                var ds = new DataSet();
                var da = new SqlDataAdapter(sqlCommand.CommandText, _conn);
                da.Fill(ds, "Products");

                result = ds
                    .Tables[0]
                    .AsEnumerable()
                    .Select(s=> new Products()
                    {
                        ProductId = (int)s["ProductID"],
                        ProductName = s["ProductName"].ToString(),
                        SupplierId = (int?)s["SupplierID"],
                        CategoryId = (int?)s["CategoryID"],
                        QuantityPerUnit =  s["QuantityPerUnit"].ToString(),
                        UnitPrice = (decimal?)s["UnitPrice"],
                        UnitsInStock = (short?)s["UnitsInStock"],
                        UnitsOnOrder = (short?)s["UnitsOnOrder"],
                        ReorderLevel = (short?)s["ReorderLevel"],
                        Discontinued = (bool)s["Discontinued"]
                    })
                    .FirstOrDefault();
            }

            return (result, DateTime.Now.Subtract(_dateBegin).Milliseconds);
        }

        internal (Products prod, int totalMilliseconds) GetProductByName(string name)
        {
            Products result = null;

            using (var sqlCommand = new SqlCommand($"SELECT * FROM Products WHERE ProductName = '{name}'", _conn))
            {
                sqlCommand.CommandText = sqlCommand.CommandText;

                var ds = new DataSet();
                var da = new SqlDataAdapter(sqlCommand.CommandText, _conn);
                da.Fill(ds, "Products");

                result = ds
                    .Tables[0]
                    .AsEnumerable()
                    .Select(s => new Products()
                    {
                        ProductId = (int)s["ProductID"],
                        ProductName = s["ProductName"].ToString(),
                        SupplierId = (int?)s["SupplierID"],
                        CategoryId = (int?)s["CategoryID"],
                        QuantityPerUnit = s["QuantityPerUnit"].ToString(),
                        UnitPrice = (decimal?)s["UnitPrice"],
                        UnitsInStock = (short?)s["UnitsInStock"],
                        UnitsOnOrder = (short?)s["UnitsOnOrder"],
                        ReorderLevel = (short?)s["ReorderLevel"],
                        Discontinued = (bool)s["Discontinued"]
                    })
                    .FirstOrDefault();
            }

            return (result, DateTime.Now.Subtract(_dateBegin).Milliseconds);
        }

        public (IList<Products> prods, int totalMilliseconds) GetProductsByName(string name)
        {
            IList<Products> result = null;

            using (var sqlCommand = new SqlCommand($"SELECT * FROM Products WHERE ProductName like '{name}'", _conn))
            {
                sqlCommand.CommandText = sqlCommand.CommandText;

                var ds = new DataSet();
                var da = new SqlDataAdapter(sqlCommand.CommandText, _conn);
                da.Fill(ds, "Products");

                result = ds
                    .Tables[0]
                    .AsEnumerable()
                    .Select(s => new Products()
                    {
                        ProductId = (int)s["ProductID"],
                        ProductName = s["ProductName"].ToString(),
                        SupplierId = (int?)s["SupplierID"],
                        CategoryId = (int?)s["CategoryID"],
                        QuantityPerUnit = s["QuantityPerUnit"].ToString(),
                        UnitPrice = (decimal?)s["UnitPrice"],
                        UnitsInStock = (short?)s["UnitsInStock"],
                        UnitsOnOrder = (short?)s["UnitsOnOrder"],
                        ReorderLevel = (short?)s["ReorderLevel"],
                        Discontinued = (bool)s["Discontinued"]
                    })
                    .ToList();
            }

            return (result, DateTime.Now.Subtract(_dateBegin).Milliseconds);
        }




        internal (Products prod, int totalMilliseconds) GetProductWithFk(int id)
        {
            Products result = null;

            using (var sqlCommand = new SqlCommand($"SELECT * FROM Products p Inner JOIN Suppliers s ON s.SupplierID = p.SupplierID WHERE p.ProductID = {id}", _conn))
            {
                sqlCommand.CommandText = sqlCommand.CommandText;

                var ds = new DataSet();
                var da = new SqlDataAdapter(sqlCommand.CommandText, _conn);
                da.Fill(ds, "Products");

                result = ds
                    .Tables[0]
                    .AsEnumerable()
                    .Select(s => new Products()
                    {
                        ProductId = (int)s["ProductID"],
                        ProductName = s["ProductName"].ToString(),
                        SupplierId = (int?)s["SupplierID"],
                        CategoryId = (int?)s["CategoryID"],
                        QuantityPerUnit = s["QuantityPerUnit"].ToString(),
                        UnitPrice = (decimal?)s["UnitPrice"],
                        UnitsInStock = (short?)s["UnitsInStock"],
                        UnitsOnOrder = (short?)s["UnitsOnOrder"],
                        ReorderLevel = (short?)s["ReorderLevel"],
                        Discontinued = (bool)s["Discontinued"],
                        Supplier = new Suppliers()
                        {
                            SupplierId = (int)s["SupplierID"],
                            CompanyName = s["CompanyName"].ToString(),
                            ContactName = s["ContactName"].ToString(),
                            ContactTitle = s["ContactTitle"].ToString(),
                            Address = s["Address"].ToString(),
                            City = s["City"].ToString(),
                            Region = s["Region"].ToString(),
                            PostalCode = s["PostalCode"].ToString(),
                            Country = s["Country"].ToString(),
                            Phone = s["Phone"].ToString(),
                            Fax = s["Fax"].ToString(),
                            HomePage = s["HomePage"].ToString()}
                    })
                    .FirstOrDefault();
            }

            return (result, DateTime.Now.Subtract(_dateBegin).Milliseconds);
        }

        internal (Products prod, int totalMilliseconds) GetProductByNameWithFk(string name)
        {
            Products result = null;

            using (var sqlCommand = new SqlCommand($"SELECT * FROM Products p Inner JOIN Suppliers s ON s.SupplierID = p.SupplierID WHERE p.ProductName = '{name}'", _conn))
            {
                sqlCommand.CommandText = sqlCommand.CommandText;

                var ds = new DataSet();
                var da = new SqlDataAdapter(sqlCommand.CommandText, _conn);
                da.Fill(ds, "Products");

                result = ds
                    .Tables[0]
                    .AsEnumerable()
                    .Select(s => new Products()
                    {
                        ProductId = (int)s["ProductID"],
                        ProductName = s["ProductName"].ToString(),
                        SupplierId = (int?)s["SupplierID"],
                        CategoryId = (int?)s["CategoryID"],
                        QuantityPerUnit = s["QuantityPerUnit"].ToString(),
                        UnitPrice = (decimal?)s["UnitPrice"],
                        UnitsInStock = (short?)s["UnitsInStock"],
                        UnitsOnOrder = (short?)s["UnitsOnOrder"],
                        ReorderLevel = (short?)s["ReorderLevel"],
                        Discontinued = (bool)s["Discontinued"],
                        Supplier = new Suppliers()
                        {
                            SupplierId = (int)s["SupplierID"],
                            CompanyName = s["CompanyName"].ToString(),
                            ContactName = s["ContactName"].ToString(),
                            ContactTitle = s["ContactTitle"].ToString(),
                            Address = s["Address"].ToString(),
                            City = s["City"].ToString(),
                            Region = s["Region"].ToString(),
                            PostalCode = s["PostalCode"].ToString(),
                            Country = s["Country"].ToString(),
                            Phone = s["Phone"].ToString(),
                            Fax = s["Fax"].ToString(),
                            HomePage = s["HomePage"].ToString()
                        }
                    })
                    .FirstOrDefault();
            }

            return (result, DateTime.Now.Subtract(_dateBegin).Milliseconds);
        }

        public (IList<Products> prods, int totalMilliseconds) GetProductsByNameWithFk(string name)
        {
            IList<Products> result = null;

            using (var sqlCommand = new SqlCommand($"SELECT * FROM Products p Inner JOIN Suppliers s ON s.SupplierID = p.SupplierID WHERE p.ProductName = '{name}'", _conn))
            {
                sqlCommand.CommandText = sqlCommand.CommandText;

                var ds = new DataSet();
                var da = new SqlDataAdapter(sqlCommand.CommandText, _conn);
                da.Fill(ds, "Products");

                result = ds
                    .Tables[0]
                    .AsEnumerable()
                    .Select(s => new Products()
                    {
                        ProductId = (int)s["ProductID"],
                        ProductName = s["ProductName"].ToString(),
                        SupplierId = (int?)s["SupplierID"],
                        CategoryId = (int?)s["CategoryID"],
                        QuantityPerUnit = s["QuantityPerUnit"].ToString(),
                        UnitPrice = (decimal?)s["UnitPrice"],
                        UnitsInStock = (short?)s["UnitsInStock"],
                        UnitsOnOrder = (short?)s["UnitsOnOrder"],
                        ReorderLevel = (short?)s["ReorderLevel"],
                        Discontinued = (bool)s["Discontinued"],
                        Supplier = new Suppliers()
                        {
                            SupplierId = (int)s["SupplierID"],
                            CompanyName = s["CompanyName"].ToString(),
                            ContactName = s["ContactName"].ToString(),
                            ContactTitle = s["ContactTitle"].ToString(),
                            Address = s["Address"].ToString(),
                            City = s["City"].ToString(),
                            Region = s["Region"].ToString(),
                            PostalCode = s["PostalCode"].ToString(),
                            Country = s["Country"].ToString(),
                            Phone = s["Phone"].ToString(),
                            Fax = s["Fax"].ToString(),
                            HomePage = s["HomePage"].ToString()
                        }
                    })
                    .ToList();
            }

            return (result, DateTime.Now.Subtract(_dateBegin).Milliseconds);
        }

        internal (IList<Suppliers> list, int totalMilliseconds) GetSuppliersByCountryFK_OneToMany(string country)
        {
            IList<Suppliers> result = null;

            using (var sqlCommand = new SqlCommand($"SELECT * FROM Suppliers s JOIN Products p ON p.SupplierID = s.SupplierID AND s.Country = '{country}'",_conn))
            {
                sqlCommand.CommandText = sqlCommand.CommandText;

                var ds = new DataSet();
                var da = new SqlDataAdapter(sqlCommand.CommandText, _conn);
                da.Fill(ds, "Products");

                result = ds
                    .Tables[0]
                    .AsEnumerable()
                    .Select(s => new Suppliers()
                    {
                        SupplierId = (int)s["SupplierID"],
                        CompanyName = s["CompanyName"].ToString(),
                        ContactName = s["ContactName"].ToString(),
                        ContactTitle = s["ContactTitle"].ToString(),
                        Address = s["Address"].ToString(),
                        City = s["City"].ToString(),
                        Region = s["Region"].ToString(),
                        PostalCode = s["PostalCode"].ToString(),
                        Country = s["Country"].ToString(),
                        Phone = s["Phone"].ToString(),
                        Fax = s["Fax"].ToString(),
                        HomePage = s["HomePage"].ToString()
                    })
                    .GroupBy(g=> g.SupplierId)
                    .Select(s=> s.FirstOrDefault())
                    .ToList();

                foreach (var row in result)
                {
                    row.Products = ds
                        .Tables[0]
                        .AsEnumerable()
                        .Where(w=> (int)w["SupplierID"] == row.SupplierId)
                        .Select(s => new Products()
                        {
                            ProductId = (int)s["ProductID"],
                            ProductName = s["ProductName"].ToString(),
                            SupplierId = (int?)s["SupplierID"],
                            CategoryId = (int?)s["CategoryID"],
                            QuantityPerUnit = s["QuantityPerUnit"].ToString(),
                            UnitPrice = (decimal?)s["UnitPrice"],
                            UnitsInStock = (short?)s["UnitsInStock"],
                            UnitsOnOrder = (short?)s["UnitsOnOrder"],
                            ReorderLevel = (short?)s["ReorderLevel"],
                            Discontinued = (bool)s["Discontinued"],
                        })
                        .ToList();
                }

            }

            return (result, DateTime.Now.Subtract(_dateBegin).Milliseconds);
        }
    }
}
