using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MyToolBoxForAudioProcessing
{
    public class ListViewDataContext : INotifyPropertyChanged
    {
        private string name;
        private string _value;

        public string Name
        {
            get => name;
            set
            {
                if (value == name) return;
                name = value;
                RaisePropertyChanged();
            }
        }
        public string Value
        {
            get => _value;
            set
            {
                if (_value == value) return;
                _value = value;
                RaisePropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
