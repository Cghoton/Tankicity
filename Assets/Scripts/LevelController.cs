using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public void SceneReload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void DelayedSceneReload(float delay = 1f)
    {
        Invoke("SceneReload", delay);
    }
}
