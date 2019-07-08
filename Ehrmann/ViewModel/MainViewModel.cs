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
        private ObservableCollection<ItemsVm> _items;
        private ContractVm _selectedContract;

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
            var core = Helpers.GetEhrmannCore(SourceType.MSSQL, ConnectionString);
            var contracts = Helpers.GetContracts(core);
            if (contracts.Any())
            {
                Items = new ObservableCollection<ItemsVm>();
                var item = new ItemsVm(contracts, this);
                Items.Add(item);
            }
        }

        public ObservableCollection<ItemsVm> Items
        {
            get { return _items; }
            set { _items = value; OnPropertyChanged(); }
        }

        public ContractVm SelectedContract
        {
            get
            {
                return _selectedContract;
            }
            set
            {
                _selectedContract = value;
                OnPropertyChanged();
            }
        }
    }
}