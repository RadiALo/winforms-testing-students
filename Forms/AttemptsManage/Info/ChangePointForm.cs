using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testing_students.Forms.AttemptsManage.Info
{
    public partial class ChangePointForm : Form
    {
        bool ok = false;
        float maxPoint;

        public float Point;
        public bool Change = false;

        public ChangePointForm()
        {
            InitializeComponent();
        }

        public ChangePointForm(int testId) : this()
        {
            maxPoint =
                Connector.ExecuteSelectQuery(
                    $@"SELECT test_point FROM test
                    WHERE test_id = {testId}"
                ).Rows[0].Field<int>(0);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            ok = true;
            Close();
        }

        private void ChangePointForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ok)
            {
                if (PointBox.Text != "")
                {
                    if (MessageBox.Show("Зберегти зміни?","Увага",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }

            try
            {
                Point = float.Parse(PointBox.Text);

                if (Point > maxPoint)
                {
                    e.Cancel = true;
                    MessageBox.Show("Число не може бути вище за максимальну оцінку", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Change = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Необхідно ввести число!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
