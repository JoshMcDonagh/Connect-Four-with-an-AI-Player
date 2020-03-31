using Connect_Four.Source.BoardUtilities.Discs;
using Connect_Four.Source.Players.PlayerLabels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Connect_Four.Source.Players
{
    public abstract class Player
    {
        private string _name;
        public string Name => _name;

        private Color _colour;
        public Color Colour => _colour;

        private PlayerLabel _label;
        public PlayerLabel Label => _label;

        private GameController _gameController;
        public GameController GameController
        {
            set => _gameController = value;
            get => _gameController;
        }

        public abstract bool IsHuman { get; }
        

        public Player(string name, Color colour, Label label)
        {
            _name = name;
            _colour = colour;
            _label = new PlayerLabel(label, _name, _colour);
        }

        public abstract void SelectDisc(Disc[] discs);

        public abstract void SetAsCurrent();

        public abstract void UnsetAsCurrent();
    }
}
