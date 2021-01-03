using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Term_Assignment.Views
{
    public partial class DetailsBook : Form
    {
        public DetailsBook()
        {
            InitializeComponent();
            
        }
        public DetailsBook(string name, string author , string edition)
        {
            InitializeComponent();
            string output = String.Format("Name : {0}" +
                "\n\nAuthor : {1}" +
                "\n\nEdition : {2}", name, author,edition);
            richTextBox1.Text = output;
        }

        private void DetailsBook_Load(object sender, EventArgs e)
        {

        }
    }
}
