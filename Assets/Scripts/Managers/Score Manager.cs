using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager ScoreManagerInstance;

    [Header("Player Attributes")]
    [SerializeField] private Transform _playerTransform;

    [Header("Score Values")]
    public float _distanceTravelled;
    public float _currentSpeed;
    public int _coins;

    [Header("Multipliers")]
    public float _distanceToCoinsMultiplier = 1f;
    public float _speedToCoinsMultiplier = 0.5f;

    private float _startZ;
    private float _lastZ;

    bool _hasGameStarted = false;
    private void Awake()
    {
        if (ScoreManagerInstance == null)
        {
            ScoreManagerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        GameManager.GameManagerInstance.OnGameStarted += GameStarted;
        GameManager.GameManagerInstance.OnGameReStarted += GameRestarted;
        GameManager.GameManagerInstance.OnGameHomePage += GameRestarted;
    }
    public void GameStarted()
    {
        _startZ = _playerTransform.position.z;
        _lastZ = _startZ;
        _hasGameStarted = true;
    }
    void Update()
    {
        if(_hasGameStarted)
        {
            UpdateDistance();
            UpdateSpeed();
            UpdateCoins();
        }

    }

    void UpdateDistance()
    {
        _distanceTravelled = _playerTransform.position.z - _startZ;
    }

    void UpdateSpeed()
    {
        float deltaZ = _playerTransform.position.z - _lastZ;
        _currentSpeed = Mathf.Abs(deltaZ / Time.deltaTime);
        _lastZ = _playerTransform.position.z;
    }

    void UpdateCoins()
    {
        _coins = Mathf.FloorToInt(
            _distanceTravelled * _distanceToCoinsMultiplier +
            _currentSpeed * _speedToCoinsMultiplier
        );
    }

    public float GetDistance() => _distanceTravelled;
    public float GetSpeed() => _currentSpeed;
    public FinalScore GetFinalScore()
    {
        Debug.Log(_coins);
        CoinManager.CoinManagerInstance.AddLocalCoins(_coins);
        return new FinalScore(_distanceTravelled,_currentSpeed, _coins);
    }
    public void GameRestarted()
    {
        _distanceTravelled = 0;
        _currentSpeed = 0;
        _coins = 0;
    }
}
public struct FinalScore
{
    public float _finalDistance;
    public float _finalSpeed;
    public int _finalCoins;

    public FinalScore(float d, float s, int c)
    {
        _finalDistance = d;
        _finalSpeed = s;
        _finalCoins = c;
    }
}

