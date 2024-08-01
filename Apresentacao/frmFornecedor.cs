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
                    btnExclui.Enabled = true;
                    btnSalva.Enabled = false;
                    btnAltera.Enabled = true;
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
                    LimpaForm();
                    txtNome.Focus();
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
            radioPessoaFisica.Checked = true;
            radioPessoaJuridica.Checked = false;
            txtBairro.Clear();
            txtCelular.Clear();
            txtCidade.Clear();
            txtRazaoSocial.Clear();
            txtCep.Clear();
            txtCpfCnpj.Clear();
            txtComplemento.Clear();
            txtTelefone.Clear();
            txtRua.Clear();
            txtNum.Clear();
            tabControl1.SelectedIndex = 0;
        }


        private void frmFornecedor_Load(object sender, System.EventArgs e)
        {
            dgFornecedor.ColumnCount = 4;
            dgFornecedor.AutoGenerateColumns = false;
            dgFornecedor.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgFornecedor.Columns[0].HeaderText = "ID";
            dgFornecedor.Columns[0].DataPropertyName = "Id";
            dgFornecedor.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgFornecedor.Columns[1].HeaderText = "NOME";
            dgFornecedor.Columns[1].DataPropertyName = "Nome";
            dgFornecedor.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgFornecedor.Columns[2].HeaderText = "EMAIL";
            dgFornecedor.Columns[2].DataPropertyName = "email";
            dgFornecedor.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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

            switch(modo)
            {
                case 1: // ele selecionou alguma coisa enquanto adicionava um fornecedor, entao sairemos do modo de insercao e iremos ao modo normal
                    LimpaForm();
                    modo = 0;
                    Habilita();
                    if (row.RowCount == 0)
                    {
                        btnExclui.Enabled = false;
                        btnAltera.Enabled = false;
                    }
                    break;
                case 0: // ele selecionou alguma coisa enquanto apenas vizualizava as coisas, entao vamos preencher o form com os dados do fornecedor selecionado
                    LimpaForm();
                    preencheForm();
                    Habilita();
                    break;
                case 2: // ele selecionou que quer editar alguma coisa, entao vamos carregar todos os dados
                    LimpaForm();
                    preencheForm();
                    Habilita();
                    break;
            }
            
        }

        private void preencheForm()
        {
            tabControl1.SelectTab(0);
            int id = Int32.Parse(dgFornecedor.CurrentRow.Cells[0].Value.ToString());
            DataTable dt = _fornecedorService.getById(id);
            Fornecedor f = FornecedorService.fromDatatable(dt);
            txtId.Text = f.Id.ToString();
            txtNome.Text = f.Nome;
            txtEmail.Text = f.Email;
            txtCpfCnpj.Text = f.Cpf_cnpj;
            txtRazaoSocial.Text = f.Razao_social;
            txtTelefone.Text = f.Telefone;
            txtCelular.Text = f.Celular;
            if (f.TipoFornecedor == TipoPessoa.PESSOA_FISICA)
                radioPessoaFisica.Checked = true;
            else
                radioPessoaJuridica.Checked = true;
            txtCidade.Text = f.Cidade;
            txtCep.Text = f.CEP;
            txtBairro.Text = f.Bairro;
            txtRua.Text = f.Rua;
            txtNum.Text = f.Numero.ToString();
            txtComplemento.Text = f.Complemento;
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
            txtNome.Focus();
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            int id;
            TipoPessoa tipoFornecedor;
            string cpf_cnpj;
            string razao_social;
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

            numero = -1;
            try
            {
                numero = Convert.ToInt32(txtNum.Text);
            }
            catch
            {
                MessageBox.Show("Número inválido!", "Aviso do sistema");
                return;
            }
            tipoFornecedor = radioPessoaFisica.Checked ? TipoPessoa.PESSOA_FISICA : TipoPessoa.PESSOA_JURIDICA;
            cpf_cnpj = txtCpfCnpj.Text;
            razao_social = txtRazaoSocial.Text;
            nome = txtNome.Text;
            rua = txtRua.Text;
            bairro = txtBairro.Text;
            cidade = txtCidade.Text;
            complemento = txtComplemento.Text;
            cep = txtCep.Text;
            telefone = txtTelefone.Text;
            celular = txtCelular.Text;
            email = txtEmail.Text;

            if(cpf_cnpj == "" || razao_social == "" || nome == "" || rua == "" || bairro == "" || cidade == "" || cep == "" || telefone == "" || celular == "" || email == "")
            {
                MessageBox.Show("Algum campo ficou vazio! Verifique se todos eles foram preenchidos.", "Aviso do Sistema!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(complemento == "")
            {
                complemento = "Sem Complemento";
            }

            if (modo == 1)
            {
                resultado = _fornecedorService.Update(
                    id, tipoFornecedor, cpf_cnpj, razao_social, nome, rua,
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
                    msg = "Falha ao cadastrar FORNECEDOR! Verifique se todos os campos estão preenchidos corretamente";
                }

                MessageBox.Show(msg, "Aviso do sistema!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (modo == 2)
            {
                resultado = _fornecedorService.Update(
                    id, tipoFornecedor, cpf_cnpj, razao_social, nome, rua,
                    numero, bairro, cidade, complemento, cep,
                    telefone, celular, email, false
                    );

                if (resultado == "SUCESSO")
                {
                    msg = "FORNECEDOR atualizado com sucesso!";
                    carregaGridView();
                 }
                else
                {
                    msg = "Falha ao atualizar FORNECEDOR! Verifique se todos os campos estão preenchidos corretamente";
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
