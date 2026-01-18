using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager CoinManagerInstance;
    public CoinsData _coinData;

    public int _loaclCoins = 0;
    public int _premiumCoins = 0;

    private void Awake()
    {
        if (CoinManagerInstance == null)
            CoinManagerInstance = this;
    }
    private void Start()
    {
        _loaclCoins = _coinData.GetLocalCoinsValue();
        _premiumCoins = _coinData.GetPremiumCoinsValue();
        UIMAnager.UiInstance.UpdateMenuCoins(_loaclCoins, _premiumCoins);
    }
    public void AddLocalCoins(int amount)
    {
        _loaclCoins += amount;
        _coinData.SetLocalCoinsValue(_loaclCoins);
        UIMAnager.UiInstance.UpdateMenuCoins(_loaclCoins, _premiumCoins);
    }
    public void UseLocalCoins(int amount)
    {
        _loaclCoins -= amount;
        _coinData.SetLocalCoinsValue(_loaclCoins);
        UIMAnager.UiInstance.UpdateMenuCoins(_loaclCoins, _premiumCoins);
    }
    public void AddPremiumCoins(int amount)
    {
        _premiumCoins += amount;
        _coinData.SetPremiumCoinsValue(_premiumCoins);
        UIMAnager.UiInstance.UpdateMenuCoins(_loaclCoins, _premiumCoins);
    }
    public void UsePremiumCoins(int amount)
    {
        _premiumCoins -= amount;
        _coinData.SetPremiumCoinsValue(_premiumCoins);
        UIMAnager.UiInstance.UpdateMenuCoins(_loaclCoins, _premiumCoins);
    }
    public void BuyingPCoin(int amount)
    {
        _premiumCoins +=  amount;
        _coinData.SetPremiumCoinsValue(_premiumCoins);
        UIMAnager.UiInstance.UpdateMenuCoins(_loaclCoins, _premiumCoins);
    }
}
