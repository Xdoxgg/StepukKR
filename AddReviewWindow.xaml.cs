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

namespace DantoBrick
{
    /// <summary>
    /// Логика взаимодействия для AddReviewWindow.xaml
    /// </summary>
    public partial class AddReviewWindow : Window
    {
        public Review review;
        public bool isEdit = false;
        public AddReviewWindow()
        {
            InitializeComponent();
            LoadComboBox();
        }
        public AddReviewWindow(Review rev)
        {
            InitializeComponent();
            LoadComboBox();
            review = rev;
            isEdit = true;
            LoadEdit();

        }

        private void LoadEdit()
        {
            txtComment.Text = review.Comment;
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
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (cmbUser.SelectedItem == null || cmbDoctor.SelectedItem == null ||
            cmbRating.SelectedItem == null || string.IsNullOrWhiteSpace(txtComment.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (isEdit == true)
            {
                FullContext c = new FullContext();
                var fff = c.Reviews.FirstOrDefault(x => x.Id == review.Id);
                fff.UserId = ((User)cmbUser.SelectedItem).Id;
                fff.User = c.Users.First(el => el.Id == ((User)cmbUser.SelectedItem).Id);
                fff.DoctorId = ((User)cmbDoctor.SelectedItem).Id;
                fff.Doctor = c.Doctors.First(el => el.Id == ((Doctor)cmbDoctor.SelectedItem).Id);
                fff.Rating = ((ComboBoxItem)cmbRating.SelectedItem).Content.ToString() == "1" ? 1 :
                         ((ComboBoxItem)cmbRating.SelectedItem).Content.ToString() == "2" ? 2 :
                         ((ComboBoxItem)cmbRating.SelectedItem).Content.ToString() == "3" ? 3 :
                         ((ComboBoxItem)cmbRating.SelectedItem).Content.ToString() == "4" ? 4 : 5;
                fff.Comment = txtComment.Text;
                fff.CreatedAt = DateTime.Now;
                c.SaveChanges();
                DialogResult = true;
                this.Close();
            }
            else
            {


                FullContext c = new FullContext();
                review = new Review
                {
                    UserId = ((User)cmbUser.SelectedItem).Id,
                    User = c.Users.First(el => el.Id == ((User)cmbUser.SelectedItem).Id),
                    DoctorId = ((Doctor)cmbDoctor.SelectedItem).Id,
                    Doctor = c.Doctors.First(el => el.Id == ((Doctor)cmbDoctor.SelectedItem).Id),
                    Rating = ((ComboBoxItem)cmbRating.SelectedItem).Content.ToString() == "1" ? 1 :
                         ((ComboBoxItem)cmbRating.SelectedItem).Content.ToString() == "2" ? 2 :
                         ((ComboBoxItem)cmbRating.SelectedItem).Content.ToString() == "3" ? 3 :
                         ((ComboBoxItem)cmbRating.SelectedItem).Content.ToString() == "4" ? 4 : 5,
                    Comment = txtComment.Text,
                    CreatedAt = DateTime.Now
                };

                c.Reviews.Add(review);
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
