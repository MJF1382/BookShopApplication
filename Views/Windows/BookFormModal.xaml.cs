using BookShopApplication.DataBase;
using BookShopApplication.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace BookShopApplication.Views.Windows
{
    public partial class BookFormModal : Window
    {
        BookShopDBContext _context = new BookShopDBContext();
        private Book? _entity;

        public BookFormModal(Window owner, Book? entity = null)
        {
            this.Owner = owner;
            this._entity = entity;

            InitializeComponent();

            cmbCategoryName.Items = _context.Categories.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnExecute_Click(object sender, RoutedEventArgs e)
        {
            if (_entity != null)
            {
                MessageBox.Show("Edit");
            }
            else
            {
                if (txtISBN.Data.HasValue() &&
                    txtTitle.Data.HasValue() &&
                    txtPrice.Data.HasValue() &&
                    cmbCategoryName.Data.HasValue())
                {
                    Book book = new Book()
                    {
                        Isbn = txtISBN.Data,
                        CategoryId = int.Parse(cmbCategoryName.Data),
                        Title = txtTitle.Data,
                        Price = int.Parse(txtPrice.Data)
                    };

                    _context.Books.Add(book);
                    bool result = Convert.ToBoolean(_context.SaveChanges());

                    if (result)
                    {
                        Model.DataAccess.Books.Add(new ViewModels.BookViewModel()
                        {
                            Isbn = book.Isbn,
                            Title = book.Title,
                            CategoryName = book.Category.Name,
                            Price = book.Price
                        });

                        Close();

                        SuccessMessageModal successMessageModal = new SuccessMessageModal(App.Current.MainWindow, "کتاب با موفقیت ثبت شد.");
                        successMessageModal.ShowDialog();
                    }
                    else
                    {
                        this.Background = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                        main.Opacity = 0.25;

                        ErrorMessageModal errorMessageModal = new ErrorMessageModal(this, "خطا در اتصال به سرور، لطفا بعدا دوباره امتحان کنید.");
                        errorMessageModal.ShowDialog();

                        this.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
                        main.Opacity = 1;
                    }
                }
                else
                {
                    this.Background = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                    main.Opacity = 0.25;

                    ErrorMessageModal errorMessageModal = new ErrorMessageModal(this, "لطفا اطلاعات خواسته شده را وارد کنید.");
                    errorMessageModal.ShowDialog();

                    this.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
                    main.Opacity = 1;
                }
            }
        }

        private void Border_Loaded(object sender, RoutedEventArgs e)
        {
            if (_entity != null)
            {
                txbTitle.Text = _entity.Title;
                btnExecute.Text = "ویرایش";
                txtISBN.Data = _entity.Isbn;
                txtTitle.Data = _entity.Title;
                //txtCategoryName.DataContent = _entity.CategoryId.ToString();
                txtPrice.Data = _entity.Price.ToString();
            }
        }
    }
}
