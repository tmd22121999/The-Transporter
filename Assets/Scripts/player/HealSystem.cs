using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text;
using SimpleJSON;
public class HealSystem : MonoBehaviour
{
    public int hp = 3;
    public Image heal;
    public Slider slider;
    public Text textBox;
    public Text bestScore;
    static float best;
    private IEnumerator healCorouine;

    public GameObject scoreMenuUI;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        SetMaxHealth(3);


    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Enemy"))
        {
            animator.SetTrigger("dead");
            if (hp > 1)
            {
                hp -= 1;
                if (animator.GetBool("healb"))
                    animator.SetBool("healb", false);
                if (healCorouine != null)
                    StopCoroutine(healCorouine);
                if (CountDown.timeStart > 10)
                    CountDown.timeStart -= 10;
                SetHealth(hp);
            }
            else
            {
                PauseMenu.IsGameOver = true;
                Score();
            }

        }

        if (target.gameObject.CompareTag("Heal"))
        {
            //if( !animator.GetBool("healb")){

            //}
            animator.SetBool("healb", true);
            /*if (hp <= 3)
            {
                healCorouine = healAni();
                StartCoroutine(healCorouine);
                
            }*/
            Destroy(target.gameObject);
        }
        if (animator.GetBool("healb"))
        {
            if (target.gameObject.CompareTag("HealDes"))
            {
                if (hp < 3)
                {
                    hp += 1;
                    SetHealth(hp);
                }
                else
                {
                    CountDown.timeStart += 10;
                }
                animator.SetBool("healb", false);
            }
        }
    }
    IEnumerator healAni()
    {
        var timeDelay = 5;
        yield return new WaitForSeconds(timeDelay);
        if (hp < 3)
        {
            hp += 1;
            SetHealth(hp);
        }
        else
        {
            CountDown.timeStart += 10;
        }
        animator.SetBool("healb", false);


    }
    public void Score()
    {
        scoreMenuUI.SetActive(true);
        Time.timeScale = 0f;

        textBox.text = CountDown.timeStart.ToString("F2");
        var jsonInput = new JSONObject();
        jsonInput["name"] = MainMenu.PlayerName;
        jsonInput["score"] = (int)CountDown.timeStart;
        Debug.Log(jsonInput.ToString());
        string urlInput = "hhttps://myartistlist99.herokuapp.com/v1/leaderboard/";
        StartCoroutine(Post(urlInput, jsonInput.ToString()));
        if (CountDown.timeStart > best)
        {
            best = CountDown.timeStart;
            bestScore.text = textBox.text;
        }
        else
        {
            bestScore.text = best.ToString("F2");
        }

    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }

    IEnumerator Post(string url, string bodyJsonString)
    {
        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();
        Debug.Log("Status Code: " + request.responseCode);
    }
}
