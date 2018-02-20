using Ninject;
using Ninject.Parameters;
using Round42.Factories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetEditor2
{

    internal static class Program
    {
        [STAThread]
        internal static void Main()
        {
            using (var kernel = new StandardKernel())
            {
                var mw = kernel.Get<MainWindow>();
                mw.ShowDialog();
            }
        }
    }
}
