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

            
            if (!double.TryParse(input, out _)) 
            {
                Console.WriteLine("Veuillez entrer un nombre valide.");
                continue;
            }

            nombres.Add(Convert.ToDouble(input));
        }
    }

    static void Menu()
    {
        //Interface graphique
        Console.WriteLine("Connexion en cours...");
        Task.Delay(1000).Wait();
        Console.Clear();

        //Menu de la calculatrice
        Console.WriteLine("Calculatrice en C#");
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Soustraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");
        Console.WriteLine("5. Puissances");
        Console.WriteLine("6. Racines");
        Console.WriteLine("7. Quitter");
        Console.Write("Choisissez une option : ");
    }

    static void Main()
    {
        while (true)
        {
            Menu();
            int choix = Convert.ToInt32(Console.ReadLine()!);
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
                    Console.WriteLine("Déconnecté avec succès !");
                    Task.Delay(500).Wait();
                    Environment.Exit(0);
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
