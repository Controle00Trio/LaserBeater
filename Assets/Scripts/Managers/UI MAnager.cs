
using UnityEngine;
using TMPro;
using System.Collections;
public class UIMAnager : MonoBehaviour
{
    public static UIMAnager UiInstance;
    [Header("Panel Objects")]
    public GameObject _menuPanel;
    public GameObject _gameplayPanel;
    public GameObject _gameOverPanel;
    public GameObject _storePanel;

    [Header("Store Panel Objects")]
    public GameObject _abilitiesPanel;
    public GameObject _skinsPanel;
    public GameObject _PcoinsPanel;

    [Header("Menu TextFields")]
    public TextMeshProUGUI _menuLocalCoinsText;
    public TextMeshProUGUI _menuPremiumCoinsText;

    [Header("Store TextFields")]
    public TextMeshProUGUI _storeLocalCoinsText;
    public TextMeshProUGUI _storePremiumCoinsText;

    [Header("GamePlay TextFields")]
    public TextMeshProUGUI _gameplayDistanceText;
    public TextMeshProUGUI _gameplayspeedText;

    [Header("GameOver TextFields")]
    public TextMeshProUGUI _gameoverDistanceText;
    public TextMeshProUGUI _gameoverSpeedText;
    public TextMeshProUGUI _gameoverCoinsText;

    [Header("Buy Messages")]
    public GameObject _successfulBuyPanel;
    public GameObject _unSuccessfulBuyPanel;

    bool _hasGameStarted;
    private void Awake()
    {
        if(UiInstance == null)
        {
            UiInstance = this;
        }
    }
    private void Start()
    {
        GameManager.GameManagerInstance.OnGameOver += GameOver;
        GameManager.GameManagerInstance.OnGameStarted += GameStarted;
        GameManager.GameManagerInstance.OnGameHomePage += OnMenu;
        GameManager.GameManagerInstance.OnGameReStarted += GameStarted;
        GameManager.GameManagerInstance.OnStorePage += OnStore;
        GameManager.GameManagerInstance.OnSucessfulBuy += OnSuccessfulBuy;
        GameManager.GameManagerInstance.OnUnSucessfulBuy += OnUnSuccessfulBuy;
        OffAllPanel();
        _menuPanel.SetActive(true);
    }
    public void GameStarted()
    {
        ResetCounters();
        _hasGameStarted = true;
        OffAllPanel();
        OnGamePlay();
        _gameplayPanel.SetActive(true);
    }
    private void Update()
    {
    }
    public void GameOver()
    {
        _hasGameStarted=false;
        OffAllPanel();
        _gameOverPanel.SetActive(true);
        FinalScore scores = ScoreManager.ScoreManagerInstance.GetFinalScore();
        _gameoverDistanceText.text = scores._finalDistance.ToString();
        _gameoverSpeedText.text = scores._finalSpeed.ToString();
        _gameoverCoinsText.text = scores._finalCoins.ToString();

    }

    public void OnGamePlay()
    {
        StartCoroutine(nameof(UpdateDistance));
    }
    IEnumerator UpdateDistance()
    {
        while (_hasGameStarted)
        {
            _gameplayDistanceText.text = ScoreManager.ScoreManagerInstance.GetDistance().ToString();
            yield return new WaitForSeconds(0.25f);
        }
    }

    public void UpdateMenuCoins(int local,int premium)
    {
        _menuLocalCoinsText.text = local.ToString();
        _storeLocalCoinsText.text = local.ToString();
        _menuPremiumCoinsText.text = premium.ToString();
        _storePremiumCoinsText.text = premium.ToString();
    }
    public void OffAllPanel()
    {
        _gameOverPanel.SetActive(false);
        _gameplayPanel.SetActive(false);
        _menuPanel.SetActive(false);
        _storePanel.SetActive(false);
    }
    public void OnMenu()
    {
        OffAllPanel();
        _menuPanel.SetActive(true);
    }
    public void OnStore()
    {
        OffAllPanel();
        _storePanel.SetActive(true);
    }
    public void OnAbilites()
    {
        _abilitiesPanel.SetActive(true);
        _skinsPanel.SetActive(false);
        _PcoinsPanel.SetActive(false);
    }
    public void OnSkins()
    {
        _skinsPanel.SetActive(true);
        _abilitiesPanel.SetActive(false);
        _PcoinsPanel.SetActive(false);
    }
    public void OnPcoins()
    {
        _PcoinsPanel.SetActive(true);
        _abilitiesPanel.SetActive(false);
        _skinsPanel.SetActive(false);
    }
    public void ResetCounters()
    {
        _gameoverDistanceText.text = 0.ToString();
        _gameoverCoinsText.text = 0.ToString();
        _gameoverSpeedText.text = 0.ToString();
        _gameplayDistanceText.text = 0.ToString();
        _gameplayspeedText.text = 0.ToString();
    }
    public void OnSuccessfulBuy()
    {
        StartCoroutine(ShowMessage(_successfulBuyPanel));
    }
    public void OnUnSuccessfulBuy()
    {
        StartCoroutine(ShowMessage(_unSuccessfulBuyPanel));
    }
    IEnumerator ShowMessage(GameObject obj)
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(.75f);
        obj.SetActive(false);
    }
}
