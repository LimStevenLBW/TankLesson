using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public Vector3 cameraOffset;
    public float rotationSpeedX;
    public float rotationSpeedY;

    private float horizontalDirection;
    private float verticalDirection;

    public float UpperViewingLimit;
    public float LowerViewingLimit;
    public bool isInvertedControls;

    public Transform pivot;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //Hide

        pivot.position = target.transform.position;
        pivot.parent = target.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        horizontalDirection = Input.GetAxis("Mouse X") * rotationSpeedX;
        verticalDirection = Input.GetAxis("Mouse Y") * rotationSpeedY;
        target.transform.Rotate(0, horizontalDirection, 0);

        if (isInvertedControls) pivot.Rotate(verticalDirection, 0, 0);
        else pivot.Rotate(-verticalDirection, 0, 0);



        //Manually clamping the rotation values
        if (pivot.rotation.eulerAngles.x > UpperViewingLimit && pivot.rotation.eulerAngles.x < 180)
        {
            pivot.rotation = Quaternion.Euler(UpperViewingLimit, 0, 0);
        }

        if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 360 + LowerViewingLimit)
        {
            pivot.rotation = Quaternion.Euler(360 + LowerViewingLimit, 0, 0);
        }

        //Create Target Angles for the camera
        float angleY = target.transform.eulerAngles.y;
        float angleX = pivot.transform.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(angleX, angleY, 0);
        transform.position = target.transform.position - (rotation * cameraOffset);

        if (transform.position.y < target.transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.transform.position.y - .5f, transform.position.z);
        }

        transform.LookAt(target.transform.position);
    }
}