using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Ehrmann.Core.Models.Interfaces;

namespace Ehrmann.ViewModel
{
    internal class ArticleGroupVm : ObservableObject
    {
        private string _name;
        private ObservableCollection<ConditionTypeVm> _conditionTypes;

        public ArticleGroupVm(ICoreArticleGroup coreArticleGroup, int coreContractId)
        {
            OwnerId = coreContractId;
            ConditionTypes = new ObservableCollection<ConditionTypeVm>();
            foreach (var coreConditionType in coreArticleGroup.ConditionTypes)
            {
                var conditionType = new ConditionTypeVm(coreArticleGroup.Id)
                {
                    Id = coreConditionType.Id,
                    Name = coreConditionType.Name,
                    Retro = coreConditionType.Retro,
                    RetroDistr = coreConditionType.RetroDistr,
                    Rku = coreConditionType.Rku,
                    RkuDistr = coreConditionType.RetroDistr
                };

                ConditionTypes.Add(conditionType);
            }
        }

        public int Retro
        {
            get
            {
                return ConditionTypes.Sum(conditionType => conditionType.Retro);
            }
        }

        public int RetroDistr
        {
            get
            {
                return ConditionTypes.Sum(conditionType => conditionType.RetroDistr);
            }
        }
        public int Rku
        {
            get
            {
                return ConditionTypes.Sum(conditionType => conditionType.Rku);
            }
        }
        public int RkuDistr
        {
            get
            {
                return ConditionTypes.Sum(conditionType => conditionType.RkuDistr);
            }
        }

        public int Id { get; set; }
        public int OwnerId { get; set; }

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged();}
        }

        public ObservableCollection<ConditionTypeVm> ConditionTypes
        {
            get { return _conditionTypes; }
            set { _conditionTypes = value; OnPropertyChanged(); }
        }
    }
}