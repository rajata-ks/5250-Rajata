using System;

namespace Mine.Models
{
    public class ItemModel
    {
        //The ID for the Item
        public string Id { get; set; }

        //The Display text for the Item
        public string Text { get; set; }

        //The Description for the Item
        public string Description { get; set; }

        //The value of the Item +9 Damage 
        public int Value { get; set; } = 0;
    }
}