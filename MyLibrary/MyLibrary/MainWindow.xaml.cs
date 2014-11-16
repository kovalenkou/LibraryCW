using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyLibrary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> chooseLib = new List<string>() {"Автор", "Тема", "Категория", "Издательство"};
        int chLibIndex = 0;
        int ch2 = 0;
        LibraryDataContext db = new LibraryDataContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tmp = "";
            tmp = (string)((ComboBox)sender).SelectedItem;
            if (tmp == "Автор")
                chLibIndex = 0;
            if (tmp == "Тема")
                chLibIndex = 1;
            if (tmp == "Категория")
                chLibIndex = 2;
            if (tmp == "Издательство")
                chLibIndex = 3;
            switch (chLibIndex)
            {
                case 0:
                    {
                        chDop.ItemsSource = db.Authors;
                        chDop.DisplayMemberPath = "LastName";
                        chDop.SelectedIndex = 0;
                        break;
                    }
                case 1:
                    {
                        chDop.ItemsSource = db.Themes;
                        chDop.DisplayMemberPath = "Name";
                        chDop.SelectedIndex = 0;
                        break;
                    }
                case 2:
                    {
                        chDop.ItemsSource = db.Categories;
                        chDop.DisplayMemberPath = "Name";
                        chDop.SelectedIndex = 0;
                        break;
                    }
                case 3:
                    {
                        chDop.ItemsSource = db.Presses;
                        chDop.DisplayMemberPath = "Name";
                        chDop.SelectedIndex = 0;
                        break;
                    }
                default:
                    break;
            }
        }

        private void mnWin_Loaded(object sender, RoutedEventArgs e)
        {
            cbChoose.ItemsSource = chooseLib;
            cbChoose.SelectedIndex = 0;
            
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Author a;
            Theme t;
            Category c;
            Press p;

            try
            {
                switch (chLibIndex)
                {
                    case 0:
                        {

                            if (((ComboBox)sender).SelectedItem is Author)
                            {
                                a = (Author)chDop.SelectedItem;
                                dgBooks.ItemsSource = a.Books;
                            }
                            
                            break;
                        }
                    case 1:
                        {
                            if (((ComboBox)sender).SelectedItem is Theme)
                            {
                                t = (Theme)chDop.SelectedItem;
                                dgBooks.ItemsSource = t.Books;
                            }
                            break;
                        }
                    case 2:
                        {
                            if (((ComboBox)sender).SelectedItem is Category)
                            {
                                c = (Category)chDop.SelectedItem;
                                dgBooks.ItemsSource = c.Books;
                            }
                            break;
                        }
                    case 3:
                        {
                            if (((ComboBox)sender).SelectedItem is Press)
                            {
                                p = (Press)chDop.SelectedItem;
                                dgBooks.ItemsSource = p.Books;
                            }
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }


    }
}
