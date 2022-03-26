using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Utilities.Results;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IProductService _productService = new ProductManager();
            Product product = new Product();
            product.CategoryId = 4;
            product.ProductName = "asdas";
            product.UnitPrice = 123;
            product.UnitsInStock = 12;
            _productService.Add(product);
        }
    }
}
