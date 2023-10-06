using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControlScript : MonoBehaviour
{
    public AudioSource source;
    public AudioClip tankFire;
    public AudioClip tankDeath;
    public AudioClip tankMove;


    private float rotation;
    public float rotationSpeed;
    public float speed;
    private float maxSpeed;
    public float jumpSpeed;
    public float gravityBooster;
    private bool isGrounded;
    private Rigidbody body;
    private Vector3 direction;

    //public float accelerationMax;
   // public float accelerationMin;
   // private float accelerationCurrent;
   // private bool accelerationActive;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //accelerationCurrent = accelerationMin;
      //  accelerationActive = false;
        maxSpeed = speed + 10;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDirection();
        CheckRotation();

        //CheckAcceleration();
        //CheckForJumping();

        //transform.position += direction.normalized * speed * Time.deltaTime;
        
    }
    void FixedUpdate()
    {
        body.AddForce(direction * speed, ForceMode.Acceleration);
        body.drag = (speed / maxSpeed); //Caps the speed of the gameobject
        body.AddForce(Vector3.down * gravityBooster);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "enemy")
        {
            Debug.Log("Bam you died");
        }

        if(other.tag == "ground")
        {
            isGrounded = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "ground")
        {
            isGrounded = false;
        }
    }



    
    void CheckAcceleration()
    {
      //  if(accelerationActive)
    }

    void CheckForJumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            body.velocity += new Vector3(0, jumpSpeed, 0);
        }
    }

    void CheckRotation()
    {
        rotation = 0;
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rotation = -1;
        }
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rotation = 1;
        }
        transform.Rotate(0f, rotation * rotationSpeed * Time.deltaTime, 0f);
    }

    void CheckDirection()
    {

        direction = new Vector3(0, 0, 0);
        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            direction = transform.forward * 1;
        }
        else if (Input.GetKey("s") || Input.GetKey("down"))
        {
            direction = transform.forward * -1;
        }



    }

}
