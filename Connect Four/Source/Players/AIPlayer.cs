using Connect_Four.Source.BoardUtilities.Discs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Connect_Four.Source.Players
{
    class AIPlayer : Player
    {
        public override bool IsHuman => false;

        private Random _random = new Random();
        private GridController _gridController;

        public AIPlayer(string name, Color colour, Label label) : base(name, colour, label)
        {
        }

        public override void SelectDisc(Disc[] discs)
        {
            List<Disc> optimalDiscs = new List<Disc>();
            int highestVal;

            // Test Horizontal
            List<Disc> horizontalDiscs = new List<Disc>();
            highestVal = 0;
            for (int i = 0; i < discs.Length; i++)
            {
                Disc disc = discs[i];
                disc.StartTest(this);

                int count = _gridController.HorizontalCount(this);

                if (count > highestVal)
                {
                    highestVal = count;
                    horizontalDiscs = new List<Disc>();
                    horizontalDiscs.Add(disc);
                }
                else if (count == highestVal)
                {
                    horizontalDiscs.Add(disc);
                }

                disc.EndTest();
            }
            optimalDiscs.AddRange(horizontalDiscs);

            // Test Vertical
            List<Disc> verticalDiscs = new List<Disc>();
            highestVal = 0;
            for (int i = 0; i < discs.Length; i++)
            {
                Disc disc = discs[i];
                disc.StartTest(this);

                int count = _gridController.VerticalCount(this);

                if (count > highestVal)
                {
                    highestVal = count;
                    verticalDiscs = new List<Disc>();
                    verticalDiscs.Add(disc);
                }
                else if (count == highestVal)
                {
                    verticalDiscs.Add(disc);
                }

                disc.EndTest();
            }
            optimalDiscs.AddRange(verticalDiscs);

            // Test Diagonal
            List<Disc> diagonalDiscs = new List<Disc>();
            highestVal = 0;
            for (int i = 0; i < discs.Length; i++)
            {
                Disc disc = discs[i];
                disc.StartTest(this);

                int count = _gridController.DiagonalCount(this);

                if (count > highestVal)
                {
                    highestVal = count;
                    diagonalDiscs = new List<Disc>();
                    diagonalDiscs.Add(disc);
                }
                else if (count == highestVal)
                {
                    diagonalDiscs.Add(disc);
                }

                disc.EndTest();
            }
            optimalDiscs.AddRange(diagonalDiscs);

            Disc selected = optimalDiscs[_random.Next(optimalDiscs.Count)];
            selected.Select(this);
            GameController.SubmitDisk(selected);
        }

        public void SetGridController(GridController gridController) => _gridController = gridController;

        public override void SetAsCurrent() => Label.SetAsActive();

        public override void UnsetAsCurrent() => Label.SetAsInactive();
    }
}
