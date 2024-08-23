using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TechsysLogProj.Domain.Enum;

namespace TechsysLogProj.Application.ViewModel
{
    public class EnderecoViewModel
    {
        [JsonPropertyName("logradouro")]
        public string Endereco { get; set; }

   
        public string Cep { get; set; }

        public int Numero { get; set; } 

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }  

        public string Complemento { get; set; }

    }
}
