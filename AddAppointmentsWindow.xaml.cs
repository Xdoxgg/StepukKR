﻿using System;
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

namespace DantoBrick
{
    /// <summary>
    /// Логика взаимодействия для AddAppointmentsWindow.xaml
    /// </summary>
    public partial class AddAppointmentsWindow : Window
    {
        public Appointment appointment;
        public bool isEdit = false;

        public AddAppointmentsWindow()
        {
            InitializeComponent();
            LoadComboBox();
        }

        public AddAppointmentsWindow(Appointment app)
        {
            InitializeComponent();
            LoadComboBox();
            appointment = app;
            isEdit = true;
            LoadEdit();
        }

        private void LoadEdit()
        {
            txtStatus.Text = appointment.Status;
        }

        public void LoadComboBox()
        {
            using (var context = new FullContext())
            {
                // Загрузка пользователей
                cmbUser.ItemsSource = context.Users.ToList();
                cmbUser.DisplayMemberPath = "UserName";
                cmbUser.SelectedValuePath = "Id";

                // Загрузка врачей
                cmbDoctor.ItemsSource = context.Doctors.ToList();
                cmbDoctor.DisplayMemberPath = "LastName"; // Можно изменить на полное имя
                cmbDoctor.SelectedValuePath = "Id";

                // Загрузка услуг
                cmbService.ItemsSource = context.Services.ToList();
                cmbService.DisplayMemberPath = "ServiceName";
                cmbService.SelectedValuePath = "Id";
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (cmbUser.SelectedItem == null || cmbDoctor.SelectedItem == null ||
            cmbService.SelectedItem == null || dpAppointmentDate.SelectedDate == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (isEdit == true)
            {
                FullContext c = new FullContext();
                var fff = c.Appointments.FirstOrDefault(x => x.Id == appointment.Id);
                fff.UserId = ((User)cmbUser.SelectedItem).Id;
                fff.User = c.Users.First(el => el.Id == ((User)cmbUser.SelectedItem).Id);
                fff.DoctorId = ((Doctor)cmbDoctor.SelectedItem).Id;
                fff.Doctor = c.Doctors.First(el => el.Id == ((Doctor)cmbDoctor.SelectedItem).Id);
                fff.ServiceId = ((Service)cmbService.SelectedItem).Id;
                fff.Service = c.Services.First(el => el.Id == ((Service)cmbService.SelectedItem).Id);
                fff.AppointmentDate = dpAppointmentDate.SelectedDate.Value;
                fff.Status = txtStatus.Text;
                c.SaveChanges();
                DialogResult = true;
                this.Close();
            }
            else
            {
                FullContext c = new FullContext();
                appointment = new Appointment
                {
                    UserId = ((User)cmbUser.SelectedItem).Id,
                    User = c.Users.First(el => el.Id == ((User)cmbUser.SelectedItem).Id),
                    DoctorId = ((Doctor)cmbDoctor.SelectedItem).Id,
                    Doctor = c.Doctors.First(el => el.Id == ((Doctor)cmbDoctor.SelectedItem).Id),
                    ServiceId = ((Service)cmbService.SelectedItem).Id,
                    Service = c.Services.First(el => el.Id == ((Service)cmbService.SelectedItem).Id),
                    AppointmentDate = dpAppointmentDate.SelectedDate.Value,
                    Status = txtStatus.Text
                };

                c.Appointments.Add(appointment);
                c.SaveChanges();
                DialogResult = true;
                this.Close();
            }
            
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
