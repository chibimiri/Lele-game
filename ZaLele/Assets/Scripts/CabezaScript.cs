using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabezaScript : MonoBehaviour
{
    
    // public AudioClip enemyAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
	    if(other.tag=="Player")
	    {
		    if (other.GetComponent<Rigidbody2D>().velocity.y < 0f)
		    {
                Debug.Log("speedY=: "+other.GetComponent<Rigidbody2D>().velocity.y);
                Destroy (transform.parent.gameObject); 
               // AudioSource.PlayClipAtPoint(enemyAudio,transform.position);
			    other.GetComponent<Rigidbody2D>().velocity = new Vector2(other.GetComponent<Rigidbody2D>().velocity.x, other.GetComponent<PlayerController>().jumpspeed);
			    
		    }
	    }
    }
}
