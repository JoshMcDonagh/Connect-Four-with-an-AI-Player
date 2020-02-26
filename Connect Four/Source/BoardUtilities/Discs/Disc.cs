using Connect_Four.Source.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Disc(Ellipse guiDisc)
        {
            _guiDisc = guiDisc;
            SetGuiColour(Colors.Black);
        }

        public void SetHolder(IPlayer holder)
        {
            _holder = holder;
            _isEmpty = false;
            SetGuiColour(_holder.Colour);
        }

        private void SetGuiColour(Color colour) => _guiDisc.Fill = new SolidColorBrush(colour);
    }
}
