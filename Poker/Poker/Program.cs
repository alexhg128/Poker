using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poker
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GameForm gameForm = new GameForm();
            SplashForm splashForm = new SplashForm(gameForm);
            gameForm.initArgs(splashForm);

            Application.Run(splashForm);
        }
    }
}
