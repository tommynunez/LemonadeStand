using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using LemonadeStand.Abstractions.Interfaces;
using LemonadeStand.Abstractions.Models;

namespace LemonadeStand.Graphql.Queries
{
    [ExtendObjectType("Query")]
    public class ProductQuery
    {
        public async Task<List<Product>> GetProductsAsync([Service] IProductService _productService)
        {
            try
            {
                var oProductslist = await _productService.GetAllProductsAsync();
                return oProductslist.ToList();
            }
            catch (Exception ex)
            {

            }
            return new List<Product>();
        }

        public async Task<Product?> RetrieveProductById([Service] IProductService _productService, int id)
        {
            var oProduct = new Product();
            try
            {
                oProduct = await _productService.GetByIdAsync(id);
                return oProduct;
            }
            catch (Exception ex)
            {

            }
            return oProduct;
        }
    }
}

