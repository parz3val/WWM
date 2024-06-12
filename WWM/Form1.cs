using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices; //required for dll import
using System.Management.Automation;
using System.Collections.ObjectModel;

namespace WWM
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
            Console.WriteLine("Hello World");
            KeyListener keyListener = new KeyListener();
            keyListener.onPress("ALT+1", windowHandler);
        }
        private void windowHandler()
        {
            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                PowerShellInstance.AddScript("Import-Module VirtualDesktop");
                Console.WriteLine("Executing the command!");
                // invoke execution on the pipeline (collecting output)
                PowerShellInstance.Invoke();

                PowerShellInstance.AddScript("Switch-Desktop 1");
                PowerShellInstance.Invoke();

                Console.WriteLine("Reading the command. Output");
                foreach (var error in PowerShellInstance.Streams.Error)
                {
                    Console.WriteLine("Error: " + error.ToString());
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
