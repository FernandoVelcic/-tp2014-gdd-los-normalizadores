using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyActiveRecord;

namespace FrbaHotel
{
    public static class Navigator
    {
        public static void nextForm(this Form form1, Form form2)
        {
            form1.Hide();
            form2.Closed += (s, a) => form1.Close();
            form2.Show();
        }

        public static void deleteRecord(this Form form1, DataGridView dataGridView1)
        {
            DialogResult dr = MessageBox.Show("¿Esta seguro que desea borrar este registro?", "Borrar registro", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (dr == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    ActiveRecord record = row.DataBoundItem as ActiveRecord;
                    record.logicalDelete();
                    //dataGridView1.Rows.RemoveAt(row.Index);
                    MessageBox.Show("Registro borrado correctamente");
                }
            }
        }

        public static void editRecord<T,F>(this Form form1, DataGridView dataGridView1)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                Object record = row.DataBoundItem;
                nextForm(form1, (Form)Activator.CreateInstance(typeof(F), record));
            }
        }
    }
}
