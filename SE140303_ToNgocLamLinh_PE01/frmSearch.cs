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
    public partial class frmSearch : Form
    {
        private StudentDB db = new StudentDB();
        private List<Student> Students;
        public frmSearch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Students = db.FindStudent(txtSearch.Text);
            dgv.DataSource = Students;
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {

        }
    }
}
