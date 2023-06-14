using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Test2
{
    public class BoardCell : INotifyPropertyChanged
    {
        private string _sign;
        private bool _canSelect = true;
        public int CellNumber { get; private set; }

        public BoardCell(int cellNumber) {
            CellNumber = cellNumber;
        }

        public string Sign
        {
            get { return _sign; }
            set
            {
                _sign = value;
                if (value != null)
                {
                    CanSelect = false;
                }
                OnPropertyChanged();
            }
        }

        public bool CanSelect
        {
            get { return _canSelect; }
            set
            {
                _canSelect = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
