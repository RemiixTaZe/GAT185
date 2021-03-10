using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeLockCamera : MonoBehaviour
{
    [Range(0, 2)] public float sensitivity = 2;
    [Range(1, 5)] public float speed = 2;
    public GameObject hitMarker;
    public GameObject explosion;

    void Update()
    {
        //rotation
        if(Input.GetMouseButton(1))
        {
            Vector3 rotate = Vector3.zero;
            rotate.y = Input.GetAxis("Mouse X");
            rotate.x = Input.GetAxis("Mouse Y");

            transform.eulerAngles += rotate * sensitivity;

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        //translate
        Vector3 translate = Vector3.zero;
        translate.x = Input.GetAxis("Horizontal");
        translate.z = Input.GetAxis("Vertical");

        transform.position += (transform.rotation * translate) * speed * Time.deltaTime;
    }
}
