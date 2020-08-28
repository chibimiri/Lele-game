using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invulnerable : MonoBehaviour
{
    public Renderer rend;
    public Color c;
    //public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
       rend = GetComponent<Renderer>();
       //rend= gameObject.GetComponent<Renderer> ().material.color;
       // player = FindObjectOfType<PlayerController>();
       c = rend.material.color;
    }

    IEnumerator GetInvulnerable()
    {
        Physics2D.IgnoreLayerCollision(10,9, true);
        c.a = 0.5f;
        rend.material.color = c;
        yield return new WaitForSeconds(3f);
        Physics2D.IgnoreLayerCollision(10,9, false);
        c.a = 1F;
        rend.material.color = c;
    }
}
