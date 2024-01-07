using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace VacationList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class Item
    {
        public string Name { get; set; }
        public bool IsChecked { get; set; }
        
        public Item(string name, bool isChecked)
        {
            Name = name;
            IsChecked = isChecked;
        }
    }
     
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            UpdateProgress();
        }

        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
            ActiveItems.Items.Add(new Item(Input.Text, false));
            UpdateProgress();
        }

        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            var item = (Item) ((CheckBox) sender).DataContext;
            item.IsChecked = true;
            ActiveItems.Items.Remove(item);
            ArchiveItems.Items.Add(new Item(item.Name, true));
            UpdateProgress();
        }

        private void ToggleButton_OnUnchecked(object sender, RoutedEventArgs e)
        {
            var item = (Item) ((CheckBox) sender).DataContext;
            item.IsChecked = false;
            ArchiveItems.Items.Remove(item);
            ActiveItems.Items.Add(new Item(item.Name, false));
            UpdateProgress();
        }

        private void UpdateProgress()
        {
            int done = ArchiveItems.Items.Count;
            int todo = ActiveItems.Items.Count;
            int total = done + todo;
            double percent = 0;

            if (total != 0)
            {
                percent = (double)done / total * 100;
                percent = Math.Round(percent, 2);
            }

            ProgressMessage.Content = $"Masz już {done} z {total} spakowanych przedmiotów ({percent}%)";
        }
    }
}