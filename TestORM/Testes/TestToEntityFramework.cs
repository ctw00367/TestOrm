using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.Query.ExpressionTranslators;
using TestORM.File;

namespace TestORM.Testes
{
    public class TestToEntityFramework
    {
        private readonly SelectDataEF _ef = null;
        private readonly Random _random;
        private readonly int _count;
        private readonly WriteToFile _file = null;

        public TestToEntityFramework()
        {
            _ef = new SelectDataEF();
            _random = new Random();
            _count = _ef.GetProducts().Count();
            _file = new WriteToFile();
        }


        public int SelectById1(int id)
        {
            var (prodEf, totalMillisecondsByIdEf) = _ef.GetProduct(id);

            _file.Write($"EF - Select By Id (1) : {totalMillisecondsByIdEf}");

            return totalMillisecondsByIdEf;
        }

        public int SelectByIdN(int n)
        {
            int total = 0;

            for (int i = 0; i < n ; i++)
            {
                var (prodEf, totalMillisecondsByIdEf) = _ef.GetProduct(_random.Next(1,_count -1 ));
                total += totalMillisecondsByIdEf;
            }

            _file.Write($"EF - Select By Id ({n}) : {total}");
            return total;
        }

        public int SelectByName1(string name)
        {
            var (prodEf, totalMilliseconds) = _ef.GetProductByName(name);
            _file.Write($"EF - Select By Name (1) : {totalMilliseconds}");
            return totalMilliseconds;
        }

        public int SelectByNameN(int n)
        {
            int total = 0;

            for (int i = 0; i < n ; i++)
            {
                var (prodEf, totalMillisecondsByIdEf) = _ef.GetProductByName($"Product {_random.Next(1, _count - 1)}");
                total += totalMillisecondsByIdEf;
            }
            _file.Write($"EF - Select By Name ({n}) : {total}");
            return total;
        }

        public int SelectByNameLike1(string name)
        {
            var (prodEf, totalMilliseconds) = _ef.GetProductsByName(name);
            return totalMilliseconds;
        }

        public int SelectByNameLikeN(int n)
        {
            int total = 0;

            for (int i = 0; i < n ; i++)
            {
                var (prodEf, totalMilliseconds) = _ef.GetProductsByName($"{_random.Next(1, _count - 1)}");
                total += totalMilliseconds;
            }

            return total;
        }

        public int SelectById1Fk(int id)
        {
            var (prodEf, totalMilliseconds) = _ef.GetProductWithFk(id);
            _file.Write($"EF - Select By Id Fk (1) : {totalMilliseconds}");
            return totalMilliseconds;
        }

        public int SelectByIdNFk(int n)
        {
            int total = 0;

            for (int i = 0; i < n - 1; i++)
            {
                var (prodEf, totalMilliseconds) = _ef.GetProductWithFk(_random.Next(1, _count - 1));
                total += totalMilliseconds;
            }
            _file.Write($"EF - Select By Id Fk ({n}) : {total}");
            return total;
        }

        public int SelectByName1Fk(string name)
        {
            var (prodEf, totalMilliseconds) = _ef.GetProductByNameWithFk(name);
            _file.Write($"EF - Select By Name Fk (1) : {totalMilliseconds}");
            return totalMilliseconds;
        }

        public int SelectByNameNFk(int n)
        {
            int total = 0;

            for (int i = 0; i < n; i++)
            {
                var (prodEf, totalMilliseconds) = _ef.GetProductByNameWithFk($"Product {_random.Next(1, _count - 1)}");
                total += totalMilliseconds;
            }
            _file.Write($"EF - Select By Name Fk ({n}) : {total}");
            return total;
        }

        public int SelectSupplierByCountry1Fk(string country)
        {
            var (prodEf, totalMilliseconds) = _ef.GetSuppliersByCountryFK_OneToMany(country);
            _file.Write($"EF - Select By Country Fk (1) : {totalMilliseconds}");
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

            for (int i = 0; i < n; i++)
            {
                var (prodEf, totalMilliseconds) = _ef.GetSuppliersByCountryFK_OneToMany(countryArray[_random.Next(0, countryArray.Length - 1)]);
                total += totalMilliseconds;
                Console.WriteLine($"n -> {i} | totalMilliseconds -> {totalMilliseconds} | total -> {total}");
            }
            _file.Write($"EF -Select By Country Fk ({n}) : {total}");
            return total;
        }
    }
}
