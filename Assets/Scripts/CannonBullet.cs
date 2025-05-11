using UnityEngine;

public class CannonBullet : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float timer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 direction = transform.position - transform.position;

        rb.linearVelocity = new Vector3(direction.x, direction.y, direction.z).normalized * speed;
    }

    public void Update()
    {
        timer += Time.deltaTime;

        if(timer > 3)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
        }
    }
}
