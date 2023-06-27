using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Text textBox;
    private float count;
    private bool check = false;
    public GameObject PauseButton;
    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 0f;
        count = 3.99999999f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (check == false)
        {
            if (count > 0)
            {
                textBox.text = Mathf.Floor(count).ToString("F0");
                count -= Time.unscaledDeltaTime;
            }
            else
            {
                PauseButton.SetActive(true);
                check = true;
                Time.timeScale = 1f;
                textBox.text = "";
            }
        }
        
    }
}
