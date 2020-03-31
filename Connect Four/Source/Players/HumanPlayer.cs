using Connect_Four.Source.BoardUtilities.Discs;
using Connect_Four.Source.Players.PlayerLabels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Connect_Four.Source.Players
{
    public class HumanPlayer : Player
    {
        public override bool IsHuman => true;

        private Disc[] _discCache;

        public HumanPlayer(string name, Color colour, Label label) : base (name, colour, label)
        {
        }

        public void SetSelectedDisc(Disc disc)
        {
            MakeDiscsNotClickable(_discCache);
            GameController.SubmitDisk(disc);
        }

        public override void SelectDisc(Disc[] discs)
        {
            _discCache = discs;
            MakeDiscsClickable(discs);
        } 
        
        private void MakeDiscsClickable(Disc[] discs)
        {
            foreach (Disc disc in discs)
                disc.SetClickable(Colour);
        }

        private void MakeDiscsNotClickable(Disc[] discs)
        {
            foreach (Disc disc in discs)
                disc.SetNotClickable();
        }

        public override void SetAsCurrent() => Label.SetAsActive();

        public override void UnsetAsCurrent() => Label.SetAsInactive();
    }
}
