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
    public partial class Form1 : Form
    {
        CheckBox lastChecked;
        public Form1()
        {
            InitializeComponent();
        }

        public CheckBox IsSelectChecked(object sender)
        {
            CheckBox activeCheckBox = sender as CheckBox;
           
            if (activeCheckBox != lastChecked && lastChecked != null)
            {
                lastChecked.Checked = false;
            }

            return activeCheckBox.Checked ? activeCheckBox : null; 
        }

        public void IsSelectChecked2(object sender)
        {
            CheckBox activeCheckBox = sender as CheckBox;

            if (activeCheckBox != lastChecked && lastChecked != null)
            {
                lastChecked.Checked = false;
                lastChecked = activeCheckBox.Checked ? activeCheckBox : null;
            }
            else
            {
                if (activeCheckBox == lastChecked && lastChecked != null)
                {
                    lastChecked = activeCheckBox;
                    lastChecked.Checked = !activeCheckBox.Checked;
                }
                    
            }

            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           // lastChecked = IsSelectChecked(sender);

            IsSelectChecked2(sender);

            if (lastChecked != null)
            {
                Console.WriteLine("checkBox1_CheckedChanged : {0} {1} {2} ", lastChecked.Name, lastChecked.Checked, checkBox2.Checked);
            }
            else
            {
 
                Console.WriteLine("checkBox1_CheckedChanged(null) : {0} {1} ", checkBox1.Checked, checkBox2.Checked);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            //lastChecked = IsSelectChecked(sender);

            IsSelectChecked2(sender);

            if (lastChecked != null)
            {
                Console.WriteLine("checkBox2_CheckedChanged : {0} {1} {2} ", lastChecked.Name, lastChecked.Checked, checkBox1.Checked);
            }
            else
            {
               // checkBox2.Checked = true;
                Console.WriteLine("checkBox2_CheckedChanged(null) : {0} {1} ", checkBox1.Checked, checkBox2.Checked);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }
    }
}
