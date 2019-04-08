using System;
using System.Collections.Generic;
using System.Text;
using Tic_Tac_Toe.GameFramework;

namespace Tic_Tac_Toe.Players
{
	/*
	 * Computer-gesteuerter-Spieler
	 */
	class ComputerPlayer : IPlayer
	{
		// Beziehungsobjekt zum Hauptspiel
		private Game game;

		/*
		 * Konstruktor um eine Beziehung zwischen Spieler und Spiel zu erstellen und um zwischen Spieler 1 und 2 zu unterscheiden
		 */
		public ComputerPlayer(Game game)
		{
			this.game = game;
		}

		/*
		 * Gibt neue errechnete Position zurück
		 */
		public (int, int) GetNewPosition()
		{
			throw new NotImplementedException();
		}

	}

}
