using UnityEngine;
using System.Collections.Generic;

public class WeightPressurePlate : MonoBehaviour
{
    public bool taskCompleted;

    public List<GameObject> weightedPlates; 

    public Renderer weightPressurePlateRenderer;

    public bool weightBoxOn;
    public bool weightBoxOn1;
    public bool weightBoxOn2;
    public bool weightBoxOn3;

    void Start()
    {
        weightPressurePlateRenderer = GetComponent<Renderer>();
    }

    //void Update()
    //{
    //   if (weightedPlates.Count > 3)
    //   {            
    //        taskCompleted = true;
    //   }
    //   else
    //   {            
    //        taskCompleted = false;
    //   }
    //}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("WeightBox"))
        {
            weightBoxOn = true;
            weightPressurePlateRenderer.material.color = Color.green;            
        }
       

        if (collision.gameObject.tag.Equals("WeightBox1"))
        {
            weightBoxOn1 = true;
            weightPressurePlateRenderer.material.color = Color.green;
        }

        if (collision.gameObject.tag.Equals("WeightBox2"))
        {
            weightBoxOn2 = true;
            weightPressurePlateRenderer.material.color = Color.green;
        }


        if (collision.gameObject.tag.Equals("WeightBox3"))
        {
            weightBoxOn3 = true;
            weightPressurePlateRenderer.material.color = Color.green;
        }


    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("WeightBox"))
        {
            weightBoxOn = false;
            weightPressurePlateRenderer.material.color = Color.grey;
        }

        if (collision.gameObject.tag.Equals("WeightBox1"))
        {
            weightBoxOn1 = false;
            weightPressurePlateRenderer.material.color = Color.grey;
        }

        if (collision.gameObject.tag.Equals("WeightBox2"))
        {
            weightBoxOn2 = false;
            weightPressurePlateRenderer.material.color = Color.grey;
        }

        if (collision.gameObject.tag.Equals("WeightBox3"))
        {
            weightBoxOn3 = false;
            weightPressurePlateRenderer.material.color = Color.grey;
        }

        if(collision.gameObject.tag.Equals("WeightPressurePlate") && weightBoxOn && weightBoxOn1 && weightBoxOn2 && weightBoxOn3)
        {
            taskCompleted = true;
        }
        else
        {
            taskCompleted = false;
        }
    }
}
