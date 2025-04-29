using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody RB;
    RaycastHit hit;
    public Camera eyes;

    public float speed;
    public float jumpForce;
    public float MouseSensitivity;


    //ground check raycast 
    public bool grounded = false;
    public float groundCheckDistance;
    public Vector3 cubeSize;

    // Rotation clamp
    private float xRotation = 0f; // Tracks up/down camera rotation

    void Start()
    {
        RB = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Debug.DrawRay(transform.position + (transform.right * 0.1f), -transform.up, Color.red);
        Debug.DrawRay(transform.position, transform.forward, Color.green);
        Debug.DrawRay(transform.position, transform.right, Color.yellow);
        // if my mouse goes left/right my body moves left/right
        float xRot = Input.GetAxis("Mouse X") * MouseSensitivity;
        transform.Rotate(0, xRot, 0);
        // if my mouse goes up/down my aim moves up/down (not the body)
        float yRot = -Input.GetAxis("Mouse Y") * MouseSensitivity;
        eyes.transform.Rotate(yRot, 0, 0);

        // Horizontal body rotation
        transform.Rotate(0, xRot, 0);

        // Vertical camera rotation with clamp
        xRotation += yRot;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        eyes.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);


        //groundCheckDistance = 1;


        if (speed > 0)
        {
            Vector3 vel = Vector3.zero;

            if (Input.GetKey(KeyCode.A))
            {
                vel -= transform.right;
            }

            if (Input.GetKey(KeyCode.D))
            {
                vel += transform.right;
            }

            if (Input.GetKey(KeyCode.W))
            {
                vel += transform.forward;
            }

            if (Input.GetKey(KeyCode.S))
            {
                vel -= transform.forward;
            }

            vel = vel.normalized * speed;

            if (jumpForce > 0 && Input.GetKey(KeyCode.Space) && isGrounded())
            {
                vel.y = jumpForce;
            }
            else
            {
                vel.y = RB.linearVelocity.y;
            }
            // RAYCAST EXAMPLE
            //if (Input.GetMouseButtonDown(0))
            //{
            //    if (Physics.Raycast(eyes.transform.position, eyes.transform.forward,
            //        out RaycastHit hit, 30))
            //    {
            //        Debug.Log(hit.collider.name);
            //    }
            //}


            RB.linearVelocity = vel;


        }
    }

    public bool isGrounded()
    {
        if (Physics.Raycast(transform.position, -transform.up, out hit, groundCheckDistance))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * groundCheckDistance, cubeSize);
    }


}
