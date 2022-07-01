using OperationsRegister.Persistence;
using System;
using System.Windows.Forms;

namespace OperationsRegister.Screens.UserControls
{
    public partial class TelaAdicionar : UserControl
    {
        public TelaAdicionar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != string.Empty || textBox2.Text != string.Empty || textBox3.Text != string.Empty)
                {
                    Operations operations = new Operations();

                    operations.NomeOperacao = textBox1.Text;
                    operations.Tempo = Convert.ToInt32(textBox2.Text);
                    operations.Unidade = textBox3.Text;

                    OperacoesCadastradas.operationsCadastradas.Add(operations);

                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    textBox3.Text = string.Empty;

                    MessageBox.Show("Operação adicionada", "Sucesso");
                }
                else
                    MessageBox.Show("Existem campos não preenchidos no cadastro", "Atenção!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro grave!");
            }
        }
    }
}