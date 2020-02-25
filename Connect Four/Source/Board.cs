using Connect_Four.Source.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_Four.Source
{
    public class Board
    {
        private IPlayer _player1;
        private IPlayer _player2;
        private IPlayer _currentPlayer = null;
        public IPlayer CurrentPlayer => _currentPlayer;

        public Board(IPlayer player1, IPlayer player2)
        {
            _player1 = player1;
            _player2 = player2;
            UpdateCurrentPlayer(_player1);
        }

        private void UpdateCurrentPlayer(IPlayer player)
        {
            if (_currentPlayer == player)
                throw new NotImplementedException();

            _currentPlayer = player;
        }

        private void AlertPlayers()
        {
            _player1.Update();
            _player2.Update();
        }

        public void Start()
        {
            AlertPlayers();
        }
    }
}
