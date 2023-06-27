using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject banana;
    public float dir;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(dropBanana());
        
    }

    // Update is called once per frame
    void Update()
    {
        HoleMovement();
    }
    
    void HoleMovement()
    {
        Vector3 temp = transform.position;
        temp.y -= speed * Time.deltaTime;
        transform.position = temp;
    }
    
    IEnumerator dropBanana(){
        var ran = Random.Range(15, 23);
        yield return new WaitForSeconds(ran);
        if(dir>0){
            banana.transform.localPosition -= new Vector3(1,0,0);
            banana.transform.localScale=new Vector3(-1,1,1);
        }else{
            banana.transform.localPosition += new Vector3(1,0,0);
            banana.transform.localScale= new Vector3(1,1,1);
        }
        banana.SetActive(true);
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }
}
