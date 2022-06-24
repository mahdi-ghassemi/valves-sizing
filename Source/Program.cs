using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Radman
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static string ProgramPath;
        public static string DatabasePath;
        public static string ImagesPath;
        public static string ConnectionString;
        public static List<Fluid> FluidList = new List<Fluid>();
        public static List<Units> UnitsList = new List<Units>();
        public static List<Project> ProjectList = new List<Project>();
        public static List<Error> ErrorList = new List<Error>();
        public static List<Symbols> SymbolList = new List<Symbols>();
        public static List<BodyMaterials> BodyMaterialsList = new List<BodyMaterials>();
        public static int CurrentProjectSelectedIndex;
        public static string UserId = "1";
        public static List<string> SelectedProjectsIdTable = new List<string>();

        [STAThread]
        static void Main()
        {
            ConnectionString = GetSqlCS();
            if (ConnectionString == "")
                Application.Exit();           
                  
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());            
        }

        static string GetSqlCS()
        {
            try
            {
                string line;
                StreamReader file = new StreamReader(Application.StartupPath + @"\SqlCS.txt");
                line = file.ReadLine();
                file.Close();
                return line;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return "";
            }
        }
    }
}