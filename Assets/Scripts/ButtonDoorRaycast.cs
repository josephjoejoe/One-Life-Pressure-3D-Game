using UnityEngine;
using UnityEngine.UI;

public class ButtonDoorRaycast : MonoBehaviour
{
    [SerializeField] private float raylength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;

    private OpenDoorButton raycastObject;

    [SerializeField] private KeyCode openDoorKey = KeyCode.Mouse0;

    [SerializeField] private Image crosshair = null;
    private bool isCrosshairActive;
    private bool doOnce;

    private const string interactableTag = "DoorButton";


    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if(Physics.Raycast(transform.position, forward, out hit, raylength, mask))
        {
            if (hit.collider.CompareTag(interactableTag))
            {
                if (!doOnce)
                {
                    raycastObject = hit.collider.gameObject.GetComponent<OpenDoorButton>();
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(openDoorKey))
                {
                    raycastObject.PlayAnimation();
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
    }

    void CrosshairChange(bool on)
    {
        if(on && !doOnce)
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
