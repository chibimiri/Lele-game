using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public LevelManager gameLevelManager;
    void Start()
    {
        gameLevelManager = FindObjectOfType<LevelManager>();   
    }
    public void PlayGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
        SceneManager.LoadScene("Level1"); 
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QUIT");
    }
    public void RemovePanel()
    {
        gameLevelManager.QuitarPanel();
    }
}
