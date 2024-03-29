﻿using ImgFilters.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ImgFilters.ViewModel.Commands
{
    public class LoadKernelCommand : ICommand
    {
        //TODO: add in vm
        public event EventHandler CanExecuteChanged;
        public ImgFiltersVM VM { get; set; }
        public LoadKernelCommand(ImgFiltersVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            OpenFileDialog dialog_window = new OpenFileDialog();
            dialog_window.Filter = "XML Files (*.xml)|*.xml";
            dialog_window.FilterIndex = 0;
            dialog_window.DefaultExt = "xml";
            if (dialog_window.ShowDialog() == true)
            {

                if (!String.Equals(Path.GetExtension(dialog_window.FileName), ".xml", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("xml only");
                }
                else
                {
                    var temp = FileManager.ReadFromXmlFile<Kernel>(dialog_window.FileName);
                    if (temp.GetType() == typeof(Kernel))
                    {
                        VM.Kernel = temp;
                    }
                }


            }
        }
    }
}
