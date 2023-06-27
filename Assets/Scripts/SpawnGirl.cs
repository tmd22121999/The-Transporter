using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGirl : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Heal;
    //private GameObject Hotel;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    IEnumerator Spawn()
    {
        var Delay = 3;
        yield return new WaitForSeconds(Delay);
        Vector3 temp = transform.position;
        //Random.Range(0, 2) == 0 ? -2 : 2;
        temp.x = (Random.Range(0, 2) * 2 - 1)*2.2f;
        int rand = Random.Range(0, 2) ;
        Instantiate(Heal[rand], temp, Quaternion.identity);
        StartCoroutine(Spawn());
    }
    // Start is called before the first frame update
}
