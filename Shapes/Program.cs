using Shapes.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shapes
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


           
            string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + @"\Files";

            var viewMain = new Views.MainView();
            var repo = new ModelsStore.Repository(path);
   
            var presenterMain = new Presenters.MainViewPresenter(viewMain, repo);

            

            Application.Run(viewMain);
        }


    }
}
