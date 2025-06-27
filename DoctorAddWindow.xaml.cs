using System.Windows;

namespace DantoBrick;

public partial class DoctorAddWindow : Window
{
    public Doctor dr;
    public bool isEdit = false;
    
    public DoctorAddWindow()
    {
        InitializeComponent();
    }

    public DoctorAddWindow(Doctor doc)
    {
        InitializeComponent();
        dr = doc;
        isEdit = true;
        LoadEdit();
    }

    private void LoadEdit()
    {
        txtFirstName.Text = dr.FirstName;
        txtLastName.Text = dr.LastName;
        txtSpecialization.Text = dr.Specialization;
        txtSchedule.Text = dr.Schedule;
    }

    private void BtnSave_Click(object sender, EventArgs e)
    {
        if (isEdit == true)
        {
            FullContext c = new FullContext();
            var f =c.Doctors.FirstOrDefault(x => x.Id==dr.Id);
            f.FirstName = txtFirstName.Text;
            f.LastName = txtLastName.Text;
            f.Specialization = txtSpecialization.Text;
            f.Schedule = txtSchedule.Text;
            c.SaveChanges();
            DialogResult = true;
            this.Close();
        }
        else
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
            this.Close();
        }
    }
    private void BtnClose_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}