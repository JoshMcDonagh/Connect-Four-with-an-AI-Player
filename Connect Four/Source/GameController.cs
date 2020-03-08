using Connect_Four.Source.BoardUtilities.Discs;
using Connect_Four.Source.EndGameStates;
using Connect_Four.Source.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Connect_Four.Source
{
    public class GameController
    {
        private PlayerController _players;
        private GridController _grid;

        private const int _columns = 7;
        private const int _rows = 6;
        private const int _winningScore = 4;

        public void SetPlayers(IPlayer player1, IPlayer player2) => _players = new PlayerController(player1, player2, this);

        public void InitialiseBoard() => _grid = new GridController(_columns, _rows, _winningScore);

        public void SetGUIGrid(Grid guiGrid) => _grid.SetGUIBoard(guiGrid, _players);

        public void Initialise(IPlayer player1, IPlayer player2, Grid guiGrid)
        {
            SetPlayers(player1, player2);
            InitialiseBoard();
            SetGUIGrid(guiGrid);
        }

        public void Play()
        {
            IEndGameState endState = _grid.HasGameEnded(_players.Player1, _players.Player2);

            if (endState != null)
                ProcessEndState(endState);
            else
                _players.CurrentPlayer.SelectDisc(_grid.GetAvailableDisks());
        }

        public void SubmitDisk(Disc disc)
        {
            _players.SwitchCurrentPlayer();
            Play();
        }

        private void ProcessEndState(IEndGameState state)
        {
            if (state.IsTie)
            {
                MessageBox.Show("Tie!");
                return;
            }

            MessageBox.Show(((WonEndGameState)state).Winner.Name + " Won!");
        }
    }
}
