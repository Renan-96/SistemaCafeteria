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
    }
}
