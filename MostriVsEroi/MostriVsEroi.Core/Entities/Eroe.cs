using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Core.Entities
{
    public class Eroe
    {
        public int IdEroe { get; set; }
        public string Nome { get; set; }
        public int Livello { get; set; } = 1;
        public int PuntiVita { get; set; } = 20;
        public int PuntiEsperienza { get; set; } = 0;
        public int IdArma { get; set; }
        public int  IdUser { get; set; }

        public CategoriaEroe Categoria { get; set; }

        public void AssegnaPuntiVita()
        {
            PuntiVita = Livello * 20;
        }

        //public void AggiornaLivello()
        //{
        //    //
        //}

        public enum CategoriaEroe
        {
            Guerriero = 1,
            Mago
        }


    }
}
