using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public float maxHorizonalSpeed;
    public float vertSpeed;

    private Rigidbody2D theBall;

    public bool ballActive;
    public Transform startPoint;

    private GameManager theGM;

    //use this for initialization
    void Start(){
        theBall = GetComponent<Rigidbody2D>();

        theGM = FindObjectOfType<GameManager>();
        // theBall.velocity=new Vector2(vertSpeed,vertSpeed);
    }

    //update is called once per frame
    void Update(){
        if(!ballActive){
            theBall.velocity=Vector2.zero;
            transform.position=startPoint.position;
        }

        if(theBall.velocity.x>maxHorizonalSpeed){
            theBall.velocity=new Vector2(maxHorizonalSpeed,theBall.velocity.y);

        }else if(theBall.velocity.x<-maxHorizonalSpeed){
            theBall.velocity=new Vector2(-maxHorizonalSpeed,theBall.velocity.y);
        }


        print(theBall.velocity);
    }

    void OnCollisionExit2D(Collision2D other){
        if(other.gameObject.tag=="Brick"){
            Destroy(other.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag=="Respawn"){
            ballActive=false;
            theGM.RespawnBall();
        }
    }

    public void ActivateBall(){
        ballActive=true;
        theBall.velocity=new Vector2(vertSpeed,vertSpeed);
    }

}
