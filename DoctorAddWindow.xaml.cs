using System.Windows;

namespace DantoBrick;

public partial class DoctorAddWindow : Window
{
    public Doctor dr;
    
    public DoctorAddWindow()
    {
        InitializeComponent();
    }
    
    private void BtnSave_Click(object sender, EventArgs e)
    {
        // Создание экземпляра класса Doctor
        dr = new Doctor
        {
            FirstName = txtFirstName.Text,
            LastName = txtLastName.Text,
            Specialization = txtSpecialization.Text,
            Schedule = txtSchedule.Text
        };

        FullContext c = new FullContext();
        c.Doctors.Add(dr);
        c.SaveChanges();
        DialogResult = true;

        MessageBox.Show("Доктор сохранен: " + dr.FirstName + " " + dr.LastName);
        this.Close();
    }
    private void BtnClose_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}