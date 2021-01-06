using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playButton;
    
    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(PlayMaze);
    }

    public void PlayMaze()
    {
        SceneManager.LoadScene("maze");
    }
}
