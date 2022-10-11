using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject PanelMenu;

    public void PauseMenuFun()
    {
        if (Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
        }
        PanelMenu.SetActive(true);
    }
    
    public void ResumeMenuFun()
    {

        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
        PanelMenu.SetActive(false);       
    }
        public void Restart(){

        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
        PanelMenu.SetActive(false);
        SceneManager.LoadScene("Game");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);

        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
        PanelMenu.SetActive(false);
        
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
    
}
