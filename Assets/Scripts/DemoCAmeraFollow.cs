using UnityEngine;

public class DemoCAmeraFollow : MonoBehaviour
{
    public Transform _Target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Pos = new Vector3(transform.position.x, transform.position.y, _Target.position.z -3);
        transform.position = Pos ;
    }
}
