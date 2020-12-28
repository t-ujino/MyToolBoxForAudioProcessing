using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;

namespace MyToolBoxForAudioProcessing
{
    public class ListViewDataContext : INotifyPropertyChanged
    {
        private string name;
        private string _value;

        private Visibility indicatorVisibility = Visibility.Hidden;

        public Visibility IndicatorVisibility
        {
            get { return indicatorVisibility; }
            set {
                if (value == indicatorVisibility) return;
                indicatorVisibility = value;
                RaisePropertyChanged();
            }
        }

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
