using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WinUiTest
{
    public class ViewModel : INotifyPropertyChanged
    {
        private DateTimeOffset selectedDate;
        public ObservableCollection<string> Dates { get; } = new();

        public DateTimeOffset SelectedDate
        {
            get => selectedDate;
            set
            {
                if (selectedDate != value)
                {
                    selectedDate = value;
                    OnPropertyChanged();
                }
            }
        }

        private void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}