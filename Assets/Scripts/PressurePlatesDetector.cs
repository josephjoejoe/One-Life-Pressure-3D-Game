using UnityEngine;

public class PressurePlatesDetector : MonoBehaviour
{
    public RandomColorPlates controller;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            controller.TryActivatePlate(this.gameObject);
        }
    }
}
