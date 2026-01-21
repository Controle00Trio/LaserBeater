using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager ItemManagerInstance;
    public OwnedItems _ItemsOwned;
    private void Awake()
    {
        if (ItemManagerInstance == null)
        {
            ItemManagerInstance = this;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    public void PurchasedWithLocalCoins(Item item)
    {
        CoinManager.CoinManagerInstance.UseLocalCoins(item.cost);
        OwnedItemData _temp = new OwnedItemData(item.ItemID, item);
        _ItemsOwned._ownedItems.Add(_temp);
    }
    public void PurchasedWithPremiumCoins(Item item)
    {
        CoinManager.CoinManagerInstance.UsePremiumCoins(item.cost);
        OwnedItemData _temp = new OwnedItemData(item.ItemID, item);
        _ItemsOwned._ownedItems.Add(_temp);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
