using OperationsRegister.Screens.UserControls;
using System;
using System.Windows.Forms;

namespace OperationsRegister.Screens
{
    public partial class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            InitializeComponent();

            ViewScreen(new SplashScreen());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewScreen(new TelaAdicionar());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewScreen(new TelaDeletar());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewScreen(new TelaVisualizar());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ViewScreen(new TelaProcura());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ViewScreen(new TelaModificar());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ViewScreen(new TelaArquivo());
        }

        private void ViewScreen(UserControl userControl)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(userControl);
        }
    }
}