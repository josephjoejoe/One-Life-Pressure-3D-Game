using UnityEngine;
using System.Collections.Generic;

public class AllBoxOffFloor : MonoBehaviour
{

    [SerializeField] public bool allBoxesOff = false;
    public Renderer floorRend;

    public List<GameObject> boxes;

    void Start()
    {
        floorRend = GetComponent<Renderer>();
    }

    void Update()
    {
        if (allBoxesOff == false )
        {
            floorRend.material.color = Color.grey;
        }
        else
        {
            floorRend.material.color = Color.green;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Box"))
            boxes.Add(collision.gameObject);

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
            boxes.Remove(collision.gameObject);
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
