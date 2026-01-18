using UnityEngine;

public class RotetoryLasers : MonoBehaviour
{
    public float _rotationSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = transform.eulerAngles;
        rotation.y += _rotationSpeed * Time.deltaTime;
        transform.eulerAngles = rotation;
    }
}
