using UnityEngine;

public class HoverEffect : MonoBehaviour
{
    public float _hoveringSpeed;
    public float _minmaxPos;
    float initialpos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialpos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float val = Mathf.Sin(Time.time * _hoveringSpeed);
        float v = val * _minmaxPos;
        float os = initialpos;
        os += v;
        transform.position = new Vector3(transform.position.x, os, transform.position.z);
    }
}
