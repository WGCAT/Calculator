using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        // Query
        const string calculation_history = "Select*from Calculation";
        
        public Form1()
        {
            InitializeComponent();
        }

        // 숫자 텍스트박스
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // 덧셈 버튼
        private void button1_Click(object sender, EventArgs e)
        {

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

        // 결과 버튼
        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
