using Connect_Four.Source.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Connect_Four.Source
{
    class GameController
    {
        private IPlayer _player1;
        private IPlayer _player2;
        private Board _board;

        public void SetPlayers(IPlayer player1, IPlayer player2)
        {
            _player1 = player1;
            _player2 = player2;
        }

        public void InitialiseBoard() => _board = new Board(_player1, _player2);

        public void SetGUIGrid(Grid guiGrid) => _board.SetGUIBoard(guiGrid);

        public void Initialise(IPlayer player1, IPlayer player2, Grid guiGrid)
        {
            SetPlayers(player1, player2);
            InitialiseBoard();
            SetGUIGrid(guiGrid);
        }

        public void EnableUserInput()
        {
            _board.MakeDiscsClickable();
        }

        public void DisableUserInput()
        {
            _board.MakeDiscsNotClickable();
        }
    }
}
