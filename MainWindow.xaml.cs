using DentalClinic;
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
            var users = context.Users.ToList();
            dataGrid.ItemsSource = users; // Привязка данных к DataGrid
        }
    }

    private void SetButtonVisibility()
    {
        // Устанавливаем видимость кнопок в зависимости от роли пользователя
        if (currentUser.Role)
        {
            AddButton.Visibility = Visibility.Visible;
            EditButton.Visibility = Visibility.Visible;
            DeleteButton.Visibility = Visibility.Visible;
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
        if (dataGrid.SelectedItem is User selectedUser)
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