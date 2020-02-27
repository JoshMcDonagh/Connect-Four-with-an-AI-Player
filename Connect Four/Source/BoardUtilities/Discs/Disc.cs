using Connect_Four.Source.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        private IPlayer _holder = null;
        public IPlayer Holder => _holder;

        private Ellipse _guiDisc;
        public Ellipse GuiDisc => _guiDisc;

        private bool _isClickable = false;

        private Board _board;

        public Disc(Ellipse guiDisc, Board board)
        {
            _guiDisc = guiDisc;
            SetGuiColour(Colors.SlateGray);
            guiDisc.MouseUp += MouseClick;
            _board = board;
        }

        public void Select(IPlayer holder)
        {
            _holder = holder;
            _isEmpty = false;
            SetGuiColour(_holder.Colour);
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

        private void SetGuiColour(Color colour) => _guiDisc.Fill = new SolidColorBrush(colour);

        private void MouseClick(object sender, MouseButtonEventArgs e)
        {
            if (_isClickable)
            {
                Select(_board.CurrentPlayer);
                _board.DiscSelected(this);
            }
        }
    }
}
