using MBTech.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    public static class GenerateObjectToTest
    {
        public static SmallCarsBrands SmallCarsBrands()
        {
            return new SmallCarsBrands
            {
                Brands = new List<SmallCarBrand> {new SmallCarBrand { Brand = "test", Code = "1" }, new SmallCarBrand { Brand = "test", Code = "2" }, new SmallCarBrand { Brand = "test", Code = "3" } },

            };
        }
    }
}
