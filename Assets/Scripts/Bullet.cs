using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float damage;

    [SerializeField]
    private float speed = 10;

    [SerializeField]
    private GameObject _expEffect;

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        
        if(other.GetComponent<HealthBar>() != null)
        {
            other.GetComponent<HealthBar>().GetDamage(damage);
            Destroy(Instantiate(_expEffect, transform.position, transform.rotation),2f);
            NavMeshControl _nmc = other.GetComponent<NavMeshControl>();
            if (_nmc != null)
            {
                _nmc.StayAngry(true);
            }
            Destroy(gameObject);
        }
        SmartBox smartBox = other.GetComponent<SmartBox>();
        if(smartBox != null)
        {
            smartBox.TryDestroy();
        }
        Destroy(Instantiate(_expEffect, transform.position, transform.rotation), 2f);
        Destroy(gameObject);

    }
}
