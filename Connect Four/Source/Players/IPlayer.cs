using Connect_Four.Source.BoardUtilities.Discs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Connect_Four.Source.Players
{
    public interface IPlayer
    {
        string Name { get; }
        Color Colour { get; }
        bool IsHuman { get; }
        GameController GameController { set; }

        void SelectDisc(Disc[] discs);

        void SetSelectedDisc(Disc disc);
    }
}
