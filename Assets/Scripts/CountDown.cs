using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public static float timeStart = 0;
    public Text textBox;

    public GameObject scoreMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        timeStart = 0;
        //textBox.text = timeStart.ToString("F2");

    }

    // Update is called once per frame
    void LateUpdate()
    {
        timeStart += Time.deltaTime;
        textBox.text = timeStart.ToString("F2");
    }
   
}
