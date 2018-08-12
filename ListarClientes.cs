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
    public partial class visualizar : Form
    {
       
        public visualizar()
        {
            InitializeComponent();
        }

        private MySqlConnection mConn;
        private MySqlDataAdapter mAdapter;
        private DataSet mDataSet;

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

        private void mostraresultados() /* CRIA O MÉTODO MOSTRA RESULTADOS  */
        {
            mDataSet = new DataSet();
            mConn = new MySqlConnection("Persist Security Info=False; server=localhost; database=pfcsharp; uid=root");

            mConn.Open();
            mAdapter = new MySqlDataAdapter("SELECT * FROM login ORDER by id", mConn);
            mAdapter.Fill(mDataSet, "revisao");

            dataGridView1.DataSource = mDataSet;
            dataGridView1.DataMember = "revisao";
        }

        private void visualizar_Load(object sender, EventArgs e)
        {

        }
                
        private void btnListarClientes_Click(object sender, EventArgs e)
        {
            mostraresultados();
           
        }

        private void btnSairSistema_Click(object sender, EventArgs e)
        {
            sairSistema();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tsbNovo_Click(object sender, EventArgs e)
        {
            this.Visible = false; /* Esconde o Form de Login Aberto */
            FormCadastroClientes entrarNaPagina = new FormCadastroClientes();
            entrarNaPagina.ShowDialog();
            this.Close(); /* Fecha o FormPrincipal Aberto */
            /*mConn.Close();/* Fecha a conexao ao BD */
        }

        private void tsbSalvar_Click(object sender, EventArgs e)
        {
            mostraresultados();
        }
    }
 }
