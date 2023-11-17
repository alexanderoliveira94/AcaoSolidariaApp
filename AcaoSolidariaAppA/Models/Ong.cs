using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcaoSolidariaAppA.Models
{
    public class ONG
    {

        [Key]
        public int? IdOng { get; set; }

        public int? IdFotoOng { get; set; }
        public string NomeOng { get; set; } = string.Empty;
        public string EnderecoOng { get; set; } = string.Empty;
        public string CNPJOng { get; set; } = string.Empty;

        public DateTime? DataRegistro { get; set; }

        [EmailAddress]
        public string EmailOng { get; set; }

        public string DescricaoOng { get; set; } = string.Empty;

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string SenhaOng { get; set; } = string.Empty;

        //public Endereco Endereco { get; set; }
    }
}