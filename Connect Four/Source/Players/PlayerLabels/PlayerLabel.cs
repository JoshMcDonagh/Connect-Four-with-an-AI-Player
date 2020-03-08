using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Connect_Four.Source.Players.PlayerLabels
{
    public class PlayerLabel
    {
        private Label _label;
        private Color _activeColour;
        private Color _inactiveColour = Colors.Gray;

        public PlayerLabel(Label label, string text, Color colour)
        {
            _label = label;
            _label.Content = text;
            _activeColour = colour;
            SetAsInactive();
        }

        public void SetAsActive() => _label.Foreground = new SolidColorBrush(_activeColour);

        public void SetAsInactive() => _label.Foreground = new SolidColorBrush(_inactiveColour);
    }
}
