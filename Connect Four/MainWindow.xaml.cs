using Connect_Four.Source;
using Connect_Four.Source.BoardUtilities.Discs;
using Connect_Four.Source.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Connect_Four
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }

        private void NewGame()
        {
            GameController gameController = new GameController();
            gameController.Initialise(new HumanPlayer("Player 1", Colors.Red, player1label), new HumanPlayer("Player 2", Colors.Yellow, player2label), guiGrid);
            gameController.Play();
        }
    }
}
