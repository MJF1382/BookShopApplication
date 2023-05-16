using BookShopApplication.DataBase;
using BookShopApplication.Helpers.Enums;
using BookShopApplication.Helpers.Extensions;
using BookShopApplication.ViewModels;
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
        private Book? _entity;

        public BookFormModal(Window owner, Book? entity = null)
        {
            Owner = owner;
            _entity = entity;

            InitializeComponent();

            cmbCategoryName.Items = Model.DataAccess.Context.Categories.ToList();

            if (_entity != null)
            {
                txbTitle.Text = _entity.Title;
                btnExecute.Text = "ویرایش";
                txtISBN.Data = _entity.Isbn;
                txtISBN.ReadOnly = true;
                txtTitle.Data = _entity.Title;
                cmbCategoryName.Data = _entity.CategoryId.ToString();
                txtPrice.Data = _entity.Price.ToString();
            }
            else
            {
                cmbCategoryName.Data = Model.DataAccess.Context.Categories.First().Id.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnExecute_Click(object sender, RoutedEventArgs e)
        {
            if (_entity != null)
            {
                Book book = Model.DataAccess.Context.Books.Find(_entity.Isbn);

                if (book != null)
                {
                    if (txtISBN.Data.HasValue() &&
                    txtTitle.Data.HasValue() &&
                    txtPrice.Data.HasValue() &&
                    cmbCategoryName.Data.HasValue())
                    {
                        book.Title = txtTitle.Data;
                        book.CategoryId = int.Parse(cmbCategoryName.Data);
                        book.Price = int.Parse(txtPrice.Data);

                        Model.DataAccess.Context.Books.Update(book);
                        bool result = Convert.ToBoolean(Model.DataAccess.Context.SaveChanges());

                        if (result)
                        {
                            Model.DataAccess.UpdateContext();

                            BookViewModel modelBook = Model.DataAccess.Books.Single(p => p.Isbn == _entity.Isbn);
                            modelBook.Title = book.Title;
                            modelBook.CategoryName = book.Category.Name;
                            modelBook.Price = book.Price;

                            Model.DataAccess.UpdateBook(modelBook);

                            Close();

                            Message("کتاب با موفقیت ویرایش شد.", MessageType.Success);
                        }
                        else
                        {
                            Message("خطا در اتصال به سرور، لطفا بعدا دوباره امتحان کنید.", MessageType.Error);
                        }
                    }
                    else
                    {
                        Message("لطفا اطلاعات خواسته شده را وارد کنید.", MessageType.Error);
                    }
                }
                else
                {
                    Message("کتاب مورد نظر یافت نشد.", MessageType.Error);
                }
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

                    Model.DataAccess.Context.Books.Add(book);
                    bool result = Convert.ToBoolean(Model.DataAccess.Context.SaveChanges());

                    if (result)
                    {
                        Model.DataAccess.UpdateContext();

                        Model.DataAccess.Books.Add(new ViewModels.BookViewModel()
                        {
                            Isbn = book.Isbn,
                            Title = book.Title,
                            CategoryName = book.Category.Name,
                            Price = book.Price
                        });

                        Close();

                        Message("کتاب با موفقیت ثبت شد.", MessageType.Success);
                    }
                    else
                    {
                        Message("خطا در اتصال به سرور، لطفا بعدا دوباره امتحان کنید.", MessageType.Error);
                    }
                }
                else
                {
                    Message("لطفا اطلاعات خواسته شده را وارد کنید.", MessageType.Error);
                }
            }
        }

        private void Message(string text, MessageType messageType)
        {
            switch (messageType)
            {
                case MessageType.Success:
                    SuccessMessageModal successMessageModal = new SuccessMessageModal(App.Current.MainWindow, text);
                    successMessageModal.ShowDialog();

                    break;
                case MessageType.Error:
                    this.Background = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                    main.Opacity = 0.25;

                    ErrorMessageModal errorMessageModal = new ErrorMessageModal(this, text);
                    errorMessageModal.ShowDialog();

                    this.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
                    main.Opacity = 1;

                    break;
                default:
                    break;
            }
        }
    }
}
