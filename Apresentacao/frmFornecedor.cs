using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Dados;
using Negocio;

namespace Apresentacao
{
    public partial class frmFornecedor : Form
    {
        private readonly FornecedorService _fornecedorService;
        private DataTable tblFornecedor = new DataTable();

        //sinaliza qual operação está em andamento
        //0 = nada
        //1 = inclusão (novo)
        //2 = alteração
        private int modo = 0; //sinaliza qual operação está em andamento
        public frmFornecedor()
        {
            InitializeComponent();
            _fornecedorService = new FornecedorService();

            dgFornecedor.Columns.Add("Id", "ID");
            dgFornecedor.Columns.Add("Nome", "NOME");
            dgFornecedor.Columns.Add("tipoPesso", "TIPO PESSOA");
            dgFornecedor.Columns.Add("email", "EMAIL");

            dgFornecedor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgFornecedor.AllowUserToAddRows = false;
            dgFornecedor.AllowUserToDeleteRows = false;
            dgFornecedor.AllowUserToOrderColumns = true;
            dgFornecedor.ReadOnly = true;

            tblFornecedor = _fornecedorService.getAll();
        }

        private void Habilita()
        {
            switch (modo)
            {
                case 0: //neutro
                    btnInclui.Enabled = true;
                    btnAltera.Enabled = true;
                    btnExclui.Enabled = true;
                    btnSalva.Enabled = false;
                    btnCancela.Enabled = false;
                    tabControl1.Enabled = false;
                    dgFornecedor.Enabled = true;
                    break;
                case 1: //inclusão
                    btnInclui.Enabled = false;
                    btnAltera.Enabled = false;
                    btnExclui.Enabled = false;
                    btnSalva.Enabled = true;
                    btnCancela.Enabled = true;
                    tabControl1.Enabled = true;
                    dgFornecedor.Enabled = false;
                    break;
                case 2:
                    btnInclui.Enabled = false;
                    btnAltera.Enabled = false;
                    btnExclui.Enabled = false;
                    btnSalva.Enabled = true;
                    btnCancela.Enabled = true;
                    tabControl1.Enabled = true;
                    dgFornecedor.Enabled = false;
                    break;
             }

        }

        public void LimpaForm()
        {
            txtNome.Clear();
            txtEmail.Clear();
            txtId.Clear();
            radioPessoaFisica.Checked = false;
            radioPessoaJuridica.Checked = false;

            txtNome.Focus();
        }


        private void frmFornecedor_Load(object sender, System.EventArgs e)
        {
            radioPessoaFisica.Text = TipoPessoa.PESSOA_FISICA.ToString();
            radioPessoaJuridica.Text = TipoPessoa.PESSOA_JURIDICA.ToString();

            dgFornecedor.ColumnCount = 4;
            dgFornecedor.AutoGenerateColumns = false;
            dgFornecedor.Columns[0].Width = 26;
            dgFornecedor.Columns[0].HeaderText = "ID";
            dgFornecedor.Columns[0].DataPropertyName = "Id";
            dgFornecedor.Columns[1].Width = 190;
            dgFornecedor.Columns[1].HeaderText = "NOME";
            dgFornecedor.Columns[1].DataPropertyName = "Nome";
            dgFornecedor.Columns[2].Width = 190;
            dgFornecedor.Columns[2].HeaderText = "EMAIL";
            dgFornecedor.Columns[2].DataPropertyName = "email";
            dgFornecedor.Columns[3].Width = 80;
            dgFornecedor.Columns[3].HeaderText = "TIPO";
            dgFornecedor.Columns[3].DataPropertyName = "tipoPessoa";

            dgFornecedor.AllowUserToAddRows = false;
            dgFornecedor.AllowUserToDeleteRows = false;
            dgFornecedor.MultiSelect = false;
            dgFornecedor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            carregaGridView();
        }

        private void carregaGridView()
        {
            dgFornecedor.DataSource = _fornecedorService.getAll();
            dgFornecedor.Refresh();
        }

        private void dgFornecedor_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView row = (DataGridView)sender;
            if (row.CurrentRow == null)
                return;

            //limpa os TextBoxes
            txtId.Text = dgFornecedor.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dgFornecedor.CurrentRow.Cells[1].Value.ToString();
            txtEmail.Text = dgFornecedor.CurrentRow.Cells[2].Value.ToString();

            if (dgFornecedor.CurrentRow.Cells[3].Value.ToString() == ((int)TipoPessoa.PESSOA_FISICA).ToString())
                radioPessoaFisica.Checked = true;
            else
                radioPessoaJuridica.Checked = true;
        }

        private void btnAltera_Click(object sender, EventArgs e)
        {
            modo = 2;
            Habilita();
        }

        private void btnInclui_Click(object sender, EventArgs e)
        {
            modo = 1;
            Habilita();
            LimpaForm();
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            int id;
            TipoPessoa tipoFornecedor;
            string cpf_cnpj;
            string nome;
            string rua; 
            int numero; 
            string bairro;
            string cidade;
            string complemento;
            string cep;
            string telefone;
            string celular;
            string email;
            string resultado;
            string msg;

            if (String.IsNullOrEmpty(txtId.Text))
                id = -1;
            else
                id = Convert.ToInt32(txtId.Text);

            tipoFornecedor = radioPessoaFisica.Checked ? TipoPessoa.PESSOA_FISICA : TipoPessoa.PESSOA_JURIDICA;
            cpf_cnpj = txtCpfCnpj.Text;
            nome = txtNome.Text;
            rua = txtRua.Text;
            numero = Convert.ToInt32(txtNum.Text);
            bairro = txtBairro.Text;
            cidade = txtCidade.Text;
            complemento = txtComplemento.Text;
            cep = txtCep.Text;
            telefone = txtTelefone.Text;
            celular = txtCelular.Text;
            email = txtEmail.Text;


            if (modo == 1)
            {
                resultado = _fornecedorService.Update(
                    id, tipoFornecedor, cpf_cnpj, nome, rua,
                    numero, bairro, cidade, complemento, cep,
                    telefone, celular, email, true
                    );
                
                if (resultado == "SUCESSO")
                {
                    msg = "FORNECEDOR cadastrado com sucesso!";
                    carregaGridView();
                }
                else
                {
                    msg = "Falha ao cadastrar FORNECEDOR!";
                }

                MessageBox.Show(msg, "Aviso do sistema!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (modo == 2)
            {
                resultado = _fornecedorService.Update(1, tipoFornecedor, nome, email, null, 1, null, null, null, null, null, null, null, true);
                
                if (resultado == "SUCESSO")
                {
                    msg = "FORNECEDOR atualizado com sucesso!";
                    carregaGridView();
                 }
                else
                {
                    msg = "Falha ao atualizar FORNECEDOR!";
                }

                MessageBox.Show(msg, "Aviso do sistema!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            modo = 0;
            Habilita();

        }

        private void btnExclui_Click(object sender, EventArgs e)
        {
            string resultado;
            String msg;
            DialogResult resposta;
            resposta = MessageBox.Show("Confirma exclusão?", "Aviso do sistema!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resposta == DialogResult.OK)
            {
                int idFornecedor = Convert.ToInt32(txtId.Text);
                resultado = _fornecedorService.Remove(idFornecedor);

                if (resultado == "SUCESSO")
                {
                    msg = "FORNECEDOR excluido com sucesso!";
                    carregaGridView();
                }
                else
                {
                    msg = "Falha ao excluir FORNECEDOR!";
                }

                MessageBox.Show(msg, "Aviso do sistema!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            modo = 0;
            Habilita();
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            frmPrompt f = new frmPrompt();
            f.ShowDialog();

            string txtBusca = f.Texto;

            DataTable tbFornecedores = _fornecedorService.filterByName(txtBusca);

            if(tbFornecedores != null)
            {
                dgFornecedor.DataSource = tbFornecedores;
                dgFornecedor.Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }
    }
}
