using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public GameObject mantlet;
    public float UpperMantletLimit;
    public float LowerMantletLimit;


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

    void ClampRotation(Transform form, float upper, float lower)
    {
        //Manually clamping the rotation values
        if (form.rotation.eulerAngles.x > upper && form.rotation.eulerAngles.x < 180)
        {
            form.rotation = Quaternion.Euler(upper, 0, 0);
        }

        if (form.rotation.eulerAngles.x > 180f && form.rotation.eulerAngles.x < 360 + lower)
        {
            form.rotation = Quaternion.Euler(360 + lower, 0, 0);
        }

    }


    // Update is called once per frame
    void LateUpdate()
    {
        horizontalDirection = Input.GetAxis("Mouse X") * rotationSpeedX;
        verticalDirection = Input.GetAxis("Mouse Y") * rotationSpeedY;
        target.transform.Rotate(0, horizontalDirection, 0);


        if (isInvertedControls) pivot.Rotate(verticalDirection, 0, 0);
        else pivot.Rotate(-verticalDirection, 0, 0);


        if (isInvertedControls) mantlet.transform.Rotate(verticalDirection, 0, 0);
        else mantlet.transform.Rotate(-verticalDirection, 0, 0);

        ClampRotation(mantlet.transform, UpperMantletLimit, LowerMantletLimit);
        ClampRotation(pivot, UpperViewingLimit, LowerViewingLimit);

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