using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static List<char> operators = new List<char> { '*', '/', '(', ')', '-','+'};

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddOperand('+');
        }

        private void sub_Click(object sender, EventArgs e)
        {
            AddOperand('-');
        }

        private void mul_Click(object sender, EventArgs e)
        {
            AddOperand('*');
        }

        private void div_Click(object sender, EventArgs e)
        {
            AddOperand('/');
        }

        private void leftbr_Click(object sender, EventArgs e)
        {
            AddOperand('(');
        }

        private void rightbr_Click(object sender, EventArgs e)
        {
            AddOperand(')');
        }
        private void AddOperand(char i)
        {
            textBox1.AppendText(i.ToString());
        }
        private void AddNum(int i)
        {
            textBox1.AppendText(i.ToString());
        }

        private void one_Click(object sender, EventArgs e)
        {
            AddNum(1);
        }

        private void two_Click(object sender, EventArgs e)
        {
            AddNum(2);
        }

        private void three_Click(object sender, EventArgs e)
        {
            AddNum(3);
        }

        private void four_Click(object sender, EventArgs e)
        {
            AddNum(4);
        }

        private void five_Click(object sender, EventArgs e)
        {
            AddNum(5);
        }

        private void six_Click(object sender, EventArgs e)
        {
            AddNum(6);
        }

        private void seven_Click(object sender, EventArgs e)
        {
            AddNum(7);
        }

        private void eight_Click(object sender, EventArgs e)
        {
            AddNum(8);
        }

        private void nine_Click(object sender, EventArgs e)
        {
            AddNum(9);
        }

        private void zero_Click(object sender, EventArgs e)
        {
            AddNum(0);
        }
        private void res_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            string polska = Polska(s);
            textBox2.Text = polska;
            textBox3.Text = Convert.ToString(GetResult(polska));
        }
        private string Polska(string expression)
        {
            string output = string.Empty;
            MyStack<char> operStack = new MyStack<char>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (Char.IsDigit(expression[i]))
                {
                    while (!IsOperator(expression[i]))
                    {
                        output += expression[i];
                        i++; 
                        if (i == expression.Length) break;
                    }
                    output += " ";
                    i--;
                }
                if (IsOperator(expression[i]))
                {
                    if (expression[i] == '(')
                        operStack.Push(expression[i]);
                    else if (expression[i] == ')')
                    {
                        char s = operStack.Peek();
                        operStack.Pop();
                        while (s != '(')
                        {
                            output += s.ToString() + " ";
                            s = operStack.Peek();
                            operStack.Pop();
                        }
                    }
                    else
                    {
                        if (operStack.IsEmpty() == false)
                            if (priority(expression[i]) <= priority(operStack.Peek()))
                            {
                                output += operStack.Peek().ToString() + " ";
                                operStack.Pop();
                            }
                         operStack.Push(char.Parse(expression[i].ToString()));
                    }
                }
            }
            while (operStack.IsEmpty() == false)
            {
                output += operStack.Peek() + " ";
                operStack.Pop();
            }
            return output;
        }
        private bool IsDigit(char c)
        {
            return !operators.Contains(c);
        }
        static private bool IsOperator(char c)
        {
            return operators.Contains(c);
        }
        static private bool IsDelimeter(char c)    
        {
            if ((" ".IndexOf(c) != -1))
                return true;
            return false;
        }
        static private byte priority(char s)
        {
            switch (s)
            {
                case '(': return 0;
                case ')': return 1;
                case '+': return 2;
                case '-': return 2;
                case '*': return 3;
                case '/': return 3;
                default: return 4;
            }
        }
        static private double GetResult(string input)
        {
            double result = 0;
            MyStack<double> temp = new MyStack<double>();

            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    string a = string.Empty;

                    while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
                    {
                        a += input[i];
                        i++;
                        if (i == input.Length) break;
                    }
                    temp.Push(double.Parse(a));
                    i--;
                }
                else if (IsOperator(input[i]))
                {
                    double a = temp.Peek();
                    temp.Pop();
                    double b = temp.Peek();
                    temp.Pop();

                    switch (input[i])
                    {
                        case '+': result = b + a; break;
                        case '-': result = b - a; break;
                        case '*': result = b * a; break;
                        case '/': result = b / a; break;
                    }
                    temp.Push(result); 
                }
            }
            return temp.Peek();
        }
    }
}
