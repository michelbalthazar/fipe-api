using MBTech.Domain;
using MBTech.Domain.Common;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MBTech.Infraestructure
{
    public class SmallCarsUtilitiesClient : ISmallCarsUtilitiesClient
    {
        private readonly HttpClient _httpClient;

        public SmallCarsUtilitiesClient(HttpClient httpClient = null)
        {
            _httpClient = httpClient ?? new HttpClient();
            _httpClient.BaseAddress = new Uri("http://veiculos.fipe.org.br/api/veiculos");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("codigoTipoVeiculo", "1");
        }

        public async Task<Result<SmallCarsBrands>> GetBrandsAsync(CancellationToken cancellationToken)
        {
            try
            {
                var url = $"/ConsultarMarcas";

                var response = await _httpClient.PostAsync(url, new StringContent("232", Encoding.UTF8, "application/json"), cancellationToken);

                var result = await HttpResponseConvert<SmallCarsBrands>.ResponseReadAsStringAsync(response);

                return result;
            }
            catch (Exception ex)
            {
                return new Result<SmallCarsBrands>(ResultStatusCode.Error, ex.Message);
            }
        }
    }
}
