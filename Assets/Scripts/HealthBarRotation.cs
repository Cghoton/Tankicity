using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarRotation : MonoBehaviour
{
    Transform PlayerCamera;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        PlayerCamera = GameObject.FindGameObjectWithTag("Player").transform;
        
        transform.LookAt(new Vector3(transform.rotation.x, PlayerCamera.transform.rotation.y, transform.rotation.z));
       
    }
}
