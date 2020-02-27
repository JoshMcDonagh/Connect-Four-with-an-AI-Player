using Connect_Four.Source.BoardUtilities.Discs;
using Connect_Four.Source.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Connect_Four.Source
{
    public class GridController
    {
        private const int _columns = 7;
        private const int _rows = 6;

        private DiscGrid _discs;

        public void SetGUIBoard(Grid guiGrid, PlayerController players) => _discs = new DiscGrid(_columns, _rows, guiGrid, players);

        public Disc[] GetAvailableDisks() => _discs.GetAvailable();
    }
}
