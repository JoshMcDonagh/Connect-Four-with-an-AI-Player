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
    public class HumanPlayer : IPlayer
    {
        private string _name;
        public string Name => _name;

        private Color _colour;
        public Color Colour => _colour;

        public bool IsHuman => true;

        private Disc[] _discCache;

        private PlayerLabel _label;

        private GameController _gameController;
        public GameController GameController
        {
            set => _gameController = value;
        }

        public HumanPlayer(string name, Color colour, Label label)
        {
            _name = name;
            _colour = colour;
            _label = new PlayerLabel(label, _name, _colour);
        }

        public void SetSelectedDisc(Disc disc)
        {
            MakeDiscsNotClickable(_discCache);
            _gameController.SubmitDisk(disc);
        }

        public void SelectDisc(Disc[] discs)
        {
            _discCache = discs;
            MakeDiscsClickable(discs);
        } 
        
        private void MakeDiscsClickable(Disc[] discs)
        {
            foreach (Disc disc in discs)
                disc.SetClickable(_colour);
        }

        private void MakeDiscsNotClickable(Disc[] discs)
        {
            foreach (Disc disc in discs)
                disc.SetNotClickable();
        }

        public void SetAsCurrent() => _label.SetAsActive();

        public void UnsetAsCurrent() => _label.SetAsInactive();
    }
}
