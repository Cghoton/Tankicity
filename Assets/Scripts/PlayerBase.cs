using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBase : MonoBehaviour
{
    [SerializeField]
    private GameObject WallBlock;

    [SerializeField]
    private GameObject ExpEffect;

    private void CreateWall()
    {
        for (int x = 0; x <= 12; x += 3)
        {
            for(int i = 0; i <= 12; i += 3)
            {
                Instantiate(WallBlock, transform.position + new Vector3(-6 + x, 0, -6 + i), transform.rotation).GetComponent<SmartBox>().StayBrick();
            }
        }
        ClearSpace();
    }
    private void ClearSpace()
    {
        Collider[] hitColliders = Physics.OverlapBox(transform.position, transform.localScale, Quaternion.identity);
        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.GetComponent<SmartBox>() != null)
            {
                Destroy(hitCollider.gameObject);
            }
        }
    }

    private void Start()
    {
        CreateWall();
    }

    private void OnTriggerEnter(Collider other)
    {
        Bullet bullet = other.GetComponent<Bullet>();
        if(bullet != null)
        {
            Destroy(Instantiate(ExpEffect, transform.position, transform.rotation), 2f);
            GameController.Instance.uIController.SendMessage("Base have been destroyed", "red");
            GameController.Instance.levelController.DelayedSceneReload();
        }
    }
}
