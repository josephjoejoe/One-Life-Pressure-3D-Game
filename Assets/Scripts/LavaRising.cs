using UnityEngine;

public class LavaRising : MonoBehaviour
{
    public float riseSpeed = 0.5f; // units per second


    
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * riseSpeed * Time.deltaTime;

    }
}
