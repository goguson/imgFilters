﻿using ImgFilters.View;
using System;
using System.Windows;
using System.Windows.Input;

namespace ImgFilters.ViewModel.Commands
{
    public class BradleyCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private bool isLocked;
        public bool IsLocked
        {
            get { return isLocked; }
            set
            {
                isLocked = value;
                OnCanExecuteChanged();
            }
        }
        public ImgFiltersVM VM { get; set; }

        public BradleyCommand(ImgFiltersVM vm)
        {
            VM = vm;
            IsLocked = false;
            VM.Bradley = Visibility.Hidden;
        }

        public bool CanExecute(object parameter)
        {
            if (IsLocked) return false;
            else return true;
        }

        public void Execute(object parameter)
        {
            
            IsLocked = true;
            VM.GaussCommand.IsLocked = false;
            VM.Gauss = Visibility.Hidden;
            VM.Bradley = Visibility.Visible;

            

        }
        public void OnCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, new EventArgs());
            }
        }
    }
}