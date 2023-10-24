using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CarregarDadosBanco();

          }

        private void CarregarDadosBanco()
        {
            string conexao = "server=localhost;database=aula1209;uid=root;pwd=";
            MySqlConnection conexaoMYSQL = new MySqlConnection(conexao);
            conexaoMYSQL.Open();

            MySqlDataAdapter adapter = new MySqlDataAdapter("select * from Aluno", conexaoMYSQL);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvAluno.DataSource = dt;

        }



        private void btnAlterar_Click(object sender, EventArgs e)
        {
            string conexao = "server=localhost;database=aula1209;uid=root;pwd=";
            MySqlConnection conexaoMYSQL = new MySqlConnection(conexao);
            conexaoMYSQL.Open();
            MySqlCommand comando = new MySqlCommand("update aluno set nome='" + txtNomeAluno.Text + "', dsEndereco='" + txtEndereco.Text + "' where idAluno=" + txtCodigoAluno.Text, conexaoMYSQL);
            comando.ExecuteNonQuery();
            MessageBox.Show("Dados alterados!!!");
            txtNomeAluno.Text = "";
            txtEndereco.Text = "";
            txtCodigoAluno.Text = "";
            pnlAlterar.Visible = false;
            CarregarDadosBanco();
        }

        private void dgvAluno_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            txtCodigoAluno.Text = dgvAluno.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtNomeAluno.Text = dgvAluno.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtEndereco.Text = dgvAluno.Rows[e.RowIndex].Cells[2].Value.ToString();
            pnlAlterar.Visible = true;

        }


    }
}
