using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerVertical : MonoBehaviour
{
    public GameObject player;
    public float offset;
    public Vector3 playerPosition;
    public float offsetSmoothing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
    }
}
