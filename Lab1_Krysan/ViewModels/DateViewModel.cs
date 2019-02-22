using Lab1_Krysan.Models;
using Lab1_Krysan.Tools.Managers;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Lab1_Krysan.ViewModels
{
    class DateViewModel : INotifyPropertyChanged
    {
        private DateTime _date;
        private string _age;
        private string _chineaseAstrologicalSign;
        private string _astrologicalSign;

        public DateViewModel()
        {
        }

        public DateTime Date
        {
            get { return _date; }

            set
            {
                if (this._date == value)
                {
                    return;
                }
                _date = value;
                CountAgeAndSign();
                OnPropertyChanged();
            }
        }

        public string Age
        {
            get { return _age; }

            set
            {
                _age = value;
                OnPropertyChanged();
            }
        }

        public string ChineaseAstrologicalSign
        {
            get { return _chineaseAstrologicalSign; }

            set
            {
                _chineaseAstrologicalSign = value;
                OnPropertyChanged();
            }
        }

        public string AstrologicalSign
        {
            get { return _astrologicalSign; }

            set
            {
                _astrologicalSign = value;
                OnPropertyChanged();
            }
        }

        private async void CountAgeAndSign()
        {
            LoaderManager.Instance.ShowLoader();
            User user = null;
            bool isError = false;
            await Task.Run(() =>
            {
                try
                {
                    user = new User(_date);
                    Age ="Age : " + user.CountAge().ToString();
                    AstrologicalSign = "Astrological Sign : " + user.DeterminateSign();
                    ChineaseAstrologicalSign = "Chinease Astrological Sign : " + user.DeterminateChineaseSign();
                }
                catch (Exception e)
                {
                    isError = true;
                }
            }
            );
            if (isError)
            {
                MessageBox.Show("Input date is invalid");
            }
            if (user!= null && user.IsBirthDay())
            {
                MessageBox.Show("Happy BirthDay!!!");
            }
            LoaderManager.Instance.HideLoader();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
