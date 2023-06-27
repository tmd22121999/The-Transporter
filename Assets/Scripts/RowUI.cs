using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RowUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Text rank, namePlayer, score;
    public void setText(int rank, string namePlayer, int score)
    {
        this.rank.text = rank.ToString();
        this.namePlayer.text = namePlayer;
        this.score.text = score.ToString();

    }

}
