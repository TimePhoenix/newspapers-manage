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
    public partial class yonghu1_1_1 : Form
    {
        public yonghu1_1_1()
        {
            InitializeComponent();
            BookTable_user();
        }

        private void yonghu1_1_1_Load(object sender, EventArgs e)
        {
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }

        public void BookTable_user()
        {
            //首先将order数据清空
            dataGridView1.Rows.Clear();

            //实例化对数据库的操作
            Dataconnct dao = new Dataconnct();
            string sql = $"SELECT * FROM Order_YH WHERE YongHuNumber = '{Data.UID}'";

            //读取数据查询结果
            IDataReader dc = dao.read(sql);

            //对查询结果一行一行地读
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString(), dc[6].ToString(), dc[7].ToString(), dc[8].ToString(), dc[9].ToString(), dc[10].ToString(), dc[11].ToString());

            }

            //关闭连接
            dc.Close();
            dao.DataconnctClose();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BookTable_user();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }

        //取消订单
        private void button2_Click(object sender, EventArgs e)
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
                    Dataconnct dao = new Dataconnct();
                    if (dao.Execute(sql) > 0)
                    {
                        MessageBox.Show("退订成功！");
                        //flush
                        BookTable_user();

                    }
                    else
                    {
                        MessageBox.Show("退订失败！请联系管理员删除！");

                    }

                    dao.DataconnctClose();

                }

            }
            catch
            {
                MessageBox.Show("请先选中一行！");
            }


        }

        //订单信息修改
        private void button3_Click(object sender, EventArgs e)
        {
            //try
            //{
                string Did = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string Yid = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string Yname = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string Bid = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                string Bname = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                string Dquan = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                string Dqishu = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                string Ddate = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                string Dpay = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();

                /*string sql = $"SELECT MonthPay FROM Book WHERE   BookNumber = '{Bid}'";
            
                Dataconnct dao = new Dataconnct();
                IDataReader dc = dao.read(sql);
                if (dc.Read())
                {
                string Monthpay = dc["MonthPay"].ToString();
                }
                MessageBox.Show($"{Bid}");
            //关闭连接
                dc.Close();
                dao.DataconnctClose();
                */

                yonghu_fixed yh_fix = new yonghu_fixed(Did,Yid,Yname,Bid,Bname,Dquan,Dqishu,Ddate,Dpay);
                yh_fix.ShowDialog();
                BookTable_user();
            // }
            try
            { }
            catch
            {
                MessageBox.Show("请先选中一行！");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
