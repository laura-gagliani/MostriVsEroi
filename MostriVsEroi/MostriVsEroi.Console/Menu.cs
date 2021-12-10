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



        internal static void Start()
        {
            // benvenuto
            Console.WriteLine("Benvenuto!");

            

            

            //commento inserito nel branch Laura
            //commento inserito da antonio

            int choice1 = -1;
            do
            {
                Console.WriteLine("[1] Accedi");
                Console.WriteLine("[2] Registrati");
                Console.WriteLine("[0] Esci");

                choice1 = GetMenuChoice();

                User utente = new User();

                switch (choice1)
                {
                    case 0:
                        Console.WriteLine("Alla prossima avventura!");
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

                int choice2 = -1;

                do
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
                } while (choice2 != 0);

            } while (choice1 != 0);
        }
        private static void MostraClassifica()
        {
            int classifica = 0;
            List<Eroe> classificaEroi = bl.GetClassifica();
            List<User> users = bl.GetUtenti();
            if (classificaEroi != null)
            {
                foreach (Eroe e in classificaEroi)
                {
                    foreach (User u in users)
                    {
                        if (u.UserId == e.IdUser && classifica < 10)
                            Console.WriteLine($"{classifica++}° Classificato {u.Nickname}, con il suo" +
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
                if(name.Length > 0)
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
            }while (!verify);
            verify = false;
            //ciclo per livelli e hp
            do
            {
                Console.WriteLine("Inserisci un livello da 1 a 5");
                if (int.TryParse(Console.ReadLine(), out int livelloMostro) && livelloMostro >= 1 && livelloMostro <= 5)
                    switch(livelloMostro)
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
            foreach( Eroe e in eroi)
            {
                Console.WriteLine($"[{e.IdEroe}] {e}\n");
            }
            do
            {
                if (int.TryParse(Console.ReadLine(), out int idEroe))
                    foreach(Eroe e in eroi)
                    {
                        if(e.IdEroe == idEroe)
                            verifyEroe = true;
                    }
                if (verifyEroe)
                {
                    Eroe ereoDaEliminare = bl.GetEroeById(idEroe);
                    if (bl.DeleteEroe(ereoDaEliminare))
                    {
                        Console.WriteLine("Eliminazione avvenuta con successo");
                        verify = true;
                    }
                    else
                        Console.WriteLine("C'è stato un problema nell'eliminazione");
                } 
                else
                    Console.WriteLine("Inserisci un id corretto");
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
                Console.WriteLine(  "Quale classe vuoi attribuire al tuo personaggio? \n" +
                                    "[1] Guerriero \n" +
                                    "[2] Mago \n");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice == 1)
                    {
                        newEroe.Categoria = Eroe.CategoriaEroe.Guerriero;
                        Console.WriteLine("Scegli l'arma");
                        List<Arma> armi = bl.GetArmiByCategoria(Arma.CategoriaPersonaggi.Guerriero);
                        foreach(Arma a in armi)
                        {
                            Console.WriteLine($"[{a.IdArma} {a} \n");
                        }
                        if (int.TryParse(Console.ReadLine(), out int choiceArma))
                            if (choiceArma == armi[0].IdArma)
                            {
                                verify = true;
                                newEroe.IdArma = choiceArma;
                            }
                            else
                                verify = false;
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
                            if (choiceArma == armi[0].IdArma)
                            {
                                newEroe.IdArma = choiceArma;
                                verify = true;
                            }
                            else
                                verify = false;
                        else
                            verify = false;
                    }
                    else
                        verify = false;
                }
            }while (!verify); //Fine while scelta categoria ed arma
            verify = false;
            do
            {
                Console.WriteLine("Inserisci il nome del tuo eroe\n");
                if (Console.ReadLine().Length > 0)
                {
                    Console.WriteLine("Nome inserito non valido. Riprova");
                }
                else
                {
                    newEroe.Nome = Console.ReadLine();
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
                    if (Console.ReadLine().Length > 0)
                    {
                        nickname = Console.ReadLine();
                        Console.WriteLine("Inserisci la password");
                        if (Console.ReadLine().Length > 0)
                        {
                            password = Console.ReadLine();
                            verificato = true;
                        }
                    }
                }while(!verificato);

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
            Console.WriteLine(  "Menu User \n" +
                                "[1] Gioca \n" +
                                "[2] Crea Nuovo Eroe \n" +
                                "[3] Elimina Eroe \n" +
                                "[0] Logout \n");
                //provo a parsare il contenuto dato dall'utente
            if (int.TryParse(Console.ReadLine(), out  choice))
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
                    Console.WriteLine($"[{e.IdEroe}] {e}\n");
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
                        //Prendiamo randomicamento il mostro dal metodo 
                        Mostro mostro = bl.GetRandomMostro(eroe.Livello);
                        //Calcoliamo il punteggio della partita
                        int punteggioPartita = bl.CalcolaEsitoPartita(eroe, mostro);
                        //aggiorniamo i dati dell'eroe con il quale l'utente ha voluto giocare
                        Eroe eroeAggiornato = bl.AggiornaEroe(choice, punteggioPartita);
                        //Infine stampiamo i dati dell'eroe aggiornato
                        if (eroe.Livello < eroeAggiornato.Livello)
                        {
                            Console.WriteLine("Il tuo eroe è salito di livello!\n" +
                                                $"{eroeAggiornato}");
                            if (eroeAggiornato.Livello >= 3)
                            {
                                bl.AggiornaUtente(id);
                                Console.WriteLine("Il tuo eroe è arrivato al 3° livello. Sei stato promosso ad Admin!");
                            }
                                
                        }
                        else
                            Console.WriteLine("Ecco le statistiche del tuo personaggio aggiornate \n" +
                                                $"{eroeAggiornato}");
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
