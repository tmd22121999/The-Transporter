using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHeal : MonoBehaviour
{
    [SerializeField]
    private GameObject Heal;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    IEnumerator Spawn()
    {
        var ran = Random.Range(2, 7);
        yield return new WaitForSeconds(ran);
        Vector3 temp = transform.position;
        temp.x = Random.Range(-1.5f, 1.5f);
        Instantiate(Heal, temp, Quaternion.identity);
        StartCoroutine(Spawn());
    }
    // Start is called before the first frame update
   
}
