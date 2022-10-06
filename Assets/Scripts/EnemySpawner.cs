using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    float timer;
    public int spawnTime = 3;
    public int enemiesCount;
    public GameObject EnemyTankPrefab;

    private Vector3 spawnDeflection;

    void Start()
    {
        enemiesCount = GameController.Instance.EnemiesSpawnAmount;
        Invoke("CheckCubes", 1f);
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTime && GameController.Instance.EnemiesSpawnLeft > 0)
        {
            timer = 0;
            SpawnEnemyTank();
        }
    }
    void SpawnEnemyTank()
    {
        spawnDeflection = new Vector3(Random.Range(-20, 20), 0, 0);
        GameController.Instance.SpawnEnemy();
        GameObject Enemy = Instantiate(EnemyTankPrefab, transform.position+spawnDeflection, transform.rotation);
    }
    void CheckCubes()
    {
        Collider[] hitColliders = Physics.OverlapBox(transform.position, transform.localScale / 2, Quaternion.identity);
        foreach(Collider hitCollider in hitColliders)
        {
            if(hitCollider.GetComponent<SmartBox>() != null)
            {
                Destroy(hitCollider.gameObject);
            }
        }
    }
}
