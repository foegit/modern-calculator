using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace calculator
{
   
    public partial class ExzoForm : Form
    {
        int signs;
        int maxSign = 20;
        bool isDotInNum = false;
        bool isNewExp = true;
        bool isOutPut = false;
        Queue<string> log = new Queue<string>();

        double result;
        char operation;
   


        public ExzoForm()
        {
            InitializeComponent();
            signs = 0;
        }

        private void changeDisplayText(String str)
        {
            
            display.Text = str;
            signs = str.Length;
        }

        private void appendDisplayText(String str)
        {
            String currentText = display.Text;
            
            if ((currentText != "0" || str == ",") && !isOutPut)
            {
                if (signs <= maxSign)
                {
                    
                    display.Text += str;
                    signs += str.Length;
                }
            }
            else 
            {
                changeDisplayText(str);
                isOutPut = false;
            }
        }

      

        
           
        private void ExzoForm_Load(object sender, EventArgs e)
        {
           
        }

        private void clean_Click(object sender, EventArgs e)
        {
            changeDisplayText("0");
            result = 0;
            operation = ' ';
            isNewExp = true;
            cleanStatusBar();
        }
        private void num1_Click(object sender, EventArgs e)
        {
            appendDisplayText("1");
        }
        private void num2_Click(object sender, EventArgs e)
        {
            appendDisplayText("2");
        }
        private void num3_Click(object sender, EventArgs e)
        {
            appendDisplayText("3");
        }
        private void num4_Click(object sender, EventArgs e)
        {
            appendDisplayText("4");
        }
        private void num5_Click(object sender, EventArgs e)
        {
            appendDisplayText("5");
        }
        private void num6_Click(object sender, EventArgs e)
        {
            appendDisplayText("6");
        }
        private void num7_Click(object sender, EventArgs e)
        {
            appendDisplayText("7");
        }
        private void num8_Click(object sender, EventArgs e)
        {
            appendDisplayText("8");
        }
        private void num9_Click(object sender, EventArgs e)
        {
            appendDisplayText("9");
        }
        private void num0_Click(object sender, EventArgs e)
        {
            appendDisplayText("0");
        }

        

        private void delete_Click(object sender, EventArgs e)
        {
            deleteLastNum();
        }

        private void deleteLastNum()
        {
            if (display.Text.Length != 1)
            {
                String currentText = display.Text;
                currentText = currentText.Remove(currentText.Length-1);
                changeDisplayText(currentText);
            }
            else
            {
                changeDisplayText("0");
                isOutPut = true;
            }
            
          

        }

        private void dot_Click(object sender, EventArgs e)
        {
            if (!isDotInNum)
            {
                appendDisplayText(",");
                isDotInNum = true;
            }
            
        }

        private void plus_Click(object sender, EventArgs e)
        {
            setData("+");
            
        }
        private void minus_Click(object sender, EventArgs e)
        {
            
            setData("-");
        }

        private void times_Click(object sender, EventArgs e)
        {
            setData("*");
        }

        private void divide_Click(object sender, EventArgs e)
        {
            setData("/");
        }
        private void pow_Click(object sender, EventArgs e)
        {
            setData("^");
        }

        private void ch_Click(object sender, EventArgs e)
        {
            setData("%");
        }
        private void binRight_Click(object sender, EventArgs e)
        {
            setData(">>");
        }

        private void binLeft_Click(object sender, EventArgs e)
        {
            setData("<<");
        }

        private void calculate_Click(object sender, EventArgs e)
        {
            //calc(double.Parse(display.Text));
            log.Enqueue(display.Text);
            addToStatusBar(display.Text + " = ");
            calc();
        }
        private void and_Click(object sender, EventArgs e)
        {
            setData("&");
        }

        private void or_Click(object sender, EventArgs e)
        {
            setData("|");
        }

        private void xor_Click(object sender, EventArgs e)
        {
            setData("x");
        }
        private void setData(string sign)
        {
            
            log.Enqueue(display.Text);
            log.Enqueue(sign);
            addToStatusBar(display.Text+ " " + sign + " ");
            changeDisplayText("0");
            isDotInNum = false;
        }
        

        private void calc()
        {
           
           
            double res;
            char sign;
            double num;
            res = double.Parse(log.Dequeue()); 
            while (log.Count() > 0)
            {
                    
                sign = log.Dequeue()[0];
                num = double.Parse(log.Dequeue());
                res = calculation(res, num, sign);
            }
           
            addToStatusBar(res.ToString() + "\n" );
            addToStatusBar("----- " + "\n");;
            changeDisplayText(res.ToString());
          
            isOutPut = true;   
        }

        private double calculation(double num1, double num2, char sign)
        {
            
            double res = num1;
            switch (sign)
            {
                case '+': res += num2; break;
                case '-': res -= num2; break;
                case '*': res *= num2; break;
                case '/': res /= num2; break;
                case '^': res = Math.Pow(res, num2); break;
                case '%': res %= num2; break;
                case '<': res = (int)res<<(int)num2;break;
                case '>': res = (int)res >> (int)num2; break;
                case '&': res = (int)res & (int)num2; break;
                case '|': res = (int)res | (int)num2; break;
                case 'x': res = (int)res ^ (int)num2; break;
               

            }
            return res;
        }

        private void addToStatusBar(string str)
        {
            statusBar.AppendText(str);
        }
        private void cleanStatusBar()
        {
            statusBar.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void deleteExp_Click(object sender, EventArgs e)
        {
            changeDisplayText("0");
        }

        
    }
}
