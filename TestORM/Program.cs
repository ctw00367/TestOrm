using System;
using System.Linq;
using TestORM.File;
using TestORM.Testes;

namespace TestORM
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var teste = new SelectData();

            //var result = teste.GetCustomer("ALFKI");

            //Console.WriteLine($"ContactName: {result.ContactName} | CompanyName: {result.CompanyName}");

            //teste.GetCustomers().ToList().ForEach(f=> Console.WriteLine($"ContactName: {f.ContactName} | CompanyName: {f.CompanyName}"));

            //Console.WriteLine("Enter input:"); 
            //string line = Console.ReadLine();

            //Insert
            //var insert = new InsertData();
            //insert.InsertBulkProducts(Convert.ToInt32(line));
            //insert.InsertBulkSuppliers(Convert.ToInt32(line));

            //Select data EF


            var file = new WriteToFile();


            //Get Test
            var testEF = new TestToEntityFramework();
            Console.WriteLine($"EF - Select By Id (1) : {testEF.SelectById1(999999)}"); 
            Console.WriteLine($"EF - Select By Id (1) : {testEF.SelectById1(999999)}"); 
            Console.WriteLine($"EF - Select By Id (1) : {testEF.SelectById1(999999)}"); 

            Console.WriteLine("***************************************************************************");file.Write("***************************************************************************");

            Console.WriteLine($"EF - Select By Id (1) : {testEF.SelectById1(999999)}");
            Console.WriteLine($"EF - Select By Id (5) : {testEF.SelectByIdN(5)}");
            Console.WriteLine($"EF - Select By Id (10) : {testEF.SelectByIdN(10)}");
            Console.WriteLine($"EF - Select By Id (100) : {testEF.SelectByIdN(100)}");
            Console.WriteLine($"EF - Select By Id (1000) : {testEF.SelectByIdN(1000)}");

            Console.WriteLine($"EF - Select By Name (1) : {testEF.SelectByName1("Product 981881")}");
            Console.WriteLine($"EF - Select By Name (5) : {testEF.SelectByNameN(5)}");
            Console.WriteLine($"EF - Select By Name (10) : {testEF.SelectByNameN(10)}");
            Console.WriteLine($"EF - Select By Name (100) : {testEF.SelectByNameN(100)}");
            Console.WriteLine($"EF - Select By Name (1000) : {testEF.SelectByNameN(1000)}");

            Console.WriteLine("*EF - **************************************************************************"); file.Write("***************************************************************************");

            Console.WriteLine($"EF - Select By Id Fk (1) : {testEF.SelectById1Fk(999999)}");
            Console.WriteLine($"EF - Select By Id Fk (5) : {testEF.SelectByIdNFk(5)}");
            Console.WriteLine($"EF - Select By Id Fk (10) : {testEF.SelectByIdNFk(10)}");
            Console.WriteLine($"EF - Select By Id Fk (100) : {testEF.SelectByIdNFk(100)}");
            Console.WriteLine($"EF - Select By Id Fk (1000) : {testEF.SelectByIdNFk(1000)}");
                               
            Console.WriteLine($"EF - Select By Name Fk (1) : {testEF.SelectByName1Fk("Product 981881")}");
            Console.WriteLine($"EF - Select By Name Fk (5) : {testEF.SelectByNameNFk(5)}");
            Console.WriteLine($"EF - Select By Name Fk (10) : {testEF.SelectByNameNFk(10)}");
            Console.WriteLine($"EF - Select By Name Fk (100) : {testEF.SelectByNameNFk(100)}");
            Console.WriteLine($"EF - Select By Name Fk (1000) : {testEF.SelectByNameNFk(1000)}");

            Console.WriteLine($"EF - Select By Country Fk (1) : {testEF.SelectSupplierByCountry1Fk("Germany")}");
            Console.WriteLine($"EF - Select By Country Fk (5) : {testEF.SelectSupplierByCountryNFk(5)}");
            Console.WriteLine($"EF - Select By Country Fk (10) : {testEF.SelectSupplierByCountryNFk(10)}");
            Console.WriteLine($"EF - Select By Country Fk (100) : {testEF.SelectSupplierByCountryNFk(100)}");
            Console.WriteLine($"EF - Select By Country Fk (1000) : {testEF.SelectSupplierByCountryNFk(1000)}");



            var testDapper = new TestToDapper();
            Console.WriteLine($"Dapper - Select By Id (1) : {testDapper.SelectById1(999999)}");
            Console.WriteLine($"Dapper - Select By Id (1) : {testDapper.SelectById1(999999)}");
            Console.WriteLine($"Dapper - Select By Id (1) : {testDapper.SelectById1(999999)}");
            
            Console.WriteLine("***************************************************************************"); file.Write("***************************************************************************");
            Console.WriteLine($"Dapper - Select By Id (1) : {testDapper.SelectById1(999999)}");
            Console.WriteLine($"Dapper - Select By Id (5) : {testDapper.SelectByIdN(5)}");
            Console.WriteLine($"Dapper - Select By Id (10) : {testDapper.SelectByIdN(10)}");
            Console.WriteLine($"Dapper - Select By Id (100) : {testDapper.SelectByIdN(100)}");
            Console.WriteLine($"Dapper - Select By Id (1000) : {testDapper.SelectByIdN(1000)}");

            Console.WriteLine($"Dapper - Select By Name (1) : {testDapper.SelectByName1("Product 981881")}");
            Console.WriteLine($"Dapper - Select By Name (5) : {testDapper.SelectByNameN(5)}");
            Console.WriteLine($"Dapper - Select By Name (10) : {testDapper.SelectByNameN(10)}");
            Console.WriteLine($"Dapper - Select By Name (100) : {testDapper.SelectByNameN(100)}");
            Console.WriteLine($"Dapper - Select By Name (1000) : {testDapper.SelectByNameN(1000)}");

            Console.WriteLine("***************************************************************************"); file.Write("***************************************************************************");

            Console.WriteLine($"Dapper - Select By Id Fk (1) : {testDapper.SelectById1Fk(999999)}");
            Console.WriteLine($"Dapper - Select By Id Fk (5) : {testDapper.SelectByIdNFk(5)}");
            Console.WriteLine($"Dapper - Select By Id Fk (10) : {testDapper.SelectByIdNFk(10)}");
            Console.WriteLine($"Dapper - Select By Id Fk (100) : {testDapper.SelectByIdNFk(100)}");
            Console.WriteLine($"Dapper - Select By Id Fk (1000) : {testDapper.SelectByIdNFk(1000)}");

            Console.WriteLine($"Dapper - Select By Name Fk (1) : {testDapper.SelectByName1Fk("Product 981881")}");
            Console.WriteLine($"Dapper - Select By Name Fk (5) : {testDapper.SelectByNameNFk(5)}");
            Console.WriteLine($"Dapper - Select By Name Fk (10) : {testDapper.SelectByNameNFk(10)}");
            Console.WriteLine($"Dapper - Select By Name Fk (100) : {testDapper.SelectByNameNFk(100)}");
            Console.WriteLine($"Dapper - Select By Name Fk (1000) : {testDapper.SelectByNameNFk(1000)}");

            Console.WriteLine($"Dapper - Select By Country Fk (1) : {testDapper.SelectSupplierByCountry1Fk("Germany")}");
            Console.WriteLine($"Dapper - Select By Country Fk (5) : {testDapper.SelectSupplierByCountryNFk(5)}");
            Console.WriteLine($"Dapper - Select By Country Fk (10) : {testDapper.SelectSupplierByCountryNFk(10)}");
            Console.WriteLine($"Dapper - Select By Country Fk (100) : {testDapper.SelectSupplierByCountryNFk(100)}");
            Console.WriteLine($"Dapper - Select By Country Fk (1000) : {testDapper.SelectSupplierByCountryNFk(1000)}");


            var testAdoNet = new TestToAdoNet();
            Console.WriteLine($"Ado - Select By Id (1) : {testAdoNet.SelectById1(999999)}");
            Console.WriteLine($"Ado - Select By Id (1) : {testAdoNet.SelectById1(999999)}");
            Console.WriteLine($"Ado - Select By Id (1) : {testAdoNet.SelectById1(999999)}");

            Console.WriteLine("***************************************************************************"); file.Write("***************************************************************************");
            Console.WriteLine($"Ado - Select By Id (1) : {testAdoNet.SelectById1(999999)}");
            Console.WriteLine($"Ado - Select By Id (5) : {testAdoNet.SelectByIdN(5)}");
            Console.WriteLine($"Ado - Select By Id (10) : {testAdoNet.SelectByIdN(10)}");
            Console.WriteLine($"Ado - Select By Id (100) : {testAdoNet.SelectByIdN(100)}");
            Console.WriteLine($"Ado - Select By Id (1000) : {testAdoNet.SelectByIdN(1000)}");
                                
            Console.WriteLine($"Ado - Select By Name (1) : {testAdoNet.SelectByName1("Product 981881")}");
            Console.WriteLine($"Ado - Select By Name (5) : {testAdoNet.SelectByNameN(5)}");
            Console.WriteLine($"Ado - Select By Name (10) : {testAdoNet.SelectByNameN(10)}");
            Console.WriteLine($"Ado - Select By Name (100) : {testAdoNet.SelectByNameN(100)}");
            Console.WriteLine($"Ado - Select By Name (1000) : {testAdoNet.SelectByNameN(1000)}");
            
            Console.WriteLine("***************************************************************************"); file.Write("***************************************************************************");

            Console.WriteLine($"Ado - Select By Id Fk (1) : {testAdoNet.SelectById1Fk(999999)}");
            Console.WriteLine($"Ado - Select By Id Fk (5) : {testAdoNet.SelectByIdNFk(5)}");
            Console.WriteLine($"Ado - Select By Id Fk (10) : {testAdoNet.SelectByIdNFk(10)}");
            Console.WriteLine($"Ado - Select By Id Fk (100) : {testAdoNet.SelectByIdNFk(100)}");
            Console.WriteLine($"Ado - Select By Id Fk (1000) : {testAdoNet.SelectByIdNFk(1000)}");
                                
            Console.WriteLine($"Ado - Select By Name Fk (1) : {testAdoNet.SelectByName1Fk("Product 981881")}");
            Console.WriteLine($"Ado - Select By Name Fk (5) : {testAdoNet.SelectByNameNFk(5)}");
            Console.WriteLine($"Ado - Select By Name Fk (10) : {testAdoNet.SelectByNameNFk(10)}");
            Console.WriteLine($"Ado - Select By Name Fk (100) : {testAdoNet.SelectByNameNFk(100)}");
            Console.WriteLine($"Ado - Select By Name Fk (1000) : {testAdoNet.SelectByNameNFk(1000)}");
                                 
            Console.WriteLine($"Ado - Select By Country Fk (1) : {testAdoNet.SelectSupplierByCountry1Fk("Germany")}");
            Console.WriteLine($"Ado - Select By Country Fk (5) : {testAdoNet.SelectSupplierByCountryNFk(5)}");
            Console.WriteLine($"Ado - Select By Country Fk (10) : {testAdoNet.SelectSupplierByCountryNFk(10)}");
            Console.WriteLine($"Ado - Select By Country Fk (100) : {testAdoNet.SelectSupplierByCountryNFk(100)}");
            Console.WriteLine($"Ado - Select By Country Fk (1000) : {testAdoNet.SelectSupplierByCountryNFk(1000)}");


            Console.ReadLine();



            Console.WriteLine("_____FIM_____");
            Console.ReadLine();
        }
    }
}
