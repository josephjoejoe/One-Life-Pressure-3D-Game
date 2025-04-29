using UnityEngine;

public class PickupController : MonoBehaviour
{
    //// pickup settings
    //Transform holdArea;
    //public GameObject heldObject;
    //public Rigidbody heldObjectRB;

    //// physics parameters
    //private float pickupRange = 5.0f;
    //private float pickupForce = 150.0f;

    //void Start()
    //{
    //    heldObjectRB = GetComponent<Rigidbody>();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        if(heldObject == null)
    //        {
    //            RaycastHit hit;
    //            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
    //            {
    //                PickupObject(hit,transform.gameObject);
    //            }
    //        }
    //        else
    //        {
    //            DropObject();
    //        }
    //    }
    //    if (heldObject != null)
    //    {
    //        MoveObject();
    //    }
    //}

    //void MoveObject()
    //{
    //    if(Vector3.Distance(heldObject.transform.position, holdArea.position) > 0.1)
    //    {
    //        Vector3 moveDirection = (holdArea.position - heldObject.transform.position);
    //        heldObjectRB.AddForce(moveDirection * pickupForce);
    //    }
    //}

    //void PickupObject(GameObject pickObject)
    //{
    //    if (pickObject.GetComponent<RigidBody>())
    //    {
    //        heldObjectRB = pickObject.GetComponent<RigidBody>();
    //        heldObjectRB.useGravity = false;
    //        heldObjectRB.linearDamping = 10;
    //        heldObjectRB.constraints = RigidbodyConstraints.FreezeRotation;

    //        heldObjectRB.transform.parent = holdArea;
    //        heldObject = pickObject;
    //    }
    //}

    //void DropObject()
    //{
    //        heldObjectRB.useGravity = true;
    //        heldObjectRB.linearDamping = 1;
    //        heldObject.constraints = RigidbodyConstraints.None;

    //        heldObject.transform.parent = null;
    //        heldObject = null;

    //}
}
