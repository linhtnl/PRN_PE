using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentAssemblies;
namespace SE140303_ToNgocLamLinh_PE01
{
    public partial class frmUpdate : Form
    {
        private Student s;
        private StudentDB db = new StudentDB();
        public frmUpdate(Student student)
        {
            s = student;
            InitializeComponent();
            txtID.Text = s.StudentID.ToString();
            txtName.Text = s.StudentName;
            txtAge.Text = s.Age.ToString();
            //txtEmail.Text = s.Email;
        }
        private string CheckData()
        {
            string msg = "";
            int age;
            string name = txtName.Text.ToString();
            //string email = txtEmail.Text.ToString();
            // check name
            if (name.Trim().Length == 0)
            {
                msg += "FullName cannot empty\n";
            }
            //check age            
            try
            {
                age = int.Parse(txtAge.Text.Trim());
              
                if (age < 0)
                {
                    msg += "Age is a integer number >0\n";
                }
            }
            catch (Exception e)
            {
                msg += "Age is a integer number\n";
            }

            /*//check address
            if (email.Trim().Length == 0)
            {
                msg += "Email cannot empty\n";
            }*/

            return msg;
        }
        private void clear()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtAge.Text = "";
            //txtEmail.Text = "";
        }
        private void Save_Click(object sender, EventArgs e)
        {
            string msg = CheckData();

            if (msg.Length != 0)
            {
                MessageBox.Show(msg);
            }
            else
            {
                bool rs = db.UpdateStudent(new Student()
                {
                    StudentID = int.Parse(txtID.Text.Trim()),
                    StudentName = txtName.Text.Trim(),
                    Age = int.Parse(txtAge.Text.Trim())
                   // Email = txtEmail.Text.Trim()
                });
                if (rs)
                {
                    MessageBox.Show("Success");
                    clear();
                }
                else
                {
                    MessageBox.Show("Fail");
                }
               
            }
        }

        private void frmUpdate_Load(object sender, EventArgs e)
        {

        }
    }
}
