using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PregameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject previewImage;
    [SerializeField]    
    private Transform  contentPanel;


    //test 
    [SerializeField] GameObject buttonPrefab;
    private Color[] colorButton =
                    {new Color(0f, 202f, 255f, 255f),
                    Color.red,
                    new Color(251f, 0f, 255f, 255f),
                    };
    void Start()
    {
        previewImage.GetComponent<Image>().color= GameManagers.Instance.playerData.color;
        createButton();
    }

    private void createButton(){
        float yPosition= 50;
        for(int i =0;i<colorButton.Length;i++){
            GameObject button = (GameObject)Instantiate(buttonPrefab);      
            Color changeColor = colorButton[i];
            button.GetComponent<Image>().color = changeColor ;   
            
            button.GetComponent<Button>().onClick.AddListener(
                () => { 
                    this.changeCostume(changeColor);
                });

            float xPos =((i%3)*3-3)*70;
            button.transform.SetPositionAndRotation(new Vector3(xPos, yPosition, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f,0.0f));
            button.transform.SetParent(contentPanel,false);
            if(i%3==2) yPosition -= 180;
        }
    }

    public void changeCostume(){
        Color newColor = Random.ColorHSV();
        // Debug.Log(newColor);
        previewImage.GetComponent<Image>().color=newColor;
        GameManagers.Instance.playerData.color=newColor;
        return;
    }

    public void changeCostume(Color colorChange){
        // Debug.Log(newColor);
        previewImage.GetComponent<Image>().color=colorChange;
        GameManagers.Instance.playerData.color=colorChange;
        return;
    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
