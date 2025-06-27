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
    /// Логика взаимодействия для AddServiceWindow.xaml
    /// </summary>
    public partial class AddServiceWindow : Window
    {
        public Service service;

        public AddServiceWindow()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Создание экземпляра класса Doctor
            service = new Service
            {
                ServiceName = txtServiceName.Text,
                Price = double.TryParse(txtPrice.Text, out double price) ? price : 0,
                Description = txtDescription.Text
            };

            FullContext c = new FullContext();
            c.Services.Add(service);
            c.SaveChanges();
            DialogResult = true;
            this.Close();
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
