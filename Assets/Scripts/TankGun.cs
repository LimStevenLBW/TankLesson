using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankGun : MonoBehaviour
{
    public AudioSource source;
    public AudioClip tankFire;


    public Camera playerCamera;
    public GameObject projectile;
    public GameObject projectileSpawn;
    public float launchVelocity = 1700f;

    // Start is called before the first frame update
    void Start()
    {

    }
    void CheckShoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            source.PlayOneShot(tankFire);

            GameObject ball = Instantiate(projectile, projectileSpawn.transform.position,
                                                      transform.rotation);
            ball.GetComponent<Rigidbody>().AddForce(transform.forward * launchVelocity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckShoot();
        /*
        float yaw = 0f;
        float pitch = 0f;
        yaw = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * 2f;

        // Clamp pitch between lookAngle
        pitch = Mathf.Clamp(pitch, -50, 50);

        transform.localEulerAngles = new Vector3(0, yaw, 0);
        playerCamera.transform.localEulerAngles = new Vector3(pitch, 0, 0);
        */

    }
}
