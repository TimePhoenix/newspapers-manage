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
    public partial class gaung_li_yuan_fixeduser_info : Form
    {
        public gaung_li_yuan_fixeduser_info()
        {
            InitializeComponent();
        }

        private void gaung_li_yuan_fixeduser_info_Load(object sender, EventArgs e)
        {
            Dataload();
        }

        //显示用户信息
        public void Dataload()
        {
            dataGridView1.Rows.Clear(); ;
            string sql = $"SELECT * FROM YH_base_infor";
            Dataconnct Dataconnct = new Dataconnct();
            IDataReader sc = Dataconnct.read(sql);
            while (sc.Read())
            {
                dataGridView1.Rows.Add(sc[0].ToString(), sc[1].ToString(), sc[2].ToString(), sc[3].ToString());

            }

            if (dataGridView1.SelectedRows[0].Cells[0].Value.ToString() != "")
            {
                label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            }

            sc.Close();
            Dataconnct.DataconnctClose();

        }

        //按真名查询用户
        public void RnameDataload()
        {
            dataGridView1.Rows.Clear(); ;
            string sql = $"SELECT * FROM YH_base_infor WHERE RealName LIKE '%{textBox1.Text}%'";
            Dataconnct Dataconnct = new Dataconnct();
            IDataReader sc = Dataconnct.read(sql);
            while (sc.Read())
            {
                dataGridView1.Rows.Add(sc[0].ToString(), sc[1].ToString(), sc[2].ToString(), sc[3].ToString());

            }

            if (dataGridView1.SelectedRows[0].Cells[0].Value.ToString() != "")
            {
                label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            }

            sc.Close();
            Dataconnct.DataconnctClose();

        }


        //按ID查询用户
        public void IDDataload()
        {
            dataGridView1.Rows.Clear(); ;
            string sql = $"SELECT * FROM YH_base_infor WHERE YongHuNumber ='{textBox2.Text}'";
            Dataconnct Dataconnct = new Dataconnct();
            IDataReader sc = Dataconnct.read(sql);
            while (sc.Read())
            {
                dataGridView1.Rows.Add(sc[0].ToString(), sc[1].ToString(), sc[2].ToString(), sc[3].ToString());

            }

            if (dataGridView1.SelectedRows[0].Cells[0].Value.ToString() != "")
            {
                label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            }

            sc.Close();
            Dataconnct.DataconnctClose();

        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows[0].Cells[0].Value.ToString() != "")
            {
                label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                RnameDataload();
            }
            else
            {
                MessageBox.Show("用户真名不能为空！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                IDDataload();
            }
            else
            {
                MessageBox.Show("用户ID不能为空！");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Dataload();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try //(dataGridView1.SelectedRows[0].Cells[0].Value.ToString() != "" && dataGridView1.SelectedRows[0].Cells[1].Value.ToString() != "" && dataGridView1.SelectedRows[0].Cells[2].Value.ToString() != "" && dataGridView1.SelectedRows[0].Cells[3].Value.ToString() != "")
            {
                string yhid = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string rnaem = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string tel = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string addr = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                gly_fix_user_info_win gly_fix_uuser = new gly_fix_user_info_win(yhid, rnaem, tel,addr);
                gly_fix_uuser.ShowDialog();
                Dataload();
            }
            catch
            {
                MessageBox.Show("请选中一行！");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string Yid = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                DialogResult dr = MessageBox.Show("确认要充值该用户的密码吗？", "温馨提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                //密码重置为000
                string sql_reset_psd = $"UPDATE YongHu SET YongHuPassword = '000' WHERE YongHuNumber = 'Y100' ";
                Dataconnct Dataconnct = new Dataconnct();
                if (Dataconnct.Execute(sql_reset_psd) > 0)
                {
                    MessageBox.Show($"请通知ID为:{Yid}的用户，其密码重置为000");
                }
                else
                {
                    MessageBox.Show("重置失败!");
                }
                Dataconnct.DataconnctClose();
            }
            catch
            {
                MessageBox.Show("请先选中一个用户！");
            }
        }
    }
}
