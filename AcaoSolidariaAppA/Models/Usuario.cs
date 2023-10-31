using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace AcaoSolidariaAppA.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public int? IdFotoUsuario { get; set; }
        public string Nome { get; set; } 
        public string Email { get; set; }
        public string SenhaUsuario { get; set; }
        public DateTime? DataRegistro { get; set; }
        public string DescricaoHabilidades { get; set; }
        public float? AvaliacaoMedia { get; set; }
    }
}