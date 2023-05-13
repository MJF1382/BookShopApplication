using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BookShopApplication.Helpers.Extensions;

namespace BookShopApplication.Views.UserControls
{
    public partial class IconButton : UserControl
    {
        private string source;
        public string Source
        {
            get { return source; }
            set
            {
                source = value;
                imgIcon.Source = new BitmapImage(new System.Uri(source, System.UriKind.Relative));
            }
        }

        private double iconWidth;
        public double IconWidth
        {
            get { return iconWidth; }
            set
            {
                iconWidth = value;
                imgIcon.Width = iconWidth;
            }
        }

        private double iconHeight;
        public double IconHeight
        {
            get { return iconHeight; }
            set
            {
                iconHeight = value;
                imgIcon.Height = iconHeight;
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

                btnIcon.Background = new BrushConverter().ConvertFrom(buttonBackground) as Brush;
            }
        }

        private double buttonWidth;
        public double ButtonWidth
        {
            get { return buttonWidth; }
            set
            {
                buttonWidth = value;
                btnIcon.Width = buttonWidth;
            }
        }

        private double buttonHeight;
        public double ButtonHeight
        {
            get { return buttonHeight; }
            set
            {
                buttonHeight = value;
                btnIcon.Height = buttonHeight;
            }
        }

        public IconButton()
        {
            InitializeComponent();
        }
    }
}
