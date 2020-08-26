using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float movement = 0f;
    public float jumpspeed = 5.0f;
    private Rigidbody2D rb;

    public Transform GroundCheckPoint;
    public float GroundCheckRadius;
    public LayerMask GroundLayer;
    private bool isTouchingGround;
    
    //private Animator playerAnimation;

    public Vector3 respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
         //playerAnimation = GetComponent<Animator>(); 
         respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(GroundCheckPoint.position, GroundCheckRadius, GroundLayer);
        movement = Input.GetAxis("Horizontal");
        if (movement > 0f){
            rb.velocity = new Vector2 (movement*speed, rb.velocity.y);
            transform.localScale = new Vector2(1f, 1f);
        }
        else if(movement < 0f){
            rb.velocity = new Vector2 (movement*speed, rb.velocity.y);
            transform.localScale = new Vector2(-1f, 1f);
        }
        else {
            rb.velocity = new Vector2 (0, rb.velocity.y);
        }
        if (Input.GetButtonDown("Jump") && isTouchingGround ){
            rb.velocity = new Vector2 (rb.velocity.x, jumpspeed);
        }
        //playerAnimation.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        //playerAnimation.SetBool("OnGround", isTouchingGround);
    }

    void OnTriggerEnter2D(Collider2D other){
         if (other.tag == "FallDetector"){
            Debug.Log ("ups");
            transform.position = respawnPoint;
         }   
         if (other.tag == "Checkpoint"){
            respawnPoint = other.transform.position;
         }
    }
}
