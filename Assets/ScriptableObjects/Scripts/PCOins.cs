using UnityEngine;

[CreateAssetMenu(fileName = "PCOins", menuName = "Scriptable Objects/PCOins")]
public class PCOins : ScriptableObject
{
    public Sprite _coinSprite;
    public int _pAmount;
    public int _cost;
}
