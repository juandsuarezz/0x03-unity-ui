using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;

    public Material trapMat;
    public Material goalMat;
    public Toggle colorblindMode;

    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(PlayMaze);
        quitButton.onClick.AddListener(QuitMaze);
    }

    public void PlayMaze()
    {
        trapMat.color = Color.red;
        goalMat.color = Color.green;
        if (colorblindMode.isOn)
        {
            trapMat.color = new Color32(255, 112, 0, 1);
            goalMat.color = Color.blue;
        }
        SceneManager.LoadScene("maze");
    }

    public void QuitMaze()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }
}
