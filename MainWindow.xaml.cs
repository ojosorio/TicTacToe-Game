using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Test2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _playerOne = true;
        private Board _board;

        public MainWindow()
        {
            InitializeComponent();
            Init();
            _board = new Board();
            icBoard.ItemsSource = _board.Cells;
        }

        private void Init()
        {
            lblDraw.Visibility = lblSign.Visibility = lblWinner.Visibility = Visibility.Hidden;
            brPlayerOneColor.Visibility = Visibility.Visible;
            brPlayerOne.Visibility = Visibility.Hidden;
            brPlayerTwoColor.Visibility = Visibility.Hidden;
            brPlayerTwo.Visibility = Visibility.Visible;
            icBoard.Visibility = Visibility.Visible;
        }

        private void CellClick(object sender, RoutedEventArgs e)
        {
            BoardCell cell = (sender as Button).DataContext as BoardCell;
            cell.Sign = _playerOne ? "X" : "O";
            ChangePlayer();
            bool gameHasAWinner = GameHasAWinner(cell.Sign);
            lblSign.Visibility = lblWinner.Visibility = lblDraw.Visibility = Visibility.Hidden;

            if (gameHasAWinner)
            {
                icBoard.Visibility = Visibility.Hidden;
                lblSign.Content = cell.Sign;
                lblSign.Visibility = lblWinner.Visibility = Visibility.Visible;
            }

            if (!gameHasAWinner && IsBoardComplete())
            {
                icBoard.Visibility = Visibility.Hidden;
                lblDraw.Visibility = Visibility.Visible;
            }
        }

        private void ChangePlayer()
        {
            _playerOne = !_playerOne;
            if (_playerOne)
            {
                brPlayerOneColor.Visibility = Visibility.Visible;
                brPlayerOne.Visibility = Visibility.Hidden;
                brPlayerTwoColor.Visibility = Visibility.Hidden;
                brPlayerTwo.Visibility = Visibility.Visible;
            }
            else
            {
                brPlayerTwoColor.Visibility = Visibility.Visible;
                brPlayerTwo.Visibility = Visibility.Hidden;
                brPlayerOneColor.Visibility = Visibility.Hidden;
                brPlayerOne.Visibility = Visibility.Visible;
            }
        }

        public bool IsBoardComplete()
        {
            return !_board.Cells.Any(a => string.IsNullOrEmpty(a.Sign));
        }

        public bool GameHasAWinner(string sign)
        {

            if (_board.Cells.Count(w => (w.CellNumber == 1 || w.CellNumber == 2 || w.CellNumber == 3) && (w.Sign == sign)) == 3 ||
                _board.Cells.Count(w => (w.CellNumber == 4 || w.CellNumber == 5 || w.CellNumber == 6) && (w.Sign == sign)) == 3 ||
                _board.Cells.Count(w => (w.CellNumber == 7 || w.CellNumber == 8 || w.CellNumber == 9) && (w.Sign == sign)) == 3)
            {
                return true;
            }

            if (_board.Cells.Count(w => (w.CellNumber == 1 || w.CellNumber == 4 || w.CellNumber == 7) && (w.Sign == sign)) == 3 ||
               _board.Cells.Count(w => (w.CellNumber == 2 || w.CellNumber == 5 || w.CellNumber == 8) && (w.Sign == sign)) == 3 ||
               _board.Cells.Count(w => (w.CellNumber == 3 || w.CellNumber == 6 || w.CellNumber == 9) && (w.Sign == sign)) == 3)
            {
                return true;
            }

            if (_board.Cells.Count(w => (w.CellNumber == 1 || w.CellNumber == 5 || w.CellNumber == 9) && (w.Sign == sign)) == 3 ||
               _board.Cells.Count(w => (w.CellNumber == 3 || w.CellNumber == 5 || w.CellNumber == 7) && (w.Sign == sign)) == 3)
            {
                return true;
            }

            return false;
        }

        private void btnRestartGame_Click(object sender, RoutedEventArgs e)
        {
            _board.Reset();
            _playerOne = true;
            Init();
        }
    }
}
