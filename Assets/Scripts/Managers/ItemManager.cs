using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager ItemManagerInstance;
    public OwnedItems _ItemsOwned;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (ItemManagerInstance == null)
        {
            ItemManagerInstance = this;
        }
    }
    public void PurchasedWithLocalCoins(Item item)
    {
        _ItemsOwned._ownedItems.Add(item.ItemID, item);
        CoinManager.CoinManagerInstance.UseLocalCoins(item.cost);
    }
    public void PurchasedWithPremiumCoins(Item item)
    {
        _ItemsOwned._ownedItems.Add(item.ItemID, item);
        CoinManager.CoinManagerInstance.UsePremiumCoins(item.cost);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
