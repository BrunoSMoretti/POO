using OperationsRegister.Persistence;
using System;
using System.Windows.Forms;

namespace OperationsRegister.Screens.UserControls
{
    public partial class TelaVisualizar : UserControl
    {
        private Operations operation;

        public TelaVisualizar()
        {
            InitializeComponent();

            dataGridView1.DataSource = OperacoesCadastradas.operationsCadastradas;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dataGridView = sender as DataGridView;

                operation = OperacoesCadastradas.operationsCadastradas[dataGridView.CurrentRow.Index];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro grave!");
            }
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (operation != null)
                    System.Diagnostics.Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe", "http://google.com/search?q=" + "Operação+de+" + operation.NomeOperacao);
                else
                    MessageBox.Show("Selecione uma operação.", "Atenção!");

                dataGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro grave!");
            }
        }
    }
}