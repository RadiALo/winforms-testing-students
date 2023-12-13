using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testing_students
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            if (InputBox.Text.ToLower().Contains("drop") && InputBox.Text.ToLower().Contains("table"))
            {
                MessageBox.Show("Заборонено використовувати ключові слова DROP TABLE!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                OutputGridView.DataSource = Connector.ExecuteSelectQuery(InputBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            if (InputBox.Text.ToLower().Contains("drop") && InputBox.Text.ToLower().Contains("table"))
            {
                MessageBox.Show("Заборонено використовувати ключові слова DROP TABLE!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Connector.ExecuteQuery(InputBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
