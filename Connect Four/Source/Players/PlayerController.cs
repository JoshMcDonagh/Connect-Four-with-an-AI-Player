using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_Four.Source.Players
{
    public class PlayerController
    {
        private Player _player1;
        private Player _player2;
        private Player _currentPlayer;
        public Player Player1 => _player1;
        public Player Player2 => _player2;
        public Player CurrentPlayer => _currentPlayer;

        public PlayerController(Player player1, Player player2, GameController gameController)
        {
            _player1 = player1;
            _player2 = player2;
            SetPlayerGameControllers(gameController);
            UpdateCurrentPlayer(_player1);
        }

        private void UpdateCurrentPlayer(Player player)
        {
            if (CurrentPlayer == player)
                throw new NotImplementedException();

            _currentPlayer = player;
            _currentPlayer.SetAsCurrent();
        }

        public void SwitchCurrentPlayer()
        {
            _currentPlayer.UnsetAsCurrent();
            
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
