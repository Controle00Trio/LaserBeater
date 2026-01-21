using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DemoLasers : MonoBehaviour
{
    public GameObject[] _lasers;
    public Coroutine _currentCoroutine;
    public float _perLaserDelay;
    public float _restDelay;
    public float _onLaserDelay;
    bool _hasGameStarted = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.GameManagerInstance.OnGameStarted += GameStarted;
        GameManager.GameManagerInstance.OnGameReStarted += Restarted;
        GameManager.GameManagerInstance.OnGameHomePage += HomePage;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        if (_currentCoroutine != null)
            return;

        _currentCoroutine = StartCoroutine(StartLasers());
    }

    private void OnDisable()
    {
        if (_currentCoroutine == null)
            return;

        StopCoroutine(_currentCoroutine);
        _currentCoroutine = null;
    }

    void GameStarted()
    {
        _hasGameStarted = true;
        if (_currentCoroutine != null)
            return;

        _currentCoroutine = StartCoroutine(StartLasers());
    }

    void Restarted()
    {
        _hasGameStarted = true;
    }

    void HomePage()
    {
        _hasGameStarted = false;
    }
    IEnumerator StartLasers()
    {
        while (true)
        {
            if (!_hasGameStarted)
            {
                yield return null;
                continue;
            }

            for (int i = 0; i < _lasers.Length; i++)
            {
                yield return new WaitForSeconds(_perLaserDelay);
                _lasers[i].GetComponent<Laser>().OnLaser(_perLaserDelay);
            }

            yield return new WaitForSeconds(_restDelay);

            for (int i = 0; i < _lasers.Length; i++)
            {
                yield return new WaitForSeconds(_perLaserDelay);
                _lasers[i].GetComponent<Laser>().OffLaser(_perLaserDelay);
            }

            yield return new WaitForSeconds(_onLaserDelay);
        }
    }
}
