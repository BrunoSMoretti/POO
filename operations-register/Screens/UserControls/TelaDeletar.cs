using OperationsRegister.Persistence;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace OperationsRegister.Screens.UserControls
{
    public partial class TelaDeletar : UserControl
    {
        public TelaDeletar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != string.Empty)
                {
                    if (OperacoesCadastradas.operationsCadastradas != null && OperacoesCadastradas.operationsCadastradas.Count > 0)
                    {
                        foreach (var operation in OperacoesCadastradas.operationsCadastradas.Where(where => where.NomeOperacao == textBox1.Text))
                        {
                            OperacoesCadastradas.operationsCadastradas.Remove(operation);
                            break;
                        }
                    }
                    else
                        MessageBox.Show("Não existem operações cadastradas no sistema", "Atenção!");
                }
                else
                    MessageBox.Show("Informe o nome da operação que deseja deletar", "Atenção!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro grave!");
            }
        }
    }
}