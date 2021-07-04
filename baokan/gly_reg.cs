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
    public partial class gly_reg : Form
    {
        public gly_reg()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                string sql_adm_check = $"SELECT * FROM GuanLiYuan WHERE GLYName = '{textBox1.Text}'";
                Dataconnct Dataconnct = new Dataconnct();
                IDataReader sd = Dataconnct.read(sql_adm_check);
                if (sd.Read())
                {

                    MessageBox.Show("该管理员名称已存在，请修改用户名！");
                }
                else
                {
                    if (textBox2.Text == textBox3.Text)
                    {
                        string adm_insert = $"INSERT INTO GuanLiYuan VALUES('{textBox1.Text}','{textBox2.Text}')";
                        if (Dataconnct.Execute(adm_insert) > 0)
                        {

                            MessageBox.Show("管理员账户创建成功！");
                        }
                        else
                        {
                            MessageBox.Show("管理员账户创建失败！");

                        }
                    }
                    else
                    {
                        MessageBox.Show("两次密码输入不一致！");

                    }

                }


                sd.Close();
                Dataconnct.DataconnctClose();
            }

            else
            {

                MessageBox.Show("不能为空！");
            }
        }
    }
}
