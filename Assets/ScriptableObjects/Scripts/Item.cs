using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject
{
    public Sprite ItemSprite;
    public string ItemName;
    public string ItemID;
    public ItemTypes ItemTypes;
    public bool isPurchased;
    public bool isPremium;
    public int cost;
}
public enum ItemTypes 
{
    None,
    Skins,
    Abilities
}
