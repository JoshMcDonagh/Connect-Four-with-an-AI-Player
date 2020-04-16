using Connect_Four.Source.BoardUtilities.Discs;
using Connect_Four.Source.EndGameStates;
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
        private int _columns;
        private int _rows;
        private int _winningScore;

        private DiscGrid _discs;

        public GridController(int columns, int rows, int winningScore)
        {
            _columns = columns;
            _rows = rows;
            _winningScore = winningScore;
        }
        
        public void SetGUIBoard(Grid guiGrid, PlayerController players) => _discs = new DiscGrid(_columns, _rows, guiGrid, players);

        public Disc[] GetAvailableDisks() => _discs.GetAvailable();

        public IEndGameState HasGameEnded(Player player1, Player player2)
        {
            if (GetAvailableDisks().Length == 0)
                return new TieEndGameState();

            else if (HasPlayerWon(player1))
                return new WonEndGameState(player1, player2);

            else if (HasPlayerWon(player2))
                return new WonEndGameState(player2, player1);

            return null;
        }

        public int HorizontalCount(Player player)
        {
            int total = 0;
            
            for (int i = _rows - 1; i >= 0; i--)
            {
                int count = 0;

                for (int j = 0; j < _columns; j++)
                {
                    Disc disc = _discs.Get(j, i);

                    if (disc.Holder == player)
                        count++;
                    else
                        break;
                }

                total = Math.Max(total, count);
            }

            return total;
        }

        public int VerticalCount(Player player)
        {
            int total = 0;
            
            for (int i = 0; i < _columns; i++)
            {
                int count = 0;

                for (int j = _rows - 1; j >= 0; j--)
                {
                    Disc disc = _discs.Get(i, j);

                    if (disc.Holder == player)
                        count++;
                    else
                        break;
                }

                total = Math.Max(total, count);
            }

            return total;
        }

        public int DiagonalCount(Player player)
        {
            int total = 0;
            
            for (int i = _rows - 1; i >= 0; i--)
            {
                for (int j = 0; j < _columns; j++)
                {
                    Disc disc = _discs.Get(j, i);

                    if (disc.Holder == player)
                        total = Math.Max(total, CountUpRight(player, j, i) + CountUpLeft(player, j, i));
                }
            }

            return total;
        }

        private int CountUpRight(Player player, int column, int row)
        {
            int count = 0;
            int i = row;
            int j = column;

            while (i >= 0 && j < _columns)
            {
                Disc disc = _discs.Get(j, i);

                if (disc.Holder == player)
                    count++;
                else
                    return count;

                i--;
                j++;
            }

            return count;
        }
        
        private int CountUpLeft(Player player, int column, int row)
        {
            int count = 0;
            int i = row;
            int j = column;

            while (i >= 0 && j >= 0)
            {
                Disc disc = _discs.Get(j, i);

                if (disc.Holder == player)
                    count++;
                else
                    return count;

                i--;
                j--;
            }

            return count;
        }

        private bool HasPlayerWon(Player player) => CheckHorizontal(player) || CheckVertical(player) || CheckDiagonal(player);

        private bool CheckDiagonal(Player player)
        {
            for (int i = _rows - 1; i >= 0; i--)
            {
                for (int j = 0; j < _columns; j++)
                {
                    Disc disc = _discs.Get(j, i);

                    if (disc.Holder == player && CheckDiagonalRun(player, j, i))
                        return true;
                }
            }

            return false;
        }

        private bool CheckDiagonalRun(Player player, int column, int row)
        {
            return RunUpLeft(player, column, row) || RunUpRight(player, column, row);
        }

        private bool RunUpRight(Player player, int column, int row)
        {
            int count = 0;
            int i = row;
            int j = column;

            while (i >= 0 && j < _columns)
            {
                Disc disc = _discs.Get(j, i);

                if (disc.Holder == player)
                {
                    count++;
                    if (count == _winningScore)
                        return true;
                }
                else
                    return false;

                i--;
                j++;
            }

            return false;
        }

        private bool RunUpLeft(Player player, int column, int row)
        {
            int count = 0;
            int i = row;
            int j = column;

            while (i >= 0 && j >= 0)
            {
                Disc disc = _discs.Get(j, i);

                if (disc.Holder == player)
                {
                    count++;
                    if (count == _winningScore)
                        return true;
                }
                else
                    return false;

                i--;
                j--;
            }

            return false;
        }
        
        private bool CheckHorizontal(Player player)
        {
            for (int i = _rows - 1; i >= 0; i--)
            {
                int count = 0;

                for (int j = 0; j < _columns; j++)
                {
                    Disc disc = _discs.Get(j, i);

                    if (disc.Holder == player)
                    {
                        count++;
                        if (count == _winningScore)
                            return true;
                    }
                    else
                        count = 0;
                }
            }

            return false;
        }

        private bool CheckVertical(Player player)
        {
            for (int i = 0; i < _columns; i++)
            {
                int count = 0;

                for (int j = _rows - 1; j >=0; j--)
                {
                    Disc disc = _discs.Get(i, j);

                    if (disc.Holder == player)
                    {
                        count++;
                        if (count == _winningScore)
                            return true;
                    }
                    else
                        count = 0;
                }
            }

            return false;
        }
    }
}
