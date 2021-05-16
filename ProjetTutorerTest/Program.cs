using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ProjetTutorerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            bool verif_caract = true;
            Console.WriteLine("Entrer le nombre de piquet (minimum 3)");

            string nb_piquet_string = Console.ReadLine();
            int nb_piquet = 0;
            if (Regex.IsMatch(nb_piquet_string, @"^[0-9]+$") && int.Parse(nb_piquet_string) >= 3)
            {
                nb_piquet = int.Parse(nb_piquet_string);
            }
            else
            {
                do
                {
                    Console.WriteLine("Veuillez insérez un nombre supérieur à 3 !");
                    nb_piquet_string = Console.ReadLine();
                    if (Regex.IsMatch(nb_piquet_string, @"^[0-9]+$") && int.Parse(nb_piquet_string) >= 3)
                    {
                        nb_piquet = int.Parse(nb_piquet_string);
                        verif_caract = false;
                    }

                }
                while (string.IsNullOrEmpty(nb_piquet_string) || verif_caract == true);
            }
            Console.WriteLine("Nombre de piquet : {0}", nb_piquet);
            Piquet[] tabPiquet = new Piquet[nb_piquet];
            for (int idx = 0; idx < nb_piquet; idx++)
            {
                Console.WriteLine("Entrer l'abscisse du piquet : {0}", idx + 1);
                double v_abscise = 0;
                double v_ordonner = 0;
                bool erreur = false;
                do
                {
                    try
                    {

                        v_abscise = double.Parse(Console.ReadLine());
                        erreur = false;
                    }
                    catch
                    {
                        Console.WriteLine("Veuillez saisir un nombre !");
                        erreur = true;
                    }

                } while (erreur == true);
                Console.WriteLine("Entrer l'ordonnée du piquet : {0}", idx + 1);
                do
                {
                    try
                    {

                        v_ordonner = double.Parse(Console.ReadLine());
                        erreur = false;
                    }
                    catch
                    {
                        Console.WriteLine("Veuillez saisir un nombre !");
                        erreur = true;
                    }

                } while (erreur == true);

                tabPiquet[idx] = new Piquet(v_abscise, v_ordonner, idx+1);
            }

            Prairie prairie1 = new Prairie(tabPiquet);
            double aire = prairie1.AirPrairie();
            double aireAbsolute = Math.Abs(aire);
            Console.WriteLine("L'air de la prairie est : {0}", aireAbsolute);
            double AbscisseCentreGravite = prairie1.CentreGraviteAbscise(aire);
            double OrdonnerCentreGravite = prairie1.CentreGraviteOrdonner(aire);
            Console.WriteLine("Le centre de gravité : {0}, {1}", AbscisseCentreGravite, OrdonnerCentreGravite);
            prairie1.CoordonneVecteur(aire);
            double angle = prairie1.SommeAngles();

            if (angle == 0)
            {
                Console.WriteLine("oh !!!!!! La vache n'est pas dans l'enclos ");
            }
            else
            {
                Console.WriteLine("Ouf !!! La vache est bien dans l'enclos");
            }

           
           

        }
    }
}
