using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OwnedItems", menuName = "Scriptable Objects/OwnedItems")]
public class OwnedItems : ScriptableObject
{
    public List<OwnedItemData> _ownedItems;

    public void AddtoList(OwnedItemData Od)
    {
        if(_ownedItems.Contains(Od)&&Od._item.canStack)
        {
            foreach(var v in _ownedItems)
            {
                if(v._item == Od._item)
                {
                    v._item.count++;
                }
            }
        }
        else
        {
            _ownedItems.Add(Od);
        }
    }
}
[Serializable]
public class OwnedItemData
{
    public string _itemId;
    public Item _item;

    public OwnedItemData (string itemId, Item item)
    {
        _itemId = itemId;
        _item = item;
    }
}
