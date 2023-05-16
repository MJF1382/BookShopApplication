using BookShopApplication.Helpers.Extensions;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BookShopApplication.Views.UserControls
{
    public partial class PanelMenuButton : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string text;
        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                OnPropertyChanged();
            }
        }

        private string iconSource;
        public string IconSource
        {
            get { return iconSource; }
            set
            {
                iconSource = value;
                OnPropertyChanged();
            }
        }

        private string contentColor;
        public string ContentColor
        {
            get { return contentColor; }
            set
            {
                contentColor = value;
                OnPropertyChanged();
            }
        }

        private double contentSize;
        public double ContentSize
        {
            get { return contentSize; }
            set
            {
                contentSize = value;
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

                buttonBackground = value;
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

        public PanelMenuButton()
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
