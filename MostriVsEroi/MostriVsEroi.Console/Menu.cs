using MostriVsEroi.Core.BusinessLayer;
using MostriVsEroi.Core.Entities;
using MostriVsEroi.Repository.MockRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//commento valentina
namespace MostriVsEroi.ConsoleApp
{
    public class Menu
    {
        static private readonly IBusinessLayer bl = new MainBusinessLayer(new MockRepositoryEroi(), new MockRepositoryMostri(), new MockRepositoryUtenti(), new MockRepositoryArmi());

        //Commento Antonio


        internal static void Start()
        {
            // benvenuto
            Console.WriteLine("Benvenuto!");





            //commento inserito nel branch Laura
            //commento inserito da antonio
            int choice2 = -1;
            int choice1 = -1;
            do
            {
                Console.WriteLine("[1] Accedi");
                Console.WriteLine("[2] Registrati");
                Console.WriteLine("[0] Esci");

                choice1 = GetMenuChoice();

                User utente = new User();
                choice2 = -1;
                switch (choice1)
                {
                    case 0:
                        Console.WriteLine("Alla prossima avventura!");
                        choice2 = 0;
                        break;
                    case 1:
                        utente = Autenticati();
                        break;
                    case 2:
                        //col case numero 2 registriamo l'utente che dovrà poi eseguire il login
                        if (Registrati())
                            utente = Autenticati();
                        break;
                }
                
                //scelta menu admin o menu user
                while(choice2 != 0 && choice1 !=0)
                {
                    if (utente.Admin)
                    {
                        choice2 = StampaMenuAdmin();
                    }
                    else
                    {

                        choice2 = StampaMenuBase();
                    }

                    switch (choice2)
                    {
                        case 1:
                            GiocaPartita(utente.UserId);
                            break;
                        case 2:
                            CreaNuovoEroe(utente.UserId);
                            break;
                        case 3:
                            EliminaEroe(utente.UserId);
                            break;
                        case 4:
                            CreaNuovoMostro();
                            break;
                        case 5:
                            MostraClassifica();
                            break;
                        case 0:
                            utente = null;
                            break;
                    }
                };

            } while (choice1 != 0);
        }
        private static void MostraClassifica()
        {
            int classifica = 1;
            List<Eroe> classificaEroi = bl.GetClassifica();
            List<User> users = bl.GetUtenti();
            if (classificaEroi != null)
            {
                foreach (Eroe e in classificaEroi)
                {
                    foreach (User u in users)
                    {
                        if (u.UserId == e.IdUser && classifica <= 10)
                            Console.WriteLine($"{classifica++}° Classificato {u.Nickname}, con il suo " +
                                $"{e.Categoria} conosciuto come {e.Nome}");
                    }
                }
            }
            else
                Console.WriteLine("Non ci sono ");
        }
        private static void CreaNuovoMostro()
        {
            bool verifyArma = false;
            bool verify = false;

            Mostro newMostro = new Mostro();
            //ciclo nickname
            do
            {
                Console.WriteLine("Scegli un nome per il mostro");
                string name = Console.ReadLine();
                if (name.Length > 0)
                    verify = true;

            } while (!verify);
            verify = false;
            //ciclo categoria e arma
            do
            {
                Console.WriteLine("Quale classe vuoi attribuire al mostro? \n" +
                    "[1] Cultista \n" +
                    "[2] Orco \n" +
                    "[3] SignoreDelMale \n");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 3)
                {
                    //Scelta della categoria e dell'arma
                    switch (choice)
                    {
                        case 1:
                            newMostro.Categoria = Mostro.CategoriaMostro.Cultista;
                            List<Arma> armiCultista = bl.GetArmiByCategoria(Arma.CategoriaPersonaggi.Cultista);
                            do
                            {
                                Console.WriteLine("Scegli l'arma da assegnare al Cultista");
                                foreach (Arma a in armiCultista)
                                {
                                    Console.WriteLine($"[{a.IdArma}] {a} \n");
                                }
                                if (int.TryParse(Console.ReadLine(), out int choiceArma))
                                    foreach (Arma a in armiCultista)
                                    {
                                        if (a.IdArma == choiceArma)
                                        {
                                            newMostro.IdArma = choiceArma;
                                            verifyArma = true;
                                        }
                                    }
                                else
                                    Console.WriteLine("Scegli un id arma corretto");
                            } while (!verifyArma);
                            break;
                        case 2:
                            newMostro.Categoria = Mostro.CategoriaMostro.Orco;
                            List<Arma> armiOrco = bl.GetArmiByCategoria(Arma.CategoriaPersonaggi.Orco);
                            do
                            {
                                Console.WriteLine("Scegli l'arma da assegnare al Cultista");
                                foreach (Arma a in armiOrco)
                                {
                                    Console.WriteLine($"[{a.IdArma}] {a} \n");
                                }
                                if (int.TryParse(Console.ReadLine(), out int choiceArma))
                                    foreach (Arma a in armiOrco)
                                    {
                                        if (a.IdArma == choiceArma)
                                        {
                                            newMostro.IdArma = choiceArma;
                                            verifyArma = true;
                                        }
                                    }
                                else
                                    Console.WriteLine("Scegli un id arma corretto");
                            } while (!verifyArma);
                            break;
                        case 3:
                            newMostro.Categoria = Mostro.CategoriaMostro.SignoreDelMale;
                            List<Arma> armiSignoreDelMale = bl.GetArmiByCategoria(Arma.CategoriaPersonaggi.SignoreDelMale);
                            do
                            {
                                Console.WriteLine("Scegli l'arma da assegnare al Cultista");
                                foreach (Arma a in armiSignoreDelMale)
                                {
                                    Console.WriteLine($"[{a.IdArma}] {a} \n");
                                }
                                if (int.TryParse(Console.ReadLine(), out int choiceArma))
                                    foreach (Arma a in armiSignoreDelMale)
                                    {
                                        if (a.IdArma == choiceArma)
                                        {
                                            newMostro.IdArma = choiceArma;
                                            verifyArma = true;
                                        }
                                    }
                                else
                                    Console.WriteLine("Scegli un id arma corretto");
                            } while (!verifyArma);
                            break;
                    }
                    verify = true;
                }
                else
                    Console.WriteLine("Scegli una categoria dall'elenco");
            } while (!verify);
            verify = false;
            //ciclo per livelli e hp
            do
            {
                Console.WriteLine("Inserisci un livello da 1 a 5");
                if (int.TryParse(Console.ReadLine(), out int livelloMostro) && livelloMostro >= 1 && livelloMostro <= 5)
                {
                    verify = true;
                    switch (livelloMostro)
                    {
                        case 1:
                            newMostro.Livello = livelloMostro;
                            newMostro.PuntiVita = 20;
                            break;
                        case 2:
                            newMostro.Livello = livelloMostro;
                            newMostro.PuntiVita = 40;
                            break;
                        case 3:
                            newMostro.Livello = livelloMostro;
                            newMostro.PuntiVita = 60;
                            break;
                        case 4:
                            newMostro.Livello = livelloMostro;
                            newMostro.PuntiVita = 80;
                            break;
                        case 5:
                            newMostro.Livello = livelloMostro;
                            newMostro.PuntiVita = 100;
                            break;
                    }
                }
            } while (!verify);
            if (bl.AddNewMostro(newMostro))
                Console.WriteLine("Il mostro è stato creato!");
            else
                Console.WriteLine("C'è stato un errore nella creazione del mostro riprova");
        }
        private static void EliminaEroe(int userId)
        {
            bool verify = false;
            bool verifyEroe = false;
            List<Eroe> eroi = bl.GetEroeByIdUser(userId);
            Console.WriteLine("Quale eroe dalla tua lista vuoi eliminare?");
            foreach (Eroe e in eroi)
            {
                Console.WriteLine($"[{e.IdEroe}] {e}\n");
            }
            do
            {
                if (int.TryParse(Console.ReadLine(), out int idEroe))
                {
                    foreach (Eroe e in eroi)
                    {
                        if (e.IdEroe == idEroe)
                            verifyEroe = true;
                    }
                }
                if (verifyEroe)
                {
                    Eroe eroeDaEliminare = bl.GetEroeById(idEroe);
                    if (bl.DeleteEroe(eroeDaEliminare))
                    {
                        Console.WriteLine("Eliminazione avvenuta con successo");
                        verify = true;
                    }
                    else
                    {
                        Console.WriteLine("C'è stato un problema nell'eliminazione");
                    }
                }
                else
                {
                    Console.WriteLine("Inserisci un id corretto");
                }
            } while (!verify);
        }
        private static void CreaNuovoEroe(int userId)
        {
            //variabile che verifica se gli inserimenti son tutti corretti
            //permette di ciclare finchè non si da una risposta corretta
            bool verify = false;
            Eroe newEroe = new Eroe();
            do
            {
                Console.WriteLine("Quale classe vuoi attribuire al tuo personaggio? \n" +
                                    "[1] Guerriero \n" +
                                    "[2] Mago \n");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice == 1)
                    {
                        newEroe.Categoria = Eroe.CategoriaEroe.Guerriero;
                        Console.WriteLine("Scegli l'arma");
                        List<Arma> armi = bl.GetArmiByCategoria(Arma.CategoriaPersonaggi.Guerriero);
                        foreach (Arma a in armi)
                        {
                            Console.WriteLine(a);
                        }
                        Console.WriteLine("Inserisci l'id dell'arma:");
                        if (int.TryParse(Console.ReadLine(), out int choiceArma))
                            foreach(Arma a in armi)
                            {
                                if (choiceArma == a.IdArma)
                                {
                                    verify = true;
                                    newEroe.IdArma = choiceArma;
                                }
                            }
                        else
                            verify = false;

                    }
                    else if (choice == 2)
                    {
                        //Scelta Mago
                        newEroe.Categoria = Eroe.CategoriaEroe.Mago;
                        List<Arma> armi = bl.GetArmiByCategoria(Arma.CategoriaPersonaggi.Mago);
                        foreach (Arma a in armi)
                        {
                            //stampa lista armi da mago
                            Console.WriteLine($"[{a.IdArma} {a} \n");
                        }
                        //verifica scelta
                        if (int.TryParse(Console.ReadLine(), out int choiceArma))
                            foreach(Arma a in armi)
                            {
                                if (choiceArma == a.IdArma)
                                {
                                    verify = true;
                                    newEroe.IdArma = choiceArma;
                                }
                            }
                        else
                            verify = false;
                    }
                    else
                        verify = false;
                }
            } while (!verify); //Fine while scelta categoria ed arma
            verify = false;
            do
            {
                Console.WriteLine("Inserisci il nome del tuo eroe\n");
                newEroe.Nome = Console.ReadLine();

                if (newEroe.Nome.Length == 0)
                {
                    Console.WriteLine("Nome inserito non valido. Riprova");                    
                }
                else
                {
                    
                    verify = true;
                }
            } while (!verify);//Fine scelta nome Eroe

            newEroe.IdUser = userId;
            //Richiamo del metodo e verifica dell'avvenuto inserimento
            if (bl.AddNewEroe(newEroe))
                Console.WriteLine("L'inserimeto è andato a buon fine");
            else
                Console.WriteLine("L'inserimento non è andato a buon fine");
        }
        private static int GetMenuChoice()
        {
            int choice = -1;
            bool verify = false;
            do
            {
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    //verifico che il dato dell'utente sia compreso tra 0 e 2
                    if (choice >= 0 && choice <= 2)
                        verify = true;
                    else
                        verify = false;
                }
                else
                    verify = false;
            } while (!verify);
            return choice;
        }
        private static bool Registrati()
        {
            Console.WriteLine("Inserisci il Nickname che vuoi utilizzare \n");
            string nickname = Console.ReadLine();
            Console.WriteLine("Inserisci la password che vuoi utilizzare \n");
            string password = Console.ReadLine();
            return bl.AddNewUser(nickname, password);
        }
        private static User Autenticati()
        {
            User user = new User();
            bool verificato = false;
            string nickname = "";
            string password = "";
            do
            {
                do
                {
                    Console.WriteLine("Inserisci il tuo nome utente \n");
                    nickname = Console.ReadLine();
                    if (nickname.Length > 0)
                    {
                        Console.WriteLine("Inserisci la password");
                        password = Console.ReadLine();
                        if (password.Length > 0)
                        {
                            verificato = true;
                        }
                    }
                } while (!verificato);

                user = bl.GetUserByNicknameAndPassword(nickname, password);
                if (user != null)
                    verificato = true;
                else
                    verificato = false;
                //metodo che chiede in input nickname e pssw
                //se trova un utente con quei dati rende quello,
                //altrimenti dice "errore, inserisci dati corretti" e continua a ciclare finché non trova
                //un utente con i dati richiesti. alla fine rende quello
            } while (!verificato);
            return user;
        }
        private static int StampaMenuBase()
        {
            //Creo una variabile verifica e scelta
            bool verify = false;
            int choice = -1;
            //Apro un ciclo do/while per tenere l'utente nel menu finchè non mi darà una scelta che voglio io
            do
            {
                //stampo a video il menu
                Console.WriteLine("Menu User \n" +
                                    "[1] Gioca \n" +
                                    "[2] Crea Nuovo Eroe \n" +
                                    "[3] Elimina Eroe \n" +
                                    "[0] Logout \n");
                //provo a parsare il contenuto dato dall'utente
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    //verifico che il dato dell'utente sia compreso tra 0 e 3
                    if (choice >= 0 && choice <= 3)
                    {
                        verify = true;
                    }
                }
                else
                    verify = false;



            } while (!verify);
            return choice; //ritorno il dato dell'utente
        }
        private static int StampaMenuAdmin()
        {
            int choise = -1;
            bool verify = false;
            do
            {
                Console.WriteLine("Menu Admin \n" +
                                    "[1] Gioca \n" +
                                    "[2] Crea Nuovo Eroe \n" +
                                    "[3] Elimina Eroe \n" +
                                    "[4] Crea Mostro \n" +
                                    "[5] Mostra Classifica \n" +
                                    "[0] Logout \n");
                if (int.TryParse(Console.ReadLine(), out choise))
                {
                    if (choise >= 0 && choise <= 5)
                    {
                        verify = true;
                    }
                }
                else
                    verify = false;



            } while (!verify);
            return choise;
        }
        private static void GiocaPartita(int id)
        {

            bool verify = false;
            Console.WriteLine("Stai iniziando una nuova partita scegli il tuo eroe");
            //Ottengo la lista eroi di un dato utente grazie al metodo qui sotto
            List<Eroe> eroi = bl.GetEroeByIdUser(id);
            if (eroi != null)
            {
                foreach (Eroe e in eroi)
                {
                    //Stampo l'elenco di eroi per un dato utente
                    Console.WriteLine($"[{e.IdEroe}] {e.Nome}\n");
                }
                //Proviamo il parse
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    //richiamiamo l'eroe scelto nella variabile "eroe"
                    foreach (Eroe e in eroi)
                    {
                        if (e.IdEroe == choice)
                            verify = true;
                    }
                    //Verifichiamo che il numero scelto sia compreso tra quelli effettivamente disponibili
                    if (verify)
                    {
                        Console.WriteLine("Preparati, inzia la partita!");
                        Eroe eroe = bl.GetEroeById(choice);
                        int lvlPrecedente = eroe.Livello;
                        //Prendiamo randomicamento il mostro dal metodo 
                        Mostro mostro = bl.GetRandomMostro(eroe.Livello);

                        Console.WriteLine($"\nSfida tra l'eroe {eroe.Nome} e {mostro.Nome}...");
                        //Calcoliamo il punteggio della partita
                        int punteggioPartita = bl.CalcolaEsitoPartita(eroe, mostro);

                        Console.WriteLine($"La partita è terminata! Punteggio finale: {punteggioPartita}");

                        //aggiorniamo i dati dell'eroe con il quale l'utente ha voluto giocare
                        Eroe eroeAggiornato = bl.AggiornaEroe(eroe, punteggioPartita);
                        //Infine stampiamo i dati dell'eroe aggiornato
                        List<User> users = bl.GetUtenti();
                        User userLoggato = new User();
                        foreach (User u in users)
                        {
                            if(u.UserId == id)
                            {
                                userLoggato = u;
                            }
                        }
                        if (lvlPrecedente < eroeAggiornato.Livello)
                        {
                            Console.WriteLine("Il tuo eroe è salito di livello!\n" +
                                                  $"{eroeAggiornato}");
                            if (eroeAggiornato.Livello >= 3 && !userLoggato.Admin)
                            {
                                bl.AggiornaUtente(id);
                                Console.WriteLine("Un tuo eroe è salito al livello 3! Sei stato promosso admin");
                            }
                        }
                        else
                        { 
                            Console.WriteLine("Ecco le statistiche del tuo personaggio aggiornate \n" +
                                                $"{eroeAggiornato}");
                        }
                    }
                }
                else
                    Console.WriteLine("Non è stato trovato nessun Eroe");
            }
            else
                Console.WriteLine("Non hai ancora nessun eroe. Aggiungine almeno uno per poter giocare!");

        }
    }
}
