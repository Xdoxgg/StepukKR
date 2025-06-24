using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DantoBrick;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private User currentUser;
    public MainWindow()
    {
        InitializeComponent();
        var us = new User
        {
            Role = true
        };
        currentUser = us; 
        LoadData();
        SetButtonVisibility();
    }
    public MainWindow(User us)
    {
        InitializeComponent();
        currentUser = us; 
        LoadData();
        SetButtonVisibility();
    }

    private void LoadData()
    {
        using (var context = new FullContext())
        {
            // Загрузка данных из всех классов, кроме User
            var doctors = context.Doctors.ToList();
            var services = context.Services.ToList();
            var appointments = context.Appointments.Include(a => a.User).Include(a => a.Doctor).Include(a => a.Service).ToList();
            var reviews = context.Reviews.Include(r => r.User).Include(r => r.Doctor).ToList();

            // Пример: Вы можете выбрать, какие данные отображать в DataGrid
            // Например, отображение данных о записях (Appointments)
            DataGridItems.ItemsSource = appointments; // Привязка данных к DataGrid

            // Если вы хотите отображать данные из других классов, вы можете создать отдельные DataGrids для каждого класса
            // или комбинировать данные в один объект для отображения
        }
    }


    private void SetButtonVisibility()
    {
        if (currentUser.Role)
        {
            AddButton.Visibility = Visibility.Visible;
            EditButton.Visibility = Visibility.Visible;
            DeleteButton.Visibility = Visibility.Visible;
            DataGridItems.IsReadOnly = true;
        }
    }

    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        // Логика добавления записи
        // Например, открытие нового окна для ввода данных
    }

    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        // Логика редактирования выбранной записи
        // Например, открытие окна с данными для редактирования
    }

    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        // Логика удаления выбранной записи
        if (DataGridItems.SelectedItem is User selectedUser)
        {
            using (var context = new FullContext())
            {
                context.Users.Remove(selectedUser);
                context.SaveChanges();
                LoadData(); // Обновляем данные в DataGrid
            }
        }
    }
}