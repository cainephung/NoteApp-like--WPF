// Filename:	MainWindow.xaml.cs
// Author:		Caine Phung
// Date:		Oct 12, 2022
// Description:	Notepad.


using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Notepad
{


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        private bool fileSaved;
        private bool fileChanged;

        public bool FileChanged { get { return fileChanged; } set { fileChanged = value; } }
        public bool FileSaved { get { return fileSaved; } set { fileSaved = value; } }


        /*
        * METHOD : MainWindow
        * DESCRIPTION :MainWindow
        * PARAMETERS : none
        */

        public MainWindow()
        {

            InitializeComponent();
        }




        /*
        * METHOD : About
        * DESCRIPTION : the standard information about the application.
        * PARAMETERS : (object sender, RoutedEventArgs e)
        {
        */
        private void About(object sender, RoutedEventArgs e)
        {

            About modalWindow = new About();
            modalWindow.ShowDialog();
        }




        /*
        * METHOD : Window_Closing
        * DESCRIPTION : Close
        * PARAMETERS : (object sender, System.ComponentModel.CancelEventArgs e)
        * RETURNS : none
        */

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if ((FileSaved == false) && (FileChanged == true))
            {
                // MessageBoxButton.Yes = "Save";
                var choice = MessageBox.Show("Do you want to save changes to " + this.Title, "Notepad", MessageBoxButton.YesNoCancel, MessageBoxImage.Information);
               
                switch (choice)
                {
                    //save
                    case MessageBoxResult.Yes:

                        SaveFileDialog sfd = new SaveFileDialog();


                        sfd.Filter = "TXT Files|*.txt|All files|*.*";
                        bool? retValue = sfd.ShowDialog();

                        if (retValue == true)
                        {
                            this.Title = sfd.SafeFileName;
                            FileSaved = true;
                           
                            break;
                        }

                        else
                        {
                            e.Cancel = true;
                            break;
                        }

                    //dont save
                    case MessageBoxResult.No:
                       
                        FileSaved = false;
                       
                        break;

                    //cancel
                    case MessageBoxResult.Cancel:

                        e.Cancel = true;
                        FileSaved = false;
                        break;
                }
            }

            else
            {

                FileSaved = false;       
            }
            
        }



        /*
        * METHOD : overloaded Window_Closing
        * DESCRIPTION : Close
        * PARAMETERS : (object sender, RoutedEventArgs e)
        * RETURNS : none
        */

        private void Window_Closing(object sender, RoutedEventArgs e)
        {
            Close();
        }




        /*
        * METHOD : SaveAsCommand_Executed
        * DESCRIPTION : Save As
        * PARAMETERS : (object sender, RoutedEventArgs e)
        * RETURNS : none
        */
        private void SaveAsCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            //sfd.FileName = "Choose something.";
            sfd.Filter = "TXT Files|*.txt|All files|*.*";
            bool? retValue = sfd.ShowDialog();

            if (retValue == true)
            {
                
               this.Title = sfd.SafeFileName;
               FileSaved = true;
               FileChanged = false;
               File.WriteAllText(sfd.FileName, this.txtWorkarea.Text);
            }
        }



        /*
        * METHOD :  SaveAsCommand_CanExecute
        * DESCRIPTION : Save As
        * PARAMETERS : (object sender, CanExecuteRoutedEventArgs e)
        * RETURNS : none
        */

        private void SaveAsCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }




        /*
        * METHOD :  txtWorkarea_TextChanged
        * DESCRIPTION : When text box's text changes
        * PARAMETERS : (object sender, TextChangedEventArgs e)
        * RETURNS : none
        */

        private void txtWorkarea_TextChanged(object sender, TextChangedEventArgs e)
        {

            FileChanged = true;
            FileSaved = false;
        }




        /*
        * METHOD : Open
        * DESCRIPTION : Open file
        * PARAMETERS :( object sender, RoutedEventArgs e)
        * RETURNS : none
        */

        private void Open(object sender, RoutedEventArgs e)
        {
            string string1 = "";

            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "TXT Files|*.txt|All files|*.*";
            bool? retValue = false;

            if ((FileSaved == false) && (FileChanged == true))
            {
                
                var choice = MessageBox.Show("Do you want to save changes to " + this.Title, "Notepad", MessageBoxButton.YesNoCancel, MessageBoxImage.Information);

                switch (choice)
                {

                    //save
                    case MessageBoxResult.Yes:
                        
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "TXT Files|*.txt|All files|*.*";
                        bool? retValue1 = sfd.ShowDialog();
                       
                        if (retValue1 == true)
                            {
                                this.Title = sfd.SafeFileName;
                            retValue = ofd.ShowDialog();
                           
                            // open
                            if (retValue == true)
                            {
                                string1 = File.ReadAllText(ofd.FileName);
                                txtWorkarea.Text = string1;
                                this.Title = ofd.SafeFileName;
                            }

                            //write file
                            FileSaved = true;
                            FileChanged = false;
                            File.WriteAllText(sfd.FileName, this.txtWorkarea.Text);
                            break;
                        }

                        else
                        {
                            break;
                        }
                        
                    // dont save
                    case MessageBoxResult.No:

                        retValue = ofd.ShowDialog();
                        
                        //open
                        if (retValue == true)
                        {
                            string1 = File.ReadAllText(ofd.FileName);
                            txtWorkarea.Text = string1;
                            this.Title = ofd.SafeFileName;
                            
                            FileSaved = false;
                            FileChanged = false;
                        }

                        break;
                    
                    //cancel
                    case MessageBoxResult.Cancel:

                        FileSaved = false;
                        break;
                }
            }

            else
            {
                retValue = ofd.ShowDialog();
               //open
                if (retValue == true)
                {

                    string1 = File.ReadAllText(ofd.FileName);
                    txtWorkarea.Text = string1;
                    this.Title = ofd.SafeFileName;
                    FileSaved = false;
                    FileChanged = false;
                }
            }
        }





        /*
        * METHOD : NewFile
        * DESCRIPTION : Open new file
        * PARAMETERS : object sender, RoutedEventArgs e)
        * RETURNS : none
        */

        private void NewFile(object sender, RoutedEventArgs e)
        {     
            
            if ((FileSaved == false) && (FileChanged == true))
            {
                var choice = MessageBox.Show("Do you want to save changes to " + this.Title, "Notepad", MessageBoxButton.YesNoCancel, MessageBoxImage.Information);
                
                //save
                 switch (choice)
                {

                    //save
                    case MessageBoxResult.Yes:

                        SaveFileDialog sfd = new SaveFileDialog();

                        
                        sfd.Filter = "TXT Files|*.txt|All files|*.*";
                        bool? retValue = sfd.ShowDialog();
                        
                        if (retValue == true)
                        {
                            this.Title = sfd.SafeFileName;
                            
                            File.WriteAllText(sfd.FileName, this.txtWorkarea.Text);
                            this.Title = "Untitled - Notepad";
                            txtWorkarea.Text = "";
                            FileSaved = true;
                            break;
                        }

                        else
                        {
                            break;
                        }
              
                    // dont save
                    case MessageBoxResult.No:

                        FileSaved = false;
                        this.Title = "Untitled - Notepad";
                        txtWorkarea.Text = "";

                        break;
                    
                    //cancel
                    case MessageBoxResult.Cancel:

                        FileSaved = false;
                        break;
                }
            }

            else
            {
                
                this.Title = "Untitled - Notepad";
                txtWorkarea.Text = "";
                FileSaved = true;

            }
        }
    }
}
