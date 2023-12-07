using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaoSolidariaApp.Models
{
    public class Publicacao
    {
        public int IdPublicacao { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int VagasDisponiveis { get; set; }
        public string Local { get; set; }
        public int OngAssociada { get; set; }
    }
}