using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ExpandableListView
{
    public class GroupModel : ObservableCollection<ItemModel>, INotifyPropertyChanged
    {
        private bool _expanded;

        public string Title { get; set; }

        public bool Expanded
        {
            get { return _expanded; }
            set
            {
                if (_expanded != value)
                {
                    _expanded = value;
                    OnPropertyChanged("Expanded");
                    OnPropertyChanged("StateIcon");
                }
            }
        }

        public string StateIcon
        {
            get { return Expanded ? "\uf140" : "\uf143"; }
        }

        public GroupModel(string title, bool expanded = true)
        {
            Title = title;
            Expanded = expanded;

        }
        public static ObservableCollection<GroupModel> All { private set; get; }

        static GroupModel()
        {
            ObservableCollection<GroupModel> Groups = new ObservableCollection<GroupModel>{
                new GroupModel("Smart Phone"){
                    new ItemModel { Name = "Apple" },
                    new ItemModel { Name = "LG" },
                    new ItemModel { Name = "MI" },
                    new ItemModel { Name = "Samsung" },
                    new ItemModel { Name = "Sony" },
                   
                },
                new GroupModel("Laptop"){
                   new ItemModel { Name = "Apple" },
                   new ItemModel { Name = "Dell" },
                   new ItemModel { Name = "Acer" },
                },
               };
            All = Groups;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
