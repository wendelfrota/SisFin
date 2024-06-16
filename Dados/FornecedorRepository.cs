using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class FornecedorRepository
    {

        public string Insert(Fornecedor fornecedor)
        {
            string resp = "";
            try
            {
                Connection.getConnection();

                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = Connection.Con,
                    CommandText = "INSERT INTO fornecedor " +
                    "(tipoPessoa, cpf_cnpj, razao_social, nome, rua, numero, bairro, cidade, complemento, cep, telefone, celular, email) VALUES " +
                    "(@pTipoFornecedor, @pCpf_cnpj, @pRazao_social, @pNome, @pRua, @pNumero, @pBairro, @pCidade, @pComplemento, @pCep, @pTelefone, @pCelular, @pEmail) "
                };
                SqlCmd.Parameters.AddWithValue("pTipoFornecedor", fornecedor.TipoFornecedor);
                SqlCmd.Parameters.AddWithValue("pCpf_Cnpj", fornecedor.Cpf_cnpj);
                SqlCmd.Parameters.AddWithValue("pRazao_Social", fornecedor.Razao_social);
                SqlCmd.Parameters.AddWithValue("pNome", fornecedor.Nome);
                SqlCmd.Parameters.AddWithValue("pRua", fornecedor.Rua);
                SqlCmd.Parameters.AddWithValue("pNumero", fornecedor.Numero);
                SqlCmd.Parameters.AddWithValue("pBairro", fornecedor.Bairro);
                SqlCmd.Parameters.AddWithValue("pCidade", fornecedor.Cidade);
                SqlCmd.Parameters.AddWithValue("pComplemento", fornecedor.Complemento);
                SqlCmd.Parameters.AddWithValue("pCep", fornecedor.CEP);
                SqlCmd.Parameters.AddWithValue("pTelefone", fornecedor.Telefone);
                SqlCmd.Parameters.AddWithValue("pCelular", fornecedor.Celular);
                SqlCmd.Parameters.AddWithValue("pEmail", fornecedor.Email);

                //executa o stored procedure
                resp = SqlCmd.ExecuteNonQuery() == 1 ? "SUCESSO" : "FALHA";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                resp = ex.Message;
            }
            finally
            {
                if (Connection.Con.State == ConnectionState.Open)
                    Connection.Con.Close();
            }

            return resp;
        }

        public string Update(Fornecedor fornecedor)
        {
            string resp = "";
            try
            {
                Connection.getConnection();

                string updateSql = String.Format("UPDATE fornecedor SET " +
                                    "tipoPessoa=@pTipoFornecedor, cpf_cnpj=@pCpf_cnpj, razao_social=@pRazao_social," +
                                    "nome=@pNome, rua=@pRua, numero=@pNumero, bairro=@pBairro, cidade=@pCidade, complemento=@pComplemento," +
                                    "cep=@pCep, telefone=@pTelefone, celular=@pCelular, email=@pEmail " +
                                    "WHERE id = @pId ");
                SqlCommand SqlCmd = new SqlCommand(updateSql, Connection.Con);
                SqlCmd.Parameters.AddWithValue("pTipoFornecedor", fornecedor.TipoFornecedor);
                SqlCmd.Parameters.AddWithValue("pCpf_Cnpj", fornecedor.Cpf_cnpj);
                SqlCmd.Parameters.AddWithValue("pRazao_Social", fornecedor.Razao_social);
                SqlCmd.Parameters.AddWithValue("pNome", fornecedor.Nome);
                SqlCmd.Parameters.AddWithValue("pRua", fornecedor.Rua);
                SqlCmd.Parameters.AddWithValue("pNumero", fornecedor.Numero);
                SqlCmd.Parameters.AddWithValue("pBairro", fornecedor.Bairro);
                SqlCmd.Parameters.AddWithValue("pCidade", fornecedor.Cidade);
                SqlCmd.Parameters.AddWithValue("pComplemento", fornecedor.Complemento);
                SqlCmd.Parameters.AddWithValue("pCep", fornecedor.CEP);
                SqlCmd.Parameters.AddWithValue("pTelefone", fornecedor.Telefone);
                SqlCmd.Parameters.AddWithValue("pCelular", fornecedor.Celular);
                SqlCmd.Parameters.AddWithValue("pEmail", fornecedor.Email);
                SqlCmd.Parameters.AddWithValue("pId", fornecedor.Id);

                //executa o stored procedure
                resp = SqlCmd.ExecuteNonQuery() == 1 ? "SUCESSO" : "FALHA";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                resp = ex.Message;
            }
            finally
            {
                if (Connection.Con.State == ConnectionState.Open)
                    Connection.Con.Close();
            }
            return resp;
        }

        public string Remove(int idFornecedor)
        {
            string resp = "";
            try
            {
                Connection.getConnection();

                string updateSql = String.Format("DELETE FROM fornecedor " +
                                    "WHERE id = @pId ");
                SqlCommand SqlCmd = new SqlCommand(updateSql, Connection.Con);
                SqlCmd.Parameters.AddWithValue("pId", idFornecedor);

                //executa o stored procedure
                resp = SqlCmd.ExecuteNonQuery() == 1 ? "SUCESSO" : "FALHA";
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            finally
            {
                if (Connection.Con.State == ConnectionState.Open)
                    Connection.Con.Close();
            }
            return resp;
        }

        public DataTable getAll()
        {
            DataTable DtResultado = new DataTable("fornecedor");
            try
            {
                Connection.getConnection();
                String sqlSelect = "select * from fornecedor";

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Connection.Con;
                SqlCmd.CommandText = sqlSelect;
                SqlCmd.CommandType = CommandType.Text;
                SqlDataAdapter SqlData = new SqlDataAdapter(SqlCmd);
                SqlData.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        public DataTable filterByName(string pNome)
        {
            DataTable DtResultado = new DataTable("fornecedor");
            string selectSql;
            try
            {
                Connection.getConnection();
                if (!string.IsNullOrEmpty(pNome))
                {
                    selectSql = String.Format("SELECT * FROM fornecedor WHERE nome LIKE @pNome");
                    pNome = '%' + pNome + '%';
                }
                else
                {
                    selectSql = String.Format("SELECT * FROM fornecedor");
                }
                SqlCommand SqlCmd = new SqlCommand(selectSql, Connection.Con);
                if (!string.IsNullOrEmpty(pNome))
                    SqlCmd.Parameters.AddWithValue("pNome", pNome);
                SqlDataAdapter SqlData = new SqlDataAdapter(SqlCmd);
                SqlData.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }


    }
}