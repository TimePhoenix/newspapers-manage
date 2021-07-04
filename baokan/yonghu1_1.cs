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
    public partial class yonghu1_1 : Form
    {
        public yonghu1_1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void yonghu1_1_Load(object sender, EventArgs e)
        {
            BookTable_yh();
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }

        //从数据视图读取数据，并显示
        public void BookTable_yh()
        {
            //首先将order数据清空
            dataGridView1.Rows.Clear();

            //实例化对数据库的操作
            Dataconnct dao = new Dataconnct();
            string sql = "SELECT * FROM YH ";

            //读取数据查询结果
            IDataReader dc = dao.read(sql);

            //对查询结果一行一行地读
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString(), dc[6].ToString());

            }

            //关闭连接
            dc.Close();
            dao.DataconnctClose();

        }

        //按刊号查询,根据报刊号查询并显示
        public void BookTable_SearchbyNumber_YH()
        {
            //首先将order数据清空
            dataGridView1.Rows.Clear();

            //实例化对数据库的操作
            Dataconnct dao = new Dataconnct();
            string sql = $"SELECT * FROM YH WHERE BookNumber ='{textBox1.Text}'";

            //读取数据查询结果
            IDataReader dc = dao.read(sql);

            //对查询结果一行一行地读
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString(), dc[6].ToString());

            }

            //关闭连接
            dc.Close();
            dao.DataconnctClose();

        }


        //按刊名查询,模糊查询
        public void BookTable_SearchbyName_YH()
        {
            //首先将order数据清空
            dataGridView1.Rows.Clear();

            //实例化对数据库的操作
            Dataconnct dao = new Dataconnct();
            //模糊查询%__%
            string sql = $"SELECT * FROM YH WHERE BookName LIKE '%{textBox2.Text}%'";

            //读取数据查询结果
            IDataReader dc = dao.read(sql);

            //对查询结果一行一行地读
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString(), dc[6].ToString());

            }

            //关闭连接
            dc.Close();
            dao.DataconnctClose();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            BookTable_SearchbyNumber_YH();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            BookTable_SearchbyName_YH();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //获取书号
            string bid      = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string bname    = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            string price    = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            string byuliang = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            int Byuliang    = int.Parse(byuliang);
            if (Byuliang < 1)
            {
                MessageBox.Show("余量不足，无法购买！");
            }
            else
            {
                yonghu1_1_2 yh1_1_2 = new yonghu1_1_2(bid, bname, price, byuliang);
                yh1_1_2.ShowDialog();
                BookTable_yh();
            }
        }
    }
}
