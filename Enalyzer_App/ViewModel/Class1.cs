using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Enalyzer.App.ViewModel
{
    public class Class1 : INotifyPropertyChanged
    {
        DatePicker datePicker = new DatePicker
        {
            MinimumDate = new DateTime(2018, 1, 1),
            MaximumDate = new DateTime(2018, 12, 31),
            Date = new DateTime(2018, 6, 21)
        };

        string nameDatabase;
        string tag;
        DateTime SelectedDateFrom = new DateTime();
        DateTime SelectedDateTo = new DateTime();

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public Command GetTagsCommand { get; }

        public bool FetchingData { get; private set; }

        public string NameDatabase
        {
            get { return nameDatabase; }
            set
            {
                nameDatabase = value;
                OnPropertyChanged(nameof(NameDatabase));
                OnPropertyChanged(nameof(DisplayMessage));
            }
        }

        public string Tag
        {
            get { return tag; }
            set
            {
                tag = value;
                OnPropertyChanged(nameof(Tag));
                OnPropertyChanged(nameof(DisplayMessage));
            }
        }

        public DateTime From
        {
            get { return SelectedDateFrom; }
            set { SelectedDateFrom = value; }
        }

        public DateTime To
        {
            get { return SelectedDateTo; }
            set { SelectedDateTo = value; }
        }

        public string DisplayMessage
        {
            get
            {
                return $"van Databank {NameDatabase}\nTag: {Tag}\n" +
                $"tussen\n {SelectedDateFrom}\n en \n{SelectedDateTo }";
            }
        }

        async Task LookUpValues()
        {
            FetchingData = true;
            await Task.Delay(4000);
            FetchingData = false;
            await Application.Current.MainPage.DisplayAlert("Fetching", "Fetching", "Naah");
        }

    }
}

