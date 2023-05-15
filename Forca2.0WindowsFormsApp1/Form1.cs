using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forca2._0WindowsFormsApp1
{
    
    public partial class Form1 : Form
    {
        string Palavra, Tentadas;
        char Letras;
        int Quantidade = 0, Erros = 0  , Faltam = 0;
        bool achou = false ,  tenta = false ;
       
        private void btTenta_Click(object sender, EventArgs e)
        {
            // verifica se a letra foi achada 

            Letras = mtLetra.Text[0];
            for (int cont = 0; cont != Quantidade; cont++)
            {
                if (Letras == Escondido[cont])
                {
                    tenta = true; 
                }
                //verifica se a letra já foi tentanda 

                Tentadas = lbTentadas.Text;
                int quant = Tentadas.Length;
                for ( cont=0; cont!= quant; cont++)
                {
                    if (Letras == Tentadas[cont])
                    {
                         tenta = true;
                    }
                    if (tenta == true)
                    {
                        MessageBox.Show(" Vc ja digitou essa letra ");
                    }
                    else
                    {
                        for (cont = 0; cont != quant; cont++)
                        {
                            if (Letras == Palavra[cont])
                            {
                                Escondido[cont] = Letras;
                                achou = true;
                                Faltam = Faltam - 1;
                            }
                        }
                    }
                    lbPalavra.Text = "";
                    for ( cont= 0; cont != Quantidade; cont++)
                    {
                        lbPalavra.Text = lbPalavra.Text + Escondido[cont];
                    }
                    if (Faltam== 0)
                    {
                        MessageBox.Show("Parabéns vc Venceu");
                        tbPalavra.Enabled = true;
                        btComeca.Enabled = true;
                        mtLetra.Enabled = false;
                        btTenta.Enabled = false;
                        tbPalavra.Text = "";
                        tbPalavra.Focus();

                    }
                    if ((achou==false) & (tenta == false))
                    {
                        Erros  = Erros + 1;
                        lbTentadas.Text = lbTentadas.Text + " " + Letras;
                    }
                    //codigo que desenha o boneco 
                    if (Erros ==1)
                    { pbCabeca.Visible = true; }
                    if (Erros ==2)
                    { pbCorpo.Visible = true; }
                    if(Erros ==3)
                    { pbBracoE.Visible = true; }
                    if (Erros == 4)
                    { pbBracoD.Visible = true; }                    
                    if(Erros == 5)
                    {pbPernaD.Visible = true; }
                    if (Erros == 6) 
                    {
                        pbBracoE.Visible = true;
                        MessageBox.Show("Vc Perder");
                        tbPalavra.Enabled = true;
                        btComeca.Enabled=true;
                        mtLetra.Enabled=false;
                        btTenta.Enabled=false;
                        tbPalavra.Text = "";
                        tbPalavra.Focus();

                    }
                    //reinicializando 
                    tenta = false;
                    achou = false;
                    mtLetra.Text = "";
                    mtLetra.Focus();

                    lbFaltam.Text = Faltam.ToString();
                    lbErros.Text = Erros.ToString();

                }
            }
        }

        char[] Escondido;
        public Form1()
        {
            InitializeComponent();
            Escondido = new char[20];
        }

        private void btComeca_Click(object sender, EventArgs e)
        {
            Palavra = tbPalavra.Text;
            Quantidade = Palavra.Length;
            Faltam = Quantidade;
            lbPalavra.Text ="";
            lbTentadas.Text = "";

            for (int cont = 0; cont !=  Quantidade;  cont++)
            {
                Escondido[cont] = '*';
                lbPalavra.Text = lbPalavra.Text + Escondido [cont];
            }
            Erros = 0;

            pbCabeca.Visible = false;   
            pbBracoE.Visible = false;
            pbBracoD.Visible = false;
            pbPernaD.Visible = false;
            pbPernaE.Visible = false;
            pbCorpo.Visible = false;

            tbPalavra.Enabled = false;
            btComeca.Enabled = false;
            mtLetra.Enabled = true;
            btTenta.Enabled = true;

            mtLetra.Focus();
            lbFaltam.Text=Faltam.ToString();
            lbErros.Text= Erros.ToString();
        }
    }
}
