using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechsysLogProj.Cross.DTO;

namespace TechsysLogProj.Cross.Proxies
{
    public class ConsultaEnderecoProxy : BaseProxy
    {
        private readonly IConfiguration _configuration; 
        public ConsultaEnderecoProxy(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public async Task<RetornoConsultaCEP> ConsultarEnderecoCEP(string cep)
        {
            var url = String.Format(_configuration.GetSection("ConsultaExterna:consultaCEP").Value.ToString(), cep); 

            return await Get<RetornoConsultaCEP>(url);

        }
    }
}
