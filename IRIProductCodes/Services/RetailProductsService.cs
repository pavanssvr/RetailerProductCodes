using System;
using System.Collections.Generic;
using Models;
using System.Globalization;
using System.Linq;

namespace Services
{
    public class RetailProductsService : IRetailProductsService
    {
        public List<ProductCodes> GetProductWithCodes(string startupPath, FileDetails fileDetails)
        {
            try
            {
                var productsFilePath = $"{startupPath}\\{fileDetails.FolderPath}\\{fileDetails.ProductsFile}";
                var retailProductsFilePath = $"{startupPath}\\{fileDetails.FolderPath}\\{fileDetails.RetailProductsFile}";

                List<Product> products = GetProducts(productsFilePath);
                List<RetailerProduct> retailerProducts = GetRetailerProducts(retailProductsFilePath);

                List<ProductCodes> listItems = (from p in products
                                                join r in retailerProducts
                                                     on p.ProductId equals r.ProductId
                                                select new
                                                {
                                                    p.ProductId,
                                                    p.ProductName,
                                                    r.RetailerProductCodeType,
                                                    r.RetailerProductCode,
                                                    r.DateReceived,
                                                }).OrderByDescending(rp => rp.DateReceived).GroupBy(rpp => new { rpp.ProductId, rpp.ProductName, rpp.RetailerProductCodeType })
                                 .SelectMany(all => all.Select((prd, ind) => new ProductCodes()
                                 {
                                     ProductId = prd.ProductId,
                                     ProductName = prd.ProductName,
                                     CodeType = prd.RetailerProductCodeType,
                                     Code = prd.RetailerProductCode,
                                     DateReceived = prd.DateReceived,
                                     RowNumber = ind + 1
                                 }))
                                 .Where(filter => filter.RowNumber == 1)
                                 .OrderBy(prc => prc.ProductId).ToList();

                return listItems;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception in fetching records from service layer");

            }

        }

        private List<Product> GetProducts(string productsFilePath)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(productsFilePath);

                List<Product> products = new List<Product>();
                foreach (string line in lines)
                {
                    var lineItems = line.Split(',');
                    products.Add(new Product { ProductId = Convert.ToInt32(lineItems[0]), ProductName = lineItems[1] });
                }
                return products;
            }
            catch(Exception ex)
            {
                throw new Exception("Exception in fetching products from file");

            }
        }

        private List<RetailerProduct> GetRetailerProducts(string retailProductsFilePath)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(retailProductsFilePath);

                List<RetailerProduct> retailerProducts = new List<RetailerProduct>();
                foreach (string line in lines)
                {
                    var lineItems = line.Split(',');
                    retailerProducts.Add(new RetailerProduct
                    {
                        ProductId = Convert.ToInt32(lineItems[0])
                        ,
                        RetailerName = lineItems[1]
                        ,
                        RetailerProductCode = lineItems[2]
                        ,
                        RetailerProductCodeType = lineItems[3]
                        ,
                        DateReceived = DateTime.ParseExact(lineItems[4], "d/MM/yyyy", CultureInfo.InvariantCulture)
                    });
                }
                return retailerProducts;
            }
            catch(Exception ex)
            {
                throw new Exception("Exception in fetching retailer products from file");

            }
        }
    }
}
