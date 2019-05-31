using System;
using System.Collections.Generic;
using System.Text;
using TestORM.File;

namespace TestORM.Testes
{
    public class TestToDapper
    {
        private readonly SelectDapper _dapper;
        private readonly Random _random;
        private readonly int _count;
        private readonly WriteToFile _file = null;

        public TestToDapper()
        {
            _dapper = new SelectDapper();
            _random = new Random();
            _count = _dapper.GetCount();
            _file = new WriteToFile();
        }


        public int SelectById1(int id)
        {
            var (prod, totalMilliseconds) = _dapper.GetProduct(id);
            _file.Write($"Dapper - Select By Id (1) : {totalMilliseconds}");
            return totalMilliseconds;
        }

        public int SelectByIdN(int n)
        {
            int total = 0;

            for (int i = 0; i < n ; i++)
            {
                var (prod, totalMilliseconds) = _dapper.GetProduct(_random.Next(1, _count - 1));
                total += totalMilliseconds;
            }
            _file.Write($"Dapper - Select By Id ({n}) : {total}");
            return total;
        }

        public int SelectByName1(string name)
        {
            var (prodEf, totalMilliseconds) = _dapper.GetProductByName(name);
            _file.Write($"Dapper - Select By Name (1) : {totalMilliseconds}");
            return totalMilliseconds;
        }

        public int SelectByNameN(int n)
        {
            int total = 0;

            for (int i = 0; i < n ; i++)
            {
                var (prodEf, totalMillisecondsByIdEf) = _dapper.GetProductByName($"Product {_random.Next(1, _count - 1)}");
                total += totalMillisecondsByIdEf;
            }
            _file.Write($"Dapper - Select By Name ({n}) : {total}");
            return total;
        }

        public int SelectById1Fk(int id)
        {
            var (prodEf, totalMilliseconds) = _dapper.GetProductWithFk(id);
            _file.Write($"Dapper - Select By Id Fk (1) : {totalMilliseconds}");
            return totalMilliseconds;
        }

        public int SelectByIdNFk(int n)
        {
            int total = 0;

            for (int i = 0; i < n - 1; i++)
            {
                var (prodEf, totalMilliseconds) = _dapper.GetProductWithFk(_random.Next(1, _count - 1));
                total += totalMilliseconds;
            }
            _file.Write($"Dapper - Select By Id Fk ({n}) : {total}");
            return total;
        }

        public int SelectByName1Fk(string name)
        {
            var (prodEf, totalMilliseconds) = _dapper.GetProductByNameWithFk(name);
            _file.Write($"Dapper - Select By Name Fk (1) : {totalMilliseconds}");
            return totalMilliseconds;
        }

        public int SelectByNameNFk(int n)
        {
            int total = 0;

            for (int i = 0; i < n ; i++)
            {
                var (prodEf, totalMilliseconds) = _dapper.GetProductByNameWithFk($"Product {_random.Next(1, _count - 1)}");
                total += totalMilliseconds;
            }

            _file.Write($"Dapper - Select By Name Fk ({n}) : {total}");
            return total;
        }

        public int SelectSupplierByCountry1Fk(string country)
        {
            var (prodEf, totalMilliseconds) = _dapper.GetSuppliersByCountryFK_OneToMany(country);
            _file.Write($"Dapper - Select By Country Fk (1) : {totalMilliseconds}");
            return totalMilliseconds;
        }

        public int SelectSupplierByCountryNFk(int n)
        {
            int total = 0;

            string[] countryArray =
            {
                "Australia", "Brazil", "Canada", "Denmark", "Finland", "France", "Germany", "Italy", "Japan",
                "Netherlands", "Norway", "Singapore", "Spain", "Sweden", "UK", "USA"
            };

            for (int i = 0; i < n ; i++)
            {
                var (prodEf, totalMilliseconds) = _dapper.GetSuppliersByCountryFK_OneToMany(countryArray[_random.Next(0, countryArray.Length - 1)]);
                total += totalMilliseconds;
                //Console.WriteLine($"n -> {i} | totalMilliseconds -> {totalMilliseconds} | total -> {total}");
            }
            _file.Write($"Dapper -Select By Country Fk ({n}) : {total}");
            return total;
        }
    }
}
