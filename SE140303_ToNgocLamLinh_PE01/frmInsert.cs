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
namespace StudentAssemblies
{
    
    public partial class frmInsert : Form
    {
        private StudentDB db = new StudentDB();
        public frmInsert()
        {
            InitializeComponent();
        }
        private string CheckData()
        {
            string msg = "";
            int id, age;
            string name = txtName.Text.ToString();
            //string email = txtEmail.Text.ToString();
            //Check id
            try
            {
                id = int.Parse(txtID.Text.Trim());

                bool check = db.IsExist(id);
                if (check)
                {
                    msg += "This ID is existed!\n";
                }
            }
            catch (Exception e)
            {
                msg += "ID is a integer number\n";
            }
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

            //check address
           /* if (email.Trim().Length == 0)
            {
                msg += "Email cannot empty\n";
            }*/

            return msg;
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
                bool rs = db.AddNewStudent(new Student()
                {
                    StudentID = int.Parse(txtID.Text.Trim()),
                    StudentName = txtName.Text.Trim(),
                    Age = int.Parse(txtAge.Text.Trim())
                  //  Email = txtEmail.Text.Trim()
                });
                if (rs)
                {
                    MessageBox.Show("Success");
                }
                else
                {
                    MessageBox.Show("Fail");
                }
                txtID.Text = "";
                txtName.Text = "";
                txtAge.Text = "";
              //  txtEmail.Text = "";
            }
        }

        private void frmInsert_Load(object sender, EventArgs e)
        {

        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
