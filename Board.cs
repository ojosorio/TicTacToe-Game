using System.Collections.ObjectModel;
using System.Linq;

namespace Test2
{
    public class Board
    {
        private ObservableCollection<BoardCell> _cells;
        public ObservableCollection<BoardCell> Cells
        {
            get
            {
                if (_cells == null)
                {
                    _cells = new ObservableCollection<BoardCell>(Enumerable.Range(0, 9).Select(i => new BoardCell(++i)));
                }

                return _cells;
            }
        }

        public void Reset()
        {
            foreach (BoardCell cell in Cells)
            {
                cell.Sign = string.Empty;
                cell.CanSelect = true;
            }
        }
    }
}
