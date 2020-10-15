using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZeroUnpacker
{
    /// <summary>
    /// MainWindow.xaml Interaction logic
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public delegate void Invoke(int value);
        private void button_Click(object sender, RoutedEventArgs e)
        {
            
            Config.bUseExternalDeLess = false;
            if (checkBox.IsChecked.Value == true)
            {
                Config.bUseExternalDeLess = true;
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select FHD file";
            openFileDialog.Filter = "FHD file|*.FHD";
            openFileDialog.FileName = string.Empty;
            if (openFileDialog.ShowDialog().Value)
            {
                string filename = openFileDialog.FileName;
                FatalFrame.GetFHDInfo(filename);
            }
            MessageBox.Show("Operation completed");
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select FHD file";
            openFileDialog.Filter = "FHD file|*.FHD";
            openFileDialog.FileName = string.Empty;
            if (openFileDialog.ShowDialog().Value)
            {
                string filename = openFileDialog.FileName;
                bool result = Patcher.PatchIMG(filename);
                if (result)
                {
                    MessageBox.Show("Patch complete");
                }
                else
                {
                    MessageBox.Show("Patch failed");
                }
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Config.bUseLIMGPatch = false;
            if (checkBox2.IsChecked.Value == true)
            {
                Config.bUseLIMGPatch = true;
            }
            string imlPath = "";
            string isoPath = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select FHD file";
            openFileDialog.Filter = "iml file|*.iml";
            openFileDialog.FileName = string.Empty;
            if (openFileDialog.ShowDialog().Value)
            {
                imlPath = openFileDialog.FileName;
                isoPath = imlPath + ".iso";
                if (imlPath.Length > 4)
                {
                    Base.WriteLogging(String.Format("iml2iso:{0},{1}", imlPath , isoPath));
                    new iml2iso.imlClass(imlPath, isoPath).Rebuild();
                    MessageBox.Show("ISO Rebuild Completed!");
                    if (Config.bUseLIMGPatch == true)
                    {
                        string path = string.Format(@"{0}", Environment.CurrentDirectory);
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        process.StartInfo.FileName = string.Format("{0}\\LIMGpatcher.exe", path);
                        process.StartInfo.WorkingDirectory = path;
                        process.StartInfo.UseShellExecute = false;
                        process.StartInfo.CreateNoWindow = false;
                        process.Start();
                        process.WaitForExit();
                    }

                }
                else
                {
                    MessageBox.Show("Error:Wrong iml Name");
                }  
            }
        }
    }
}
