using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] Transform _shootPoint;
    [SerializeField] Transform _tankTower;
    [SerializeField] GameObject _bullet;
    [SerializeField] float _coolDown = 1f;
    [SerializeField] float shootDistance;
    [SerializeField] Transform targetLook;
    [SerializeField] private int fireRate = 3;
    [SerializeField] NavMeshControl navMeshControl;

    private float timer;

    Vector3 startTowerPosition;
    Transform _player;
    float currentCooldown;
    RaycastHit hit;

    SoundManager soundSource;

    [Range(0.5f, 10)]
    public float towerRotateSpeed = 5;

    void Start()
    {
        startTowerPosition = targetLook.localPosition;
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        soundSource = GetComponent<SoundManager>();
        soundSource.Play("Motor");
    }

    void Update()
    {
        if(currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }

        float distance = Vector3.Distance(_tankTower.position, _player.position);
        Vector3 smoothPosition;
        if(distance < shootDistance || navMeshControl._angry)
        {
            smoothPosition = Vector3.Lerp(targetLook.position, _player.position, 0.0125f * towerRotateSpeed);
            smoothPosition.y = _tankTower.position.y;
            targetLook.position = smoothPosition;
            _tankTower.LookAt(targetLook, Vector3.up);
        }
        else
        {
            smoothPosition = Vector3.Lerp(targetLook.localPosition, startTowerPosition, 0.0125f);
            targetLook.localPosition = smoothPosition;
            _tankTower.LookAt(targetLook, Vector3.up);
        }
        if (Physics.Raycast (_shootPoint.position, _tankTower.forward, out hit, shootDistance, -1)&& distance < shootDistance)
        {
            if (hit.collider != null && hit.collider.CompareTag("Player"))
            {
                Shoot();
            }
        }
        RandomShot();
    }

    public void Shoot()
    {
        if(currentCooldown <= 0)
        {
            Instantiate(_bullet, _shootPoint.position, _shootPoint.rotation);
            soundSource.Play("Shot");
            currentCooldown = _coolDown;
        }
    }
    private void RandomShot()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate && (hit.collider == null || (hit.collider != null && !hit.collider.CompareTag("Enemy"))))
        {
            timer = 0;
            Shoot();
        }
    }
}
