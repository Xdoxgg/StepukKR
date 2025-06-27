using Microsoft.EntityFrameworkCore;
using System.Numerics;
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
            var bebeb = context.Doctors.ToList();
            DataGridItems.ItemsSource = bebeb.ToList();
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
        switch (ComboBoxList.SelectedIndex)
        {
            case 0:
            {
               
                DoctorAddWindow addWindow = new DoctorAddWindow();
                this.Hide();
                if (addWindow.ShowDialog() == true)
                {
                    Doctor doctor = addWindow.dr;
                    MessageBox.Show("Доктор сохранен: " + doctor.FirstName + " " + doctor.LastName);
                    LoadData();
                }
                this.Show();
                break;

                
            }
            case 1:
            {

                    AddServiceWindow addServiceWindow = new AddServiceWindow();
                    this.Hide();
                    if(addServiceWindow.ShowDialog() == true)
                    {
                        Service serv = addServiceWindow.service;
                        MessageBox.Show("Услуга сохранена: " + serv.ServiceName);
                        LoadData();
                    }
                    this.Show();
                    break;

                
            }
            case 2:
            {

                    AddAppointmentsWindow addAppointmentsWindow = new AddAppointmentsWindow();
                    this.Hide();
                    if (addAppointmentsWindow.ShowDialog() == true)
                    {
                        Appointment appoint = addAppointmentsWindow.appointment;
                        MessageBox.Show("Запись добавлена: " + appoint.Doctor.LastName + " " + appoint.User.UserName + " " + appoint.Service.ServiceName);
                        LoadData();
                    }
                    this.Show();
                    break;


                }
            case 3:
            {
                
                // var bebeb = context.Reviews.ToList();
                // DataGridItems.ItemsSource = bebeb.ToList();
                break;

                
            }
            default:
            {
                MessageBox.Show("Для начала нужно выбрать таблицу!");
                break;
            }
        }
       
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

    private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var context = new FullContext();
        
        switch (ComboBoxList.SelectedIndex)
        {
            case 0:
            {
               
                    var bebeb = context.Doctors.ToList();
                    DataGridItems.ItemsSource = bebeb.ToList();
                    break;

                
            }
            case 1:
            {
               
                    var bebeb = context.Services.ToList();
                    DataGridItems.ItemsSource = bebeb.ToList();
                    break;

                
            }
            case 2:
            {
               
                    var bebeb = context.Appointments.ToList();
                    DataGridItems.ItemsSource = bebeb.ToList();
                    break;

                
            }
            case 3:
            {
                
                    var bebeb = context.Reviews.ToList();
                    DataGridItems.ItemsSource = bebeb.ToList();
                    break;

                
            }
        }
    }
}