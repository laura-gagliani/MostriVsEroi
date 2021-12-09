using MostriVsEroi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Repository
{
    public class InMemoryStorage
    {
        public static List<User> Utenti = new List<User>()
        {
            new User() { UserId = 1, Nickname="Laura", Password="Laura01", Admin = false },
            new User() { UserId = 2, Nickname="Valentina", Password="Valentina02", Admin = true },
            new User() { UserId = 3, Nickname="Antonio", Password="Antonio03", Admin = false },
        };

        public static List<Eroe> Eroi = new List<Eroe>()
        {
            new Eroe() { IdEroe = 1, Nome = "Maghetto", Categoria = Eroe.CategoriaEroe.Mago, IdUser = 2, Livello = 1, PuntiVita = 20, IdArma = 4, PuntiEsperienza =0 }
        };

        public static List<Arma> Armi = new List<Arma>()
        {
            new Arma() { IdArma = 1, Nome= "Alabarda", PuntiDanno = 15, Categoria = Arma.CategoriaPersonaggi.Guerriero },
            new Arma() { IdArma = 2, Nome= "Ascia", PuntiDanno = 8, Categoria = Arma.CategoriaPersonaggi.Guerriero },

            new Arma() { IdArma = 3, Nome= "Arco", PuntiDanno = 7, Categoria = Arma.CategoriaPersonaggi.Orco },
            new Arma() { IdArma = 4, Nome= "Bacchetta", PuntiDanno = 5, Categoria = Arma.CategoriaPersonaggi.Mago },
        };

        public static List<Mostro> Mostri = new List<Mostro>()
        {
            new Mostro() {IdMostro = 1, Nome = "CiccioPasticcio", Categoria = Mostro.CategoriaMostro.Orco, Livello=1, IdArma = 3, PuntiVita = 20}
        };
    }
}
