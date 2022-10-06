using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{

    [SerializeField]
    public Transform playerTrans;

    private Transform _trans;
    void Start()
    {
        _trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition = playerTrans.position;
        newPosition.y = _trans.position.y;
        _trans.position = Vector3.Lerp(_trans.position, newPosition, 0.125f);

        _trans.rotation = Quaternion.Euler(90f, playerTrans.eulerAngles.y, 0f);
    }
}
