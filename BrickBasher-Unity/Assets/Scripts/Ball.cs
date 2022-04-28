/**** 
 * Created by: Tyrese Peoples
 * Date Created: April 20, 2022
 * 
 * Last Edited by: 
 * Last Edited:
 * 
 * Description: Controls the ball and sets up the intial game behaviors. 
****/

/*** Using Namespaces ***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{
    [Header("General Settings")]
    public string ballTxt; //number of balls
    public int scoreTxt; //player score
    public int score; //actual score


    [Header("Ball Settings")]
    public float speed = 10f;
    Vector3 initForce = new Vector3 (0, 10);
    public int numBalls;
    public bool isInPlay;
    GameObject paddle;
    Rigidbody rb; //reference to ball rigid body
    AudioSource audioSource; //declaring audio source

   


 


    //Awake is called when the game loads (before Start).  Awake only once during the lifetime of the script instance.
    void Awake()
    {
        rb = GetComponent<Rigidbody>(); //get rigidbody of the projectile
        audioSource = GameObject.FindObjectOfType<AudioSource>();


    }//end Awake()


        // Start is called before the first frame update
        void Start()
    {
        SetStartingPos(); //set the starting position

    }//end Start()


    // Update is called once per frame
    void Update()
    {
        //if ball is in play move ball with paddle
        if(isInPlay == false)
        {
            Vector3 pos = new Vector3();
            pos.x = paddle.transform.position.x; //x position of paddel
            pos.y = paddle.transform.position.y + paddle.transform.localScale.y; //Y position of paddle plus it's height

            transform.position = pos;
        }

        //if space key is pressed 
        if (Input.GetButtonDown("Space") && isInPlay == false){
            isInPlay = false;
            Move();
        }

    }//end Update()


    private void LateUpdate()
    {

        if(isInPlay == true)
        {
            var moveDir = Vector3.Cross(rb.angularVelocity, Vector3.up).normalized;
            rb.AddForce(moveDir * speed);
        }

    }//end LateUpdate()


    void SetStartingPos()
    {
        isInPlay = false;//ball is not in play
        rb.velocity = Vector3.zero;//set velocity to keep ball stationary

        Vector3 pos = new Vector3();
        pos.x = paddle.transform.position.x; //x position of paddel
        pos.y = paddle.transform.position.y + paddle.transform.localScale.y; //Y position of paddle plus it's height

        transform.position = pos;//set starting position of the ball 
    }//end SetStartingPos()


    public void Move()
    {
        //add initial movement to ball
        rb.AddForce(initForce);
    }// end Move()

    private void OnTriggerEnter(Collider other)
    { 
    
        if(other.tag == "OutBounds")
        {
            numBalls = numBalls - 1;
        }

        if(numBalls > 0)
        {
            Invoke("SetStartingPos", 2);
        }

    } //end OnRiggerEnter()

    void onCollisionEnter(Collision collision)
    {
        audioSource.Play(); //play audio bouce effect on collision

        if(collision.gameObject.tag == "Brick")
        {
            score = score + 100;
            Destroy(collision.gameObject);
        }
    } // end OnCollisionEnter()





    }
