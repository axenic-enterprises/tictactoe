using System;
using System.Collections.Generic;
using System.Text;
using Tic_Tac_Toe.Players;

namespace Tic_Tac_Toe.GameFramework
{
    /*
     * Regelt die Interaktion mit den Spielern innerhalb einer Partie.
     */
    class Game
    {
		// Spielbrett
		public PlayerType[,] playboard;

		// Die beiden Spieler
		public IPlayer player1;
		public IPlayer player2;


		/*
		 * Konstuktor um das Spielfeld zu erstellen
		 */
		public Game(int size)
        {
			this.playboard = new PlayerType[size, size];
        }

		/*
		 * Methode um die Spieler zu setzten
		 */
		public void SetPlayer(IPlayer player1, IPlayer player2)
		{
			this.player1 = player1;
			this.player2 = player2;
		}

		/*
		 * Methode um zu überprüfen, ob die Spieler bereits gesetzt wurden! Falls sie nicht gesetzt wurden werden sie durch LocalPlayer aufgefüllt
		 */
		private void CheckIfPlayerAreSet()
		{

			if (this.player1 == null)
			{
				this.player1 = new LocalPlayer(this);
			}

			if (this.player2 == null)
			{
				this.player2 = new LocalPlayer(this);
			}

		}

        /*
         * Startet eine einzelne Runde des Spiels und gibt zurück, wenn diese beendet ist.
         */
        public void PlayMatch()
        {
			// Überprüft, ob Spieler gesetzt wurden
			CheckIfPlayerAreSet();

            Console.WriteLine("RUNDE BEGINNT...");
            //Runde spielen
            Console.WriteLine("RUNDE ABGESCHLOSSEN");
            //Ergebnis ausgeben
        }
    }

	/*
	 * Repräsentiert den Status des Spieles
	 */
	enum GameState
	{
		Player1Won, Player2Won, Draw, Running
	}

	/*
	 * Unterscheidet die beiden Spieler und leere Felder von einander
	 */
	enum PlayerType
	{
		Player1, Player2, None
	}

}
