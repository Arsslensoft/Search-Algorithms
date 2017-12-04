using DevComponents.DotNetBar;
using Search.Base;
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
    public partial class AddEdgeForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public AddEdgeForm(ComboBoxItem[] items)
        {
            InitializeComponent();
            source.Items.AddRange(items);
            target.Items.AddRange(items);
        }
        public bool Add = false;
        public double Weight;
        public Node<string> Source, Target;
        private void buttonX1_Click(object sender, EventArgs e)
        {
            Add = true;
            Source = (source.SelectedItem as ComboBoxItem).Tag as Node<string>;
            Target = (target.SelectedItem as ComboBoxItem).Tag as Node<string>;
            Weight = doubleInput1.Value;
            this.Close();

        }
    }
}
