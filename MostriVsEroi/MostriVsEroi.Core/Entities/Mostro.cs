using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Core.Entities
{
    public class Mostro
    {
        public int IdMostro { get; set; }
        public string Nome { get; set; }
        public int Livello { get; set; } = 1;
        public int PuntiVita { get; set; } = 20;
        public int IdArma { get; set; }

        public CategoriaMostro Categoria { get; set; }
        public void AssegnaPuntiVita()
        {
            PuntiVita = Livello * 20;
        }

        
        public enum CategoriaMostro
        {
            Cultista = 1,
            Orco,
            SignoreDelMale
        }
    }
}
