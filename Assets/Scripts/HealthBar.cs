using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private Transform healthBar;
    [SerializeField]
    public bool isPlayer = false;
    private float currentHealth;

    [SerializeField]
    private GameObject _expEffect;

    private SoundManager SM;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        SM = GetComponent<SoundManager>();
    }

    public void GetDamage(float dmg)
    {
        currentHealth -= dmg;
        if(currentHealth <= 0)
        {
            Die();
        }
        if (currentHealth > 0)
        {
            healthBar.localScale = new Vector3(healthBar.localScale.x, currentHealth / maxHealth, healthBar.localScale.z);
        }
        else
        {
            healthBar.localScale = Vector3.zero;
        }
        if (dmg > 0)
        {
            if(SM != null)
            {
                SM.Play("Damage");
            }

        }
        else
        {
            if (SM != null)
            {
                SM.Play("AidUp");
            }
        }
    }

    void Die()
    {
        Destroy(Instantiate(_expEffect, transform.position, transform.rotation),3f);
        if (isPlayer)
        {
            if (SM != null)
            {
                SM.Play("Destroy");
            }
            GameController.Instance.uIController.SendMessage("Tank Exploded", "red");
            GameController.Instance.levelController.DelayedSceneReload();
        }
        else
        {
            GameController.Instance.EnemyDeath();
            Destroy(gameObject, 0.1f);
        }
    }


}
