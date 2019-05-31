using System;
using System.Collections.Generic;
using System.Text;
using  System.Linq;

namespace TestORM
{
    public class InitialTests
    {

        public void Test()
        {
            var selectEf = new SelectDataEF();
            var selectDapper = new SelectDapper();
            var selectAdo = new SelectAdo();


            Console.WriteLine("******* EF ***********");
            var (prodEf, totalMillisecondsByIdEf) = selectEf.GetProduct(999999);
            Console.WriteLine($"Select By Id: {prodEf.ProductId} | Name: {prodEf.ProductName} | Time Milliseconds: {totalMillisecondsByIdEf}");

            var (prodByNameEf, totalMillisecondsByNameEf) = selectEf.GetProductByName("Product 981881");
            Console.WriteLine($"Select By Name: {prodByNameEf.ProductId} | Name: {prodByNameEf.ProductName} | Time Milliseconds: {totalMillisecondsByNameEf}");

            var (prodByNameEfLike, totalMillisecondsByNameEfLike) = selectEf.GetProductsByName("410");
            Console.WriteLine($"Last Select By Name Like: {prodByNameEfLike.LastOrDefault()?.ProductId} | Name: {prodByNameEfLike.LastOrDefault()?.ProductName} | Count: {prodByNameEfLike.Count} | Time Milliseconds: {totalMillisecondsByNameEfLike}");


            Console.WriteLine("******* Dapper ***********");
            var (prodDapper, totalMillisecondsByIdDapper) = selectDapper.GetProduct(999999);
            Console.WriteLine($"Select By Id: {prodDapper.ProductId} | Name: {prodDapper.ProductName} | Time Milliseconds: {totalMillisecondsByIdDapper}");

            var (prodByNameDapper, totalMillisecondsByNameDapper) = selectDapper.GetProductByName("Product 981881");
            Console.WriteLine($"Select By Name: {prodByNameDapper.ProductId} | Name: {prodByNameDapper.ProductName} | Time Milliseconds: {totalMillisecondsByNameDapper}");

            var (prodByNameDapperLike, totalMillisecondsByNameDapperLike) = selectDapper.GetProductsByName("410");
            Console.WriteLine($"Last Select By Name Like: {prodByNameDapperLike.LastOrDefault()?.ProductId} | Name: {prodByNameDapperLike.LastOrDefault()?.ProductName} | Count: {prodByNameDapperLike.Count} | Time Milliseconds: {totalMillisecondsByNameDapperLike}");


            Console.WriteLine("******* ADO.NET ***********");
            var (prodAdoNet, totalMillisecondsByIdAdoNet) = selectAdo.GetProduct(999999);
            Console.WriteLine($"Select By Id: {prodAdoNet.ProductId} | Name: {prodAdoNet.ProductName} | Time Milliseconds: {totalMillisecondsByIdAdoNet}");

            var (prodByNameAdoNet, totalMillisecondsByNameAdoNet) = selectAdo.GetProductByName("Product 981881");
            Console.WriteLine($"Select By Name: {prodByNameAdoNet.ProductId} | Name: {prodByNameAdoNet.ProductName} | Time Milliseconds: {totalMillisecondsByNameAdoNet}");

            var (prodByNameAdoNetLike, totalMillisecondsByNameAdoNetLike) = selectAdo.GetProductsByName("410");
            Console.WriteLine($"Last Select By Name Like: {prodByNameAdoNetLike.LastOrDefault()?.ProductId} | Name: {prodByNameAdoNetLike.LastOrDefault()?.ProductName} | Count: {prodByNameAdoNetLike.Count} | Time Milliseconds: {totalMillisecondsByNameAdoNetLike}");









            Console.WriteLine("**************************************************************************************************************************");


            Console.WriteLine("******* EF with FK ***********");
            var (prodEfFk, totalMillisecondsByIdEfFk) = selectEf.GetProductWithFk(999999);
            Console.WriteLine($"Select By Id: {prodEfFk.ProductId} | Name: {prodEfFk.ProductName} | Suppliers: {prodEfFk.Supplier?.CompanyName} | Time Milliseconds: {totalMillisecondsByIdEfFk}");

            var (prodByNameEfFk, totalMillisecondsByNameEfFk) = selectEf.GetProductByNameWithFk("Product 981881");
            Console.WriteLine($"Select By Name: {prodByNameEfFk.ProductId} | Name: {prodByNameEfFk.ProductName} | Suppliers: {prodEfFk.Supplier?.CompanyName} | Time Milliseconds: {totalMillisecondsByNameEfFk}");

            var (prodByNameEfLikeFk, totalMillisecondsByNameEfLikeFk) = selectEf.GetProductsByNameFk("410");
            Console.WriteLine($"Last Select By Name Like: {prodByNameEfLikeFk.LastOrDefault()?.ProductId} | Name: {prodByNameEfLikeFk.LastOrDefault()?.ProductName} | Suppliers: {prodByNameEfLikeFk.LastOrDefault()?.Supplier?.CompanyName} | Count: {prodByNameEfLikeFk.Count} | Time Milliseconds: {totalMillisecondsByNameEfLikeFk}");

            var (prodByCountryEfFk, totalMillisecondsByCountryEfFk) = selectEf.GetSuppliersByCountryFK_OneToMany("Germany");
            Console.WriteLine($"Last Select By Country: " +
                              $"{prodByCountryEfFk.LastOrDefault()?.Products.LastOrDefault()?.ProductId} " +
                              $"| Name: {prodByCountryEfFk.LastOrDefault()?.Products.LastOrDefault()?.ProductName} " +
                              $"| Suppliers: {prodByCountryEfFk.LastOrDefault()?.CompanyName} " +
                              $"| Count Suppliers : {prodByCountryEfFk.Count} " +
                              $"| Count Products : {prodByCountryEfFk.SelectMany(sm => sm.Products).Count()}" +
                              $"| Time Milliseconds: {totalMillisecondsByCountryEfFk}");



            Console.WriteLine("******* Dapper with Fk ***********");
            var (prodDapperFk, totalMillisecondsByIdDapperFk) = selectDapper.GetProductWithFk(999999);
            Console.WriteLine($"Select By Id: {prodDapperFk.ProductId} | Name: {prodDapperFk.ProductName} | Suppliers: {prodEfFk.Supplier?.CompanyName} | Time Milliseconds: {totalMillisecondsByIdDapperFk}");

            var (prodByNameDapperFk, totalMillisecondsByNameDapperFk) = selectDapper.GetProductByNameWithFk("Product 981881");
            Console.WriteLine($"Select By Name: {prodByNameDapperFk.ProductId} | Name: {prodByNameDapperFk.ProductName} | Suppliers: {prodByNameDapperFk.Supplier?.CompanyName} | Time Milliseconds: {totalMillisecondsByNameDapperFk}");

            var (prodByNameDapperLikeFk, totalMillisecondsByNameDapperLikeFk) = selectDapper.GetProductsByNameWithFk("410");
            Console.WriteLine($"Last Select By Name Like: {prodByNameDapperLikeFk.LastOrDefault()?.ProductId} | Name: {prodByNameDapperLikeFk.LastOrDefault()?.ProductName} | Suppliers: {prodByNameDapperLikeFk.LastOrDefault()?.Supplier?.CompanyName} | Count: {prodByNameDapperLikeFk.Count} | Time Milliseconds: {totalMillisecondsByNameDapperLikeFk}");

            var (prodByCountryDapperFk, totalMillisecondsByCountryDapperFk) = selectDapper.GetSuppliersByCountryFK_OneToMany("Germany");
            Console.WriteLine($"Last Select By Country: " +
                              $"{prodByCountryDapperFk.LastOrDefault()?.Products.LastOrDefault()?.ProductId} " +
                              $"| Name: {prodByCountryDapperFk.LastOrDefault()?.Products.LastOrDefault()?.ProductName} " +
                              $"| Suppliers: {prodByCountryDapperFk.LastOrDefault()?.CompanyName} " +
                              $"| Count Suppliers : {prodByCountryDapperFk.Count} " +
                              $"| Count Products : {prodByCountryDapperFk.SelectMany(sm => sm.Products).Count()}" +
                              $"| Time Milliseconds: {totalMillisecondsByCountryDapperFk}");




            Console.WriteLine("******* Ado .Net with Fk ***********");
            var (prodAdoNetFk, totalMillisecondsByIdAdoNetFk) = selectAdo.GetProductWithFk(999999);
            Console.WriteLine($"Select By Id: {prodAdoNetFk.ProductId} | Name: {prodAdoNetFk.ProductName} | Suppliers: {prodAdoNetFk.Supplier?.CompanyName} | Time Milliseconds: {totalMillisecondsByIdAdoNetFk}");

            var (prodByNameAdoNetFk, totalMillisecondsByNameAdoNetFk) = selectAdo.GetProductByNameWithFk("Product 981881");
            Console.WriteLine($"Select By Name: {prodByNameAdoNetFk.ProductId} | Name: {prodByNameAdoNetFk.ProductName} | Suppliers: {prodByNameAdoNetFk.Supplier?.CompanyName} | Time Milliseconds: {totalMillisecondsByNameAdoNetFk}");

            var (prodByNameAdoNetLikeFk, totalMillisecondsByNameAdoNetLikeFk) = selectAdo.GetProductsByNameWithFk("410");
            Console.WriteLine($"Last Select By Name Like: {prodByNameAdoNetLikeFk.LastOrDefault()?.ProductId} | Name: {prodByNameAdoNetLikeFk.LastOrDefault()?.ProductName} | Suppliers: {prodByNameAdoNetLikeFk.LastOrDefault()?.Supplier?.CompanyName} | Count: {prodByNameAdoNetLikeFk.Count} | Time Milliseconds: {totalMillisecondsByNameAdoNetLikeFk}");

            var (prodByCountryAdoNetFk, totalMillisecondsByCountryAdoNetFk) = selectAdo.GetSuppliersByCountryFK_OneToMany("Germany");
            Console.WriteLine($"Last Select By Country: " +
                              $"{prodByCountryAdoNetFk.LastOrDefault()?.Products.LastOrDefault()?.ProductId} " +
                              $"| Name: {prodByCountryAdoNetFk.LastOrDefault()?.Products.LastOrDefault()?.ProductName} " +
                              $"| Suppliers: {prodByCountryAdoNetFk.LastOrDefault()?.CompanyName} " +
                              $"| Count Suppliers : {prodByCountryAdoNetFk.Count} " +
                              $"| Count Products : {prodByCountryAdoNetFk.SelectMany(sm => sm.Products).Count()}" +
                              $"| Time Milliseconds: {totalMillisecondsByCountryAdoNetFk}");



            selectAdo.Dispose();
            selectEf.Dispose();
            selectDapper.Dispose();
        }
    }
}
