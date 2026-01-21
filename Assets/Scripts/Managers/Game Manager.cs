using UnityEngine;
using System;
public class GameManager : MonoBehaviour
{
    public static GameManager GameManagerInstance;
    public event Action OnGameOver;
    public event Action OnGameStarted;
    public event Action OnGameReStarted;
    public event Action OnGameHomePage;
    public event Action OnStorePage;
    public event Action OnSucessfulBuy;
    public event Action OnUnSucessfulBuy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (GameManagerInstance == null)
        {
            GameManagerInstance = this;
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameStarted()
    {
        OnGameStarted?.Invoke();
        Time.timeScale = 1f;
    }
    public void GameOver()
    {
        OnGameOver?.Invoke();
        Time.timeScale = 0f; 
    }
    public void RestartGame()
    {
        OnGameReStarted?.Invoke();
        Time.timeScale = 1f; 
    }
    public void HomePage()
    {
        OnGameHomePage?.Invoke();
    }
    public void StorePage()
    {
        OnStorePage?.Invoke();
    }
    public void SuccessfulBuy()
    {
        OnSucessfulBuy?.Invoke();
    }
    public void UnSuccessfulBuy()
    {
        OnUnSucessfulBuy?.Invoke();
    }
    public void Exit()
    {
        Application.Quit();
    }
}
