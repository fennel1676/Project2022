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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

           dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ScrollBars = ScrollBars.Both;

           // dataGridView1.ColumnCount = 5;
            //dataGridView1.Columns.Add("ID", "ID1");
            //dataGridView1.Columns.Add("제목", "제목1");
            //dataGridView1.Columns.Add("구분", "구분1");
            //dataGridView1.Columns.Add("생성일", "생성일1");
            //dataGridView1.Columns.Add("수정일", "수정일1");


            //dataGridView1.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            //idColumn.Resizable = DataGridViewTriState.False;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DataTable table = new DataTable();

            //table.Columns.Add(new DataColumn("ID", typeof(string)));
            //table.Columns.Add(new DataColumn("제목", typeof(string)));
            // column을 추가합니다.
            table.Columns.Add("ID", typeof(string));
            table.Columns.Add("제목", typeof(string));
            table.Columns.Add("구분", typeof(string));
            table.Columns.Add("생성일", typeof(string));
            table.Columns.Add("수정일", typeof(string));

            // 각각의 행에 내용을 입력합니다.
            //table.Rows.Add("fgdfgfdgdfgdfgdfgdfgdfgfgfgfgdfgdfgdfgdfg", "제목 1번", "사용중", "2019/03/11", "2019/03/18");
            //table.Rows.Add("fgfdgdfgfdgfdgdfgdffgfgfggfdgdfgdfg", "제목 2번", "미사용", "2019/03/12", "2019/03/18");
            //table.Rows.Add("fgfgdgfdgfdgdfgfdgdfgfdgffgfgfgfdgfdgfdgfdgdfgdgd", "제목 3번", "미사용", "2019/03/13", "2019/03/18");
            //table.Rows.Add("fgdgdfgfdgfdgdfgdfgdfgdfgdfgdfgfgfgfgfgfgfdgfdgdffgfgfgfgfgfgfggdfgdfgfd", "제목 4번", "사용중", "2019/03/14", "2019/03/18");

            table.Rows.Add("fgdfgfdgdfgd", "제목 1번", "사용중", "2019/03/11", "2019/03/18");
            table.Rows.Add("fgfdgdfgf", "제목 2번", "미사용", "2019/03/12", "2019/03/18");
            table.Rows.Add("fgfgdgf", "제목 3번", "미사용", "2019/03/13", "2019/03/18");
            table.Rows.Add("fgdgdfgfdgfdgghhddhdhdhdhdghghfhfghfhgfvbvbvbvbvbvbvtffffff", "제목 4번", "사용중", "2019/03/14", "2019/03/18");

            // 값들이 입력된 테이블을 DataGridView에 입력합니다.
            dataGridView1.DataSource = table;

            ResizeDataGridView(); 
        }


        private void ResizeDataGridView()
        {
            if (dataGridView1.Columns.Count > 0)
            {
                int ColumnsWidth = 0;
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    if (col.Visible)
                        ColumnsWidth += col.Width;
                }


                int rowheaderWidth = dataGridView1.RowHeadersWidth;
                int lastColWidth = dataGridView1.Columns.GetLastColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.None).Width;
                int total = ColumnsWidth + rowheaderWidth;

                if (total < dataGridView1.Width)
                {
                    dataGridView1.Columns.GetLastColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.None).AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill;
                }
                //else
                //{
                //    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //}
            }


            //int i = dataGridView1.Columns.Count;

            //if (i > 0)
            //{




            //dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ////dataGridView1.Columns[0].Width = 200;
            //dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;



            // 머리글과 모든 셀의 내용에 맞게 열 너비 자동 조정
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


            // dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //  dataGridView1.Columns.GetLastColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.None).AutoSizeMode =
            //     DataGridViewAutoSizeColumnMode.Fill;

            // 헤더와 모든 셀의 내용에 맞게 행 높이 자동 조정
            // dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
    }

}
