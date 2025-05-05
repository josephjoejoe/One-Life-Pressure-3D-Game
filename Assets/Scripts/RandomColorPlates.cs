using System.Collections;
using UnityEngine;

public class OneRedBoxAtATime : MonoBehaviour
{
    public string PressurePlateTag = "PressurePlate";
    public float changeInterval = 1.5f;

    private GameObject[] pressurePlate;
    private GameObject currentGreenBox;
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

            // Pick a random box that isn't the current red one
            GameObject newGreenBox;
            do
            {
                newGreenBox = pressurePlate[Random.Range(0, pressurePlate.Length)];
            }
            while (newGreenBox == currentGreenBox && pressurePlate.Length > 1);

            // Restore previous box's color
            if (currentGreenBox != null)
            {
                Renderer prevRend = currentGreenBox.GetComponent<Renderer>();
                if (prevRend != null)
                {
                    prevRend.material.color = originalColor;
                }
            }

            // Change new box to green
            Renderer newRend = newGreenBox.GetComponent<Renderer>();
            if (newRend != null)
            {
                originalColor = newRend.material.color;
                newRend.material.color = Color.green;
                currentGreenBox = newGreenBox;
            }
        }
    }
}

