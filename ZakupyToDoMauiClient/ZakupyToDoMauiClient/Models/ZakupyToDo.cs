using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZakupyToDoMauiClient.Models
{
    public class ZakupyToDo : INotifyPropertyChanged
    {
        int _id;
        public int Id
        {
            get => _id;
            set
            {
                if (_id == value)
                    return;

                _id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
            }
        }


        string _zakupytodoname;

        public string ZakupyToDoName
        {
            get => _zakupytodoname;
            set
            {
                if (_zakupytodoname == value)
                    return;

                _zakupytodoname = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ZakupyToDoName)));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}