using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Quản lý game
public class GameManagers : MonoBehaviour
{
    public static GameManagers Instance {get;private set;}
    private Player _playerData = new Player();
    public Player playerData{get{return _playerData;} private set{}}

    // Start is called before the first frame update
    private void Awake() {
        if(Instance !=null && Instance !=this){
            Debug.Log("aaa");
            Destroy(this);
        }else{
            Debug.Log("tesst");
            Instance=this;
             DontDestroyOnLoad(this);
        }
        //
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
