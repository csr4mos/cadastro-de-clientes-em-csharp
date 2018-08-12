/* --------------------------------------------- 
*
*   Este Projeto foi desenvolvido por Cristiano Ramos ( csramos.poa@gmail.com ) .
*      
*   É parte integrante de meu Projeto Final em C# como Conclusão do Curso de Técnico de Informática
*   na Escola Alcides Maya - 2013/2014 - Turma 3M2 - PRONATEC
*   Desenvolvido com o Microsoft Visual C# 2010  , utilizando banco de dados Mysql .
*   Utilizei técnicas aprendidas em aula e pesquisas na internet .
*   Grato á todos os professores que ao longo deste período contribuíram para o meu aprendizado .
*      
* --------------------------------------------- */
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
    public partial class FORMLogin : Form

    {
        public FORMLogin()
        {
            InitializeComponent();
        }
        /*private MySqlConnection mConn;
        private MySqlDataAdapter mAdapter;
        private DataSet mDataSet;*/

        private void cadastrarUsuario()/* CRIA O MÉTODO CADASTRAR  */
        {
            try
            {
                MySqlConnection mConn = new MySqlConnection("Persist Security Info=False; server=localhost; database=pfcsharp; uid=root");

                mConn.Open();

                MySqlCommand comando = new MySqlCommand("INSERT INTO login (usuario, empresa, funcao, email, senha)" +
                        "VALUES('" + txt_01_CadastroNome.Text + "','" + txt_02_CadastroEmpresa.Text + "','" + txt_03_CadastroFuncao + "','" + txt_04_CadastroEmail.Text + "','" + txt_05_CadastroSenha.Text + "')", mConn);

                //Executa a Query SQL
                comando.ExecuteNonQuery();

                // Fecha a conexão
                mConn.Close();
                               
                /* Msg Informa o usuario que já pode realizar o Login */

                MessageBox.Show("Cadastro realizado corretamente. \n Você já pode fazer o Login com o email e senha cadastrados .", "Cadastro Efetuado com sucesso ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                /* Apaga os campos do Formulário de Cadastro */

                limparCampos();
                
            }
            catch (MySqlException msqle) /* Caso haja erro de conexao ao BD apresenta a msg  */
            {
                MessageBox.Show("Ooops !!! Ocorreu um erro !\n\n Não foi possível acessar o banco de dados. \n\n Verifique sua conexão com o MySQL e tente novamente! \n O(s) seguinte(s) erro(s) foi(foram) encontrado(s) : \n" + msqle.Message, "Erro de Conexão ao MySQL");
            }
        }

        private void limparCampos()/* CRIA O MÉTODO LIMPAR CAMPOS  */
        {
            txt_01_CadastroNome.Clear();
            txt_01_LoginEmail.Clear();
            txt_02_CadastroEmpresa.Clear();
            txt_02_LoginSenha.Clear();
            txt_03_CadastroFuncao.Clear();
            txt_04_CadastroEmail.Clear();
            txt_05_CadastroSenha.Clear();

        }

        private void proibirCamposVazios()/* CRIA O MÉTODO LIMPAR CAMPOS  */
        {
            if (string.IsNullOrEmpty(txt_01_CadastroNome.Text +
            txt_01_LoginEmail.Text +
            txt_02_CadastroEmpresa.Text +
            txt_02_LoginSenha.Text +
            txt_03_CadastroFuncao.Text +
            txt_04_CadastroEmail.Text +
            txt_05_CadastroSenha.Text))
            {
                MessageBox.Show("Ocorreu um erro .\n Desculpe , todos os campos são obrigatórios , verifique e tente novamente !");
                return;
            }
            
        }

        private void entrarSistema()/* CRIA O MÉTODO DE LOGIN  */
        {         
            try
            {

                MySqlConnection mConn = new MySqlConnection("Persist Security Info=False; server=localhost; database=pfcsharp; uid=root");

                mConn.Open();/* Abre a conexão */

                string mSQL = "select count(*)from login where email = @email and senha=@senha"; /* Faz a consulta sql por email e senha */
                MySqlCommand cmd = new MySqlCommand(mSQL, mConn); /* Retorna a consulta */
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                cmd.Parameters.Add("@email", MySqlDbType.VarChar, 100).Value = txt_01_LoginEmail.Text;/* Recebe o email e senha digitados */
                cmd.Parameters.Add("@senha", MySqlDbType.VarChar, 100).Value = txt_02_LoginSenha.Text;/* Recebe o email e senha digitados */

                int i = int.Parse(cmd.ExecuteScalar().ToString());

                if (i > 0) /* SE encontrar o resultado no BD */
                {
                    this.Visible = false; /* Esconde o Form de Login Aberto */
                    FormCadastroClientes entrarNaPagina = new FormCadastroClientes();
                    entrarNaPagina.ShowDialog();
                    this.Close(); /* Fecha o FormPrincipal Aberto */
                     mConn.Close();/* Fecha a conexao ao BD */
                }

                else /* SENÃO apresenta a MsgBox */
                {

                    MessageBox.Show("Ooops !!! Ocorreu um erro !\n\n Você já realizou o cadastro ? \n\n O email ou a senha digitados estão incorretos ! \n Verifique e tente novamente!", "Erro ao efetuar o Login", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                mConn.Close();/* Fecha a conexao ao BD */

            }

            catch (MySqlException msqle) /* Caso haja erro de conexao ao BD apresenta a msg  */
            {
                MessageBox.Show("Ooops !!! Ocorreu um erro !\n\n Não foi possível acessar o banco de dados. \n\n Verifique sua conexão com o MySQL e tente novamente! \n O(s) seguinte(s) erro(s) foi(foram) encontrado(s) : \n" + msqle.Message, "Erro de Conexão ao MySQL");
            }
        }

        private void sairSistema()/* CRIA O MÉTODO SAIR  */
        {
            /* MsgBox confirmando a saída do sistema */
            DialogResult resultado = MessageBox.Show("Você ainda não entrou no sistema . \n Confirma a saída ?", "Confirmar Saída do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            switch (resultado)/* Switch case para receber a resposta do MsgBox */
            {
                case DialogResult.Yes: Application.Exit();

                    break;

                default:

                    break;

            }/* Fecha o Switch Case do botão "Fechar" */

        }

        private void Login_Load(object sender, EventArgs e)/* FORM LOAD  INICIA O FORMULÁRIO */
        {

        }

        private void btnApagarCadastro_Click(object sender, EventArgs e)/* BOTÃO APAGAR LIMPAR CADASTRO  */
        {
            limparCampos();

        }

        private void btnApagarLogin_Click(object sender, EventArgs e)/* BOTÃO LIMPAR LOGIN */
        {
            limparCampos();
        }

        private void btnRecebeLogin_Click(object sender, EventArgs e)/* BOTÃO DE LOGIN  */
        {
            proibirCamposVazios();
            entrarSistema();

        }

        private void btnRecebeCadastro_Click(object sender, EventArgs e) /* BOTÃO DE CADASTRO  */
        {
            proibirCamposVazios();
            cadastrarUsuario();
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)/* BOTÃO SAIR DO SISTEMA  */
        {
            sairSistema();
        }
    }
}
