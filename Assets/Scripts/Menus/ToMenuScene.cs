using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMenuScene : MonoBehaviour
{
    
    public void ChangeToMenuScene() {
        SceneManager.LoadScene("MenuScene");
    }
    
}
