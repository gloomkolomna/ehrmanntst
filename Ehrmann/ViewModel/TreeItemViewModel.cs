using System.Collections.ObjectModel;

namespace Ehrmann.ViewModel
{
    public class TreeItemViewModel : ObservableObject
    {
        private string _name;
        private TreeItemViewModel _owner;
        private bool _isRemoved;
        private bool _isExpanded;
        private bool _isEnabled;
        private bool _isSelected;
        private bool _isVisibility;

        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
                OnPropertyChanged();
            }
        }

        public bool IsExpanded
        {
            get
            {
                return _isExpanded;
            }
            set
            {
                _isExpanded = value;
                OnPropertyChanged();
            }
        }

        public bool IsRemoved
        {
            get
            {
                return _isRemoved;
            }

            protected set
            {
                _isRemoved = value;
                OnPropertyChanged();
            }
        }

        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
                OnPropertyChanged();
            }
        }

        /// <summary> Возвращает и устанавливает коллекцию элементов. </summary>
        /// <value> Коллекция элементов. </value>
        public virtual ObservableCollection<TreeItemViewModel> Items { get; private set; }

        /// <summary> Возвращает и устанавливает имя элемента. </summary>
        /// <value> Имя элемента. </value>
        public virtual string Name { get { return _name; } set { _name = value; } }

        /// <summary> Возвращает и устанавливает владельца элемента. </summary>
        /// <value> Владелец элемента. </value>
        public TreeItemViewModel Owner
        {
            get { return GetOwner(); }
            set { SetOwner(value); }
        }
        /// <summary> Возвращает владельца элемента. </summary>
        /// <returns> Владелец элемента. </returns>
        protected virtual TreeItemViewModel GetOwner()
        {
            return _owner;
        }

        /// <summary> Устанавливает владельца элемента. </summary>
        /// <param name="value"> Экземпляр владельца. </param>
        protected virtual void SetOwner(TreeItemViewModel value)
        {
            _owner = value;
        }

        public bool IsVisibility
        {
            get
            {
                return _isVisibility;
            }
            set
            {
                _isVisibility = value;
                OnPropertyChanged();
            }
        }
    }
}