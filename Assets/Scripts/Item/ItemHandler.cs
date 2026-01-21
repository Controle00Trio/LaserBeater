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
        _sprite.sprite = _itemData.ItemHiddenSprite;
        _amount.text = _itemData.cost.ToString() + " C";
        UpdateItem();
    }
    public void TryToBuy()
    {
        bool success = false;

        if (!_itemData.isPurchased && !_itemData.isPremium && CoinManager.CoinManagerInstance._loaclCoins >= _itemData.cost)
        {
            success = true;
            ItemManager.ItemManagerInstance.PurchasedWithLocalCoins(_itemData);
        }
        else if (!_itemData.isPurchased && _itemData.isPremium && CoinManager.CoinManagerInstance._premiumCoins >= _itemData.cost)
        {
            success = true;
            ItemManager.ItemManagerInstance.PurchasedWithPremiumCoins(_itemData);
        }
        else
        {
            success = false;
        }
        HandleBuyResult(success);
    }
    void HandleBuyResult(bool success)
    {
        if (success)
        {
            _itemData.isPurchased = true;
            UpdateItem();
            GameManager.GameManagerInstance.SuccessfulBuy();
        }
        else
        {
            GameManager.GameManagerInstance.UnSuccessfulBuy();
        }
    }
    public void UpdateItem()
    {

        if (_itemData.isPurchased)
        {
            _sprite.sprite = _itemData.ItemSprite;
            _amount.text = "";
            _button.interactable = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
