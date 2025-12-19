using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    /*
        Stacks up to 30
        Tradeable to other party
        Equipped equipment not stored in items
        Sort options
        Trash/sell/favorite selected items options
    */
    public enum Type 
    {
        KeyItems,
        Equippables,
        Junk,
        Food,
        AnythingPouch
    }
    private string title;
    private string description;
    private Type type;
    private int amount;
    //one for icon 

    public Item()
    {
        title = "null";
        description = "null";
        type = Type.AnythingPouch;
        amount = 1;
    }


    public Item(string n, string d, Type t)
    {
        title = n;
        description = d;
        type = t;
        amount = 1;
    }

    public Item(string n, string d, Type t, int a)
    {
        title = n;
        description = d;
        type = t;
        amount = a;
    }

    public void AddItem()
    {
        switch(this.type)
        {
            case Type.AnythingPouch:
                for(int i = 0; i <= InventoryButtons.AnythingPouch.Length; i++)
                {
                    if(i == InventoryButtons.AnythingPouch.Length)
                    {
                        //this inventory is full
                    }
                    else if(InventoryButtons.AnythingPouch[i] != null)
                    {
                        InventoryButtons.AnythingPouch[i] = this;
                        break;
                    }
                }
                break;
        }
    }

}
