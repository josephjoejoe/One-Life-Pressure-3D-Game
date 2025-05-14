using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            SceneManager.LoadScene(1);
        }
    }
}
