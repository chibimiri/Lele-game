using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabezaBoss : MonoBehaviour
{
    public static int bossLife=3;
    public LevelManager gameLevelManager;
    // Start is called before the first frame update
    void Start()
    {
        gameLevelManager = FindObjectOfType<LevelManager>();
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
                bossLife-=1;
                if (bossLife<=0){
                    gameLevelManager.BossDefeat();
                    Destroy (transform.parent.gameObject); 
                }
               // AudioSource.PlayClipAtPoint(enemyAudio,transform.position);
			    other.GetComponent<Rigidbody2D>().velocity = new Vector2(other.GetComponent<Rigidbody2D>().velocity.x, other.GetComponent<PlayerController>().jumpspeed);
			    
		    }
	    }
    }
}
