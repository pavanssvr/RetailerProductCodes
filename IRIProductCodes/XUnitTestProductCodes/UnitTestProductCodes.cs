using Xunit;
using Models;
using Services;
using System.Linq;
using System.IO;

namespace XUnitTestProductCodes
{
    public class UnitTestProductCodes
    {
        [Fact]
        public void RetailerProducts_ProductDetails1_ProductCode1_ReturnRecordsCountSuccess()
        {
            var fileRootPath = Directory.GetCurrentDirectory().Replace("\\bin\\Debug\\netcoreapp2.2", "");
            var fileDetails = new FileDetails() { FolderPath= "Files", ProductsFile = "IRIProducts.txt", RetailProductsFile = "RetailerProducts.txt" };
            IRetailProductsService retailProductsService = new RetailProductsService();
            var retailerProducts = retailProductsService.GetProductWithCodes(fileRootPath, fileDetails);

            var productDetails1RecordsCount = retailerProducts.Where(rp => rp.ProductId == 18886 && rp.CodeType == "Barcode").ToList().Count;

            Assert.Equal(1, productDetails1RecordsCount);
        }

        [Fact]
        public void RetailerProducts_ProductDetails1_ProductCode1_ReturnSuccess()
        {
            var fileRootPath = Directory.GetCurrentDirectory().Replace("\\bin\\Debug\\netcoreapp2.2", "");
            var fileDetails = new FileDetails() { FolderPath = "Files", ProductsFile = "IRIProducts.txt", RetailProductsFile = "RetailerProducts.txt" };
            IRetailProductsService retailProductsService = new RetailProductsService();
            var retailerProducts = retailProductsService.GetProductWithCodes(fileRootPath, fileDetails);

            var productDetails1Record = retailerProducts.Where(rp => rp.ProductId == 18886 && rp.CodeType == "Barcode").FirstOrDefault();

            Assert.Equal("93482745", productDetails1Record.Code);
        }

        [Fact]
        public void RetailerProducts_ProductDetails1_ProductCode2_ReturnRecordsCountSuccess()
        {
            var fileRootPath = Directory.GetCurrentDirectory().Replace("\\bin\\Debug\\netcoreapp2.2", "");
            var fileDetails = new FileDetails() { FolderPath = "Files", ProductsFile = "IRIProducts.txt", RetailProductsFile = "RetailerProducts.txt" };
            IRetailProductsService retailProductsService = new RetailProductsService();
            var retailerProducts = retailProductsService.GetProductWithCodes(fileRootPath, fileDetails);

            var productDetails1RecordsCount = retailerProducts.Where(rp => rp.ProductId == 212855 && rp.CodeType == "Woolworths Reference Number").ToList().Count;

            Assert.Equal(1, productDetails1RecordsCount);
        }

        [Fact]
        public void RetailerProducts_ProductDetails1_ProductCode2_ReturnSuccess()
        {
            var fileRootPath = Directory.GetCurrentDirectory().Replace("\\bin\\Debug\\netcoreapp2.2", "");
            var fileDetails = new FileDetails() { FolderPath = "Files", ProductsFile = "IRIProducts.txt", RetailProductsFile = "RetailerProducts.txt" };
            IRetailProductsService retailProductsService = new RetailProductsService();
            var retailerProducts = retailProductsService.GetProductWithCodes(fileRootPath, fileDetails);

            var productDetails1Record = retailerProducts.Where(rp => rp.ProductId == 212855 && rp.CodeType == "Woolworths Reference Number").FirstOrDefault();

            Assert.Equal("1B805DC15FE871DADFD5225772CFDE9F", productDetails1Record.Code);
        }
    }
}
