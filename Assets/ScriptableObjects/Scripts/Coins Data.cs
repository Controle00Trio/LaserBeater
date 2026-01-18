using UnityEngine;

[CreateAssetMenu(fileName = "CoinsData", menuName = "Scriptable Objects/CoinsData")]
public class CoinsData : ScriptableObject
{
    public int _localCoins;
    public int _premiumCoins;

    public void SetLocalCoinsValue(int localCoins)
    {
        _localCoins = localCoins;
    }
    public int GetLocalCoinsValue()
    {
        return _localCoins;
    }
    public void SetPremiumCoinsValue(int premiumCoins)
    {
        _premiumCoins = premiumCoins;
    }
    public int GetPremiumCoinsValue()
    {
        return _premiumCoins;
    }
}
