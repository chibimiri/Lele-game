using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public AudioSource enemyAudio;
    //private LevelManager gameLevelManager;
    // Start is called before the first frame update
    void Start()
    {
       // gameLevelManager = FindObjectOfType<LevelManager>();
       //enemyAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.tag=="Player"){
           // LevelManager.hearts -= 1;
           Debug.Log ("Score -1");
            enemyAudio.Play();
            //Destroy (transform.parent.gameObject);
            //gameLevelManager.Respawn();
        }
    }
}
