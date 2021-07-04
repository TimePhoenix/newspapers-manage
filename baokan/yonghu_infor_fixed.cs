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
    public partial class yonghu_infor_fixed : Form
    {
        public yonghu_infor_fixed()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void yonghu_infor_fixed_Load(object sender, EventArgs e)
        {
            //首先读取信息
            Dataload();
        }

        public void Dataload()
        {
            dataGridView1.Rows.Clear(); ;
            string sql = $"SELECT * FROM YH_base_infor WHERE YongHuNumber = '{Data.UID}'";
            Dataconnct dao = new Dataconnct();
            IDataReader sc = dao.read(sql);
            if (sc.Read())
            {
                dataGridView1.Rows.Add(sc[0].ToString(), sc[1].ToString(), sc[2].ToString(), sc[3].ToString());

            }


            textBox1.Text = sc[1].ToString();
            textBox2.Text = sc[2].ToString();
            textBox3.Text = sc[3].ToString();



            sc.Close();
            dao.DataconnctClose();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                //更新的sql语句
                string sql = $"UPDATE YongHu SET RealName = '{textBox1.Text}',Tel = '{textBox2.Text}',Addr = '{textBox3.Text}' WHERE YongHuNumber = '{Data.UID}'";
                Dataconnct dao = new Dataconnct();
                if (dao.Execute(sql) > 0)
                {
                    MessageBox.Show("信息修改成功，祝您购物愉快！", $"用户{Data.UName}");
                    //flush
                    Dataload();
                }
                else
                {

                    MessageBox.Show("信息修改失败！请联系管理员");

                }

            }
         }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == '\b' || (e.KeyChar >= '0' && e.KeyChar <= '9')))
            {
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //textBox2.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

        }
    }
}
