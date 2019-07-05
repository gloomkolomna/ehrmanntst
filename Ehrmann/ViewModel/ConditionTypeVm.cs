using System;
using System.Collections.Generic;
using Ehrmann.Core.Models.Interfaces;

namespace Ehrmann.ViewModel
{
    internal class ConditionTypeVm : ObservableObject
    {
        private int _retro;
        private int _retroDistr;
        private int _rku;
        private int _rkuDistr;
        private string _name;

        public ConditionTypeVm(int ownerId)
        {
            OwnerId = ownerId;
        }

        public int Retro
        {
            get { return _retro; }
            set { _retro = value; OnPropertyChanged(); }
        }

        public int RetroDistr
        {
            get { return _retroDistr; }
            set { _retroDistr = value; OnPropertyChanged(); }
        }

        public int Rku
        {
            get { return _rku; }
            set { _rku = value; OnPropertyChanged(); }
        }

        public int RkuDistr
        {
            get { return _rkuDistr; }
            set { _rkuDistr = value; OnPropertyChanged(); }
        }

        public int Id { get; set; }
        public int OwnerId { get; set; }

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }
    }
}