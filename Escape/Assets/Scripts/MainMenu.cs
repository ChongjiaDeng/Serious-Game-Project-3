using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class MainMenu : MonoBehaviour

{
    public void playgame(){
        SceneManager.LoadScene("Scenes/Main");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
