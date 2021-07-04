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
    public partial class guang_li_yaun2 : Form
    {
        public guang_li_yaun2()
        {
            //窗体实例化时执行booktable（）
            InitializeComponent();

           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guang_li_yaun2_Load(object sender, EventArgs e)
        {
            BookTable();
            //获取当前选中的报刊号
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }


        //从数据读取数据，并显示
        public void BookTable()
        {
            //首先将order数据清空
            dataGridView1.Rows.Clear();

            //实例化对数据库的操作
            Dataconnct Dataconnct = new Dataconnct();
            string sql = "SELECT * FROM GLY_book_infor ";

            //读取数据查询结果
            IDataReader dc = Dataconnct.read(sql);

            //对查询结果一行一行地读
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString(), dc[6].ToString(), dc[7].ToString());

            }

            //关闭连接
            dc.Close();
            Dataconnct.DataconnctClose(); 

        }

        //按刊号查询,根据报刊号查询并显示
        public void BookTable_SearchbyNumber()
        {
            //首先将order数据清空
            dataGridView1.Rows.Clear();

            //实例化对数据库的操作
            Dataconnct Dataconnct = new Dataconnct();
            string sql = $"SELECT * FROM GLY_book_infor WHERE BookNumber ='{textBox2.Text}'";

            //读取数据查询结果
            IDataReader dc = Dataconnct.read(sql);

            //对查询结果一行一行地读
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString(), dc[6].ToString(), dc[7].ToString());

            }

            //关闭连接
            dc.Close();
            Dataconnct.DataconnctClose();

        }


        //按刊名查询,模糊查询
        public void BookTable_SearchbyName()
        {
            //首先将order数据清空
            dataGridView1.Rows.Clear();

            //实例化对数据库的操作
            Dataconnct Dataconnct = new Dataconnct();
            //模糊查询%__%
            string sql = $"SELECT * FROM GLY_book_infor WHERE BookName LIKE '%{textBox1.Text}%'";

            //读取数据查询结果
            IDataReader dc = Dataconnct.read(sql);

            //对查询结果一行一行地读
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString(), dc[6].ToString(), dc[7].ToString());

            }

            //关闭连接
            dc.Close();
            Dataconnct.DataconnctClose();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            guang_li_yuan2_1 gly2_1 = new guang_li_yuan2_1();
            gly2_1.ShowDialog();  //有一点问题，修正完毕topmost变为true
            BookTable();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //转为字符串格式
                //获取书号
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                DialogResult dr = MessageBox.Show("真的要删除吗？","信息提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                //确认删除
                if (dr == DialogResult.OK)
                {
                    string sql = $"DELETE FROM Book WHERE BookNumber = '{id}'";
                    Dataconnct Dataconnct = new Dataconnct();
                    //删除成功提示
                    if (Dataconnct.Execute(sql) > 0)
                    {
                        MessageBox.Show("删除成功！ "+sql);
                        //flush to 窗体
                        BookTable();
                    }
                    else
                    {
                        MessageBox.Show("删除失败！" + sql);

                    }
                    Dataconnct.DataconnctClose();
                }
            }
            //为避免一行也没有选中地状态
            catch
            {
                
                MessageBox.Show("无法删除！已有用户购买该书，无法删除！" ,"温馨提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);

            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string id       = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string bookname = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string pub      = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string pay      = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                string content  = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                string type     = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                string ntype    = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                string amount   = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                guang_li_yuan2_2 gly2_2 = new guang_li_yuan2_2(id,bookname,pub,pay,content,type,ntype,amount);
                gly2_2.ShowDialog();
                BookTable();
            }
            catch
            {
                MessageBox.Show("请先选中一行！");
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

            //清空（查询）文本框
            //flush to 窗体
            textBox1.Clear();
            textBox2.Clear();

            BookTable();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BookTable_SearchbyNumber();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            BookTable_SearchbyName();
        }
    }
}
