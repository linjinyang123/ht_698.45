using ht_698._45.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ht_698._45
{
    public partial class Aboat : Form
    {
        public Aboat(Form_Main parent)
        {
            InitializeComponent();
            base.MdiParent = parent;
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            base.Close();
        }
    }
}
