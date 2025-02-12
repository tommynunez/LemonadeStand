using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using LemonadeStand.Abstractions.Interfaces;
using LemonadeStand.Abstractions.Models;
using Microsoft.Toolkit.Diagnostics;

namespace LemonadeStand.Graphql.Queries
{
    [ExtendObjectType("Query")]
    public class LemonadeTypeQuery
    {
        public async Task<LemonadeType?> RetrieveLemonadeTypeById([Service] ILemonadeTypeService _lemonadeTypeService, int id)
        {
            var oLemoandeType = new LemonadeType();
            try
            {
                oLemoandeType = await _lemonadeTypeService.GetByIdAsync(id);
                return oLemoandeType;
            }
            catch (Exception ex)
            {
                
            }
            return oLemoandeType;
        }

        public async Task<IEnumerable<LemonadeType>> RetrieveAllLemonadeTypes([Service] ILemonadeTypeService _lemonadeTypeService)
        {
            try
            {
                var oLemoandeTypelist = await _lemonadeTypeService.GetAllLemonadeTypesAsync();
                oLemoandeTypelist.ToList();
                return oLemoandeTypelist;
            }
            catch (Exception ex)
            {

            }
            return new List<LemonadeType>();
        }
    }
}

