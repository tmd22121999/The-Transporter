using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player 
{
    private Color _color=Color.red;
    private int _maxSpeedLevel = 5 ;
    private int _speedLevel = 0;
    private int _coin = 1000;
    public Color color{get{return _color;}set{_color=value;}}
    public int speedLevel{get{return _speedLevel;} private set{_speedLevel=value;}}
    public int coin{get{return _coin;} private set{_coin=value;}}

    public enum SkillID{Speed = 0};
    private int[] _skillLevel ={0};
    private int[] _maxSkillLevel ={5};
    private int[] _skillCost ={50};
    public int skillLevel{get{return _speedLevel;} private set{_speedLevel=value;}}
    public bool upgradeSkill(int skillID){
        switch(skillID){
            case (int)SkillID.Speed:
                if(_speedLevel==_maxSpeedLevel){
                    return false;
                }
                if(!changeCoin(-_skillCost[skillID])){
                    return false;
                }
                Debug.Log(coin);
                speedLevel=Mathf.Clamp(speedLevel+1,0,_maxSpeedLevel);
                break;
            default:
                return false;
        }
        return true;
    }
    public bool changeCoin(int coinAmount){
        if(coin + coinAmount<0){
            return false;
        }
        coin =coin + coinAmount;
        return true;
    }

}
