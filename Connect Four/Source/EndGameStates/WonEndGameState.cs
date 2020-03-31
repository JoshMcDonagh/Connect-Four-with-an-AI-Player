using Connect_Four.Source.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_Four.Source.EndGameStates
{
    class WonEndGameState : IEndGameState
    {
        public bool IsTie => false;

        private Player _winner;
        public Player Winner => _winner;

        private Player _loser;
        public Player Loser => _loser;

        public WonEndGameState(Player winner, Player loser)
        {
            _winner = winner;
            _loser = loser;
        }
    }
}
