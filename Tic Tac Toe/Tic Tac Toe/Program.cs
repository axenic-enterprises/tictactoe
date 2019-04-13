using System;
using Tic_Tac_Toe.GameFramework;
using Tic_Tac_Toe.Players;

namespace Tic_Tac_Toe
{
    /*
     * Enthält den Einstiegspunkt des Programms.
     */
    class Program
    {
        /*
         * Übernimmt die Interaktion mit dem Benutzer und startet einzelne Partien.
         * Fragt nach jeder Partie, ob noch einmal gespielt werden soll oder nicht.
         * Einzelne Partien werden an das GameFramework delegiert.
         */
        static void Main(string[] args)
        {
            Console.WriteLine("###############################################################");
            Console.WriteLine("#                         Tic Tac Toe                         #");
            Console.WriteLine("###############################################################");
            Console.WriteLine();
            Console.WriteLine("Herzlich Willkommen bei Tic Tac Toe!");

            Game game = new Game(3);
			game.SetPlayer(new LocalPlayer(game), new LocalPlayer(game));

            do
            {
                game.PlayMatch();
            }
            while (WantsToPlayAgain());

            Console.WriteLine("Tschüss, bis zum nächsten Mal!");
            Console.ReadKey(true);
        }

        /*
         * Fragt den Benutzer, ob eine weitere Runde gestartet werden soll.
         * Liefert true, wenn eine weitere Runde gespielt werden möchte, sonst false.
         */
        static bool WantsToPlayAgain()
        {
            Console.Write("Weitere Runde spielen? (j/n): ");
            return Console.ReadLine().Equals("j", StringComparison.OrdinalIgnoreCase);
        }
    }
}
