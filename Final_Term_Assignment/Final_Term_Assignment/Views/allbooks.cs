using Final_Term_Assignment.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using Final_Term_Assignment.Models;
using System.Configuration;

namespace Final_Term_Assignment.Views
{
    
    public partial class allbooks : Form
    {
         
        public allbooks()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
           
        }
        DataTable dt = new DataTable("books");
        private void allbooks_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                    if(cn.State==ConnectionState.Closed)
                        
                            cn.Open();
                            using(SqlDataAdapter da = new SqlDataAdapter("select * from books",cn))
                                {
                                    da.Fill(dt);
                                    ShowSearchBooks.DataSource = dt;
                                }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }
        private void SearchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("Name like '%{0}%'", SearchBox.Text);
                ShowSearchBooks.DataSource = dv.ToTable();
            }
        }

        private void ShowSearchBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >=0)
            {
                DataGridViewRow row = this.ShowSearchBooks.Rows[e.RowIndex];

                NameInput.Text = row.Cells["Name"].Value.ToString();
                AuthorBox.Text = row.Cells["Author"].Value.ToString();
                EditionBox.Text = row.Cells["Edition"].Value.ToString();
            }
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btn_Click(object sender, EventArgs e)
        {
            string name = NameInput.Text;
            string author = AuthorBox.Text;
            string edition = EditionBox.Text;
            new DetailsBook(name, author, edition).Show();
        }
    }
}
