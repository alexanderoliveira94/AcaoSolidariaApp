using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcaoSolidariaApp.Models
{
    public class FotoPerfil
    {
        [Key]
        public int ?IdFoto { get; set; }
        public byte[] Foto { get; set; }
    }
}