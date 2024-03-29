﻿using System;
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
    public partial class MenuCafeteria : Form
    {

        public MenuCafeteria()
        {
            InitializeComponent();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MT_categorias obj = new MT_categorias();
            // obj.MdiParent = this;
            obj.ShowDialog();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MT_proveedores obj = new MT_proveedores();
            obj.ShowDialog();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MT_producto obj = new MT_producto();
            obj.ShowDialog();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MT_usuario obj = new MT_usuario();
            obj.ShowDialog();
        }
    }
}
