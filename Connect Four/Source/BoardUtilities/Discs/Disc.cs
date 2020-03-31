using Connect_Four.Source.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Connect_Four.Source.BoardUtilities.Discs
{
    public class Disc
    {
        private bool _isEmpty = true;
        public bool IsEmpty => _isEmpty;

        private Player _holder = null;
        public Player Holder => _holder;

        private Ellipse _guiDisc;
        public Ellipse GuiDisc => _guiDisc;

        private bool _isClickable = false;

        private PlayerController _players;
        private DiscGrid _grid;

        private int _column;

        public Disc(int column, Ellipse guiDisc, PlayerController players, DiscGrid grid)
        {
            _column = column;
            _guiDisc = guiDisc;
            _grid = grid;
            SetDefaultGuiColour();
            guiDisc.MouseUp += MouseClick;
            _players = players;
        }

        public void Select(Player holder)
        {
            _holder = holder;
            _isEmpty = false;
            _grid.DropAnimationAsync(this, _column, holder);
        }

        public void SetClickable(Color borderColour)
        {
            _guiDisc.Stroke = new SolidColorBrush(borderColour);
            _guiDisc.StrokeThickness = 5;
            _isClickable = true;
        }

        public void SetNotClickable()
        {
            _guiDisc.Stroke = null;
            _isClickable = false;
        }

        public async void TempColourChange(Color colour, int milliseconds)
        {
            SetGuiColour(colour);
            await Task.Delay(milliseconds);
            SetDefaultGuiColour();
        }

        private void SetDefaultGuiColour() => SetGuiColour(Colors.SlateGray);

        public void SetGuiColour(Color colour) => _guiDisc.Fill = new SolidColorBrush(colour);

        private void MouseClick(object sender, MouseButtonEventArgs e)
        {
            if (_isClickable && _players.CurrentPlayer.IsHuman)
            {
                Select(_players.CurrentPlayer);
                ((HumanPlayer)_players.CurrentPlayer).SetSelectedDisc(this);
            }
        }
    }
}
