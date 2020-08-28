using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformaScript : MonoBehaviour
{
    public float movement = 0f;
    public float speed = 2.0f;
    private Rigidbody2D rb;
    public Transform leftPoint,rightPoint;
    private bool movingRight=true;
    private Vector3 localScale;
    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        leftPoint = leftPoint.GetComponent<Transform>();
        rightPoint = rightPoint.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > rightPoint.position.x)
        { movingRight=false; }
        if (transform.position.x < leftPoint.position.x)
        { movingRight=true; }
        if (movingRight)
          { moveRight();}
        else
          { moveLeft();}
    }
    void moveRight()
    {
        movingRight=true;
       transform.localScale=localScale;
        rb.velocity = new Vector2(localScale.x * speed, rb.velocity.y);
    }
     void moveLeft()
    {
        movingRight=false;
       transform.localScale=localScale;
        rb.velocity = new Vector2(localScale.x * -speed, rb.velocity.y);
    }
}
