using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    public GameObject PauseMenuObj;

    public static bool inPause;

    private void Start()
    {
        PauseMenuObj.SetActive(false);
        
    }

    void StayPause()
    {
        ChangeState(true);
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        PauseMenuObj.SetActive(false);
        ChangeState(false);
    }

    public void LoadMainMenu()
    {
        GameController.Instance.SetZeroLevel();
        SceneManager.LoadScene("MainMenu");
        ChangeState(false);
    }

    private void ChangeState(bool toPause)
    {
        Time.timeScale = toPause ? 0f : 1f;
        PauseMenuObj.SetActive(toPause);
        Cursor.lockState = toPause ? CursorLockMode.None : CursorLockMode.Locked;
        inPause = toPause;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (inPause)
            {
                Resume();
            }
            else
            {
                StayPause();
            }
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
