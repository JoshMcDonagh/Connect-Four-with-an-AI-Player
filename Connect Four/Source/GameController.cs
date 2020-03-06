using Connect_Four.Source.BoardUtilities.Discs;
using Connect_Four.Source.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Connect_Four.Source
{
    public class GameController
    {
        private PlayerController _players;
        private GridController _board;

        public void SetPlayers(IPlayer player1, IPlayer player2) => _players = new PlayerController(player1, player2, this);

        public void InitialiseBoard() => _board = new GridController();

        public void SetGUIGrid(Grid guiGrid) => _board.SetGUIBoard(guiGrid, _players);

        public void Initialise(IPlayer player1, IPlayer player2, Grid guiGrid)
        {
            SetPlayers(player1, player2);
            InitialiseBoard();
            SetGUIGrid(guiGrid);
        }

        public void Play()
        {
            _players.CurrentPlayer.SelectDisc(_board.GetAvailableDisks());
        }

        public void SubmitDisk(Disc disc)
        {
            _players.SwitchCurrentPlayer();
            Play();
        }
    }
}
