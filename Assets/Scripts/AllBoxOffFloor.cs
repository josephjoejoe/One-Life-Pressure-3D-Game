using UnityEngine;

public class AllBoxOffFloor : MonoBehaviour
{

    [SerializeField] public bool allBoxesOff = false;
    public Renderer floorRend;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        floorRend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
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
        {
            allBoxesOff = false;
        }
        else
        {
            allBoxesOff = true;
        }
       
        
    }

   
}
