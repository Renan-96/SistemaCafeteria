using capaEntidades;
using capaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capaPresentacion
{
    public partial class MT_usuario : Form
    {
        usuarioBL usuario = new usuarioBL();

        public MT_usuario()
        {
            InitializeComponent();
        }

        private void MT_usuario_Load(object sender, EventArgs e)
        {
            listar();
            bloqueo();
        }

        private void bloqueo()
        {
            btn_agregar.Enabled = true;
            btn_eliminar.Enabled = false;
            btn_modificar.Enabled = false;
        }

        private void desbloqueo()
        {
            btn_agregar.Enabled = false;
            btn_eliminar.Enabled = true;
            btn_modificar.Enabled = true;
        }

        private void limpiar()
        {
            txt_codigo.Enabled = true;
            txt_codigo.Text = "";//modo uno de limpiar (.Text = "";")
            txt_nombre.Clear();//modo dos de limpiar (.Clear();)
            txt_clave.Clear();
            txt_codigo.Focus();
            bloqueo();
        }

        private void listar()
        {
            dataGridView1.DataSource = usuario.Listado().Tables[0];
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 180;
            dataGridView1.Columns[2].Width = 150;
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            if (txt_codigo.Text == "" || txt_nombre.Text == "" || txt_clave.Text == "")
            {
                MessageBox.Show("Complete todo los datos...!!", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (usuario.validarCodigo(int.Parse(txt_codigo.Text)))
            {
                MessageBox.Show("El codigo ya se encuentra registrado!!", "Error en codigo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            UsuarioEntity usu = new UsuarioEntity();
            usu.codigo = int.Parse(txt_codigo.Text);
            usu.nombre = txt_nombre.Text;
            usu.clave = txt_clave.Text;
            usuario.guardar(usu);
            listar();
            limpiar();
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (txt_codigo.Text == "" || txt_nombre.Text == "" || txt_clave.Text == "")
            {
                MessageBox.Show("Complete todo los datos...!!", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult a = MessageBox.Show("Desea actualizar los datos!!", "Modificar Categoria", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (a == DialogResult.Yes)
            {
                UsuarioEntity usu = new UsuarioEntity();
                usu.codigo = int.Parse(txt_codigo.Text);
                usu.nombre = txt_nombre.Text;
                usu.clave = txt_clave.Text;
                usuario.modificar(usu);
                listar();
                limpiar();
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            DialogResult suprimir = MessageBox.Show("Desea eliminar esta categoria!!", "Eliminar Categoria", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (suprimir == DialogResult.Yes)
            {
                UsuarioEntity usu = new UsuarioEntity();
                usu.codigo = int.Parse(txt_codigo.Text);
                usuario.eliminar(usu);
                listar();
                limpiar();
            }
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_codigo.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txt_nombre.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txt_clave.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txt_codigo.Enabled = false;
            desbloqueo();
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = usuario.buscar(txt_buscar.Text).Tables[0];
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 180;
            dataGridView1.Columns[2].Width = 150;
        }

        private void txt_codigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && !(char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
                return;
            }
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            global.GridAExcel(dataGridView1);
        }
    }
}
