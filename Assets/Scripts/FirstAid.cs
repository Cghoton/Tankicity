using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid : MonoBehaviour
{
    [SerializeField]
    private float healValue;
    private Transform _trasn;

    [SerializeField]
    private GameObject TakeEffect;


    private void Start()
    {
        _trasn = GetComponent<Transform>();
        Invoke("CheckCubes", 0.5f);
    }

    private void Update()
    {
        _trasn.Rotate(Vector3.up * 30 * Time.deltaTime);
    }
    
    void CheckCubes()
    {
        Collider[] hitColliders = Physics.OverlapBox(transform.position, transform.localScale / 2, Quaternion.identity);
        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.GetComponent<SmartBox>() != null)
            {
                Destroy(hitCollider.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(Instantiate(TakeEffect, transform.position, transform.rotation), 2f);
            other.GetComponent<HealthBar>().GetDamage(-healValue);
            Destroy(gameObject);
        }
    }
}
