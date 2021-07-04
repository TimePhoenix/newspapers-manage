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
    public partial class yonghu_fixed : Form
    {
        string DID = "";
        float DMoney = 0;
        int quan = 0;
        string BID = "";

       // string Monthpay = "";
        public yonghu_fixed()
        {
            InitializeComponent();
        }

        public yonghu_fixed(string Did,string Yid, string Yname, string Bid, string Bname,string Dquan,string Dqishu,string Ddate,string Dpay)
        {
            InitializeComponent();
            
            DID = label9.Text = Did;
            label10.Text = Yid;
            label11.Text = Yname;
            BID = label12.Text = Bid;
            label13.Text = Bname;
            textBox1.Text = Dquan;
            textBox2.Text = Dqishu;
            label15.Text = Ddate;
            DMoney = float.Parse(Dpay);
            quan   = int.Parse(Dquan);
            Oridate();
        }


        public void Oridate()
        {
            dataGridView1.Rows.Clear();
            string sql = $"SELECT BookNumber,BookName,MonthPay,Bookamount FROM Book WHERE   BookNumber = '{BID}'";
            Dataconnct dao = new Dataconnct();
            IDataReader dc = dao.read(sql);
            if (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(),dc[3].ToString());

            }
            //关闭连接
            dc.Close();
            dao.DataconnctClose();

            

        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == '\b' || (e.KeyChar >= '0' && e.KeyChar <= '9')))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == '\b' || (e.KeyChar >= '0' && e.KeyChar <= '9')))
            {
                e.Handled = true;
            }
        }

        private void yonghu_fixed_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                int number1 = int.Parse(textBox1.Text);      //报刊份数
                int number2 = int.Parse(textBox2.Text);      //订阅期数
                int Bamount = int.Parse(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());

                string Monthpay = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                float payMonth = float.Parse(Monthpay);
                if (number1 != 0 && number2 != 0)
                {
                    if (Bamount < 1 || Bamount < number1)
                    {
                        MessageBox.Show("库存容量不足!", "遇到错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {

                        float temp_sum = number1 * number2 * payMonth - DMoney;
                        int newamon =  Bamount - number1 + quan;
                       
                        label14.Text = temp_sum.ToString() + " RMB";
                        //修改订单的“份数”和“期数”
                        string sql = $"UPDATE BookOrder SET FenShu = '{number1}',Cycle = '{number2}' WHERE NumberOrder = '{DID}';UPDATE Book SET  Bookamount = '{newamon}' WHERE BookNumber = '{BID}'"; 
                        Dataconnct dao = new Dataconnct();
                        if (dao.Execute(sql) > 2)
                        {
                            MessageBox.Show($"用户:{Data.UName}成功修改订单信息！");
                            //flush
                            
                        }
                        else
                        {
                            MessageBox.Show("修改失败！请联系管理员", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        dao.DataconnctClose();

                        Oridate();
                    }
                }
                else
                {
                    MessageBox.Show("如不想订阅，请返回上一级界面取消订单！");

                }
            }
            else
            {
                MessageBox.Show("订单数量或订阅的期数不能为空！");


            }

        }
          
        

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                int number1 = int.Parse(textBox1.Text);      //报刊份数
                int number2 = int.Parse(textBox2.Text);      //订阅期数
                string Monthpay = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();                                                //BID
                int Bamount = int.Parse(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
                float payMonth = float.Parse(Monthpay);
                if (number1 != 0 && number2 != 0)
                {
                    if (Bamount < 1 || Bamount < number1)
                    {
                        MessageBox.Show("库存容量不足!", "遇到错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        float temp_sum = number1 * number2 * payMonth - DMoney;
                        label14.Text = temp_sum.ToString() + " RMB";
                    }
                }
                else
                {
                    MessageBox.Show("如不想订阅，请返回上一级界面取消订单！");

                }
            }
            else
            {
                MessageBox.Show("订单数量或订阅的期数不能为空！");


            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
