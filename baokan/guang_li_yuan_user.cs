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
    public partial class guang_li_yuan_user : Form
    {
        public guang_li_yuan_user()
        {
            InitializeComponent();
        }

        private void guang_li_yuan_user_Load(object sender, EventArgs e)
        {
            LookUser_GLY();
            label2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }

        //管理员查看用户信息
        public void LookUser_GLY()
        {
            //首先将order数据清空
            dataGridView1.Rows.Clear();

            //实例化对数据库的操作
            Dataconnct Dataconnct = new Dataconnct();
            string sql = $"SELECT * FROM Order_YH ";

            //读取数据查询结果
            IDataReader dc = Dataconnct.read(sql);

            //对查询结果一行一行地读
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString(), dc[6].ToString(), dc[7].ToString(), dc[8].ToString(), dc[9].ToString(), dc[10].ToString(), dc[11].ToString());

            }

            //关闭连接
            dc.Close();
            Dataconnct.DataconnctClose();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == '\b' || (e.KeyChar >= '0' && e.KeyChar <= '9')))
            {
                e.Handled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "")
             {
                dataGridView1.Rows.Clear();
                string sql_byid = $"SELECT * FROM Order_YH WHERE YongHuNumber = '{textBox1.Text}'";
                Dataconnct Dataconnct = new Dataconnct();
                IDataReader dc = Dataconnct.read(sql_byid);
                while (dc.Read())
                {
                    dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString(), dc[6].ToString(), dc[7].ToString(), dc[8].ToString(), dc[9].ToString(), dc[10].ToString(), dc[11].ToString());

                }

                //关闭连接
                dc.Close();
                Dataconnct.DataconnctClose();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                dataGridView1.Rows.Clear();
                string sql_byid = $"SELECT * FROM Order_YH WHERE NumberOrder = '{textBox2.Text}'";
                Dataconnct Dataconnct = new Dataconnct();
                IDataReader dc = Dataconnct.read(sql_byid);
                while (dc.Read())
                {
                    dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString(), dc[6].ToString(), dc[7].ToString(), dc[8].ToString(), dc[9].ToString(), dc[10].ToString(), dc[11].ToString());

                }

                //关闭连接
                dc.Close();
                Dataconnct.DataconnctClose();

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            LookUser_GLY();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //获取主码订单号
            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                //确认一下是否真的要删除
                DialogResult dr = MessageBox.Show("真的要删除吗？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    string sql = $"DELETE FROM BookOrder WHERE NumberOrder = '{id}'";
                    Dataconnct Dataconnct = new Dataconnct();
                    if (Dataconnct.Execute(sql) > 0)
                    {
                        MessageBox.Show("删除成功！");
                        //flush
                        LookUser_GLY();

                    }
                    else
                    {
                        MessageBox.Show("删除失败！");

                    }

                    Dataconnct.DataconnctClose();

                }

            }
            catch
            {
                MessageBox.Show("请先选中一行！");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            guang_li_yuan_consume yh_consume = new guang_li_yuan_consume();
            yh_consume.ShowDialog();
            LookUser_GLY();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            guang_li_yuan_sales gly_sales = new guang_li_yuan_sales();
            gly_sales.ShowDialog();
            LookUser_GLY();
        }
    }
}