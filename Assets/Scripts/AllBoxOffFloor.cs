using UnityEngine;
using System.Collections.Generic;

public class AllBoxOffFloor : MonoBehaviour
{
    public AudioSource buttonReady;

    public Renderer floorRend;

    public List<GameObject> boxes;

    public bool taskCompleted;

    void Start()
    {
        floorRend = GetComponent<Renderer>();
        buttonReady = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (boxes.Count>0 )
        {
            floorRend.material.color = Color.grey;
            taskCompleted = false;
        }
        else
        {
            floorRend.material.color = Color.green;
            taskCompleted = true;
            buttonReady.Play();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Box"))
        {
            boxes.Add(collision.gameObject);
        }

        //if (collision.gameObject.tag.Equals("Box"))
        //{
        //    allBoxesOff = false;
        //}
        //else
        //{
        //    allBoxesOff = true;
        //}


    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Box"))
        {
            boxes.Remove(collision.gameObject);
        }
        //if (collision.gameObject.tag.Equals("Box"))
        //{
        //    allBoxesOff = false;
        //}
        //else
        //{
        //    allBoxesOff = true;
        //}



    }

}
