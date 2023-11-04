using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudPersonas
{
    public partial class Form1 : Form
    {
        private int? id;
        public Form1(int? id=null)
        {
            InitializeComponent();
            this.id = id;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            refrescar();
        }
        private void refrescar()
        {
            dsCrudTableAdapters.PersonaTableAdapter da=new dsCrudTableAdapters.PersonaTableAdapter();
            dsCrud.PersonaDataTable dt = da.GetData();
            dataGridViewPeople.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (id == null)
            {
                dsCrudTableAdapters.PersonaTableAdapter da = new dsCrudTableAdapters.PersonaTableAdapter();
                da.AgregarPersona(txtNombre.Text.Trim(), Convert.ToInt32(txtEdad.Value));
                MessageBox.Show("Registro Insertado");
                refrescar();

            }
            else
            {
                dsCrudTableAdapters.PersonaTableAdapter da = new dsCrudTableAdapters.PersonaTableAdapter();
                da.Editar(txtNombre.Text.Trim(), Convert.ToInt32(txtEdad.Value), (int)id);
                refrescar();

            }


        }

        private void button2_Click(object sender, EventArgs e)//editar
        {
            id = obtenerId();
            if (id != null)
            {
                dsCrudTableAdapters.PersonaTableAdapter ta = new dsCrudTableAdapters.PersonaTableAdapter();
                dsCrud.PersonaDataTable dt=ta.GetDataById((int)id);
                dsCrud.PersonaRow row = (dsCrud.PersonaRow)dt.Rows[0];
                txtNombre.Text = row.nombre;
                txtEdad.Value=row.edad;
            }

        }

        //obtenr id
        private int? obtenerId()//obtenr id
        {
            try
            {
                return int.Parse(
                    dataGridViewPeople.Rows[dataGridViewPeople.CurrentRow.Index].Cells[0].Value.ToString()

                    );
            }
            catch
            {
                return null;
            }
        }

        private void button3_Click(object sender, EventArgs e)//eliminar
        {
            id = obtenerId();
            if (id != null)
            {
                dsCrudTableAdapters.PersonaTableAdapter ta = new dsCrudTableAdapters.PersonaTableAdapter();
                ta.Remove((int)id);
                refrescar();

            }
        }
    }
}
