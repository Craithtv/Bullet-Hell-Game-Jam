using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    private bool menuOpen = false;
   public Canvas quitButtonMenu;
   public Canvas settingsButtonMenu;
   public Canvas pauseButtonMenu;
    public AudioSource mainSong;
    public AudioSource bossSong;
   
   
   private void Awake()
   {
       
       settingsButtonMenu.GetComponent<Canvas> ().enabled = false;
       pauseButtonMenu.GetComponent<Canvas> ().enabled = false;
       quitButtonMenu.GetComponent<Canvas> ().enabled = false;
       Time.timeScale = 1;
   }

   public void Update()
   {
       if (Input.GetKeyDown(KeyCode.Escape) && menuOpen == false)
        {
            Time.timeScale = 0;
            pauseButtonMenu.GetComponent<Canvas>().enabled = true;
            mainSong.Pause();
            if (bossSong != null)
                bossSong.Pause();
            menuOpen = true;
            Debug.Log("Key Detected");
        }
    else if(Input.GetKeyDown(KeyCode.Escape) && menuOpen == true)
        {
            Time.timeScale = 1;
            if(bossSong != null)
                bossSong.UnPause();
            mainSong.UnPause();
            pauseButtonMenu.GetComponent<Canvas>().enabled = false;
            settingsButtonMenu.GetComponent<Canvas>().enabled = false;
            quitButtonMenu.GetComponent<Canvas>().enabled = false;
           

            menuOpen = false;
        }

       
   }
   
   
   
    public void OnQuitConfirmButton()
    {
        Application.Quit();
    }

    public void OnPauseButton()
    {
        pauseButtonMenu.GetComponent<Canvas> ().enabled = true;
        Time.timeScale = 0;
    }

    public void OnResumeButton()
    {
         pauseButtonMenu.GetComponent<Canvas> ().enabled = false;
         Time.timeScale = 1;
    }

    public void OnSettingsButton()
    {
        settingsButtonMenu.GetComponent<Canvas> ().enabled = true;
        pauseButtonMenu.GetComponent<Canvas>().enabled = false;
    }

    public void OnSettingsBackButton()
    {
        settingsButtonMenu.GetComponent<Canvas> ().enabled = false;
        pauseButtonMenu.GetComponent<Canvas>().enabled = true;
    }

    public void OnFirstQuitButton()
    {
        quitButtonMenu.GetComponent<Canvas> ().enabled = true;
        pauseButtonMenu.GetComponent<Canvas>().enabled = false;

    }

    public void OnQuitConfirmBackButton()
    {
        quitButtonMenu.GetComponent<Canvas> ().enabled = false;
        pauseButtonMenu.GetComponent<Canvas>().enabled = true;
    }
    
    public void OnBackButton()
    {
        SceneManager.LoadScene(0); 
    }


    
    public void OnMainMenuButton()
    {
        SceneManager.LoadScene(0); 
    }

    public void OnRetryButton()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         

    }

    public void OnNextLevelButton()
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnCloseButton()
    {
        GetComponent<Canvas> ().enabled = false;
    }


}
