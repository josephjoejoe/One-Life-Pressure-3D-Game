using UnityEngine;

public class CannonBullet : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public Vector3 shootDirection = Vector3.forward;
    public float timer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.linearVelocity = shootDirection.normalized * speed;

    }

    public void Update()
    {
        timer += Time.deltaTime;

        if(timer > 4)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
