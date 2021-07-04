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
    public partial class yonghu_reg : Form
    {
        public yonghu_reg()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == '\b' || (e.KeyChar >= '0' && e.KeyChar <= '9')))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                string sql_ac_check = $"SELECT * FROM YongHu WHERE YongHuNumber = '{textBox1.Text}'";
                Dataconnct dao = new Dataconnct();
                IDataReader sd = dao.read(sql_ac_check);
                if (sd.Read())
                {

                    MessageBox.Show("该用户名已存在，请修改用户名！");
                }
                else
                {
                    if (textBox3.Text == textBox4.Text)
                    {
                        string sql_regist = $"INSERT INTO YongHu VALUES ('{textBox1.Text}','{textBox3.Text}','{textBox2.Text}','{textBox5.Text}','{textBox6.Text}')";
                        if (dao.Execute(sql_regist) > 0)
                        {
                            MessageBox.Show("注册成功！");
                        }
                        else
                        {
                            MessageBox.Show("注册失败！请稍后再试");
                        }
                    }
                    else
                    {
                        MessageBox.Show("两次输入的密码不同，请重新输入！");

                    }
                }
                sd.Close();
                dao.DataconnctClose();

            }
            else
            {
                MessageBox.Show("不能为空！");
            }
        }
    }
}
