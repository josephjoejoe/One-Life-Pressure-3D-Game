using UnityEngine;

public class PressurePlatesDetector : MonoBehaviour
{
    public OneRedBoxAtATime controller;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            controller.TryActivatePlate(this.gameObject);
        }
    }
}
