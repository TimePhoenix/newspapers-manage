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
    public partial class yonghu_pad_fixed : Form
    {
        public yonghu_pad_fixed()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void yonghu_pad_fixed_Load(object sender, EventArgs e)
        {
            label5.Text = Data.UID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool oripsd = false;
            string sql = $"SELECT * FROM YongHu WHERE YongHuNumber = '{Data.UID}' AND YongHuPassword ='{textBox1.Text}'";
            Dataconnct dao = new Dataconnct();
            IDataReader rd = dao.read(sql);
            if (rd.Read())
            {
                 oripsd =true;
            }
            rd.Close();
            dao.DataconnctClose();
            if (oripsd )
            {
                if (textBox2.Text != "" && textBox3.Text != "")
                {
                    string sql_temp = $"SELECT * FROM YongHu WHERE YongHuNumber = '{Data.UID}' AND YongHuPassword ='{textBox2.Text}'";
                    bool temp_flag = false;
                    Dataconnct dao_temp = new Dataconnct();
                    IDataReader rd_temp = dao_temp.read(sql_temp);
                    if (rd_temp.Read())
                    {
                        temp_flag = true;
                    }

                    rd_temp.Close();
                    dao_temp.DataconnctClose();

                    if (temp_flag)
                    {
                        MessageBox.Show("设置的新密码，不能和原来的密码相同！");

                    }

                    else
                    {
                        if (textBox2.Text == textBox3.Text)
                        {

                            // MessageBox.Show("pass"); 调试，通过
                            string sql_fixed = $"UPDATE YongHu SET YongHuPassword = '{textBox2.Text}' WHERE YongHuNumber = '{Data.UID}'";
                            Dataconnct dao_psd = new Dataconnct();
                            if (dao_psd.Execute(sql_fixed)>0)
                            {
                                MessageBox.Show("密码修改完成，请妥善保管您的密码！", "温馨提示");

                            }
                            dao.DataconnctClose();

                        }
                        else
                        {

                            MessageBox.Show("新密码两次输入不一致！");

                        }

                    }
                    //temp_flag = false;
                }
                else
                {
                    MessageBox.Show("不能为空！");


                }
            }
            else
            {
                MessageBox.Show("原密码输入错误！");


            }
           // oripsd = false;


        }
    }
}
