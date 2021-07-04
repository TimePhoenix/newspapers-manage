using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace baokan
{
    public partial class baokan : Form
    {
        public baokan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //两个文本框都不能为空
            if (textUser.Text != "" && txtPwd.Text != "")
            {
                login();

            }
            else
            {
                MessageBox.Show("输入项不能为空，请重新输入！");

            }


        }

        //登陆验证方法
        public void login()
        {
            //用户
            if (radioButton1yh.Checked == true)
            {
                //实例化一个dao
                Dataconnct dao = new Dataconnct();
                string sql = $"SELECT * FROM YongHu WHERE YongHuNumber = '{textUser.Text}' AND YongHuPassword ='{txtPwd.Text}'";
                //MessageBox.Show(sql);
                IDataReader dc = dao.read(sql);
                if (dc.Read())
                {
                    
                    Data.UID = dc["YongHuNumber"].ToString();
                    Data.UName = dc["RealName"].ToString();

                    MessageBox.Show("登录成功！");
                    //return true;

                    //打开用户窗体
                    yonghu1 yh1 = new yonghu1();
                    //隐藏旧窗体
                    this.Hide();
                    //打开用户第一个窗体
                    yh1.ShowDialog();
                    //用户窗体关闭后，显示原来的窗体
                    this.Show();
                }

                else
                {
                    MessageBox.Show("登陆失败！请检查密码或账号！");
                  //  return false;

                }
                // MessageBox.Show(dc[0].ToString()+dc[1].ToString());
                 dao.DataconnctClose();
            }
            
            //管理员
            if (radioButton2gly.Checked == true)
            {
                Dataconnct dao = new Dataconnct();
                string sql = $"SELECT * FROM GuanLiYuan WHERE GLYName = '{textUser.Text}' AND GLYPassword ='{txtPwd.Text}'";
                //MessageBox.Show(sql);
                IDataReader dc = dao.read(sql);
                if (dc.Read())
                {
                    Data.UID = dc["GLYName"].ToString();
                    MessageBox.Show("登录成功！");
                    //return true;

                    //打开用户窗体
                    guang_li_yuan gly1 = new guang_li_yuan();
                    //隐藏旧窗体
                    this.Hide();
                    //打开管理员第一个窗体
                    gly1.ShowDialog();
                    //用户窗体关闭后，显示原来的窗体
                    this.Show();
                }

                else
                {
                    MessageBox.Show("登陆失败！请检查密码或账号！");
                  //  return false;

                }
                dao.DataconnctClose();

            }

            //两种登录均失败，直接返回false
           // MessageBox.Show("出现故障，请检查单选框！");
           // return false;

        }  

        //注册用
        public void YH_register()
        {
            if (radioButton1yh.Checked == true)
            {
                yonghu_reg yh_reg = new yonghu_reg();
                yh_reg.ShowDialog();
            }
           

           else if(radioButton2gly.Checked == true)
            {
                gly_reg gly_regist = new gly_reg();
                gly_regist.ShowDialog();
            }
            else
            {
                MessageBox.Show("系统出现问题，请联系负责人！");

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            YH_register();
        }
    }
}
