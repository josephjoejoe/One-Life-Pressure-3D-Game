using UnityEngine;
using System.Collections;

public class OpenDoorButton : MonoBehaviour
{
    [SerializeField] private Animator doorAnim = null;

    public AudioSource doorOepning;

    public bool doorOpen = false;

    public AllBoxOffFloor Task1;

    public RandomColorPlates Task2;

    //public WeightPressurePlate Task3;

    public Renderer buttonRend;

    [SerializeField] private string openAnimationName = "DoorOpen";
    [SerializeField] private string closeAnimationName = "DoorClose";

    [SerializeField] private int waitTimer = 1;
    [SerializeField] private bool pauseInteraction = false;

    void Start()
    {
        doorOepning = GetComponent<AudioSource>();
        buttonRend = GetComponent<Renderer>();
    }

    void Update()
    {
        if (Task1.taskCompleted == true)
        {

            buttonRend.material.color = Color.green;
        }
        else
        {
            buttonRend.material.color = Color.red;
        }

        if (Task2.taskCompleted == true)
        {

            buttonRend.material.color = Color.green;
        }
        else
        {
            buttonRend.material.color = Color.red;
        }

    }
    private IEnumerator PauseDoorInteraction()
    {
        pauseInteraction = true;
        yield return new WaitForSeconds(waitTimer);
        pauseInteraction = false;
    }

    public void PlayAnimation()
    {
        if (Task1.taskCompleted == true)
        {
            if (!doorOpen && !pauseInteraction)
            {
                doorAnim.Play(openAnimationName, 0, 0.0f);
                doorOpen = true;
                StartCoroutine(PauseDoorInteraction());
                doorOepning.Play();
            }
            else
            {
                if (!doorOpen && !pauseInteraction)
                {
                    doorAnim.Play(closeAnimationName, 0, 0.0f);
                    doorOpen = false;
                    StartCoroutine(PauseDoorInteraction());
                }
            }
        }

        if (Task2.taskCompleted == true)
        {
            if (!doorOpen && !pauseInteraction)
            {
                doorAnim.Play(openAnimationName, 0, 0.0f);
                doorOpen = true;
                StartCoroutine(PauseDoorInteraction());
                doorOepning.Play();
            }
            else
            {
                if (!doorOpen && !pauseInteraction)
                {
                    doorAnim.Play(closeAnimationName, 0, 0.0f);
                    doorOpen = false;
                    StartCoroutine(PauseDoorInteraction());
                }
            }
        }

    }


}
