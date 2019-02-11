using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * GDAPS 2 Online Section 2
 * Bag Class
 * Programmed by Fred
 */

namespace PlasmaPeasant
{
    class Bag
    {
        // attributes
        // dictionary contains all items
        Dictionary<int, Items> bag = new Dictionary<int, Items>();
        Dictionary<int, RangedWeap> weapBag = new Dictionary<int, RangedWeap>();
        // number of items in the bag
        int count;
        int space;
        // number of items in the weapon bag
        int weapCount;
        int weapSpace;

        // accessor for Dictionary
        public Dictionary<int, Items> Inventory { get { return bag; } }
        public int Count { get { return count; } }

        // constructor
        // sets number of items to 0
        // sets max space
        public Bag(int maxItem)
        {
            count = 0;
            space = maxItem;
        }

        // method for adding items to bag
        // called when player picks up/ collides with an item
        public void PickUp(Items i)
        {
            bag.Add(count,i);
            count++;
        }

        public void PickUp(RangedWeap i)
        {
            weapBag.Add(weapCount, i);
            weapCount++;
        }

        // method for using an item
        // returns item to be used
        public Items Use(int i)
        {
            count--;
            Items item = bag[i];
            bag.Remove(i);
            return item;
        }

        public RangedWeap GetWeap(int i)
        {
            weapCount--;
            RangedWeap rWeap = weapBag[i];
            weapBag.Remove(i);
            return rWeap;
        }
    }
}
