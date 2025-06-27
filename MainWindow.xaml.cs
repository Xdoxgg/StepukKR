using System.Windows;
using System.Windows.Controls;

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
                        MessageBox.Show("Доктор добавлен: " + doctor.FirstName + " " + doctor.LastName);
                        LoadData();
                    }
                    this.Show();
                    break;


                }
            case 1:
                {

                    AddServiceWindow addServiceWindow = new AddServiceWindow();
                    this.Hide();
                    if (addServiceWindow.ShowDialog() == true)
                    {
                        Service serv = addServiceWindow.service;
                        MessageBox.Show("Услуга добавлена: " + serv.ServiceName);
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
                    AddReviewWindow addReviewWindow = new AddReviewWindow();
                    this.Hide();
                    if (addReviewWindow.ShowDialog() == true)
                    {
                        Review rev = addReviewWindow.review;
                        MessageBox.Show("Комментарий добавлен: " + rev.Doctor.Id + " " + rev.User.Id);
                        LoadData();
                    }
                    this.Show();
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
        if (DataGridItems.SelectedItem == null)
        {
            MessageBox.Show("Для начала выберете строку");
            return;
        }
        switch (ComboBoxList.SelectedIndex)
        {
            case 0:
                {
                    if (DataGridItems.SelectedItem is Doctor selectedDoctor)
                    {

                        DoctorAddWindow addWindow = new DoctorAddWindow();
                        this.Hide();
                        if (addWindow.ShowDialog() == true)
                        {
                            Doctor doctor = addWindow.dr;
                            MessageBox.Show("Доктор обновлен: " + doctor.FirstName + " " + doctor.LastName);
                            LoadData();
                        }
                        this.Show();
                    }
                    break;


                }
            case 1:
                {

                    AddServiceWindow addServiceWindow = new AddServiceWindow();
                    this.Hide();
                    if (addServiceWindow.ShowDialog() == true)
                    {
                        Service serv = addServiceWindow.service;
                        MessageBox.Show("Услуга обновлена: " + serv.ServiceName);
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
                        MessageBox.Show("Запись обновлена: " + appoint.Doctor.LastName + " " + appoint.User.UserName + " " + appoint.Service.ServiceName);
                        LoadData();
                    }
                    this.Show();
                    break;


                }
            case 3:
                {
                    AddReviewWindow addReviewWindow = new AddReviewWindow();
                    this.Hide();
                    if (addReviewWindow.ShowDialog() == true)
                    {
                        Review rev = addReviewWindow.review;
                        MessageBox.Show("Комментарий обновлен: " + rev.Doctor.Id + " " + rev.User.Id);
                        LoadData();
                    }
                    this.Show();
                    break;


                }
            default:
                {
                    MessageBox.Show("Для начала нужно выбрать таблицу!");
                    break;
                }
        }
    }

    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataGridItems.SelectedItem == null)
        {
            MessageBox.Show("Для начала выберете строку");
            return;
        }
        switch (ComboBoxList.SelectedIndex)
        {
            case 0:
                {

                    if (DataGridItems.SelectedItem is Doctor selectedDoctor)
                    {
                        using (var context = new FullContext())
                        {
                            context.Doctors.Remove(selectedDoctor);
                            context.SaveChanges();
                            LoadData();
                        }
                    }
                    break;


                }
            case 1:
                {

                    if (DataGridItems.SelectedItem is Service selecteServicr)
                    {
                        using (var context = new FullContext())
                        {
                            context.Services.Remove(selecteServicr);
                            context.SaveChanges();
                            LoadData();
                        }
                    }
                    break;


                }
            case 2:
                {

                    if (DataGridItems.SelectedItem is Appointment selecteAppointment)
                    {
                        using (var context = new FullContext())
                        {
                            context.Appointments.Remove(selecteAppointment);
                            context.SaveChanges();
                            LoadData();
                        }
                    }
                    break;

                }
            case 3:
                {
                    if (DataGridItems.SelectedItem is Review selecteReview)
                    {
                        using (var context = new FullContext())
                        {
                            context.Reviews.Remove(selecteReview);
                            context.SaveChanges();
                            LoadData();
                        }
                    }
                    break;


                }
            default:
                {
                    MessageBox.Show("Для начала нужно выбрать таблицу!");
                    break;
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