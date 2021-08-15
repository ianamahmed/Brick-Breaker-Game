using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
//    Touch touch;  
   //    KeyCode.A
    
    public KeyCode moveLeft;
    public KeyCode moveRight;
    
    public float speed ;
    public float boundX ;
    private Rigidbody2D paddle;

    void Start () {
        paddle = GetComponent<Rigidbody2D>();
    }

/*for window*/
       void Update () {
        var vel = paddle.velocity;

        if (Input.GetKey(moveRight)) {
            vel.x = speed;
        }
        else if (Input.GetKey(moveLeft)) {
            vel.x = -speed;
        }
        else {
            vel.x = 0;
        }
        paddle.velocity = vel;
      // condition for paddle to do not move out of the screen 
        var pos = transform.position;
        if (pos.x > boundX) {
            pos.x = boundX;
        }
        else if (pos.x < -boundX) {
            pos.x = -boundX;
        }
        transform.position = pos;
    } 

    /* For android  */  
    //  void Update () {

    //     var vel = paddle.velocity;
    //     /*for touch*/
    //      for(var i=0;i<Input.touchCount;i++){
    //         touch = Input.GetTouch(i);
    //     }

    //     if (touch.position.x>(Screen.width/2)) {
    //         vel.x = speed;
    //     }
    //     else if (touch.position.x<(Screen.width/2)) {
    //         vel.x = -speed;
    //     }
        
    //     // vel.x = 0;
        
    //     paddle.velocity = vel;

    //     var pos = transform.position;
    //     if (pos.x > boundX) {
    //         pos.x = boundX;
    //     }
    //     else if (pos.x < -boundX) {
    //         pos.x = -boundX;
    //     }
    //     transform.position = pos;
    // }  

}
