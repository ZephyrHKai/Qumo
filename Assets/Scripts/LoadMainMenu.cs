using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadMainMenu : MonoBehaviour
{
    [SerializeField] int LevelNumber = 1;
    // Start is called before the first frame update
 

    public void MainMenu()
    {
        SceneManager.LoadScene(LevelNumber);
    }
}
