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
    private GameObject  CostumeContentPanel;
    [SerializeField]    
    private GameObject  SkillContentPanel;


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
        // Tạo các nút thay trang phục từ danh sách có sẵn vào trong scroll costume view
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
            button.transform.SetParent(CostumeContentPanel.transform,false);
            if(i%3==2) yPosition -= 180;
        }
        yPosition= 50;
        // Tạo các nút thay kỹ năng từ danh sách có sẵn vào trong scroll skill view
        for(int i =0;i<colorButton.Length;i++){
            GameObject button = (GameObject)Instantiate(buttonPrefab);      
            Color changeColor = colorButton[i];
            button.GetComponent<Image>().color = changeColor ;   
            
            button.GetComponent<Button>().onClick.AddListener(
                () => { 
                    this.upgradeSkill(0);
                });
                float xPos =((i%3)*3-3)*70;
            button.transform.SetPositionAndRotation(new Vector3(xPos, yPosition, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f,0.0f));
            button.transform.SetParent(SkillContentPanel.transform,false);
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

    public enum TabID {Costume=0, Skill=1,Map=2};

    public void changeTab(int tabID){
        switch (tabID){
            case (int)TabID.Costume:
                CostumeContentPanel.SetActive(true);
                SkillContentPanel.SetActive(false);
                break;
            case (int)TabID.Skill:
                CostumeContentPanel.SetActive(false);
                SkillContentPanel.SetActive(true);
                break;
            case (int)TabID.Map:
            Debug.Log("test");
                gameObject.GetComponent<Animator>().Play("ChangeTabToMap", -1, 0f);
                break;
            default:
                break;

        }
    }

    private void changeCostume(Color colorChange){
        // Debug.Log(newColor);
        previewImage.GetComponent<Image>().color=colorChange;
        GameManagers.Instance.playerData.color=colorChange;
        return;
    }
    private void upgradeSkill(int skillID){
        Debug.Log(GameManagers.Instance.playerData.upgradeSkill(skillID)); 
        return;
    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
