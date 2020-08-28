﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public AudioClip enemyAudio;
 
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.tag=="Player"){
            AudioSource.PlayClipAtPoint(enemyAudio,transform.position);
        }
    }
}
