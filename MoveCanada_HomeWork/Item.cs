using System;
using System.Collections.Generic;

namespace MoveCanada_HomeWork
{
    public class Item
    {
        private string _name;
        private List<string> _dependencies;

        public string Name
        {
            get { return _name; }         
        }

        public List<string> Dependencies
        {
            get { return _dependencies; }            
        }
        
        public Item()
        {
            _name = "";
            _dependencies = new List<string>();
        }

        public Item(string itemName)
        {
            if (!string.IsNullOrEmpty(itemName))
                _name = itemName;

            _dependencies = new List<string>();
        }

        public void AddDependency(string dependencyItemName)
        {
            _dependencies.Add(dependencyItemName);
        }

        public void AddDependencies(List<string> dependencies)
        {
            _dependencies.AddRange(dependencies);
        }        
    }
}
