using UnityEngine;
using System.Collections.Generic;

public class AllBoxOnOnePlate : MonoBehaviour
{
    public List<GameObject> boxes;

    public bool taskComplete;

    public Renderer longPlateRend;

    public AudioSource buttonReady;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        longPlateRend = GetComponent<Renderer>();
        buttonReady = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(boxes.Count > 3)
        {
            taskComplete = true;
            longPlateRend.material.color = Color.green;
            buttonReady.Play();
        }
        else
        {
            taskComplete = false;
            longPlateRend.material.color = Color.grey;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Box"))
        {
            boxes.Add(collision.gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Box"))
        {
            boxes.Remove(collision.gameObject);
        }
    }
}
