using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace MBTech.Domain
{
    /// <summary>
    /// Marcas de carros utilitário
    /// </summary>
    [JsonObject]
    public class SmallCarsBrands
    {
        /// <summary>
        /// Marcas de carro
        /// </summary>
        [JsonProperty(null)]
        public IEnumerable<SmallCarBrand> Brands { get; set; }
    }

    /// <summary>
    /// Marca de carro utilitário
    /// </summary>
    [JsonObject]
    public class SmallCarBrand
    {
        /// <summary>
        /// Marca
        /// </summary>
        [JsonProperty("Label")]
        public string Brand { get; set; }
        /// <summary>
        /// Código da marca
        /// </summary>
        [JsonProperty("Value")]
        public string Code { get; set; }
    }
}
