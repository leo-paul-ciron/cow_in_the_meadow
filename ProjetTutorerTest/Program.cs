using System;
using System.Collections.Generic;

namespace ProjetTutorerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entrer le nombre de piquet ");
            string nb_piquet_string = Console.ReadLine();
            int nb_piquet = int.Parse(nb_piquet_string);
            Console.WriteLine("nombre de piquet {0}",nb_piquet);
            Piquet[] tabPiquet = new Piquet[nb_piquet];
            for (int idx = 0; idx < nb_piquet; idx++)
            {
                Console.WriteLine("entrer l'abscise du piquet {0}", idx + 1);
                double v_abscise = double.Parse(Console.ReadLine());
                Console.WriteLine("entrer l'ordonnée du piquet {0}", idx + 1);
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
            prairie1.CoordonneVecteur(aire);
            double angle = prairie1.angle();
            Console.WriteLine("angle = {0}",angle);
           
           

        }
    }
}
