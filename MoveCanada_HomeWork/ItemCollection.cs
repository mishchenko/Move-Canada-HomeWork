using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoveCanada_HomeWork
{
    class ItemCollection
    {
        private List<Item> _items;
        private List<Item> _sortedItems; 
        private List<Item> _visitedItems;
        
        public ItemCollection()
        {
            _items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public Item GetItemByName(string name)
        {
            return _items.Find(i => i.Name == name);
        }           

        public List<Item> SortByDependencies()
        {
            _sortedItems = new List<Item>();
            _visitedItems = new List<Item>();

            //ValidateItemDependencies(); 

            foreach (Item item in _items)
            {
                VisitItem(item);
            }
            
            return _sortedItems;            
        }

        private void VisitItem(Item item)
        {
            if (!_visitedItems.Contains(item))
            {
                _visitedItems.Add(item);

                foreach (string itemName in item.Dependencies)
                {
                    Item dependencyItem = GetItemByName(itemName);

                    if (dependencyItem != null)
                        VisitItem(dependencyItem);
                }
                _sortedItems.Add(item);
            }
        }

        //check if all dependencies are valid Item objects in collection
        private void ValidateItemDependencies()
        {
            StringBuilder errorMessageBuilder = new StringBuilder();

            foreach (Item item in _items)
            {
                foreach (string dependencyItemName in item.Dependencies)
                {
                    if (GetItemByName(dependencyItemName) == null)
                        errorMessageBuilder.Append(dependencyItemName + ", ");
                }
            }

            if (errorMessageBuilder.Length > 0)
                throw new Exception("Invalid dependencies names in ItemCollection: " + errorMessageBuilder.ToString().TrimEnd(new char[] { ' ', ',' }));
        }        
    }
}
