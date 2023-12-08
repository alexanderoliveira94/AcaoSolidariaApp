using AcaoSolidariaAppA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaoSolidariaApp.Models
{
    public class Candidatura
    {
        public int IdCandidatura { get; set; }

        public int IdPublicacao { get; set; }

        public int IdUsuario { get; set; }

        public DateTime DataCandidatura { get; set; }
    }
}