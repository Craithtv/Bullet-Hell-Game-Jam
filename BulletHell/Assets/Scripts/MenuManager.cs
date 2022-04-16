using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    
   public Canvas quitButtonMenu;
   public Canvas settingsButtonMenu;
   public Canvas pauseButtonMenu;
   
   
   private void Awake()
   {
       
       settingsButtonMenu.GetComponent<Canvas> ().enabled = false;
       pauseButtonMenu.GetComponent<Canvas> ().enabled = false;
       quitButtonMenu.GetComponent<Canvas> ().enabled = false;
       Time.timeScale = 1;
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
    }

    public void OnFirstQuitButton()
    {
        quitButtonMenu.GetComponent<Canvas> ().enabled = true;
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
