using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ProjetTutorerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entrer le nombre de piquet (minimum 3)");
            string nb_piquet_string = Console.ReadLine();
            bool verif_caract = true;
            do
            {
                Console.WriteLine("Veuillez insérez un nombre supérieur à 3 !");
                nb_piquet_string = Console.ReadLine();
                if (Regex.IsMatch(nb_piquet_string, @"^[0-9]+$") && int.Parse(nb_piquet_string) >= 3)
                {
                    verif_caract = false;
                }
            }
            while (string.IsNullOrEmpty(nb_piquet_string) || verif_caract == true);
            int nb_piquet = int.Parse(nb_piquet_string);
            Console.WriteLine("nombre de piquet : {0}",nb_piquet);
            Piquet[] tabPiquet = new Piquet[nb_piquet];
            for (int idx = 0; idx < nb_piquet; idx++)
            {
                Console.WriteLine("entrer l'abscise du piquet : {0}", idx + 1);
                double v_abscise = double.Parse(Console.ReadLine());
                Console.WriteLine("entrer l'ordonnée du piquet : {0}", idx + 1);
                double v_ordonner = double.Parse(Console.ReadLine());

                tabPiquet[idx] = new Piquet(v_abscise, v_ordonner, idx+1);
            }

            Prairie prairie1 = new Prairie(tabPiquet);
            double aire = prairie1.AirPrairie();
            double aireAbsolute = Math.Abs(aire);
            Console.WriteLine("L'air de la prairie est : {0}", aireAbsolute);
            double AbscisseCentreGravite = prairie1.CentreGraviteAbscisse(aire);
            double OrdonnerCentreGravite = prairie1.CentreGraviteOrdonner(aire);
            Console.WriteLine("Le centre de gravité : {0}, {1}", AbscisseCentreGravite, OrdonnerCentreGravite);
        }
    }
}
