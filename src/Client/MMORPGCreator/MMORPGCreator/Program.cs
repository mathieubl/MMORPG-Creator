using System;
using System.Windows.Forms;
namespace MmorpgEngine
{
#if WINDOWS
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main(string[] args)
        {
            GlobalClass.Program = GlobalClass.CLIENT;

            Application.EnableVisualStyles();

            GlobalDataEditor.EngineEditorWinform.Projects = new frmprojects();
            Application.Run(GlobalDataEditor.EngineEditorWinform.Projects);

            if (GlobalDataGame.online == true)
                Application.Run(GlobalDataEditor.EngineEditorWinform.Login = new frmlogin());

           
           GlobalDataGame.GameScreen = new Game();
           GlobalDataGame.GameScreen.Run();
        }

    }
#endif
}

