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
    public LevelManager gameLevelManager;
    private bool doubleJump;
    public bool conejo;
    public bool colibri;
    public AudioClip jumpAudio;
    public AudioClip doubleJumpAudio;
    public AudioClip flightAudio;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //playerAnimation = GetComponent<Animator>(); 
        respawnPoint = this.transform.position;
        gameLevelManager = FindObjectOfType<LevelManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        conejo = gameLevelManager.poderConejo;
        colibri = gameLevelManager.poderColibri;
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
        if (isTouchingGround&&conejo){
            doubleJump=true;
        }
        if (Input.GetButtonDown("Jump") ){
            if (isTouchingGround){
                AudioSource.PlayClipAtPoint(jumpAudio,transform.position);
                rb.velocity = new Vector2 (rb.velocity.x, jumpspeed); 
            }else {
                if(doubleJump){
                    AudioSource.PlayClipAtPoint(doubleJumpAudio,transform.position);
                    rb.velocity = new Vector2 (rb.velocity.x, jumpspeed); 
                    doubleJump=false;
                }else{
                    if(colibri){
                        AudioSource.PlayClipAtPoint(flightAudio,transform.position);
                        rb.velocity = new Vector2 (rb.velocity.x, jumpspeed); 
                     }
                }
            }
            
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy"){
            rb.AddForce(new Vector2(-50,50f));
            gameLevelManager.restarVida(1);
        }   
        if (col.gameObject.tag == "CheckPoint"){
            respawnPoint = col.gameObject.transform.position;
        }
    }   

}
