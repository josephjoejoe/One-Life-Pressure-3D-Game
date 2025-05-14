using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    public GameObject CannonBullet;
    public Transform bulletPos;

    public float timer;

    public AudioSource cannonSound;

    private void Start()
    {
        cannonSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 5)
        {
            timer = 0;
            shoot();
        }
    }

    void shoot()
    {
        Instantiate(CannonBullet, bulletPos.position, Quaternion.identity);
        cannonSound.Play();
    }
}
