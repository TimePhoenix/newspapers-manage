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
    public partial class guang_li_yuan_deluser : Form
    {
        public guang_li_yuan_deluser()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dataconnct Dataconnct = new Dataconnct();
            string sql = $"SELECT * FROM YongHu WHERE YongHuNumber = '{textBox1.Text}'";
            //查看输入的用户是否存在
            IDataReader dc = Dataconnct.read(sql);
            if (textBox1.Text != "")
            {
               
                //对查询结果一行一行地读
                if (dc.Read())
                {
                    string sql_check_order = $"SELECT * FROM Order_YH WHERE YongHuNumber = '{textBox1.Text}'";
                    dc = Dataconnct.read(sql_check_order);
                    bool flag = false;
                    while (dc.Read())
                    {
                        dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString());
                        flag = true;
                    }
                    if (flag)
                    {
                        dataGridView1.Show();
                        MessageBox.Show($"用户ID:{textBox1.Text}已在系统中消费，不能删除!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        
                    }
                    else
                    {
                        string del_user_sql = $"DELETE FROM YongHu WHERE YongHuNumber = '{textBox1.Text}'";
                        if (Dataconnct.Execute(del_user_sql) > 0)
                        {
                            MessageBox.Show("删除成功！");
                        }
                        else
                        {
                            MessageBox.Show("删除失败！");
                        }
                    }



                    
                }
                else
                {
                    MessageBox.Show("该用户不存在！请检查后再输入！");
                }

               

            }

            else
            {
                MessageBox.Show("ID不能为空！");
            }
            dc.Close();
            Dataconnct.DataconnctClose();
        }

        private void guang_li_yuan_deluser_Load(object sender, EventArgs e)
        {
            dataGridView1.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Hide();
        }
    }
}
