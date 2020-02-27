using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public HumanPlayer(string name, Color colour)
        {
            _name = name;
            _colour = colour;
        }

        public void Update()
        {
            
        }
    }
}
