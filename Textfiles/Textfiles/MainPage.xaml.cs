using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Textfiles.Resources;
using System.IO.IsolatedStorage;
using System.IO;

namespace Textfiles
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            //if using directory
            //uncomment the following line given below
            //createdirectory();
        }

        //filename
        string filename = "Samplefile.txt";


        //If you are reading and writing files to the directory call the function in constructor of class
        public void createdirectory()
        {
            IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication();
            myIsolatedStorage.CreateDirectory("TextFilesFolder");
            filename = "TextFilesFolder\\Samplefile.txt";
        }

        //creating a new text file
        private void Create_new_file(object sender, RoutedEventArgs e)
        {
            IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication();

            //Best practice that need to be followed
            //Before creating a file check that no file with same name has been created before in isolated storage.
            //If you don't follow this and any file with same name has been created before the below code will give an exception

            if (!myIsolatedStorage.FileExists(filename))
            {
                using (StreamWriter writeFile = new StreamWriter(new IsolatedStorageFileStream(filename, FileMode.Create, FileAccess.Write, myIsolatedStorage)))
                {
                    string someTextData = "Use Tuts+ to Learn Creative Skills, Shape Your Future";
                    writeFile.WriteLine(someTextData);
                    writeFile.Close();
                }
            }
        }


        //Read from the text file

        private void Read_from_the_text_File(object sender, RoutedEventArgs e)
        {
            IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication();

            //Best practice that need to be followed
            //Before reading from the file check that the file with given name exists in isolated storage

            if (myIsolatedStorage.FileExists(filename))
            {
                IsolatedStorageFileStream fileStream = myIsolatedStorage.OpenFile(filename, FileMode.Open, FileAccess.Read);
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    Displayblock.Text = reader.ReadToEnd();
                    //if you use reader.Readline() it will read the first line of the file
                }
            }

        }


        //Write to the existing file

        private void Write_or_change_the_data_of_file(object sender, RoutedEventArgs e)
        {
            IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication();

            //Best practice that need to be followed
            //Before writng to the file check whether file with the given name exists in isolated storage or not
            if (myIsolatedStorage.FileExists(filename))
            {
                using (StreamWriter writeFile = new StreamWriter(new IsolatedStorageFileStream(filename, FileMode.Open, FileAccess.Write, myIsolatedStorage)))
                {
                    string someTextData = "Use Tuts+ to Learn Creative Skills, Shape Your Future";
                    writeFile.WriteLine(someTextData);
                    writeFile.Close();
                }
            }
        }


        //Append data to the existing file
        private void Append_data_to_the_existing_file(object sender, RoutedEventArgs e)
        {
            IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication();

            //Best practice that need to be followed
            //Before writng to the file check whether file with the given name exists in isolated storage or not
            if (myIsolatedStorage.FileExists(filename))
            {
                if (myIsolatedStorage.FileExists(filename))
                {
                    using (StreamWriter writeFile = new StreamWriter(new IsolatedStorageFileStream(filename, FileMode.Append, FileAccess.Write, myIsolatedStorage)))
                    {
                        string someTextData = "Tuts+";
                        writeFile.WriteLine(someTextData);
                        writeFile.Close();
                    }
                }
            }
        }


        //Delete the file
        private void Delete_the_text_file(object sender, RoutedEventArgs e)
        {
            IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication();
          
            //Best practice that need to be followed
            //Before deleting the file check whether file with the given name exists in isolated storage or not
            if (myIsolatedStorage.FileExists(filename))
            {
                myIsolatedStorage.DeleteFile(filename);
            }

        }



      
    }
}