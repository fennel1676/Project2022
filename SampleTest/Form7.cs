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
    public partial class Form7 : Form
    {
        int quadrantX1 = 0;
        int quadrantX2 = 0;
        int quadrantX3 = 0;
        int quadrantX4 = 0;

        int quadrantY1 = 0;
        int quadrantY2 = 0;
        int quadrantY3 = 0;
        int quadrantY4 = 0;

        int quadrantXY1 = 0;
        int quadrantXY2 = 0;
        int quadrantXY3 = 0;
        int quadrantXY4 = 0;

        private int[,] arr = new int[5, 5] { { 0, 0, 0, 0, 0 },{ 0, 1, 1, 4, 4 }, { 0, 1, 2, 3, 4 }, { 0, 4, 3, 3, 4 }, { 0, 4, 4, 4, 4 } };


        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            foreach (int a in arr)
                Console.WriteLine(">>>{0}", a);


            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write("[{0}, {1}] : {2} ", i, j, arr[i, j]);
                }
                Console.WriteLine();
            }




            //int pos = arr[0, 1];
            //int pos = arr[0, 1];
            //int pos = arr[0, 1];
            //int pos = arr[0, 1];
            //int pos = arr[0, 1];
        }
    }
}
