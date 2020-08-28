using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantaScript : MonoBehaviour
{
    private LevelManager gameLevelManager;
	public int plantaValue;
	public AudioClip plantaAudio;
    //private Animator plantAnimation;
    // Start is called before the first frame update
    void Start()
    {
       gameLevelManager = FindObjectOfType<LevelManager>();
       // plantAnimation = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        AudioSource.PlayClipAtPoint(plantaAudio,transform.position);
		gameLevelManager.AddPlantitas(plantaValue);
        //gameObject.SetActive(false);
        Destroy (gameObject);
    }
}
