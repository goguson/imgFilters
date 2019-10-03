﻿using ImgFilters.ViewModel.Commands;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace ImgFilters.ViewModel
{
    public class ImgFiltersVM : INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler PropertyChanged;

        private BitmapImage uploadedPhoto;

        public BitmapImage UploadedPhoto
        {
            get { return uploadedPhoto; }
            set
            {
                uploadedPhoto = value;
                OnPropertyChanged("UploadedPhoto");
            }
        }

        public AfterPhotoCommand AfterPhotoCommand { get; set; }
        public BradleyCommand BradleyCommand { get; set; }
        public GaussCommand GaussCommand { get; set; }
        public OriginalPhotoCommand OriginalPhotoCommand { get; set; }
        public SelectPhotoCommand SelectPhotoCommand { get; set; }

        public ImgFiltersVM()
        {
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            AfterPhotoCommand = new AfterPhotoCommand(this);
            BradleyCommand = new BradleyCommand(this);
            GaussCommand = new GaussCommand(this);
            OriginalPhotoCommand = new OriginalPhotoCommand(this);
            SelectPhotoCommand = new SelectPhotoCommand(this);
        }

        public void SelectImage()
        {
            OpenFileDialog dialog_window = new OpenFileDialog();
            dialog_window.Filter = "Image files (*.png; *.jpg;)|*.png;*.jpg;*.jpeg|All files(*.*)|*.*";
            if (dialog_window.ShowDialog() == true)
            {
                string filePath = dialog_window.FileName;
                UploadedPhoto = new BitmapImage(new Uri(filePath));
            }
        }

        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}