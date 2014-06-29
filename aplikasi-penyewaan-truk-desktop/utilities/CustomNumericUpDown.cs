using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace desktop.utilities
{
    class CustomNumericUpDown : NumericUpDown
    {
        //Override this to format the displayed text
        protected override void UpdateEditText()
        {
            Text = Value.ToString("0." + new string('#', DecimalPlaces));
        }

    }
}
