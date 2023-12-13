using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testing_students.Forms.AttemptsManage.CreateAttempt
{
    public partial class BlackListForm : Form
    {
        List<string> blackList;
        List<string> names;
        private bool ok = false;
        public BlackListForm()
        {
            InitializeComponent();
        }

        public BlackListForm(List<string> students, List<string> names) : this()
        {
            blackList = students;
            this.names = names;
            for (int i = 0; i < students.Count; i++)
            {
                BlackListBox.Items.Add(names[i]);
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            ok = true;
            Close();
        }

        private void BlackListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ok)
            {
                if (BlackListBox.CheckedItems.Count > 0)
                {
                    if (MessageBox.Show("Видалити обраних студентів з вибірки?", "Увага!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }

            if (BlackListBox.CheckedItems.Count > 0)
            {
                for (int i = 0; i < BlackListBox.CheckedItems.Count; i++)
                {
                    blackList.RemoveAt(names.IndexOf(BlackListBox.CheckedItems[i].ToString()));
                    names.Remove(BlackListBox.CheckedItems[i].ToString());
                }
            }
        }
    }
}
