using System.Windows.Controls;
using System.Windows.Media.Imaging;

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

        public IconButton()
        {
            InitializeComponent();
        }
    }
}
