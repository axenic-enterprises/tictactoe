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
				this.player1 = new LocalPlayer(this, PlayerType.Player1);
			}

			if (this.player2 == null)
			{
				this.player2 = new LocalPlayer(this, PlayerType.Player2);
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
			Console.WriteLine(GivePlayerWon(playboard));
			while (GiveGameState(this.playboard) == GameState.Running)
			{
				PlayerType nextPlayer = GiveNextPlayer(playboard);
				IPlayer player = (nextPlayer == PlayerType.Player1 ? player1 : player2);
				(int, int) position = player.GetNewPosition();
				playboard[position.Item1, position.Item2] = nextPlayer;
			}

            Console.WriteLine("RUNDE ABGESCHLOSSEN");
			//Ergebnis ausgeben
			Console.WriteLine("Das Ergebnis des Spieles ist: " + GiveGameState(playboard));
        }

		/*
		 * Gibt zurück, welcher Spieler als nächstes am Zug ist
		 */
		public static PlayerType GiveNextPlayer(PlayerType[,] playboard)
		{
			int counter1 = 0, counter2 = 0;
			int size = Convert.ToInt32(Math.Sqrt(playboard.Length));

			for (int x = 0; x < size; x++)
			{

				for (int y = 0; y < size; y++)
				{
					PlayerType field = playboard[x, y];

					if (field == PlayerType.Player1)
					{
						counter1++;
					} 
					else if (field == PlayerType.Player2)
					{
						counter2++;
					}

				}

			}

			if (counter1 > counter2)
			{
				return PlayerType.Player2;
			} 
			else
			{
				return PlayerType.Player1;
			}

		}

		/*
		 * Gibt den Spielstatus einen mitgegebenen Spielfeldes zurück
		 */
		public static GameState GiveGameState(PlayerType[,] playboard)
		{
			PlayerType playerWon = GivePlayerWon(playboard);

			if (playerWon == PlayerType.Player1)
			{
				return GameState.Player1Won;
			}
			else if (playerWon == PlayerType.Player2)
			{
				return GameState.Player2Won;
			}

			int size = Convert.ToInt32(Math.Sqrt(playboard.Length));
			bool areThereFreeFields = false;

			for (int x = 0; x < size; x++)
			{

				for (int y = 0; y < size; y++)
				{
					PlayerType field = playboard[x, y];
					
					if (field == PlayerType.None)
					{
						areThereFreeFields = true;
					}

				}

			}

			if (areThereFreeFields)
			{
				return GameState.Running;
			} 
			else
			{
				return GameState.Draw;
			}

		}

		/*
		 * Testet, ob auf einem mitgegebenen Spielfeld ein Spieler gewonnen hat
		 */
		public static PlayerType GivePlayerWon(PlayerType[,] playboard)
		{
			int size = Convert.ToInt32(Math.Sqrt(playboard.Length));

			// Zeilen und Spalten überprüfen
			for (int cord1 = 0; cord1 < size; cord1++)
			{
				PlayerType check1 = PlayerType.Empty;
				PlayerType check2 = PlayerType.Empty;

				bool isWon1 = true;
				bool isWon2 = true;

				for (int cord2 = 0; cord2 < size; cord2++)
				{
					PlayerType field1 = playboard[cord1, cord2];
					PlayerType field2 = playboard[cord2, cord1];

					if (check1 == PlayerType.Empty && field1 != PlayerType.None)
					{
						check1 = field1;
					}
					else if (field1 == PlayerType.None || check1 != field1)
					{
						isWon1 = false;
					}

					if (check2 == PlayerType.Empty && field2 != PlayerType.None)
					{
						check2 = field2;
					}
					else if (field2 == PlayerType.None || check2 != field2)
					{
						isWon2 = false;
					}

				}

				if (isWon1)
				{
					return check1;
				}

				if (isWon2)
				{
					return check2;
				}

			}

			// Diagonalen überprüfen
			{
				bool isWon = true;
				PlayerType check = PlayerType.Empty;

				for (int cord = 0; cord < size; cord++)
				{
					PlayerType field = playboard[cord, cord];

					if (check == PlayerType.Empty && field != PlayerType.None)
					{
						check = field;
					}
					else if (field == PlayerType.None || check != field)
					{
						isWon = false;
					}

				}

				if (isWon)
				{
					return check;
				}

			}

			{
				bool isWon = true;
				PlayerType check = PlayerType.Empty;

				for (int cord = 0; cord < size; cord++)
				{
					PlayerType field = playboard[cord, size - 1 - cord];

					if (check == PlayerType.Empty && field != PlayerType.None)
					{
						check = field;
					}
					else if (field == PlayerType.None || check != field)
					{
						isWon = false;
					}

				}

				if (isWon)
				{
					return check;
				}

			}

			return PlayerType.None;
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
	 * None = Leeres Feld; Empty = Null
	 */
	enum PlayerType
	{
		Player1, Player2, None, Empty
	}

}
