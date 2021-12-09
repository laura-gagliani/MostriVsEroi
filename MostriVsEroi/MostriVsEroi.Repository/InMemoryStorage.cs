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
            new Arma() { IdArma = 3, Nome= "Mazza", PuntiDanno = 5, Categoria = Arma.CategoriaPersonaggi.Guerriero },
            new Arma() { IdArma = 4, Nome= "Spada", PuntiDanno = 10, Categoria = Arma.CategoriaPersonaggi.Guerriero },
            new Arma() { IdArma = 5, Nome= "Spadone", PuntiDanno = 15, Categoria = Arma.CategoriaPersonaggi.Guerriero },

            new Arma() { IdArma = 6, Nome= "Arco e frecce", PuntiDanno = 8, Categoria = Arma.CategoriaPersonaggi.Mago },
            new Arma() { IdArma = 7, Nome= "Bacchetta", PuntiDanno = 5, Categoria = Arma.CategoriaPersonaggi.Mago },
            new Arma() { IdArma = 8, Nome= "Bastone magico", PuntiDanno = 10, Categoria = Arma.CategoriaPersonaggi.Mago },
            new Arma() { IdArma = 9, Nome= "Onda d'urto", PuntiDanno = 15, Categoria = Arma.CategoriaPersonaggi.Mago },
            new Arma() { IdArma = 10, Nome= "Pugnale", PuntiDanno = 5, Categoria = Arma.CategoriaPersonaggi.Mago },

            new Arma() { IdArma = 11, Nome= "Discorso noioso", PuntiDanno = 4, Categoria = Arma.CategoriaPersonaggi.Cultista },
            new Arma() { IdArma = 12, Nome= "Farneticazione", PuntiDanno = 7, Categoria = Arma.CategoriaPersonaggi.Cultista },
            new Arma() { IdArma = 13, Nome= "Imprecazione", PuntiDanno = 5, Categoria = Arma.CategoriaPersonaggi.Cultista },
            new Arma() { IdArma = 14, Nome= "Magia nera", PuntiDanno = 3, Categoria = Arma.CategoriaPersonaggi.Cultista },

            new Arma() { IdArma = 15, Nome= "Arco", PuntiDanno = 7, Categoria = Arma.CategoriaPersonaggi.Orco },
            new Arma() { IdArma = 16, Nome= "Clava", PuntiDanno = 5, Categoria = Arma.CategoriaPersonaggi.Orco },
            new Arma() { IdArma = 17, Nome= "Spada rotta", PuntiDanno = 3, Categoria = Arma.CategoriaPersonaggi.Orco },
            new Arma() { IdArma = 18, Nome= "Mazza chiodata", PuntiDanno = 10, Categoria = Arma.CategoriaPersonaggi.Orco },

            new Arma() { IdArma = 19, Nome= "Alabarda del drago", PuntiDanno = 30, Categoria = Arma.CategoriaPersonaggi.SignoreDelMale },
            new Arma() { IdArma = 20, Nome= "Divinazione", PuntiDanno = 15, Categoria = Arma.CategoriaPersonaggi.SignoreDelMale },
            new Arma() { IdArma = 21, Nome= "Fulmine", PuntiDanno = 10, Categoria = Arma.CategoriaPersonaggi.SignoreDelMale },
            new Arma() { IdArma = 22, Nome= "Fulmine celeste", PuntiDanno = 15, Categoria = Arma.CategoriaPersonaggi.SignoreDelMale },
            new Arma() { IdArma = 23, Nome= "Tempesta", PuntiDanno = 8, Categoria = Arma.CategoriaPersonaggi.SignoreDelMale },
            new Arma() { IdArma = 24, Nome= "Tempesta oscura", PuntiDanno = 15, Categoria = Arma.CategoriaPersonaggi.SignoreDelMale },

        };

        public static List<Mostro> Mostri = new List<Mostro>()
        {
            new Mostro() {IdMostro = 1, Nome = "CiccioPasticcio", Categoria = Mostro.CategoriaMostro.Orco, Livello=1, IdArma = 17, PuntiVita = 20 },
            new Mostro() {IdMostro = 2, Nome = "Grog Schiacciateste", Categoria = Mostro.CategoriaMostro.Orco, Livello=2, IdArma = 16, PuntiVita = 40 },
            new Mostro() {IdMostro = 3, Nome = "Anonimo Cultista", Categoria = Mostro.CategoriaMostro.Cultista, Livello=2, IdArma = 11, PuntiVita = 40},
            new Mostro() {IdMostro = 4, Nome = "Arbnal il distruttore", Categoria = Mostro.CategoriaMostro.SignoreDelMale, Livello=1, IdArma = 23, PuntiVita = 20}
        };
    }
}
