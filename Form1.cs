using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        const string connection_address = "Data Source=WGCAT;Initial Catalog=history;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        DataTable dt = new DataTable();

        // Query 변수 선언
        const string calculationHistoryQuery = "Select * from Calculation";

        int number = 0;
        int numberCal = 0;
        string sign = "";
        string history = "";
        bool flag = false;

        public Form1()
        {
            InitializeComponent();
        }

        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // 덧셈 버튼
        private void button1_Click(object sender, EventArgs e)
        {
                    number = int.Parse(textBox1.Text);
            if (sign == "+")
                {
                flag = true;
                numberCal = numberCal + number;
                }
            else if (sign == "-")
                {
                flag = true;
                numberCal = numberCal - number;
                }
            else if (sign == "*")
                {
                flag = true;
                numberCal = numberCal * number;
                }
            else if (sign == "/")
                {
                flag = true;
                numberCal = numberCal / number;
                }
            else if (sign == "")
            {
                numberCal = number;
            }
            sign = "+";
            history = history + textBox1.Text + sign;



            using (SqlConnection sqlCon = new SqlConnection(connection_address))
            {
                if (!flag)
                {
                    using (SqlCommand dbcmd = new SqlCommand("Insert Into Calculation Values('" + history + "', '"+ numberCal +"')", sqlCon))
                    {
                        try
                        {
                            sqlCon.Open();
                            dbcmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("덧셈db에러1" + ex.Message);
                        }
                    }
                }
                else
                {
                    using (SqlCommand dbcmd = new SqlCommand("UPDATE Calculation SET calculate = '" + history + "', result =  '"+ numberCal + "' WHERE id = (SELECT MAX(id) FROM Calculation);", sqlCon))
                    {
                        try
                        {
                            sqlCon.Open();
                            dbcmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("덧셈db에러2" + ex.Message);
                        }
                    }
                }
            }

            textBox1.Text = "";
            listBox1.Items.Add(history);
            labelResult.Text = numberCal.ToString();
        }
        // 뺄셈 버튼
        private void button2_Click(object sender, EventArgs e)
        {

        }

        // 곱셈 버튼
        private void button3_Click(object sender, EventArgs e)
        {

        }
        // 나눗셈 버튼
        private void button4_Click(object sender, EventArgs e)
        {

        }

        // 계산 버튼
        private void button5_Click(object sender, EventArgs e)
        {
            number = int.Parse(textBox1.Text);

            try
            {
                if (sign == "+")
                {
                    number = int.Parse(textBox1.Text);
                    numberCal = numberCal + number;
                    sign = "=";
                    history = history + textBox1.Text + sign;
                }
                else if (sign == "-")
                {
                    number = int.Parse(textBox1.Text);
                    numberCal = numberCal - number;
                    sign = "=";
                    history = history + textBox1.Text + sign;
                }
                else if (sign == "*")
                {
                    number = int.Parse(textBox1.Text);
                    numberCal = numberCal * number;
                    sign = "=";
                    history = history + textBox1.Text + sign;
                }
                else if (sign == "/")
                {
                    number = int.Parse(textBox1.Text);
                    numberCal = numberCal / number;
                    sign = "=";
                    history = history + textBox1.Text + sign;
                }

            }
            catch (Exception ex)
            {
                if (sign == "")
                {
                MessageBox.Show("계산식을 입력해주세요" + ex.Message);
                }
            }

            sign = "";

            using (SqlConnection sqlCon = new SqlConnection(connection_address))
            {
                using (SqlCommand dbcmd = new SqlCommand(calculationHistoryQuery, sqlCon))
                {
                    try
                    {
                        // 데이터베이스 접속 시작
                        sqlCon.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(dbcmd);
                        adapter.Fill(dt);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error" + ex.Message);
                    }
                }
            }

            textBox1.Text = "";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Text = history;
        }

        private void labelResult_Click(object sender, EventArgs e)
        {
            labelResult.Text = numberCal.ToString();
        }
    }
}
