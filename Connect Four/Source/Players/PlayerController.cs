using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_Four.Source.Players
{
    public class PlayerController
    {
        private IPlayer _player1;
        private IPlayer _player2;
        private IPlayer _currentPlayer;
        public IPlayer CurrentPlayer => _currentPlayer;

        public PlayerController(IPlayer player1, IPlayer player2, GameController gameController)
        {
            _player1 = player1;
            _player2 = player2;
            SetPlayerGameControllers(gameController);
            UpdateCurrentPlayer(_player1);
        }

        private void UpdateCurrentPlayer(IPlayer player)
        {
            if (CurrentPlayer == player)
                throw new NotImplementedException();

            _currentPlayer = player;
        }

        public void SwitchCurrentPlayer()
        {
            if (CurrentPlayer == _player1)
                UpdateCurrentPlayer(_player2);
            else
                UpdateCurrentPlayer(_player1);
        }

        private void SetPlayerGameControllers(GameController gameController)
        {
            _player1.GameController = gameController;
            _player2.GameController = gameController;
        }
    }
}
