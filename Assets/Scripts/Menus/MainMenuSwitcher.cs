using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSwitcher : MonoBehaviour
{
    
    public Canvas mainMenuCanvas;
    public SpriteRenderer mainMenuBackground;
    public Canvas instructionsMenuCanvas;
    public SpriteRenderer instructionsMenuBackground;
    
    void Start() {
        MainMenu();
    }
    
    public void StartGame() {
        SceneManager.LoadScene("GameScene");
    }
    
    public void InstructionsMenu() {
        mainMenuCanvas.gameObject.SetActive(false);
        mainMenuBackground.gameObject.SetActive(false);
        instructionsMenuCanvas.gameObject.SetActive(true);
        instructionsMenuBackground.gameObject.SetActive(true);
    }
    
    public void MainMenu() {
        instructionsMenuCanvas.gameObject.SetActive(false);
        instructionsMenuBackground.gameObject.SetActive(false);
        mainMenuCanvas.gameObject.SetActive(true);
        mainMenuBackground.gameObject.SetActive(true);
    }
    
    public void QuitGame() {
        Application.Quit();
    }
    
}
