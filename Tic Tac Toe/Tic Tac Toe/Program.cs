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
         * Fragt nach jeder Partei, ob noch einmal gespielt werden soll oder nicht.
         * Einzelne Partien werden an das GameFramework delegiert.
         */
        static void Main(string[] args)
        {
            Console.WriteLine("###############################################################");
            Console.WriteLine("#                         Tic Tac Toe                         #");
            Console.WriteLine("###############################################################");
            Console.WriteLine();
            Console.WriteLine("Herzlich Willkommen bei Tic Tac Toe!");
            Console.WriteLine("Starte das Spiel gegen den Computergegner...");

            Game game = new Game();
        }
    }
}
