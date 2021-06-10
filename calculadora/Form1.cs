using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculadora
{
    public partial class Form1 : Form
    {
        //função para fatorial
        public static decimal Fatorial(decimal a)
        {
            return ((a <= 1) ? 1 : (a * Fatorial(a - 1)));//função recursiva
        }

        //iniciei uma função para chamar mais vezes esta operação
        public void calcula() 
        {
            if (operador == "+")//adição
            {
                label1.Text = label1.Text + txt_valor.Text + "=";
                txt_valor.Text = Convert.ToString(a + Convert.ToDecimal(txt_valor.Text));
            }
            else if (operador == "-")//subtração
            {
                label1.Text = label1.Text + txt_valor.Text + "=";
                txt_valor.Text = Convert.ToString(a - Convert.ToDecimal(txt_valor.Text));
            }
            else if (operador == "x")//multiplicação
            {
                label1.Text = label1.Text + txt_valor.Text + "=";
                txt_valor.Text = Convert.ToString(a * Convert.ToDecimal(txt_valor.Text));
            }
            else if (operador == "/")//divisão
            {
                label1.Text = label1.Text + txt_valor.Text + "=";
                txt_valor.Text = Convert.ToString(a / Convert.ToDecimal(txt_valor.Text));
            }
            else if (operador == "rz")//raiz quadrada
            {
                label1.Text = label1.Text + " =";
                txt_valor.Text = Convert.ToString(Math.Sqrt(Convert.ToInt32(a)));
            }
            else if (operador == "!")//fatorial
            {
                label1.Text = label1.Text + " =";
                f= Fatorial(a);
                txt_valor.Text = Convert.ToString(f);
            }
        }

        //variaveis
        String operador;//operador para os sinais
        decimal f, a = 0;// f para o fatorial, a para armazenar e susceder calculo
        bool validar = false;//bool para validar a ordem

        public Form1()
        {
            InitializeComponent();
        }

        private void btnNumerador_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender; //recebendo o valor do botão apertado
            txt_valor.Text = txt_valor.Text + bt.Text; //inserindo o valor na tela
        }

        private void btn_limpar_Click(object sender, EventArgs e)
        {
            //limpando as variaveis
            validar = false;
            label1.Text = "";
            txt_valor.Text = "";
            a = 0;
        }
        private void btn_igual_Click(object sender, EventArgs e)
        {
            calcula(); //chamando função
            validar = false; //para iniciar calculo com base no else do operador
        }

        private void btn_subtracao_Click(object sender, EventArgs e)
        {
            if (validar == true)// caso o usuario nao aperte o btn_igual, calcula diretamente
            {
                if (operador == "-")//caso o usuario mude o operador, seja feito o ultimo calculo
                {
                    a = a - Convert.ToDecimal(txt_valor.Text);
                }
                else
                {
                    calcula(); //chamando a função para calcular com operador anterior
                    a = Convert.ToDecimal(txt_valor.Text);
                }
                label1.Text = Convert.ToString(a) + "-";
                txt_valor.Text = "";
                operador = "-";

            }
            else
            {
                label1.Text = txt_valor.Text + btn_subtracao.Text;
                a = Convert.ToDecimal(txt_valor.Text);
                txt_valor.Text = "";
                operador = "-";
                validar = true;
            }
        }

        private void btn_adicao_Click(object sender, EventArgs e)
        {
            if (validar == true)
            {
                if (operador == "+")//caso o usuario mude o operador, seja feito o ultimo calculo
                {
                    a = a + Convert.ToDecimal(txt_valor.Text);
                }
                else
                {
                    calcula(); //chamando a função para calcular com operador anterior
                    a = Convert.ToDecimal(txt_valor.Text);
                }
                label1.Text = Convert.ToString(a) + "+";
                txt_valor.Text = "";
                operador = "+";
            }
            else
            {
                label1.Text = txt_valor.Text + btn_adicao.Text;
                a = Convert.ToDecimal(txt_valor.Text);
                txt_valor.Text = "";
                operador = "+";
                validar = true;
            }
        }

        private void btn_multiplicacao_Click(object sender, EventArgs e)
        {
            if (validar == true)
            {
                if (operador == "x")//caso o usuario mude o operador, seja feito o ultimo calculo
                {
                    a = a * Convert.ToDecimal(txt_valor.Text);
                }
                else
                {
                    calcula(); //chamando a função para calcular com operador anterior
                    a = Convert.ToDecimal(txt_valor.Text);
                }
                label1.Text = Convert.ToString(a) + "x";
                txt_valor.Text = "";
                operador = "x";
            }
            else
            {
                label1.Text = txt_valor.Text + btn_multiplicacao.Text;
                a = Convert.ToDecimal(txt_valor.Text);
                txt_valor.Text = "";
                operador = "x";
                validar = true;
            }
        }

        private void btn_divisao_Click(object sender, EventArgs e)
        {
            if (validar == true)
            {
                if (operador == "/")//caso o usuario mude o operador, seja feito o ultimo calculo
                {
                    a = a / Convert.ToDecimal(txt_valor.Text);
                }
                else
                {
                    calcula(); //chamando a função para calcular com operador anterior
                    a = Convert.ToDecimal(txt_valor.Text);
                }
                label1.Text = Convert.ToString(a) + "/";
                txt_valor.Text = "";
                operador = "/";
            }
            else
            {
                label1.Text = txt_valor.Text + btn_divisao.Text;
                a = Convert.ToDecimal(txt_valor.Text);
                txt_valor.Text = "";
                operador = "/";
                validar = true;
            }
        }

        private void btn_raiz_Click(object sender, EventArgs e)
        //botão para raiz quadrada, existe reprtição no codigo para que o usuario selecione os botões se ter erros
        {
            if (validar == true)
            {
                if (operador == "rz")//caso o usuario mude o operador, seja feito o ultimo calculo
                {
                }
                else
                {
                    calcula(); //chamando a função para calcular com operador anterior
                }
                label1.Text = txt_valor.Text + " raiz";
                a = Convert.ToDecimal(txt_valor.Text); // calculo referente ao inicial
                txt_valor.Text = "";
                operador = "rz";
                calcula();//para ser feito o calculo ao clicar no botão da raiz
            }
            else
            {
                label1.Text = txt_valor.Text + " raiz";
                a = Convert.ToDecimal(txt_valor.Text);
                txt_valor.Text = "";
                operador = "rz";
                validar = true;
                calcula();//para ser feito o calculo ao clicar no botão da raiz
            }
        }

        private void btn_fatorial_Click(object sender, EventArgs e)
        {
            if (validar == true)
            {
                if (operador == "!")//caso o usuario mude o operador, seja feito o ultimo calculo
                {
                }
                else
                {
                    calcula(); //chamando a função para calcular com operador anterior
                }
                label1.Text = txt_valor.Text + " !";
                a = Convert.ToDecimal(txt_valor.Text); // calculo referente ao inicial
                txt_valor.Text = "";
                operador = "!";
                calcula();//para ser feito o calculo ao clicar no botão da raiz
            }
            else
            {
                label1.Text = txt_valor.Text + " !";
                a = Convert.ToDecimal(txt_valor.Text);
                txt_valor.Text = "";
                operador = "!";
                validar = true;
                calcula();//para ser feito o calculo ao clicar no botão da raiz
            }
        }
    }
}
