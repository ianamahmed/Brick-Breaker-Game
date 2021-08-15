using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private BallControl theBall;
    public bool gameActive;

    public Text livesText;
    public int lives;
    
    public GameObject gameOverScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        theBall = FindObjectOfType<BallControl>();
        livesText.text="Lives : "+lives;
    }

    // Update is called once per frame
    void Update()
    {
        /*for windows*/
        if(Input.GetKeyDown(KeyCode.Space) && !gameActive){
            theBall.ActivateBall();
            gameActive=true;
        }
        /* for touch*/
        // if((Input.GetTouch(0).position.y > Screen.height/3) && !gameActive){
        //     theBall.ActivateBall();
        //     gameActive=true;
        // }
    }

    public void RespawnBall(){
        gameActive=false;
        lives--;
        
        livesText.text="Lives : "+lives;

        if(lives<=0){
            theBall.gameObject.SetActive(false);
            gameOverScreen.SetActive(true);
        }
    }
}
