using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Reloader : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        HealthBar health = other.GetComponent<HealthBar>();
        if(health != null)
        {
            if (health.isPlayer)
            {
                GameController.Instance.levelController.SceneReload();
                return;
            }
            Destroy(other.gameObject);
        }
    }
}
