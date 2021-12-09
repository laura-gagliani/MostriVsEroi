using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Core.Entities
{
    public class Arma
    {
        public int IdArma { get; set; }
        public string Nome { get; set; }
        public int PuntiDanno { get; set; }
        public CategoriaPersonaggi Categoria { get; set; }

        public enum CategoriaPersonaggi
        {
            Guerriero = 1,
            Mago,
            Cultista,
            Orco,
            SignoreDelMale

        }
    }
}
