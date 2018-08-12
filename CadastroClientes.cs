using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public partial class FormCadastroClientes : Form
    {
        public FormCadastroClientes()
        {
            InitializeComponent();
        }
        /*private MySqlConnection mConn;
        private MySqlDataAdapter mAdapter;
        private DataSet mDataSet;*/

        string connectionString = ("Persist Security Info=False; server=localhost; database=pfcsharp; uid=root");
        bool novo;


        private void sairSistema()/* CRIA O MÉTODO SAIR  */
        {
            /* MsgBox confirmando a saída do sistema */
            DialogResult resultado = MessageBox.Show("Antes de Sair , salve suas alterações . \n Confirma a saída ?", "Confirmar Saída do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            switch (resultado)/* Switch case para receber a resposta do MsgBox */
            {
                case DialogResult.Yes: Application.Exit();

                    break;

                default:

                    break;

            }/* Fecha o Switch Case do botão "Fechar" */

        }

        private void limparCampos()/* CRIA O MÉTODO LIMPAR CAMPOS  */
        {
            txt_03_Nome_Fantasia.Clear();
            txt_04_Razao_S.Clear();
            txt_05_cnpj.Clear();
            txt_06_cpf.Clear();
            txt_07_tel_comercial.Clear();
            txt_08_email_empresa.Clear();
            txt_09_contato.Clear();
            txt_10_email_gerente.Clear();
            txt_11_celular_gerente.Clear();
            txt_12_Endereco.Clear();
            txt_13_end_numero.Clear();
            txt_14_Cep.Clear();
            txt_15_bairro.Clear();
            txt_16_cidade.Clear();
            txt_17_estado.Clear();
            txt_18_produto.Clear();
            txt_20_ult_visita.Clear();
            txt_21_prox_visita.Clear();
        }

        private void Checked()/* CRIA O MÉTODO LIMPAR CAMPOS  */
        {
            if (txt_19_news.Checked)
            {
                txt_19_news.Text = "Enviar Informativo";
            }

            else
            {
                txt_19_news.Text = "Não Recebe Informativo";
            }

        }

      


        private void CadastroClientes_Load(object sender, EventArgs e)
        {
            /* ------------------------------------------------------------------------------------------ */
            /*		  CÓDIGO DO EVENTO LOAD DO FORMULÁRIO PRINCIPAL                              */
            /* ------------------------------------------------------------------------------------------ */
            tsbNovo.Enabled = true;
            tsbSalvar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbExcluir.Enabled = false;
            tstId.Enabled = true;
            tsbBuscar.Enabled = true;
            txt_01_num_cliente.Enabled = false;
            txt_02_data_cad.Enabled = false;
            txt_03_Nome_Fantasia.Enabled = false;
            txt_04_Razao_S.Enabled = false;
            txt_05_cnpj.Enabled = false;
            txt_06_cpf.Enabled = false;
            txt_07_tel_comercial.Enabled = false;
            txt_08_email_empresa.Enabled = false;
            txt_09_contato.Enabled = false;
            txt_10_email_gerente.Enabled = false;
            txt_11_celular_gerente.Enabled = false;
            txt_12_Endereco.Enabled = false;
            txt_13_end_numero.Enabled = false;
            txt_14_Cep.Enabled = false;
            txt_15_bairro.Enabled = false;
            txt_16_cidade.Enabled = false;
            txt_17_estado.Enabled = false;
            txt_18_produto.Enabled = false;
            txt_19_news.Enabled = false;
            txt_20_ult_visita.Enabled = false;
            txt_21_prox_visita.Enabled = false;
            txt_22_Status_Cliente.Enabled = false;

        }

        private void btnSairSistema_Click(object sender, EventArgs e)
        {
            sairSistema();
        }
                
        private void tsbSalvar_Click(object sender, EventArgs e)
        {
            if (novo)
            {
                try
                {
                    MySqlConnection mConn = new MySqlConnection("Persist Security Info=False; server=localhost; database=pfcsharp; uid=root");

                    mConn.Open();

                    MySqlCommand comando = new MySqlCommand("INSERT INTO cadclientes (nome_fantasia, razao_social, cnpj, cpf, tel_comercial, email_comercial, contato, email_contato, cel_contato, endereco, numero, cep, bairro, cidade, estado, produto, ultima_visita, proxima_visita)" +
                    "VALUES( '" + txt_03_Nome_Fantasia.Text + "' ,'" + txt_04_Razao_S.Text + "' ,'" + txt_05_cnpj.Text + "' ,'" + txt_06_cpf.Text + "' ,'" + txt_07_tel_comercial.Text + "' ,'" + txt_08_email_empresa.Text + "' ,'" + txt_09_contato.Text + "' ,'" + txt_10_email_gerente.Text + "' ,'" + txt_11_celular_gerente.Text + "' ,'" + txt_12_Endereco.Text + "' ,'" + txt_13_end_numero.Text + "' ,'" + txt_14_Cep.Text + "' ,'" + txt_15_bairro.Text + "' ,'" + txt_16_cidade.Text + "' ,'" + txt_17_estado.Text + "' ,'" + txt_18_produto.Text + "' ,'" + txt_20_ult_visita.Text + "' ,'" + txt_21_prox_visita.Text + "')", mConn);

                    //Executa a Query SQL
                    comando.ExecuteNonQuery();

                    // Fecha a conexão
                    mConn.Close();

                    /* Msg Informa o usuario que já pode realizar o Login */

                    MessageBox.Show("Cliente cadastrado com sucesso.", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    /* Apaga os campos do Formulário de Cadastro */

                    limparCampos();

                }
                catch (MySqlException msqle) /* Caso haja erro de conexao ao BD apresenta a msg  */
                {
                    MessageBox.Show("Ooops !!! Ocorreu um erro !\n\n Não foi possível acessar o banco de dados. \n\n Verifique sua conexão com o MySQL e tente novamente! \n O(s) seguinte(s) erro(s) foi(foram) encontrado(s) : \n" + msqle.Message, "Erro de Conexão ao MySQL");
                }
            }

            else
            {

                string sql = "UPDATE cadclientes SET nome_fantasia ='" + txt_03_Nome_Fantasia.Text + "' , razao_social = '" + txt_04_Razao_S.Text + "' , cnpj = '" + txt_05_cnpj.Text + "' , cpf = '" + txt_06_cpf.Text + "' ,tel_comercial = '" + txt_07_tel_comercial.Text + "' ,tel_cel = '" + txt_11_celular_gerente.Text + "' , email_comercial = '" + txt_08_email_empresa.Text + "' ,contato = '" + txt_09_contato.Text + "' ,email_contato = '" + txt_10_email_gerente.Text + "' , cel_contato = '" + txt_11_celular_gerente.Text + "' ,endereco = '" + txt_12_Endereco.Text + "' , numero = '" + txt_13_end_numero.Text + "' , cep = '" + txt_14_Cep.Text + "' ,bairro = '" + txt_15_bairro.Text + "' ,	cidade = '" + txt_16_cidade.Text + "' , estado = '" + txt_17_estado.Text + "' ,produto = '" + txt_18_produto.Text + "' , ultima_visita = '" + txt_20_ult_visita.Text + "' ";

                MySqlConnection con = new MySqlConnection(connectionString);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                        MessageBox.Show("Cadastro realizado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.ToString());
                }
                finally
                {
                    con.Close();
                }

            }

            tsbNovo.Enabled = true;
            tsbSalvar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbExcluir.Enabled = false;
            tstId.Enabled = true;
            tsbBuscar.Enabled = false;
            txt_01_num_cliente.Enabled = false;
            txt_02_data_cad.Enabled = false;
            txt_03_Nome_Fantasia.Enabled = false;
            txt_04_Razao_S.Enabled = false;
            txt_05_cnpj.Enabled = false;
            txt_06_cpf.Enabled = false;
            txt_07_tel_comercial.Enabled = false;
            txt_08_email_empresa.Enabled = false;
            txt_09_contato.Enabled = false;
            txt_10_email_gerente.Enabled = false;
            txt_11_celular_gerente.Enabled = false;
            txt_12_Endereco.Enabled = false;
            txt_13_end_numero.Enabled = false;
            txt_14_Cep.Enabled = false;
            txt_15_bairro.Enabled = false;
            txt_16_cidade.Enabled = false;
            txt_17_estado.Enabled = false;
            txt_18_produto.Enabled = false;
            txt_19_news.Enabled = false;
            txt_20_ult_visita.Enabled = false;
            txt_21_prox_visita.Enabled = false;
            txt_22_Status_Cliente.Enabled = false;


            txt_03_Nome_Fantasia.Text = "";
            txt_04_Razao_S.Text = "";
            txt_05_cnpj.Text = "";
            txt_06_cpf.Text = "";
            txt_07_tel_comercial.Text = "";
            txt_08_email_empresa.Text = "";
            txt_09_contato.Text = "";
            txt_10_email_gerente.Text = "";
            txt_11_celular_gerente.Text = "";
            txt_12_Endereco.Text = "";
            txt_13_end_numero.Text = "";
            txt_14_Cep.Text = "";
            txt_15_bairro.Text = "";
            txt_16_cidade.Text = "";
            txt_17_estado.Text = "";
            txt_18_produto.Text = "";
            txt_20_ult_visita.Text = "";
            txt_21_prox_visita.Text = "";


        }

        private void tsbCancelar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void tsbExcluir_Click(object sender, EventArgs e)
        {

           
        }

        private void tsbNovo_Click_1(object sender, EventArgs e)
        {
            tsbNovo.Enabled = false;
            tsbSalvar.Enabled = true;
            tsbCancelar.Enabled = true;
            tsbExcluir.Enabled = false;
            tstId.Enabled = false;
            tsbBuscar.Enabled = false;
            txt_01_num_cliente.Enabled = true;
            txt_02_data_cad.Enabled = true;
            txt_03_Nome_Fantasia.Enabled = true;
            txt_04_Razao_S.Enabled = true;
            txt_05_cnpj.Enabled = true;
            txt_06_cpf.Enabled = true;
            txt_07_tel_comercial.Enabled = true;
            txt_08_email_empresa.Enabled = true;
            txt_09_contato.Enabled = true;
            txt_10_email_gerente.Enabled = true;
            txt_11_celular_gerente.Enabled = true;
            txt_12_Endereco.Enabled = true;
            txt_13_end_numero.Enabled = true;
            txt_14_Cep.Enabled = true;
            txt_15_bairro.Enabled = true;
            txt_16_cidade.Enabled = true;
            txt_17_estado.Enabled = true;
            txt_18_produto.Enabled = true;
            txt_19_news.Enabled = true;
            txt_20_ult_visita.Enabled = true;
            txt_21_prox_visita.Enabled = true;
            txt_22_Status_Cliente.Enabled = true;
            txt_03_Nome_Fantasia.Focus();
            novo = true;
        }

        private void btn_ListarClientes_Click(object sender, EventArgs e)
        {
            this.Visible = false; /* Esconde o Form de Login Aberto */
            visualizar entrarNaPagina = new visualizar();
            entrarNaPagina.ShowDialog();
            this.Close(); /* Fecha o FormPrincipal Aberto */
            /*mConn.Close();/* Fecha a conexao ao BD */
        }

    }

}