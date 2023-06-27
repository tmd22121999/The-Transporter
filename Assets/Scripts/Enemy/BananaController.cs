using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Animator bananaAni;
    // Start is called before the first frame update
    void Start()
    {
        bananaAni = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(bananaAni.GetCurrentAnimatorStateInfo(0).normalizedTime >=1)
            HoleMovement();
    }
    
    void HoleMovement()
    {
        Vector3 temp = transform.localPosition;
        temp.y -= speed * Time.deltaTime;
        transform.localPosition = temp;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }
}
