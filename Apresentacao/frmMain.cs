using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apresentacao
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja sair do SisFin?", "Exit", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Em desenvolvimento...", "Indisponível");
        }

        private void fornecedorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmFornecedor frm = new frmFornecedor();

            frm.MdiParent = this;

            frm.Show();
        }

        private void fornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRelatorio frm = new frmRelatorio();

            frm.MdiParent = this;

            frm.Show();
        }

        private void sobreToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Alunos:\nMiguel Cyrineu Vale\t\tRA: 203001\nWendel Tolentino Alves Frota\tRA: 203243", "Sobre");
        }
    }
}
