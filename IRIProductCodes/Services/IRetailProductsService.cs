using System.Collections.Generic;
using Models;

namespace Services
{
    public interface IRetailProductsService
    {
        List<ProductCodes> GetProductWithCodes(string startupPath, FileDetails fileDetails);
    }
}
