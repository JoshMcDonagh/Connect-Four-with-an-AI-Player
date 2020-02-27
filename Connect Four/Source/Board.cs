using Connect_Four.Source.BoardUtilities.Discs;
using Connect_Four.Source.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Connect_Four.Source
{
    public class Board
    {
        private const int _columns = 7;
        private const int _rows = 6;
        
        private IPlayer _player1;
        private IPlayer _player2;
        private IPlayer _currentPlayer = null;
        public IPlayer CurrentPlayer => _currentPlayer;

        private DiscGrid _discs;

        public Board(IPlayer player1, IPlayer player2)
        {
            _player1 = player1;
            _player2 = player2;
            UpdateCurrentPlayer(_player1);
        }

        private void UpdateCurrentPlayer(IPlayer player)
        {
            if (CurrentPlayer == player)
                throw new NotImplementedException();

            _currentPlayer = player;
            CurrentPlayer.Update();
        }

        private void SwitchCurrentPlayer()
        {
            if (CurrentPlayer == _player1)
                UpdateCurrentPlayer(_player2);
            else
                UpdateCurrentPlayer(_player1);
        }

        public void SetGUIBoard(Grid guiGrid) => _discs = new DiscGrid(_columns, _rows, guiGrid, this);

        public void MakeDiscsClickable()
        {
            Disc[] discs = _discs.GetAvailable();

            foreach (Disc disc in discs)
                disc.SetClickable(_currentPlayer.Colour);
        }

        public void MakeDiscsNotClickable()
        {
            Disc[] discs = _discs.GetAvailable();

            foreach (Disc disc in discs)
                disc.SetNotClickable();
        }

        public void DiscSelected(Disc disc)
        {
            if (CurrentPlayer.IsHuman)
                MakeDiscsNotClickable();

            SwitchCurrentPlayer();
        }
    }
}
