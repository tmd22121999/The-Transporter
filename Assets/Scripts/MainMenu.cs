using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject board;
    public Text nameBox;
    public static string PlayerName;
    // Start is called before the first frame update
    void Start()
    {
        if (MainMenu.PlayerName != null)
            nameBox.text = MainMenu.PlayerName;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
    public void Credit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void LeaderBoard()
    {
        board.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    public void changeName(string PlayerName)
    {
        MainMenu.PlayerName = PlayerName;
        Debug.Log(MainMenu.PlayerName);
    }
}

