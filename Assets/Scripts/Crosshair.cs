using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField]
    private GameObject crossHair;

    [SerializeField]
    private Material enemyMaterial;

    [SerializeField]
    private Material neutralMaterial;

    private Renderer _renderer;
    private Transform _chTransform;
    private Transform _trans;

    void Start()
    {
        _trans = GetComponent<Transform>();
        _chTransform = crossHair.GetComponent<Transform>();
        _renderer = crossHair.GetComponent<Renderer>();
    }

    void Update()
    {
        Ray ray = new Ray(_trans.position, _trans.forward * 2000);
       
        float distance = (_trans.position - _chTransform.position).magnitude;

        distance = Mathf.Clamp(distance, 3f, 15f);
        _chTransform.localScale = Vector3.one * distance / 3;
        if(Physics.Raycast(ray,out RaycastHit hit) && hit.collider.tag != "Bullet")
        {
            _chTransform.position = Vector3.Lerp(_chTransform.position, hit.point - _chTransform.forward, 0.7f);
            if (hit.collider.CompareTag("Enemy"))
            {
                _renderer.material = enemyMaterial;
            }
            else
            {
                _renderer.material = neutralMaterial;
            }
        }
        else if (!Physics.Raycast(ray))
        {
            _renderer.material = neutralMaterial;
            _chTransform.position = Vector3.Lerp(_chTransform.position, _trans.position + _trans.forward * 10f, 0.5f);
        }
    }
}
