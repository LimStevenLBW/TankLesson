using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCopyScript : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public float gravityBooster;

    private bool isGrounded;
    private Rigidbody body;
    private Vector3 direction;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        CheckDirection();
        CheckForJumping();

        transform.position += direction.normalized * speed * Time.deltaTime;
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

    void FixedUpdate()
    {
        body.AddForce(Vector3.down * gravityBooster);
    }



    void CheckForJumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            body.velocity += new Vector3(0, jumpSpeed, 0);
        }
    }

    void CheckDirection()
    {
        direction = new Vector3(0, 0, 0);
        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            direction.z = 1;
        }
        if (Input.GetKey("s") || Input.GetKey("down"))
        {
            direction.z = -1;
        }
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            direction.x = -1;
        }
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            direction.x = 1;
        }

    }

}
