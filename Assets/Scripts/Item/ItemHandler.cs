using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemHandler : MonoBehaviour
{
    public Image _sprite;
    public TextMeshProUGUI _amount;
    public Button _button;
    public Item _itemData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateItem();
    }
    public void TryToBuy()
    {
        if (!_itemData.isPremium && CoinManager.CoinManagerInstance._loaclCoins >= _itemData.cost)
        {
            _itemData.isPurchased = true;
            ItemManager.ItemManagerInstance.PurchasedWithLocalCoins(_itemData);
        }
        else if (_itemData.isPremium && CoinManager.CoinManagerInstance._premiumCoins >= _itemData.cost)
        {
            _itemData.isPurchased= true;
            ItemManager.ItemManagerInstance.PurchasedWithLocalCoins(_itemData);
        }
    }
    public void UpdateItem()
    {
        _sprite.sprite = _itemData.ItemSprite;
        _amount.text = _itemData.cost.ToString() + " C";
        if (_itemData.isPurchased)
        {
            _button.enabled = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
