using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);

    }

    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }
    

    // Update is called once per frame
   
}
