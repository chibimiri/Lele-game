using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantaScript : MonoBehaviour
{
    public int score = 0;
    //private Animator plantAnimation;
    // Start is called before the first frame update
    void Start()
    {
       // plantAnimation = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("activada");
        score+=5;
        Debug.Log("Score: " + score);
        //plantAnimation.SetBool("OnTriggered", true);
        Destroy (gameObject);
    }
}
