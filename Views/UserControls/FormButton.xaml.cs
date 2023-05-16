using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace BookShopApplication.Views.UserControls
{
    public partial class FormButton : UserControl
    {
        private RoutedEventHandler onButtonClick;
        public RoutedEventHandler OnButtonClick
        {
            get { return onButtonClick; }
            set
            {
                onButtonClick = value;
                btn.Click += onButtonClick;
            }
        }

        private string text;
        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                btn.Content = text;
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
            }
        }

        private string buttonBackground;
        public string ButtonBackground
        {
            get { return buttonBackground; }
            set
            {
                buttonBackground = value;
                btn.Background = new BrushConverter().ConvertFrom(buttonBackground) as Brush;
            }
        }

        private string buttonForeground;
        public string ButtonForeground
        {
            get { return buttonForeground; }
            set
            {
                buttonForeground = value;
                btn.Foreground = new BrushConverter().ConvertFrom(buttonForeground) as Brush;
            }
        }

        public FormButton()
        {
            InitializeComponent();
        }
    }
}
