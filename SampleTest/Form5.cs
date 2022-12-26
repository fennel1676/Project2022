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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            string a = ""; //"234.567";
            double b;

            if (Double.TryParse(a, out b))
            {
                MessageBox.Show(b.ToString());
            }
            else
            {
                MessageBox.Show("숫자가 아닙니다.");
                 a = "0";
            }


            label1.Text = string.Format("{0:0.0#} ", double.Parse(a));




            DataTable dt = new DataTable();
            dt.Columns.Add("IND", typeof(string));
            dt.Columns.Add("FILTER_TYP", typeof(string));
            dt.Columns.Add("X_RANK", typeof(string));
            dt.Columns.Add("Y_RANK", typeof(string));
            //dt.Columns.Add("X", typeof(string));
            //dt.Columns.Add("Y", typeof(string));

            dt.Rows.Add("1", "gfgdg", "0.1", "0.21");
            dt.Rows.Add("2", "ROBUST", "0.2", "0.22");
            dt.Rows.Add("3", "fgdg", "0.3", "0.23");
            dt.Rows.Add("4", "ROBUST", "0.4", "0.24");

            double minX = 0.2;
            double maxX = 0.4;
            double minY = 0.23;
            double maxY = 0.21;
            DataRow[] rslt = dt.Select(string.Format("(X_RANK >= {0} AND X_RANK < {1}) OR (Y_RANK < {2} AND Y_RANK >= {3})", minX, maxX, minY, maxY)  );

            int count  = dt.Select("(X_RANK >= 0.2 AND X_RANK < 0.4) OR (Y_RANK < 0.23 AND Y_RANK >= 0.21)").Count<DataRow>();



            DataRow[] dr;



            //dr = (gridControl.DataSource as DataTable).Select(string.Format("PART_NO = '{0}'", strPART_NO));


            //int count  = dt.Compute("(X_RANK >= 0.2 AND X_RANK < 0.4) OR (Y_RANK < 0.23 AND Y_RANK >= 0.21)");
        }
    }
}
