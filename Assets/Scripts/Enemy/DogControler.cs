using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogControler : MonoBehaviour
{
    [SerializeField]
    private float speed;
    public float downspeed;
    public int dir;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HoleMovement();
    }

    void HoleMovement()
    {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime* dir;
        temp.y -= downspeed * Time.deltaTime;
        transform.position = temp;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }
}
