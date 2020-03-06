using Connect_Four.Source.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Connect_Four.Source.BoardUtilities.Discs
{
    public class DiscGrid
    {
        private int _columns;
        private int _rows;

        private Disc[][] _discs;

        public DiscGrid(int columns, int rows, Grid guiGrid, PlayerController players)
        {
            _columns = columns;
            _rows = rows;
            
            _discs = new Disc[_rows][];
            for (int i = 0; i < _discs.Length; i++) _discs[i] = new Disc[_columns];

            InitialiseGuiGrid(guiGrid);
            MakeDiscs(guiGrid, players);
        }

        public Disc Get(int column, int row) => _discs[row][column];

        public Disc[] GetAvailable()
        {
            List<Disc> available = new List<Disc>();

            for (int i = 0; i < _columns; i++)
            {
                for (int j = 0; j < _rows; j++)
                {
                    if (!Get(i, j).IsEmpty)
                    {
                        available.Add(Get(i, j - 1));
                        break;
                    }
                    else if (j == _rows - 1)
                    {
                        available.Add(Get(i, j));
                    }
                }
            }

            return available.ToArray();
        }

        public async void DropAnimationAsync(Disc callingDisc, int column, IPlayer holder)
        {
            int milliseconds = 50;

            for (int i = 0; i < _rows; i++)
            {
                Disc disc = Get(column, i);
                await Task.Delay(milliseconds);
                if (disc.IsEmpty)
                    disc.TempColourChange(holder.Colour, milliseconds);
                else
                    break;
            }

            callingDisc.SetGuiColour(holder.Colour);
        }

        private void InitialiseGuiGrid(Grid guiGrid)
        {
            for (int i = 0; i < _columns; i++)
                guiGrid.ColumnDefinitions.Add(new ColumnDefinition());

            for (int i = 0; i < _rows; i++)
                guiGrid.RowDefinitions.Add(new RowDefinition());
        }

        private void MakeDiscs(Grid guiGrid, PlayerController players)
        {
            Ellipse[][] discs = MakeGuiDiscs(guiGrid);
            MakeDiscData(discs, players);
        }

        private Ellipse MakeGuiEllipse(int column, int row, Grid guiGrid)
        {
            double diameter = (Math.Min(guiGrid.Height, guiGrid.Width) / Math.Min(_columns, _rows)) - 15;
            Ellipse disc = MakeEllipse(diameter);
            AddToGuiGrid(column, row, disc, guiGrid);
            return disc;
        }

        private Ellipse MakeEllipse(double diameter)
        {
            Ellipse disc = new Ellipse();
            disc.Width = diameter;
            disc.Height = diameter;
            
            return disc;
        }

        private void AddToGuiGrid(int column, int row, Ellipse disc, Grid guiGrid)
        {
            Grid.SetRow(disc, row);
            Grid.SetColumn(disc, column);
            guiGrid.Children.Add(disc);
        }

        private Ellipse[][] MakeGuiDiscs(Grid guiGrid)
        {
            Ellipse[][] discs = new Ellipse[_rows][];

            for (int i = 0; i < _rows; i++)
            {
                discs[i] = new Ellipse[_columns];
                for (int j = 0; j < _columns; j++)
                    discs[i][j] = MakeGuiEllipse(j, i, guiGrid);
            }

            return discs;
        }

        private void MakeDiscData(Ellipse[][] guiDiscs, PlayerController players)
        {
            for (int i = 0; i < _rows; i++)
                for (int j = 0; j < _columns; j++) _discs[i][j] = new Disc(j, guiDiscs[i][j], players, this);
        }
    }
}
