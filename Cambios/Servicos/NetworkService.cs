using Cambios.Modelos;
using System.Net;

namespace Cambios.Servicos
{
    public class NetworkService
    {
        public Response CheckConnection()
        {
            var cliente = new WebClient();

            try
            {
                using (cliente.OpenRead("http://www.google.com"))
                {
                    return new Response
                    {
                        IsSuccess = true,
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao verificar conexão: " + ex.Message);
                return new Response
                {
                    IsSuccess = false,
                    Message = "Configure a sua ligação à Internet",
                };
            }
        }
    }
}
