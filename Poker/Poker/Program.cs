using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

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

            var soundPlayer = new SoundPlayer(Properties.Resources.music);

            GameForm gameForm = new GameForm(soundPlayer);
            SplashForm splashForm = new SplashForm(gameForm, soundPlayer);
            gameForm.initArgs(splashForm);
            

            Application.Run(splashForm);


        }
    }
}
