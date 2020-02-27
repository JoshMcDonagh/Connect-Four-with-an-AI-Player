using Connect_Four.Source.BoardUtilities.Discs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Connect_Four.Source.Players
{
    public class HumanPlayer : IPlayer
    {
        private string _name;
        public string Name => _name;

        private Color _colour;
        public Color Colour => _colour;

        public bool IsHuman => true;

        private Disc _selectedDisc = null;
        private Mutex _mutex = new Mutex();

        public HumanPlayer(string name, Color colour)
        {
            _name = name;
            _colour = colour;
        }

        public void SetSelectedDisc(Disc disc)
        {
            _selectedDisc = disc;
            _mutex.ReleaseMutex();
        }

        public Disc SelectDisc(Disc[] discs)
        {
            MakeDiscsClickable(discs);
            Disc selectedDisc = WaitUntilDiscClicked();
            MakeDiscsNotClickable(discs);
            ResetSelectedDisc();

            return selectedDisc;
        } 
        
        private void MakeDiscsClickable(Disc[] discs)
        {
            _mutex.WaitOne();
            foreach (Disc disc in discs)
                disc.SetClickable(_colour);
        }

        private void MakeDiscsNotClickable(Disc[] discs)
        {
            foreach (Disc disc in discs)
                disc.SetNotClickable();
        }

        private Disc WaitUntilDiscClicked()
        {
            _mutex.WaitOne();
            while (_selectedDisc == null) ;
            return _selectedDisc;
        }

        private void ResetSelectedDisc() => _selectedDisc = null;
    }
}
