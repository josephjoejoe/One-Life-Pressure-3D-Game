using UnityEngine;
using System.Collections.Generic;

public class Level3PuzzleManager : MonoBehaviour
{
    public List<WeightPressurePlate> weightPressurePlateScripts;

    public bool allWeightedPlatesAreOn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (weightPressurePlateScripts.Count > 3)
        {
            allWeightedPlatesAreOn = true;
        }
        else
        {
            allWeightedPlatesAreOn = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag.Equals("Box"))
        //{
        //    weightPressurePlateScripts.Add(collision.gameObject);
        //}

    }

    void OnCollisionExit(Collision collision)
    {
        //if (collision.gameObject.tag.Equals("Box"))
        //{
        //    weightPressurePlateScripts.Remove(collision.gameObject);
        //}
        
    }

}
