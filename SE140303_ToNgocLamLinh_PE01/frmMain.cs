using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentAssemblies;
namespace SE140303_ToNgocLamLinh_PE01
{
    public partial class frmMain : Form
    {
        private StudentDB db = new StudentDB();
        private List<Student> Students
            ;
        public frmMain()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            Students = db.GetStudentList();
            dgv.DataSource = Students;
            //clear
            txtID.DataBindings.Clear();
            txtName.DataBindings.Clear();
            txtAge.DataBindings.Clear();
            //txtEmail.DataBindings.Clear();
            //set value
            txtID.DataBindings.Add("Text", Students, "StudentID");
            txtName.DataBindings.Add("Text", Students, "StudentName");
            txtAge.DataBindings.Add("Text", Students, "Age");
           // txtEmail.DataBindings.Add("Text", Students, "Email");
            txtID.Enabled = false;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lbStatus.Text = "Inserting ...";
            frmInsert frm = new frmInsert();
            frm.ShowDialog();
            LoadData();
            lbStatus.Text = "Ready";
        }

        private string CheckData()
        {
            string msg = "";
            int age;
            string name = txtName.Text.ToString();
           // string email = txtEmail.Text.ToString();
            // check name
            if (name.Trim().Length == 0)
            {
                msg += "FullName cannot empty\n";
            }
            //check age            
            try
            {
                age = int.Parse(txtAge.Text.Trim());
                Debug.WriteLine("Age:" + age);
                if (age < 0)
                {
                    msg += "Age is a integer number >0\n";
                }
            }
            catch (Exception e)
            {
                msg += "Age is a integer number\n";
            }

            /*  //check address
              if (email.Trim().Length == 0)
              {
                  msg += "Email cannot empty\n";
              }
            */
            return msg;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            lbStatus.Text = "Updating...";
            frmUpdate frm = new frmUpdate(new Student() {
                StudentID = int.Parse(txtID.Text.Trim()),
                StudentName = txtName.Text.Trim(),
                Age = int.Parse(txtAge.Text.Trim())
                //Email = txtEmail.Text.Trim()
            });
            frm.ShowDialog();
            LoadData();
            lbStatus.Text = "Ready";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lbStatus.Text = "Searching ...";
            frmSearch frm = new frmSearch();
            frm.ShowDialog();
            lbStatus.Text = "Ready";
        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
