using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Ehrmann.Core.Models.Interfaces;

namespace Ehrmann.ViewModel
{
    internal class ContractVm : ObservableObject
    {
        private string _name;
        private DateTime _startDate;
        private DateTime _endDate;
        private ObservableCollection<ArticleGroupVm> _articleGroups;
        private bool _isSelected;
        private MainViewModel _owner;

        public ContractVm(ICoreContract coreContract)
        {
            Name = coreContract.Name;
            StartDate = coreContract.StartDate;
            EndDate = coreContract.EndDate;
            Id = coreContract.Id;

            ArticleGroups = new ObservableCollection<ArticleGroupVm>();
            foreach (var coreArticleGroup in coreContract.ArticleGroups)
            {
                var articleGroup = new ArticleGroupVm(coreArticleGroup, Id)
                {
                    Name = coreArticleGroup.Name
                };

                ArticleGroups.Add(articleGroup);
            }
        }

        public ContractVm(ICoreContract coreContract, MainViewModel owner) : this(coreContract)
        {
            _owner = owner;
        }

        public int Id { get; set; }

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; OnPropertyChanged(); }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; OnPropertyChanged(); }
        }

        public ObservableCollection<ArticleGroupVm> ArticleGroups
        {
            get { return _articleGroups; }
            set { _articleGroups = value; OnPropertyChanged(); }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                OnPropertyChanged();
                if (value)
                    _owner.SelectedContract = this;
            }
        }
    }
}