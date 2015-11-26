using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DrLektor
{
    class MusicListVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<MusicFile> musics;

        public ObservableCollection<MusicFile> Musics
        {
            get { return musics; }
            set
            {
                musics = value;
                RaisePropertyChanged("Musics");
            }
        }

        public MusicListVM ()
        {
            Musics = new ObservableCollection<MusicFile>()
            {
                new MusicFile("test"),
                new MusicFile("test2")
            };
        }

        private void LoadMusicFromFileExecute()
        {
            var openDialog = new OpenFileDialog();
            openDialog.Multiselect = true;
            openDialog.Filter = "Musiques (*.mp3)|*.mp3";

            if (openDialog.ShowDialog() == true)
            {
                foreach (var nom in openDialog.SafeFileNames)
                {
                    Musics.Add(new MusicFile(nom));
                }
            }
        }

        private bool CanLoad ()
        {
            return true;
        }

        public ICommand LoadMusics { get { return new RelayCommand(LoadMusicFromFileExecute, CanLoad); } }

        private void RaisePropertyChanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
