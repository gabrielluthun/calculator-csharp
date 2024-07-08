class Calculatrice
{
    static List<double> nombres = new List<double>();

    static void entrerNombres()
    {
        nombres.Clear(); // Vider la liste avant d'ajouter de nouveaux nombres
        while (true)
        {
            Console.Write("Entrez un nombre (ou appuyez sur Entrée pour terminer) : ");
            string input = Console.ReadLine()!;
            if (input == "") break;
            if (input == "d")
            {
                nombres.RemoveAt(nombres.Count - 1);
                continue;
            }
            nombres.Add(Convert.ToDouble(input));
        }
    }

    static void Menu()
    {
        // Interface graphique
        Console.WriteLine("Connexion en cours...");
        Task.Delay(750).Wait();
        Console.Clear();

        // Menu de la calculatrice
        Console.WriteLine("--------- Calculatrice en C# (tapez 8 pour de l'aide) ------------------");
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Soustraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");
        Console.WriteLine("5. Puissances");
        Console.WriteLine("6. Racines");
        Console.WriteLine("7. Quitter");
        Console.WriteLine("8. Commandes");
        Console.Write("Choisissez une option : ");
    }

    static int verifyInput()
    {
        int choix;
        bool isInt;
        while (true)
        {
            // Vérification de l'entrée utilisateur
            isInt = int.TryParse(Console.ReadLine(), out choix);

            // Si l'entrée n'est pas un nombre ou si le nombre n'est pas entre 1 et 7, on affiche un message d'erreur, puis on retourne au menu
            if (isInt && choix >= 1 && choix <= 8) break;
            Console.WriteLine("Veuillez entrer un nombre entre 1 et 8.");
            Task.Delay(1000).Wait();
            Console.Clear();
            Menu();
        }
        return choix;
    }


    static void Main()
    {
        while (true) // Tant que l'utilisateur ne quitte pas, on continue
        {
            Menu();
            int choix = verifyInput();
            double result;

            switch (choix)
            {
                case 1:
                    entrerNombres();
                    result = nombres.Sum();
                    Console.WriteLine("Le résultat de l'addition est : " + result);
                    break;
                case 2:
                    entrerNombres();
                    result = nombres.Aggregate((a, b) => a - b);
                    Console.WriteLine("Le résultat de la soustraction est : " + result);
                    break;
                case 3:
                    entrerNombres();
                    result = nombres.Aggregate((a, b) => a * b);
                    Console.WriteLine("Le résultat de la multiplication est : " + result);
                    break;
                case 4:
                    entrerNombres();
                    result = nombres.Aggregate((a, b) => a / b);
                    Console.WriteLine("Le résultat de la division est : " + result);
                    break;
                case 5:
                    entrerNombres();
                    if (nombres.Count >= 2)
                    {
                        result = Math.Pow(nombres[0], nombres[1]);
                        Console.WriteLine("Le résultat de la puissance est : " + result);
                    }
                    else
                    {
                        Console.WriteLine("Veuillez entrer au moins deux nombres pour la puissance.");
                    }
                    break;
                case 6:
                    Console.Write("Entrez un nombre : ");
                    double num = Convert.ToDouble(Console.ReadLine()!);
                    result = Math.Sqrt(num);
                    Console.WriteLine("Le résultat de la racine est : " + result);
                    break;
                case 7:
                    Console.Clear();
                    Console.WriteLine("Déconnecté avec succès !");
                    Task.Delay(500).Wait();
                    Environment.Exit(0);
                    break;
                case 8:
                    Console.Clear();
                    Console.WriteLine("Commandes :");
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("Lors d'une opération, en cas d'erreur, utilisez la commande 'd' pour supprimer le dernier nombre entré");
                    Console.WriteLine("Entrée : valider un nombre entré");
                    break;
                default:
                    Console.WriteLine("Choix invalide");
                    break;
            }

            Console.WriteLine("Voulez-vous retourner au menu ? (o/n)");
            string retourMenu = Console.ReadLine()!.ToLower();
            Console.Clear();
            if (retourMenu != "o")
            {
                Console.WriteLine("Déconnecté avec succès !");
                Environment.Exit(0);
            }
        }
    }
}