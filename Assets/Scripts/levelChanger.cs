using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelChanger : MonoBehaviour
{
    private Animator anim;
    public int levelToLoad;

    public Vector3 position;
    //public VectorValue playerStorage;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void FadeToLevel(int lvl_num)
    {
        anim.SetTrigger("fade");
    }

    public void LevelLoad(int lvl_num)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(lvl_num);
        PausePanel.SetActive(false);
    }


    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void levelReload()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PausePanel.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    void Update()
    {

    }


    // PAUSE MENU

    public GameObject PausePanel;

    public void PauseButton()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ContinueButton()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
