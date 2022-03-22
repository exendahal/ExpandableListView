using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

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
            get { return Expanded ? "⇓" : "⇑"; }
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
                new GroupModel("Mobile"){
                    new ItemModel { Name = "Iphone" },
                    new ItemModel { Name = "Samsung" },
                    new ItemModel { Name = "MI" },
                   
                },
                new GroupModel("Laptop"){
                   new ItemModel { Name = "Mac" },
                   new ItemModel { Name = "Dell" },
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
