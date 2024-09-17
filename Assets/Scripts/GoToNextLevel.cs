using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLevel : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (collision.CompareTag("Player"))
        {
            if (currentLevel == 5)
                SceneManager.LoadScene(0);
            else
            {
                UnLockLevel();
                SceneManager.LoadScene(currentLevel + 1);
            }

        }
    }

    public void UnLockLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel >= PlayerPrefs.GetInt("levels"))
        {
            PlayerPrefs.SetInt("levels", currentLevel + 1);
        }
    }
}
