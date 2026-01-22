using crud_operations.Model;
using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace crud_operations.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        public AddProductWindow()
        {
            InitializeComponent();

            CategoryCmb.ItemsSource = App.context.Category.ToList();
            CategoryCmb.SelectedIndex = 0;
            CategoryCmb.DisplayMemberPath = "Name";
            CategoryCmb.SelectedValuePath = "id";
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if(String.IsNullOrEmpty(NameTb.Text) &&
                String.IsNullOrEmpty(PriceTb.Text) &&
                String.IsNullOrEmpty(DescriptionTb.Text) &&
                String.IsNullOrEmpty(CategoryCmb.Text) &&
                String.IsNullOrEmpty(ReleaseDateDp.Text) &&
                String.IsNullOrEmpty(PhotoTb.Text))
            {
                MessageBox.Show("Заполните все поля", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                Product product = new Product();
                {
                    Name = NameTb.Text,
                    Price = Convert.ToDecimal(PriceTb.Text),
                    Description = DescriptionTb.Text,
                    Category = CategoryCmb.SelectedItem as Category,
                    ReleaseDate = (DateTime)ReleaseDateDp.SelectedDate,
                    IsAvaliable = Convert.ToBoolean(IsAvaliableCb.IsChecked)                    
                };
                App.context.Product.Add(product);
                App.context.SaveChanges();

                MessageBox.Show("Товар успешно длбавлен", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
            }
        }

        private void LoadFromPCBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                PhotoTb.Text = openFileDialog.FileName;
            }
        }
    }
}
