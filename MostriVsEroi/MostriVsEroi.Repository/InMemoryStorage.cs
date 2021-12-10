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
            new Eroe() { IdEroe = 1, Nome = "Evet'el", Categoria = Eroe.CategoriaEroe.Mago,                 IdUser = 2, Livello = 1, PuntiVita = 20, IdArma = 9, PuntiEsperienza = 7 },
            new Eroe() { IdEroe = 2, Nome = "Gandalf", Categoria = Eroe.CategoriaEroe.Mago,                 IdUser = 2, Livello = 3, PuntiVita = 60, IdArma = 8, PuntiEsperienza = 72 },
            new Eroe() { IdEroe = 3, Nome = "Otis Pugnodiferro", Categoria = Eroe.CategoriaEroe.Guerriero,  IdUser = 2, Livello = 5, PuntiVita = 100, IdArma = 3, PuntiEsperienza =0 },

            new Eroe() { IdEroe = 4, Nome = "Ehig il Rosso", Categoria = Eroe.CategoriaEroe.Guerriero,      IdUser = 1, Livello = 2, PuntiVita = 40, IdArma = 1, PuntiEsperienza =80 },
            new Eroe() { IdEroe = 5, Nome = "Agernak", Categoria = Eroe.CategoriaEroe.Mago,                 IdUser = 1, Livello = 1, PuntiVita = 20, IdArma = 6, PuntiEsperienza =12 },
            new Eroe() { IdEroe = 6, Nome = "Tia di BoscoGrigio", Categoria = Eroe.CategoriaEroe.Guerriero, IdUser = 1, Livello = 1, PuntiVita = 20, IdArma = 4, PuntiEsperienza =16 },
            new Eroe() { IdEroe = 7, Nome = "Strega Varana", Categoria = Eroe.CategoriaEroe.Mago,           IdUser = 1, Livello = 1, PuntiVita = 20, IdArma = 10, PuntiEsperienza =18 },
            new Eroe() { IdEroe = 8, Nome = "Mago Merlino", Categoria = Eroe.CategoriaEroe.Mago,            IdUser = 1, Livello = 2, PuntiVita = 40, IdArma = 7, PuntiEsperienza =5 },

            new Eroe() { IdEroe = 9, Nome = "Bruenor", Categoria = Eroe.CategoriaEroe.Guerriero,            IdUser = 3, Livello = 2, PuntiVita = 40, IdArma = 2, PuntiEsperienza =12 },
            new Eroe() { IdEroe = 10, Nome = "Ivan l'Onorevole", Categoria = Eroe.CategoriaEroe.Guerriero,  IdUser = 3, Livello = 1, PuntiVita = 20, IdArma = 1, PuntiEsperienza =20 },
            new Eroe() { IdEroe = 11, Nome = "Fata Lina", Categoria = Eroe.CategoriaEroe.Mago,              IdUser = 3, Livello = 1, PuntiVita = 20, IdArma = 8, PuntiEsperienza =5 },



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
            new Mostro() {IdMostro = 2, Nome = "Grog Schiacciateste", Categoria = Mostro.CategoriaMostro.Orco, Livello=1, IdArma = 16, PuntiVita = 20 },
            new Mostro() {IdMostro = 3, Nome = "Anonimo Cultista", Categoria = Mostro.CategoriaMostro.Cultista, Livello=1, IdArma = 11, PuntiVita = 20},
            new Mostro() {IdMostro = 4, Nome = "Arbnal il Distruttore", Categoria = Mostro.CategoriaMostro.SignoreDelMale, Livello=1, IdArma = 23, PuntiVita = 20},

            new Mostro() {IdMostro = 5, Nome = "Glub Spezzaschiene", Categoria = Mostro.CategoriaMostro.Orco, Livello=2, IdArma = 18, PuntiVita = 40},
            new Mostro() {IdMostro = 6, Nome = "Oscuro predicatore", Categoria = Mostro.CategoriaMostro.Cultista, Livello=2, IdArma = 12, PuntiVita = 40},
            new Mostro() {IdMostro = 7, Nome = "Saruman", Categoria = Mostro.CategoriaMostro.SignoreDelMale, Livello=2, IdArma = 23, PuntiVita = 40},
            new Mostro() {IdMostro = 8, Nome = "Adaregh l'Oscuro", Categoria = Mostro.CategoriaMostro.SignoreDelMale, Livello=2, IdArma = 19, PuntiVita = 40},

            new Mostro() {IdMostro = 9, Nome = "Brugg Junior", Categoria = Mostro.CategoriaMostro.Orco, Livello=3, IdArma = 16, PuntiVita = 60},
            new Mostro() {IdMostro = 10, Nome = "Jrea il Corrotto", Categoria = Mostro.CategoriaMostro.Cultista, Livello=3, IdArma = 14, PuntiVita = 60},
            new Mostro() {IdMostro = 11, Nome = "Omenonn il Bestemmiatore", Categoria = Mostro.CategoriaMostro.Cultista, Livello=3, IdArma = 13, PuntiVita = 60},
            new Mostro() {IdMostro = 12, Nome = "Colui Che Non Deve Essere Nominato", Categoria = Mostro.CategoriaMostro.SignoreDelMale, Livello=3, IdArma = 21, PuntiVita = 60},


        };
    }
}
