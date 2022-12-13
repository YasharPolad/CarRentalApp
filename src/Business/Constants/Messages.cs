using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ItemNotFound(Type itemType, int itemId)
        {
            return $"{GetClassName(itemType)} with id {itemId} wasn't found";
        }
        public static string ItemNotFound()
        {
            return $"The item you are looking for wasn't found";
        }
        public static string ItemNotFound(Type itemType)
        {
            return $"The {GetClassName(itemType)} you are looking for wasn't found";
        }

        public static string InvalidItem()
        {
            return "The item you entered was invalid";
        }
        public static string InvalidItem(Type itemType)
        {
            return $"The entered {GetClassName(itemType)} was invalid";
        }

        private static string GetClassName(Type itemType) //TODO: I feel like this method doesn't fit in this class
        {
            var itemSplitName = itemType.Name.Split(".");
            var length = itemSplitName.Length;
            return itemSplitName[length - 1];
        }

    }
}
