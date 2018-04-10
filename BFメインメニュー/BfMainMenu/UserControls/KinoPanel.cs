using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B2.BestFunction.UserControls
{
    public partial class KinoPanel : UserControl
    {
        public KinoPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// controlを置き換える
        /// </summary>
        /// <param name="control"></param>
        public void Replace(Control control)
        {
            this.Controls.Clear();
            this.Controls.Add(control);
        }
    }
}
