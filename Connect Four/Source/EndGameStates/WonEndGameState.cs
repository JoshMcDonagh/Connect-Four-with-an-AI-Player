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

        private IPlayer _winner;
        public IPlayer Winner => _winner;

        public WonEndGameState(IPlayer winner) => _winner = winner;
    }
}
