using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleTest
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            this.userControl11.OnSelectEvent += OnReceiveEvent;
        }

        private void OnReceiveEvent(object sender, object e)
        {

            List<DataRow> dRows1 = e as List<DataRow>;

            foreach (DataRow r in dRows1)
            {
                Console.WriteLine("row data : {0} {1}", r["check"].ToString(), r["point"].ToString());
            }

        }
    }
}
