using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Connect_Four.Source.BoardUtilities.Discs
{
    public class DiscGrid
    {
        private int _columns;
        private int _rows;

        private Disc[][] _discs;

        public DiscGrid(int columns, int rows, Ellipse[][] guiDiscs)
        {
            _columns = columns;
            _rows = rows;
            
            _discs = new Disc[_rows][];
            for (int i = 0; i < _discs.Length; i++) _discs[i] = new Disc[_columns];

            MakeDiscs(guiDiscs);
        }

        public Disc Get(int column, int row) => _discs[row][column];

        private void MakeDiscs(Ellipse[][] guiDiscs)
        {
            for (int i = 0; i < _rows; i++)
                for (int j = 0; j < _columns; j++) _discs[i][j] = new Disc(guiDiscs[i][j]);
        }
    }
}
