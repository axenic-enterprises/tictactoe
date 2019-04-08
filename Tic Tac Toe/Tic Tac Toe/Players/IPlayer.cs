using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe.Players
{
	/*
	 * Interface um die Kompatibilität von KI und echtem Spieler sicher zu stellen
	 */
    interface IPlayer
	{
		/*
		 * Gibt Position des neues Feldes an
		 */
		(int, int) GetNewPosition();



	}

}
