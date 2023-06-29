using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Animator animator;
    public float movementSpeed = 4;
    public Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().color=GameManagers.Instance.playerData.color;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        transform.position += movement * Time.deltaTime * (movementSpeed+GameManagers.Instance.playerData.speedLevel*0.5f);


        float horizontalMove = Input.GetAxisRaw("Horizontal") * (movementSpeed+GameManagers.Instance.playerData.speedLevel*0.5f);
        animator.SetFloat("Horizontal", horizontalMove);

       
    }
}
