using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TechsysLogProj.Cross.Proxies
{
    public abstract class BaseProxy
    {
        private readonly JsonSerializerOptions _optionsNameCaseInsensitive = new() { PropertyNameCaseInsensitive = true };

        public BaseProxy()
        {
        }

        protected async Task<TipoRetorno> Get<TipoRetorno>(string pathUrl)
        {
            HttpResponseMessage responseMessage = null;

            try
            {
                using(HttpClient httpClient = new HttpClient())
                {
                    responseMessage = await httpClient.GetAsync(pathUrl);

                    if (!responseMessage.IsSuccessStatusCode)
                        throw new ArgumentException($"[{responseMessage.StatusCode}] - {await responseMessage.Content.ReadAsStringAsync()}");

                    return JsonSerializer.Deserialize<TipoRetorno>(await responseMessage.Content.ReadAsStringAsync(), _optionsNameCaseInsensitive);
                }
               
            }
            catch (HttpRequestException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
