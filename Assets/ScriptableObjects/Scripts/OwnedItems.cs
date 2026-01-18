using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OwnedItems", menuName = "Scriptable Objects/OwnedItems")]
public class OwnedItems : ScriptableObject
{
    public Dictionary<string, Item> _ownedItems;
}
