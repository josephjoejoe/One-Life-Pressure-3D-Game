using UnityEngine;

public class WeightPressurePlate : MonoBehaviour
{
    public string weightPressurePlateTag = "WeightPressurePlate";
    public string boxTag = "Box";

    public Renderer weightPressurePlateRenderer;

    void Start()
    {
        weightPressurePlateRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag.Equals(boxTag))
        {
            weightPressurePlateRenderer.material.color = Color.green;
        }
        else
        {
            weightPressurePlateRenderer.material.color = Color.grey;

        }
    }

}
