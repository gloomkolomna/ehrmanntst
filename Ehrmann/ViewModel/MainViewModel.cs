using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Ehrmann.Core;

namespace Ehrmann.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        private string _connectionString;
        private bool _isApplySelect;
        private ICommand _applySelectCommand;
        private IEhrmannCore _ehrmannCore;
        private ObservableCollection<ContractVm> _contracts;

        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; OnPropertyChanged(); }
        }

        public bool IsApplySelect
        {
            get { return _isApplySelect; }
            set { _isApplySelect = value; OnPropertyChanged(); }
        }

        public ICommand ApplySelectCommand
        {
            get
            {
                return _applySelectCommand ??
                       (_applySelectCommand = new RelayCommand(param => ApplySelect()));
            }
        }

        private void ApplySelect()
        {
            IsApplySelect = true;
            LoadData();
        }

        private void LoadData()
        {
            _ehrmannCore = EhrmannCore.Create(SourceType.MSSQL, ConnectionString);
            var contracts = _ehrmannCore.GetContracts();
            if (contracts.Any())
            {
                Contracts = new ObservableCollection<ContractVm>();
                foreach (var coreContract in contracts)
                {
                    var contract = new ContractVm(coreContract);
                    Contracts.Add(contract);
                }
            }
        }

        public ObservableCollection<ContractVm> Contracts
        {
            get { return _contracts; }
            set { _contracts = value; OnPropertyChanged();}
        }
    }
}