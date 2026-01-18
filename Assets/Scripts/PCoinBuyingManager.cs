using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PCoinBuyingManager : MonoBehaviour
{
    public TextMeshProUGUI _pAmount;
    public TextMeshProUGUI _Cost;
    public Button _button;
    public PCOins _itemData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateItem();
    }
    public void TryToBuy()
    {
        CoinManager.CoinManagerInstance.BuyingPCoin(_itemData._pAmount);
    }
    public void UpdateItem()
    {
        _pAmount.text = _itemData._pAmount.ToString() + " P";
        _Cost.text = _itemData._cost.ToString() + " INR";
    }
}
