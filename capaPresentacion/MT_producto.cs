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
    public partial class MT_producto : Form
    {
        proveedorBL proveedor = new proveedorBL();
        categoriaBL categoria = new categoriaBL();

        public MT_producto()
        {
            InitializeComponent();
        }

        private void MT_producto_Load(object sender, EventArgs e)
        {
            cargarCategoria();
            cargarProveedor();
        }

        public void cargarCategoria() 
        {
            cb_categoria.DataSource = categoria.Listado().Tables[0];
            cb_categoria.ValueMember = "codigo";
            cb_categoria.DisplayMember = "nombre";
        }

        public void cargarProveedor()
        {
            cb_proveedor.DataSource = proveedor.Listado().Tables[0];
            cb_proveedor.ValueMember = "codigo";
            cb_proveedor.DisplayMember = "nombre";
        }
    }
}
