using UnityEngine;
using UnityEngine.UI;

public class InteractableRaycast : MonoBehaviour
{
    [SerializeField] private float raylength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;

    private OpenDoorButton raycastObject;
    private PickupController raycastObject1;
    private OpenDoorButton1 raycastObject2;

    [SerializeField] private KeyCode openDoorKey = KeyCode.Mouse0;

    [SerializeField] private Image crosshair = null;
    private bool isCrosshairActive;
    private bool doOnce;

    private const string interactableTag = "DoorButton";
    private const string interactableTag1 = "Box";
    private const string interactableTag2 = "WeightBox";



    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        //Button Raycast
        if (Physics.Raycast(transform.position, forward, out hit, raylength, mask))
        {
            if (hit.collider.CompareTag(interactableTag) || hit.collider.CompareTag(interactableTag1) || hit.collider.CompareTag(interactableTag2))
            {
                if (!doOnce)
                {
                    raycastObject = hit.collider.gameObject.GetComponent<OpenDoorButton>();
                    CrosshairChange(true);
                }

                if (!doOnce)
                {
                    raycastObject2 = hit.collider.gameObject.GetComponent<OpenDoorButton1>();
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(openDoorKey))
                {
                    raycastObject.PlayAnimation();
                }

                if (Input.GetKeyDown(openDoorKey))
                {
                    raycastObject2.PlayAnimation();
                }

            }
        }
        else
        {
            if (isCrosshairActive)
            {
                CrosshairChange(false);
                doOnce = false;
            }
        }

        //Box Raycast
        //if (Physics.Raycast(transform.position, forward, out hit, raylength, mask))
        //{
        //    if (hit.collider.CompareTag(interactableTag1))
        //    {
        //        if (!doOnce)
        //        {
        //            raycastObject1 = hit.collider.gameObject.GetComponent<PickupController>();
        //            CrosshairChange(true);
        //        }

        //        isCrosshairActive = true;
        //        doOnce = true;
        //    }
        //}
        //else
        //{
        //    if (isCrosshairActive)
        //    {
        //        CrosshairChange(false);
        //        doOnce = false;
        //    }
        //}

    }

    void CrosshairChange(bool on)
    {
        if (on && !doOnce)
        {
            crosshair.color = Color.red;
        }
        else
        {
            crosshair.color = Color.white;
            isCrosshairActive = false;
        }
    }
}
