using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public LevelController levelController;
    public UIController uIController;
    public SoundManager playerSM;

    private int[] EnemiesOnLevel = { 4, 6, 8, 10, 15 };
    public int EnemiesSpawnAmount { get; private set; }
    public int EnemiesSpawnLeft { get; private set; }
    public int EnemiesLeft { get; private set; }
    public static int Level = 0;

    void Awake()
    {
        Instance = this;
        EnemiesSpawnAmount = EnemiesOnLevel[Level];
    }

    private void Start()
    {
        EnemiesSpawnLeft = EnemiesSpawnAmount;
        EnemiesLeft = EnemiesSpawnAmount;

        uIController.UpdateEnemiesAmount(EnemiesLeft);
        uIController.SendMessage("Stage " + Level, "yellow");
    }


    public void SpawnEnemy()
    {
        EnemiesSpawnLeft--;
    }
    public void EnemyDeath()
    {
        EnemiesLeft--;
        uIController.UpdateEnemiesAmount(EnemiesLeft);
        if(EnemiesLeft <= 0)
        {
            playerSM.Play("LevelUp");
            uIController.SendMessage("Level Comleted", "green");
            Invoke("ChangeLevel", 1f);
        }
    }

    private void ChangeLevel()
    {
        if(Level < EnemiesOnLevel.Length)
        {
            Level++;
            levelController.SceneReload();
        }
        else
        {
            uIController.SendMessage("You Won!", "green");
      
        }
    }
    public void SetZeroLevel()
    {
        Level = 0;
    }

}
