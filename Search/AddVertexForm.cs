using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Search
{
    public partial class AddVertexForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public AddVertexForm()
        {
            InitializeComponent();
        }
        public double Heuristic;
        public string Name;
        public bool Add = false;
        private void addbtn_Click(object sender, EventArgs e)
        {
            Add = true;
            Name = node_name.Text;
            Heuristic = node_heuris.Value;
            this.Close();
        }
    }
}
