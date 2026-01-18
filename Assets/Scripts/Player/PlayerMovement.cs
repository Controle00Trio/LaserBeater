using UnityEngine;
using UnityEngine.Splines;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Attributes")]
    public SplineAnimate splineAnimate;
    public SplineContainer splineOptions;
    bool hasSwitched = false;
    bool _hasGameStarted = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.GameManagerInstance.OnGameStarted += GameStarted;
        GameManager.GameManagerInstance.OnGameReStarted += ResetGame;
        GameManager.GameManagerInstance.OnGameHomePage += HomePage;
    }
    public void GameStarted()
    {
        _hasGameStarted = true;
    }
    public void HomePage()
    {
        ResetGame();
        _hasGameStarted = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (_hasGameStarted)
        {
            SplineUpdate();
            InputUpdate();
        }

    }
    #region Input Region
    void InputUpdate()
    {
#if UNITY_EDITOR
        // Mouse input for Editor testing
        if (Input.GetMouseButton(0))
        {
            if (!splineAnimate.IsPlaying)
                splineAnimate.Play();
        }
        else
        {
            if (splineAnimate.IsPlaying)
                splineAnimate.Pause();
        }
#else
    // Touch input for mobile
    if (Input.touchCount > 0)
    {
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary)
        {
            if (!splineAnimate.IsPlaying)
                splineAnimate.Play();
        }
        else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
        {
            if (splineAnimate.IsPlaying)
                splineAnimate.Pause();
        }
    }
    else
    {
        if (splineAnimate.IsPlaying)
            splineAnimate.Pause();
    }
#endif
    }

    #endregion
    #region Spline Region
    void SplineUpdate()
    {
        float normalisedtime = splineAnimate.NormalizedTime * 4;
        if (!hasSwitched && normalisedtime >= 3.99f)
        {
            Debug.Log("Switched");
            hasSwitched = true;
            AssignNextSpline();
        }
    }
    public void AssignNextSpline()
    {
        splineAnimate.Pause();

        GameObject tile = TilesManager.TileManagerInstance.GetNextSplineTileToMoveOn();
        splineOptions = tile.GetComponentInChildren<SplineContainer>();

        Debug.Log("Switching to spline: " + splineOptions.name);

        splineAnimate.Container = splineOptions;
        splineAnimate.Restart(false);

        hasSwitched = false;
    }

    #endregion
    public void ResetGame()
    {
        _hasGameStarted = false;
        splineAnimate.Pause();
        splineAnimate.NormalizedTime = 0f;

        hasSwitched = false;

        AssignNextSpline();
        _hasGameStarted = true;
    }
}
