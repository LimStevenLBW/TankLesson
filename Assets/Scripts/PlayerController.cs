using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float gravityBoost;

    private Rigidbody body;

    //private int jumpAmountCounter = 0;
   // [SerializeField] private int jumpAmountAllowed;
    private bool isGrounded;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        ResetDirection();
        CheckRotation();
        CheckDirection();
        //CheckJump();


        MoveDirection();
    }

    void FixedUpdate()
    {
        body.AddForce(Vector3.down * gravityBoost * body.mass);
    }

    /*
    void CheckJump()
    {

        if(isGrounded || jumpAmountCounter < jumpAmountAllowed)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isGrounded = false;
                body.velocity += new Vector3(0, jumpSpeed, 0);
                jumpAmountCounter++;
            }
        }
      
    }
    */

    void MoveDirection()
    {
        transform.position += direction.normalized * speed * Time.deltaTime;
    }

    void CheckRotation()
    {
        if (Input.GetKey("a"))
        {
           
        }
        if (Input.GetKey("d"))
        {
            
        }
    }

    void CheckDirection()
    {
        if (Input.GetKey("w"))
        {
            direction.z = 1;
        }
        if (Input.GetKey("s"))
        {
            direction.z = -1;
        }
    }

    void ResetDirection()
    {
        direction = new Vector3(0, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        /*
        if(other.tag == "ground")
        {
            isGrounded = true;
            jumpAmountCounter = 0;
        }
        */
    }
}
