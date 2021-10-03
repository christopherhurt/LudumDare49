using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSwitcher : MonoBehaviour
{
    
    public Canvas mainMenuCanvas;
    public Canvas instructionsMenuCanvas;
    
    void Start() {
        MainMenu();
    }
    
    public void StartGame() {
        SceneManager.LoadScene("GameScene");
    }
    
    public void InstructionsMenu() {
        mainMenuCanvas.gameObject.SetActive(false);
        instructionsMenuCanvas.gameObject.SetActive(true);
    }
    
    public void MainMenu() {
        instructionsMenuCanvas.gameObject.SetActive(false);
        mainMenuCanvas.gameObject.SetActive(true);
    }
    
    public void QuitGame() {
        Application.Quit();
    }
    
}
