using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baokan
{
    public partial class guangliyuan_btype : Form
    {
        public guangliyuan_btype()
        {
            InitializeComponent();
        }

        private void guangliyuan_btype_Load(object sender, EventArgs e)
        {
            BtypeInfo();
            label2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

            label3.Hide();
            dataGridView2.Hide();
        }


        //读取报刊分类信息
        public void BtypeInfo()
        {
            dataGridView1.Rows.Clear();

            Dataconnct dao = new Dataconnct();
            string sql = "SELECT * FROM GLY_Btype ";

            //读取数据查询结果
            IDataReader dc = dao.read(sql);

            //对查询结果一行一行地读
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString());

            }

            //关闭连接
            dc.Close();
            dao.DataconnctClose();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addBtype add_btype = new addBtype();
            add_btype.ShowDialog();
            BtypeInfo();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string tid      = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            string tname    = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            修改类别 type_1 = new 修改类别(tid, tname);
            type_1.ShowDialog();
            BtypeInfo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string B_type_id    = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            string sql_check_id = $"SELECT * FROM GLY_del_Btype WHERE BookType ='{B_type_id}'";
            bool flag = false;
            dataGridView2.Rows.Clear();

            Dataconnct dao = new Dataconnct();
            IDataReader idr = dao.read(sql_check_id);
            while (idr.Read())
            {
                dataGridView2.Rows.Add(idr[0].ToString(), idr[1].ToString(), idr[2].ToString(), idr[3].ToString(), idr[4].ToString());
                flag = true;
            }
            
            if (flag == true)
            {
                dataGridView2.Show();
                label3.Show();
                label3.Text = $"下面这些报刊正在使用分类编号:'{B_type_id}',无法删除";
                MessageBox.Show($"请先到报刊管理系统中解除报刊对分类编号{B_type_id}的使用，然后在进行删除", "错误提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string del_sql = $"DELETE FROM BookInType WHERE BookType = '{B_type_id}'";
                if (dao.Execute(del_sql) > 0)
                {
                    MessageBox.Show("删除成功！");
                }
                else
                {
                    MessageBox.Show("删除失败！");

                }

            }
            idr.Close();
            dao.DataconnctClose();
            BtypeInfo();

        }
    }
}
