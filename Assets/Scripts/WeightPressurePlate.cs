using UnityEngine;
using System.Collections.Generic;

public class WeightPressurePlate : MonoBehaviour
{
    public string weightPressurePlateTag = "WeightPressurePlate";
    public string boxTag = "WeightBox";

    public Renderer weightPressurePlateRenderer;

    void Start()
    {
        weightPressurePlateRenderer = GetComponent<Renderer>();
    }

    void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag.Equals("WeightBox"))
       {
            weightPressurePlateRenderer.material.color = Color.green;
       }
       else
       {
            weightPressurePlateRenderer.material.color = Color.grey;
       }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("WeightBox"))
        {
            weightPressurePlateRenderer.material.color = Color.grey;
        }
    }
}
