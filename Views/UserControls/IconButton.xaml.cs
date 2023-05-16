using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BookShopApplication.Helpers.Extensions;

namespace BookShopApplication.Views.UserControls
{
    public partial class IconButton : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string source;
        public string Source
        {
            get { return source; }
            set
            {
                source = value;
                OnPropertyChanged();
            }
        }

        private double iconWidth;
        public double IconWidth
        {
            get { return iconWidth; }
            set
            {
                iconWidth = value;
                OnPropertyChanged();
            }
        }

        private double iconHeight;
        public double IconHeight
        {
            get { return iconHeight; }
            set
            {
                iconHeight = value;
                OnPropertyChanged();
            }
        }

        private string buttonBackground;
        public string ButtonBackground
        {
            get { return buttonBackground; }
            set
            {
                if (value.HasValue())
                {
                    buttonBackground = value;
                }
                else
                {
                    buttonBackground = "#00FFFFFF";
                }

                OnPropertyChanged();
            }
        }

        private double buttonWidth;
        public double ButtonWidth
        {
            get { return buttonWidth; }
            set
            {
                buttonWidth = value;
                OnPropertyChanged();
            }
        }

        private double buttonHeight;
        public double ButtonHeight
        {
            get { return buttonHeight; }
            set
            {
                buttonHeight = value;
                OnPropertyChanged();
            }
        }

        public IconButton()
        {
            DataContext = this;
            InitializeComponent();
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
