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
    public class SizeQuery
    {
        public async Task<Size?> RetrieveSizeTypeById([Service] ISizeService _sizeService, int id)
        {
            var oSize = new Size();
            try
            {
                oSize = await _sizeService.GetByIdAsync(id);
                return oSize;
            }
            catch (Exception ex)
            {

            }
            return oSize;
        }

        public async Task<IEnumerable<Size>> RetrieveAllSizes([Service] ISizeService _sizeService)
        {
            try
            {
                var oSizelist = await _sizeService.GetAllSizesAsync();
                oSizelist.ToList();
                return oSizelist;
            }
            catch (Exception ex)
            {

            }
            return new List<Size>();
        }
    }
}

