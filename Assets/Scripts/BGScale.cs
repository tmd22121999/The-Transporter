using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var worlHeight = Camera.main.orthographicSize * 2f;
        var worlWitdh = worlHeight * Screen.width / (Screen.height);
        transform.localScale = new Vector3(worlWitdh, worlHeight, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
