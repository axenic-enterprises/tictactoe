using System;
using System.Collections.Generic;
using System.Text;
using Tic_Tac_Toe.GameFramework;

namespace Tic_Tac_Toe.Players
{
	/*
	 * Echter Spieler
	 */
	class LocalPlayer : IPlayer
	{
		// Beziehungsobjekt zum Hauptspiel
		private Game game;

		/*
		 * Konstruktor um eine Beziehung zwischen Spieler und Spiel zu erstellen und um zwischen Spieler 1 und 2 zu unterscheiden 
		 */
		public LocalPlayer(Game game)
		{
			this.game = game;
		}

		/*
		 * Gibt neue eingegebene Position des Spielers zurück
		 */
		public (int, int) GetNewPosition()
		{
			// Spielfeld ausgeben, damit der Spieler seinen nächsten Zug entscheiden kann
			
			throw new NotImplementedException();
		}

		/*
		 * Schreibt einen 2D-int-Array in die Konsole
		 * Index verhält sich, wie in einem Koordinatensystem
		 */
		private void Write(int[,] playboard)
		{
			// "Kantengrößte des Quadrats"
			int size = Convert.ToInt32(Math.Sqrt(playboard.Length));

			// Felder in gewünschter Reihenfolge durchgehen und mit spezieller Formatierung ausgeben
			for (int x = size - 1; x < -1; x--)
			{
				string row = "[";

				for (int y = 0; y < size; y++)
				{
					row += playboard[x, y] + ", ";
				}

				row = row.Substring(0, row.Length - 2) + "]";
				Console.WriteLine(row);
			}

		}

	}

}
