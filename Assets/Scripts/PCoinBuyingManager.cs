using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PCoinBuyingManager : MonoBehaviour
{
    public Image _pImage;
    public TextMeshProUGUI _pAmount;
    public TextMeshProUGUI _Cost;
    public Button _button;
    public PCOins _coinData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateItem();
    }
    public void TryToBuy()
    {
        CoinManager.CoinManagerInstance.BuyingPCoin(_coinData._pAmount);
    }
    public void UpdateItem()
    {
        _pImage.sprite = _coinData._coinSprite;
        _pAmount.text = _coinData._pAmount.ToString() + "X";
        _Cost.text = _coinData._cost.ToString() + " INR";
    }
}
