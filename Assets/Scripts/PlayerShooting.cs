using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    private Transform _shootPoint;
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private float _coolDown;
    [SerializeField]
    private GameObject _expEffect;


    float currentCooldown;
    bool isButtonHolding;

    [SerializeField]
    private SoundManager soundManager;

    void Update()
    {
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.Mouse0) || isButtonHolding)
        {
            Shoot();
        }
    }
    void Shoot()
    {
        if(currentCooldown <= 0)
        {
            CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
            Instantiate(_bullet, _shootPoint.position, _shootPoint.rotation);
            Destroy(Instantiate(_expEffect, _shootPoint.position, _shootPoint.rotation), 2f);
            soundManager.Play("Shot");
            currentCooldown = _coolDown;
        }
    }
}
