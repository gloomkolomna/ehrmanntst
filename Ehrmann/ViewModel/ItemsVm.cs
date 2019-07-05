using System.Collections.Generic;
using System.Collections.ObjectModel;
using Ehrmann.Core.Models.Interfaces;

namespace Ehrmann.ViewModel
{
    internal class ItemsVm : ObservableObject
    {
        private ObservableCollection<ContractVm> _contracts;

        public ItemsVm(IEnumerable<ICoreContract> contracts)
        {
            Contracts = new ObservableCollection<ContractVm>();
            foreach (var coreContract in contracts)
            {
                var contract = new ContractVm(coreContract);
                Contracts.Add(contract);
            }
        }

        public ObservableCollection<ContractVm> Contracts
        {
            get { return _contracts; }
            set { _contracts = value; OnPropertyChanged(); }
        }
    }
}