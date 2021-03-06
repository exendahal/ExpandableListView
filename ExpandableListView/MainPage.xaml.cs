using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExpandableListView
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<GroupModel> _allGroups;
        private ObservableCollection<GroupModel> _expandedGroups;
        public MainPage()
        {
            InitializeComponent();
            _allGroups = GroupModel.All;
            UpdateListContent();
        }
        private void HeaderTapped(object sender, EventArgs args)
        {
            var te = (TappedEventArgs)args;
            int selectedIndex = _expandedGroups.IndexOf(
                ((GroupModel)te.Parameter));
            _allGroups[selectedIndex].Expanded = !_allGroups[selectedIndex].Expanded;
            UpdateListContent();
        }

        private void UpdateListContent()
        {
            _expandedGroups = new ObservableCollection<GroupModel>();
            foreach (GroupModel group in _allGroups)
            {
                GroupModel newGroup = new GroupModel(group.Title, group.Expanded);

                if (group.Expanded)
                {
                    foreach (ItemModel item in group)
                    {
                        newGroup.Add(item);
                    }
                }
                _expandedGroups.Add(newGroup);
            }
            GroupedView.ItemsSource = _expandedGroups;
        }
    }
}
