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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        _currentCoroutine = StartCoroutine(StartLasers());
    }
    private void OnDisable()
    {
        StopCoroutine( _currentCoroutine );
        foreach (GameObject obj in _lasers)
        {
            obj.SetActive(false);
        }
    }
    IEnumerator StartLasers()
    {
        foreach (var l in _lasers)
        {
            yield return new WaitForSeconds(_perLaserDelay);
            l.SetActive(true);
        }
        yield return new WaitForSeconds(_restDelay);
        foreach (var l in _lasers)
        {
            yield return new WaitForSeconds(_perLaserDelay);
            l.SetActive(false);
        }
        yield return new WaitForSeconds( _onLaserDelay);
        StartCoroutine(StartLasers());
    }
}
