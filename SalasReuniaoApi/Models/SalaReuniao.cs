using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalasReuniaoApi.Models
{
    public class SalaReuniao
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Capacidade { get; set; }
        public bool PossuiProjetor { get; set; }

    }
}