﻿using SportStore.Models;
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

namespace SportStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(User user)
        {
            InitializeComponent();

            List<string> sortList = new List<string>() { "По возрастанию цены", "По убыванию цены" };
            sortUserComboBox.ItemsSource = sortList;

            using (SportStoreContext db = new SportStoreContext())
            {
                if (user != null)
                {
                    statusUser.Text = user.RoleNavigation.Name;
                    MessageBox.Show($"{user.RoleNavigation.Name}: {user.Surname} {user.Name} {user.Patronymic}. \r\t");
                }
                else
                {
                    statusUser.Text = "Гость";
                    MessageBox.Show("Гость");
                }

                List<string> filtertList = db.Products.Select(u => u.Manufacturer).Distinct().ToList();
                filtertList.Insert(0, "Все производители");
                filterUserComboBox.ItemsSource = filtertList.ToList();


                countProducts.Text = $"Количество: {db.Products.Count()}";


                productlistView.ItemsSource = db.Products.ToList();
            }

        }


        private void UpdateProducts()
        {
            using (SportStoreContext db = new SportStoreContext())
            {

                var currentProducts = db.Products.ToList();
                productlistView.ItemsSource = currentProducts;

                //Сортировка
                if (sortUserComboBox.SelectedIndex != -1)
                {
                    if (sortUserComboBox.SelectedValue == "По убыванию цены")
                    {
                        currentProducts = currentProducts.OrderByDescending(u => u.Cost).ToList();

                    }

                    if (sortUserComboBox.SelectedValue == "По возрастанию цены")
                    {
                        currentProducts = currentProducts.OrderBy(u => u.Cost).ToList();

                    }
                }


                // Фильтрация
                if (filterUserComboBox.SelectedIndex != -1)
                {
                    if (db.Products.Select(u => u.Manufacturer).Distinct().ToList().Contains(filterUserComboBox.SelectedValue))
                    {
                        currentProducts = currentProducts.Where(u => u.Manufacturer == filterUserComboBox.SelectedValue.ToString()).ToList();
                    }
                    else
                    {
                        currentProducts = currentProducts.ToList();
                    }
                }

                // Поиск

                if (searchBox.Text.Length > 0)
                {

                    currentProducts = currentProducts.Where(u => u.Name.Contains(searchBox.Text) || u.Description.Contains(searchBox.Text)).ToList();

                }

                productlistView.ItemsSource = currentProducts;


                countProducts.Text = $"Количество: {currentProducts.Count} из {db.Products.ToList().Count}";

            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        { 
                new LoginWindow().Show();
                this.Close();
            
        }

        private void sortUserComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (SportStoreContext db = new SportStoreContext())
            {
                if (sortUserComboBox.SelectedValue == "По убыванию цены")
                {
                    productlistView.ItemsSource = db.Products.OrderByDescending(u => u.Cost).ToList();
                }

                if (sortUserComboBox.SelectedValue == "По возрастанию цены")
                {
                    productlistView.ItemsSource = db.Products.OrderBy(u => u.Cost).ToList();
                }
            }
            UpdateProducts();

        }


        private void filterUserComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (SportStoreContext db = new SportStoreContext())
            {
                if (db.Products.Select(u => u.Manufacturer).Distinct().ToList().Contains(filterUserComboBox.SelectedValue))
                {
                    productlistView.ItemsSource = db.Products.Where(u => u.Manufacturer == filterUserComboBox.SelectedValue).ToList();
                }
                else
                {
                    productlistView.ItemsSource = db.Products.ToList();
                }
            }
            UpdateProducts();
        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (SportStoreContext db = new SportStoreContext())
            {
                if (searchBox.Text.Length > 0)
                {
                    productlistView.ItemsSource = db.Products.Where(u => u.Name.Contains(searchBox.Text) || u.Description.Contains(searchBox.Text)).ToList();
                }

            }
            UpdateProducts();

        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            searchBox.Text = "";
            sortUserComboBox.SelectedIndex = -1;
            filterUserComboBox.SelectedIndex = -1;
           
        }

        private void addUserButtonClick(object sender, RoutedEventArgs e)
        {
            new AddProductWindow().ShowDialog();
        }



        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

            using (SportStoreContext dm = new SportStoreContext())
            {

                var selectedUsers = productlistView.SelectedItems.Cast<Product>().ToList();

                if (MessageBox.Show($"Вы точно хотите удалить {selectedUsers.Count()} объектов", "Внимание!",
                   MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {


                    try
                    {
                        foreach (var user in selectedUsers)
                        {
                            dm.Products.Attach(user);
                        }

                        dm.Products.RemoveRange(selectedUsers);
                        dm.SaveChanges();
                        productlistView.ItemsSource = dm.Products.ToList();
                        MessageBox.Show("Пользователи удалены!");



                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message}");
                    }


                }
            }


        }

    }
}
