using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGameUI
{
    internal class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            MemoryGameEntranceForm FormToShow = new MemoryGameEntranceForm();
            FormToShow.StartPosition = FormStartPosition.CenterScreen;
            FormToShow.ShowDialog();
        }
    }
}
