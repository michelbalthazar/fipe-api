using MBTech.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MBTech.Domain
{
    public interface ISmallCarsUtilitiesClient
    {
        /// <summary>Obter todas as marcas de carro utilitário</summary>
        /// <returns>Lista de todas as marcas de carros utilitário</returns>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<Result<SmallCarsBrands>> GetBrandsAsync(System.Threading.CancellationToken cancellationToken);
    }
}
