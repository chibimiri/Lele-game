using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossScript : MonoBehaviour
{
    public AudioClip enemyAudio;
    public float movement = 0f;
    public float speed = 3.0f;
    private Rigidbody2D rb;
    public Transform leftPoint,rightPoint;
    private Vector3 localScale;
    private bool movingRight=true;
    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        leftPoint = leftPoint.GetComponent<Transform>();
        rightPoint = rightPoint.GetComponent<Transform>();
    }

    void Update()
    {
       if (transform.position.x > rightPoint.position.x)
        { movingRight=false;}
        if (transform.position.x < leftPoint.position.x)
        {movingRight=true;}
        if (movingRight)
          { moveRight();}
        else
            {moveLeft();}
    }
    void moveRight()
    {
        movingRight=true;
        localScale.x=4f;
        transform.localScale=localScale;
        rb.velocity = new Vector2(localScale.x * speed, rb.velocity.y);
    }
     void moveLeft()
    {
        movingRight=false;
        localScale.x=-4f;
        transform.localScale=localScale;
        rb.velocity = new Vector2(localScale.x * speed, rb.velocity.y);
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.tag=="Player"){
            AudioSource.PlayClipAtPoint(enemyAudio,transform.position);
        }
    }
}
