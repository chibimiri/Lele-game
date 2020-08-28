using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float respawnDelay;
    public PlayerController gamePlayer;
    public Text numPlantitaText;
    public Text numVidasText;
    public int plantitas;
    public Invulnerable gameInvulnerable;
    public static int hearts;
    public bool dead;
    public bool poderConejo=false;
    public GameObject panelConejo;
    public bool poderColibri=false;
    public GameObject panelColibri;
    public bool bossDead1 =false;
    public GameObject plantaBoss;

    void Start()
    {
        hearts = 3;
        gamePlayer = FindObjectOfType <PlayerController>();
        gameInvulnerable = FindObjectOfType<Invulnerable>();
        numPlantitaText.text = "Plantitas: " + plantitas;
        numVidasText.text = "Vidas: " + hearts;
    }

    // Update is called once per frame
    void Update()
    {
        //gameovertxt.gameObject.SetActive(true);
        //Time.timeScale = 0;
        
    }

    public void Respawn()
    {
        StartCoroutine("RespawnCoroutine");
    }

    public IEnumerator RespawnCoroutine()
    {
        gamePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        gamePlayer.transform.position = gamePlayer.respawnPoint;
        gamePlayer.gameObject.SetActive(true);
        dead=false;
        numVidasText.text = "Vidas: " + hearts;
    }

    public void AddPlantitas(int numberOfPlantitas)
    {
        plantitas += numberOfPlantitas;
        if (plantitas==3){
            poderConejo=true;
            panelConejo.gameObject.SetActive(true);
        }
        if (hearts<3){
            hearts+=1;
            numVidasText.text = "Vidas: " + hearts; 
        }
        if (plantitas==6){
            Debug.Log("Poder colibri unlock!!");
            poderColibri=true;
            poderConejo=false;
            panelColibri.gameObject.SetActive(true);
        }
        numPlantitaText.text = "Plantitas: " + plantitas;
    }
    public void BossDefeat()
    {
        bossDead1=true;
        plantaBoss.gameObject.SetActive(true);
    }
    public void QuitarPanel()
    {
        panelConejo.gameObject.SetActive(false);
        panelColibri.gameObject.SetActive(false);
    }

    public void restarVida(int damage)
    {
        if (!dead)
        {
            hearts-=damage;
            numVidasText.text = "Vidas: " + hearts;
            Debug.Log(hearts);
            if (hearts<=0){
                hearts=3;
                dead=true;
                Respawn();
            }else{
                gameInvulnerable.StartCoroutine("GetInvulnerable");
            }
        }
    }
   
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver"); 
    }
}
