using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcaoSolidariaApp.Models
{
    public class ONG
    {

        public int IdOng { get; set; }
        public int IdFotoOng { get; set; }
        public string NomeOng { get; set; }
        public string EnderecoOng { get; set; }
        public string CNPJOng { get; set; }
        public string EmailOng { get; set; }
        public string DescricaoOng { get; set; }
        public string SenhaOng { get; set; }

        //public Endereco Endereco { get; set; }
    }
}