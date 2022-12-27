using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleTest
{
    public partial class UserControl1 : UserControl
    {

        public event EventHandler<object> OnSelectEvent;

        public enum eSelectEventType
        {
            Remove,
            Select,
        }


        public class SelectEventArgs : EventArgs
        {
            public eSelectEventType EventType;
            public object EventData;

            public SelectEventArgs(eSelectEventType eventType, object dataType)
            {
                this.EventType = eventType;
                this.EventData = dataType;
            }
        }

        public UserControl1()
        {
            InitializeComponent();

            dataGridView1.MultiSelect = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            InitDataTable();
        }

        public virtual void InitDataTable()
        {
            //DataSet ds = new DataSet();
            DataTable table = new DataTable("Sample");

            table.Columns.Add("one1", typeof(string));
            table.Columns.Add("two1", typeof(string));
            table.Columns.Add("point", typeof(string));
            table.Columns.Add("check", typeof(string));


            table.Rows.Add("apple", "안녕하세요", "1", "True");
            table.Rows.Add("banana", "반갑습니다", "3", "False");
            table.Rows.Add("cherry", "오랜만이네요", "2", "True");
            table.Rows.Add("pineple", "또만나요", "4", "False");

            this.dataGridView1.DataSource = table;

           

        }

        private void dataGridView1_MouseUp(object sender, MouseEventArgs e)
        {

            DataTable dt = GetDataGridViewAsDataTable(dataGridView1);



            //IEnumerable<DataRow> rows = dt.Rows.Cast<DataRow>().Where(r => r["check"].ToString() == "True");
           // rows.ToList().ForEach(r => r.SetField("check", "False"));

            List<DataRow> draggedRows = new List<DataRow>();



            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {
                    int index = dataGridView1.SelectedRows[i].Index;

                    DataGridViewRow d = dataGridView1.SelectedRows[i];
                    DataRow row = (dataGridView1.SelectedRows[i].DataBoundItem as DataRowView).Row;
                    draggedRows.Add(row);
                }


                //IEnumerable<DataRow> rows1 = dt.Rows.Cast<DataRow>().Where(r => r["point"].ToString() == index);
                //rows1.ToList().ForEach(r => r.SetField("check", "True"));

                //draggedRows.AddRange(rows1);
            }

            int selectedCount = dataGridView1.SelectedRows.Count;
            //while (selectedCount > 0)
            //{
            //    if (!dataGridView1.SelectedRows[0].IsNewRow)
            //        dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            //    selectedCount--;
            //}



            //CellRange[] range = fpSpread.ActiveSheet.GetSelections();

            //foreach (CellRange cr in range)
            //{
            //    for (int i = cr.Row; i < (cr.Row + cr.RowCount); i++)
            //    {
            //        string index = fpSpread.ActiveSheet.Cells[i, fpSpread.ActiveSheet.ColumnCount - 2].Value.ToString();

            //        IEnumerable<DataRow> rows1 = dt.Rows.Cast<DataRow>().Where(r => r["point"].ToString() == index);
            //        rows1.ToList().ForEach(r => r.SetField("check", "True"));

            //        draggedRows.AddRange(rows1);
            //    }
            //}
            //SetDataSource(dt);

            OnSelectEvent?.Invoke(this, (object)draggedRows);
        }



        public static DataTable GetDataGridViewAsDataTable(DataGridView _DataGridView)
        {
            try
            {
                if (_DataGridView.ColumnCount == 0)
                    return null;
                DataTable dtSource = new DataTable();
                //////create columns
                foreach (DataGridViewColumn col in _DataGridView.Columns)
                {
                    if (col.ValueType == null)
                        dtSource.Columns.Add(col.Name, typeof(string));
                    else
                        dtSource.Columns.Add(col.Name, col.ValueType);
                    dtSource.Columns[col.Name].Caption = col.HeaderText;
                }
                ///////insert row data
                foreach (DataGridViewRow row in _DataGridView.Rows)
                {
                    DataRow drNewRow = dtSource.NewRow();
                    foreach (DataColumn col in dtSource.Columns)
                    {
                        drNewRow[col.ColumnName] = row.Cells[col.ColumnName].Value;
                    }
                    dtSource.Rows.Add(drNewRow);
                }
                return dtSource;
            }
            catch
            {
                return null;
            }
        }
    }
}
