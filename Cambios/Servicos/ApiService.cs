using Cambios.Modelos;
using Newtonsoft.Json;

namespace Cambios.Servicos
{
    public class ApiService
    {
        public async Task<Response> GetRates(string urlBase, string controller)
        {
            try
            {
                var client = new HttpClient(); //Criar HTTP p/fazer ligacao externa via HTTP
                client.BaseAddress = new Uri(urlBase); //Endereco base API

                var response = await client.GetAsync(controller); //Controlador API

                var result = await response.Content.ReadAsStringAsync(); //Carregar dados formato string p/ dentro da variavel result

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                var rates = JsonConvert.DeserializeObject<List<Rate>>(result);

                return new Response
                {
                    IsSuccess = true,
                    Result = rates
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
