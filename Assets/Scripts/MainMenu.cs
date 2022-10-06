using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Animator fadeInAnimator;

    [SerializeField]
    private GameObject fadeInImage;
    void Start()
    {
        Cursor.lockState = CursorLockMode.None; 
    }
    public void StartGame()
    {
        StartCoroutine("StartLevel");
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void OnHoverEnter(GameObject btn)
    {
        btn.GetComponent<Image>().enabled = true;
    }
    public void OnHoverExit(GameObject btn)
    {
        btn.GetComponent<Image>().enabled = false;
    }
    IEnumerator StartLevel()
    {
        fadeInImage.SetActive(true);
        fadeInAnimator.SetTrigger("LevelStart");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Game");
    }
}
