using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField]
    private Transform tankTower;

    [SerializeField]
    private float rotationSpeed = 20f;

    private Vector3 currentRotation;

    void Start()
    {
        currentRotation = tankTower.localEulerAngles;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentRotation.y += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        tankTower.localEulerAngles = currentRotation;
    }
}
