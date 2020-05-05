using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using BusinessUI.Annotations;

namespace BusinessUI.Services.IncomeEntriesLogic
{
    public class IncomeTimeButton : INotifyPropertyChanged
    {
        public string ButtonId { get; set; }

        private double _borderWidth;
        public double BorderWidth
        {
            get => _borderWidth;
            set
            {
                _borderWidth = value;
                OnPropertyChanged(nameof(BorderWidth));
            }
        }
        public string ButtonText { get; set; }
        public ICommand ShowIncomes { get; set; }

        public IncomeTimeButton(string buttonId, double borderWidth, string buttonText, ICommand showIncomes)
        {
            this.ButtonId = buttonId;
            this.BorderWidth = borderWidth;
            this.ButtonText = buttonText;
            this.ShowIncomes = showIncomes;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
