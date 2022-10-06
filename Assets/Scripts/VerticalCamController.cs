using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalCamController : MonoBehaviour
{
    public float sensitivity = 5f;
    public float titleAngle;
    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.inPause)
        {
        float mouseY = Input.GetAxis("Mouse Y");
        titleAngle -= mouseY * sensitivity;
        titleAngle = Mathf.Clamp(titleAngle, -40f, 50f);
        transform.localRotation = Quaternion.Euler(titleAngle, 0, 0);
        }
    }
}
