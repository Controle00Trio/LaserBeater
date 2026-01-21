using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject
{
    public Sprite ItemHiddenSprite;
    public Sprite ItemSprite;
    public string ItemName;
    public string ItemID;
    public ItemTypes ItemTypes;
    public bool isPremium;
    public bool isPurchased;
    public bool canStack;
    public int cost;
    public int count;
}
public enum ItemTypes 
{
    None,
    Skins,
    Abilities
}
