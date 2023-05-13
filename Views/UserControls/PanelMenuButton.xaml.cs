using BookShopApplication.Helpers.Extensions;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BookShopApplication.Views.UserControls
{
    public partial class PanelMenuButton : UserControl
    {
        private string text;
        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                txbText.Text = text;
            }
        }

        private string iconSource;
        public string IconSource
        {
            get { return iconSource; }
            set
            {
                iconSource = value;
                imgIcon.Source = new BitmapImage(new System.Uri(iconSource, System.UriKind.Relative));
            }
        }

        private string contentColor;
        public string ContentColor
        {
            get { return contentColor; }
            set
            {
                contentColor = value;
                txbText.Foreground = new BrushConverter().ConvertFrom(contentColor) as Brush;
            }
        }

        private double contentSize;
        public double ContentSize
        {
            get { return contentSize; }
            set
            {
                contentSize = value;
                txbText.FontSize = contentSize;
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
                btn.Background = new BrushConverter().ConvertFrom(buttonBackground) as Brush; ;
            }
        }

        private double buttonWidth;
        public double ButtonWidth
        {
            get { return buttonWidth; }
            set
            {
                buttonWidth = value;
                btn.Width = buttonWidth;
                stackPanel.Width = buttonWidth;
            }
        }

        private double buttonHeight;
        public double ButtonHeight
        {
            get { return buttonHeight; }
            set
            {
                buttonHeight = value;
                btn.Height = buttonHeight;
                stackPanel.Height = buttonHeight;
            }
        }

        public PanelMenuButton()
        {
            InitializeComponent();
        }
    }
}
