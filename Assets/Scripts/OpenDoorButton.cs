using UnityEngine;
using System.Collections;

public class OpenDoorButton : MonoBehaviour
{
    [SerializeField] private Animator doorAnim = null;

    public AudioSource doorOepning;

    public bool doorOpen = false;
    public bool task1Complete = false;

    [SerializeField] private string openAnimationName = "DoorOpen";
    [SerializeField] private string closeAnimationName = "DoorClose";

    [SerializeField] private int waitTimer = 1;
    [SerializeField] private bool pauseInteraction = false;

    void Start()
    {
        doorOepning = GetComponent<AudioSource>();
    }

    private IEnumerator PauseDoorInteraction()
    {
        pauseInteraction = true;
        yield return new WaitForSeconds(waitTimer);
        pauseInteraction = false;
    }

    public void PlayAnimation()
    {
        if(!doorOpen && !pauseInteraction )
        {
            doorAnim.Play(openAnimationName, 0, 0.0f);
            doorOpen = true;
            StartCoroutine(PauseDoorInteraction());
            doorOepning.Play();
        }
        else
        {
            if (!doorOpen && !pauseInteraction )
            {
                doorAnim.Play(closeAnimationName, 0, 0.0f);
                doorOpen = false;
                StartCoroutine(PauseDoorInteraction());
            }
        }


    }


}
