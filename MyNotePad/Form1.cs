using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace MyNotePad
{
    public partial class Form1 : Form
    {
        private string ficheiro = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void MenuFicheiro_ButtonClick(object sender, EventArgs e)
        {

        }

        private void menuFicheiroNovo_Click(object sender, EventArgs e)
        {
            VerificarAlteracoes();

            rbTexto.ResetText();
            rbTexto.Modified = false;
            ficheiro = null;
        }

        private void menuFicheiroAbrir_Click(object sender, EventArgs e)
        {
            VerificarAlteracoes();

            openFileDialog1.Filter = "Ficheiros RTF| *.rtf| Ficheiros TXT| *.txt| Todos| *.*";
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ficheiro=openFileDialog1.FileName;
                rbTexto.LoadFile(ficheiro);
                rbTexto.Modified = false;

            }
        }

        private void menuFicheiroGuardar_Click(object sender, EventArgs e)
        {
            if (ficheiro != "")
            {
                rbTexto.SaveFile(ficheiro);
            }
            else
            {
                GuardarFicheiro();
            }
        }

        private void menuFicheiroSair_Click(object sender, EventArgs e)
        {
            DialogResult resposta = MessageBox.Show("Deseja sair da aplicação?",
                "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resposta == DialogResult.Yes)
            {
                VerificarAlteracoes();
                this.Close();
            }
        }

        private void VerificarAlteracoes()
        {
            if(rbTexto.Modified == true)
            {
                DialogResult resposta = MessageBox.Show("Deseja guardar o texto atual?",
                    "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (resposta == DialogResult.Yes)
                {
                    if (ficheiro!= "")
                    {
                        rbTexto.SaveFile(ficheiro);
                        rbTexto.Modified = false;
                    }
                    else
                    {
                        GuardarFicheiro();
                    }
                }
            }
        }

        private void GuardarFicheiro()
        {
            saveFileDialog1.Filter = "\"Ficheiros RTF| *.rtf| Ficheiros TXT| *.txt";

            saveFileDialog1.FileName = "";

            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ficheiro = saveFileDialog1.FileName;
                rbTexto.SaveFile(ficheiro);
                rbTexto.Modified = false;
            }

            else
            {
                rbTexto.Modified = false;
            }


        }

        private void menuEditarCortar_Click(object sender, EventArgs e)
        {
            rbTexto.Cut();
        }

        private void menuEditarCopiar_Click(object sender, EventArgs e)
        {
            rbTexto.Copy();
        }

        private void menuEditarColar_Click(object sender, EventArgs e)
        {
            rbTexto.Paste();
        }

        private void menuEditarSelecionarTudo_Click(object sender, EventArgs e)
        {
            rbTexto.SelectAll();
        }

        private void menuEditarProcurar_Click(object sender, EventArgs e)
        {
            string txtProcura = Interaction.InputBox("Digite o que procura: ",
                "Procurar", "", 150, 200);

            int resultado = rbTexto.Find(txtProcura);

            if (resultado== -1)
            {
                MessageBox.Show("Aviso", "Não foi encontrada a sua procura. ",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void menuFormatarLetra_Click(object sender, EventArgs e)
        {
            if (rbTexto.SelectionFont != null)
            {
                fontDialog1.Font = rbTexto.SelectionFont;
            }

            else
            {
                fontDialog1.Font = null;
            }

            fontDialog1.ShowDialog();
            rbTexto.SelectionFont = fontDialog1.Font;
        }

        private void menuFormatarCores_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            rbTexto.SelectionColor = colorDialog1.Color;
        }

        private void menuFormatarCoresLetra_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            rbTexto.SelectionColor = colorDialog1.Color;
        }

        private void menuFormatarCoresFundo_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            rbTexto.SelectionColor = colorDialog1.Color;
        }

        private void menuFormatarAlinhamentoEsquerda_Click(object sender, EventArgs e)
        {
            rbTexto.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void menuFormatarAlinhamentoCentro_Click(object sender, EventArgs e)
        {
            rbTexto.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void menuFormatarAlinhamentoDireita_Click(object sender, EventArgs e)
        {
            rbTexto.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            VerificarAlteracoes();
        }

        private void ferramentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 box = new AboutBox1();
            box.ShowDialog();
        }
    }
}
