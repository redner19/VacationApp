using StartVacation.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace StartVacation.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<PropertyType> PropertyTypeList { set; get; }
        private ObservableCollection<Property> propertyList;

        public ObservableCollection<Property> PropertyList
        {
            get { return propertyList; }
            set { propertyList = value;
                OnPropertyChanged(nameof(PropertyList));
            }
        }
        private string searchQuery;

        public string SearchQuery
        {
            get { return searchQuery; }
            set { searchQuery = value;
                OnPropertyChanged(nameof(SearchQuery));
                SearchNow(SearchQuery);
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public MainPageViewModel()
        {
            PropertyList = GetProperties();
            PropertyTypeList = GetPropertyTypes();
        }

        private ObservableCollection<PropertyType> GetPropertyTypes()
        {
            return new ObservableCollection<PropertyType>
            {
                new PropertyType { TypeName = "All" },
                new PropertyType { TypeName = "2 Bed" },
                new PropertyType { TypeName = "3 Bed" },
                new PropertyType { TypeName = "4 Bed" },
                new PropertyType { TypeName = "Kings Bed" },
                new PropertyType { TypeName = "Queens Bed" }
            };
        }

        private ObservableCollection<Property> GetProperties()
        {
            return new ObservableCollection<Property>
            {
                new Property { Image = "waterfront.jpg", PropertyName = "Waterfront Hotel & Casino" , Address = "Salinas Dr, Cebu City, 6000 Cebu", Location = "Cebu City",Contact="(032) 232 6888", Price = "2,348", Bed = "2 Bed",IsKingSize = false ,IsQueenSize = false, Bath = "1 Bath", Space = "1600 sqft", Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies integer quis. Iaculis urna id volutpat lacus laoreet. Mauris vitae ultricies leo integer malesuada. Ac odio tempor orci dapibus ultrices in. Egestas diam in arcu cursus euismod. Dictum fusce ut" },
                new Property { Image = "radisson.jpg", PropertyName = "Radisson Blu" , Address = "Serging Osmena Boulevard, Corner Juan Luna Avenue, Cebu City, 6000 Cebu", Location = "Cebu City",Contact="(032) 505 1700", Price = "2,140", Bed = "2 Bed",IsKingSize = true ,IsQueenSize = true, Bath = "1 Bath", Space = "1100 sqft", Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies integer quis. Iaculis urna id volutpat lacus laoreet. Mauris vitae ultricies leo integer malesuada. Ac odio tempor orci dapibus ultrices in. Egestas diam in arcu cursus euismod. Dictum fusce ut" },
                new Property { Image = "crimson.jpg", PropertyName = "Crimson Resort and Spa Mactan" , Address = "Seascapes Resort Town Mactan Island, Lapu-Lapu City, 6015 Cebu", Location = "Lapu-Lapu City",Contact="(032) 239 3900", Price = "4,513", Bed = "4 Bed",IsKingSize = true ,IsQueenSize = false, Bath = "2 Bath", Space = "1200 sqft", Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies integer quis. Iaculis urna id volutpat lacus laoreet. Mauris vitae ultricies leo integer malesuada. Ac odio tempor orci dapibus ultrices in. Egestas diam in arcu cursus euismod. Dictum fusce ut" },
                new Property { Image = "marcopolo.jpg", PropertyName = "Marco Polo Plaza" , Address = "Nivel Hills, Cebu Veterans Dr, Cebu City, 6000 Cebu", Location = "Cebu City",Contact="(032) 253 1111", Price = "3,421", Bed = "2 Bed",IsKingSize = false ,IsQueenSize = true, Bath = "2 Bath", Space = "1200 sqft", Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies integer quis. Iaculis urna id volutpat lacus laoreet. Mauris vitae ultricies leo integer malesuada. Ac odio tempor orci dapibus ultrices in. Egestas diam in arcu cursus euismod. Dictum fusce ut" },
                new Property { Image = "jpark.jpg", PropertyName = "Jpark Island Resort and Waterpark" , Address = "M.L. Quezon National Highway, Maribago, Lapu-Lapu City, Cebu", Location = "Lapu-Lapu City",Contact="(032) 494 5000", Price = "4,750", Bed = "3 Bed",IsKingSize = false ,IsQueenSize = true, Bath = "2 Bath", Space = "1200 sqft", Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Bibendum est ultricies integer quis. Iaculis urna id volutpat lacus laoreet. Mauris vitae ultricies leo integer malesuada. Ac odio tempor orci dapibus ultrices in. Egestas diam in arcu cursus euismod. Dictum fusce ut" },
            };
        }

        public void KingsBed() => PropertyList = new ObservableCollection<Property>(GetProperties().Where(w => w.IsKingSize == true).ToList());
        
        public void QueensBed() => PropertyList = new ObservableCollection<Property>(GetProperties().Where(w => w.IsQueenSize == true).ToList());
        
        public void Beds(string beds) {
            if (beds.Equals("All"))
            {
                PropertyList = GetProperties();
                return;
            }

            PropertyList = new ObservableCollection<Property>(GetProperties().Where(w => w.Bed.Contains(beds)).ToList());
        }

        private void SearchNow(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) {
                PropertyList = GetProperties();
                return;
            }
            PropertyList = new ObservableCollection<Property>(GetProperties().Where(w => w.PropertyName.ToLower().Contains(name.ToLower())).ToList());
        }
        
    }
}
