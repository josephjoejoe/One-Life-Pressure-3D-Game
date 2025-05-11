using System.Collections;
using UnityEngine;


public class RandomColorPlates : MonoBehaviour
{
    public string PressurePlateTag = "PressurePlate";
    public string PlayerTag = "Player";
    public float changeInterval = 1.5f;

    public bool PlayerOnPressurePlate;
    public bool taskCompleted;

    private GameObject[] pressurePlate;
    private GameObject currentGreenPlate;
    private Color originalColor;

    void Start()
    {
        pressurePlate = GameObject.FindGameObjectsWithTag(PressurePlateTag);
        StartCoroutine(ChangeBoxColorRoutine());
    }

    

    IEnumerator ChangeBoxColorRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(changeInterval);

            // If player is standing on the current green plate, stop changing
            if (PlayerOnPressurePlate) continue;

            // Pick a random plate that isn't the current green one
            GameObject newGreenPlate;
            do
            {
                newGreenPlate = pressurePlate[Random.Range(0, pressurePlate.Length)];
            }
            while (newGreenPlate == currentGreenPlate && pressurePlate.Length > 1);

            // Restore previous box's color
            if (currentGreenPlate != null)
            {
                Renderer prevRend = currentGreenPlate.GetComponent<Renderer>();
                if (prevRend != null)
                {
                    prevRend.material.color = originalColor;
                }
            }

            // Change new plate to green
            Renderer newRend = newGreenPlate.GetComponent<Renderer>();
            if (newRend != null)
            {
                originalColor = newRend.material.color;
                newRend.material.color = Color.green;
                currentGreenPlate = newGreenPlate;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _ = gameObject;
        }
    }

    public void TryActivatePlate(GameObject plate)
    {
        if (plate == currentGreenPlate)
        {
            Debug.Log("Player stepped on the green plate!");
            PlayerOnPressurePlate = true;
        }

        if (PlayerOnPressurePlate == true)
        {
            taskCompleted = true;
        }
        else
        {
            taskCompleted = false;
        }
    }
}

