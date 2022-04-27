/**** 
 * Created by: Akram Taghavi-Burris
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
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    [Header("General Settings")]
    public int numberOfBalls = 3; //ball lives
    public int score = 0;//intial score 
    public Text ballTxt;
    public Text scoreTxt;

    [Header("Ball Settings")]
    public Vector3 intialForce; //intial force to move the ball
    public float speed = 20; //constant speed
    public GameObject paddle; //reference to paddle
    private bool isInPlay = false; //is the ball in play 
    private Rigidbody rb; //refecen to RigidBody
    private AudioSource audioSource; //get the audio source

 


    //Awake is called when the game loads (before Start).  Awake only once during the lifetime of the script instance.
    void Awake()
    {
        rb = GetComponent<Rigidbody>(); //get the rigidbody
        audioSource = GetComponent<AudioSource>(); //get the audio source
    }//end Awake()

        // Start is called before the first frame update
        void Start()
    {
        SetStartingPos(); //set the starting position

    }//end Start()

    // Update is called once per frame
    void Update()
    {
        ballTxt.text = "Balls " + numberOfBalls; //update the balls text
        scoreTxt.text = "Score " + score; //update the score text

        //if the ball is not in play
        if (!isInPlay)
        {
            //Move the ball with the paddle until ball is set into play

            Vector3 pos = new Vector3();
            pos = transform.position; //get the ball's position
            pos.x = paddle.transform.position.x; //set x to the positon of the paddle
            transform.position = pos;//reset balls position

        }//end if (!isInPlay)

        //if we press space and we are not in play
        if (Input.GetKeyUp(KeyCode.Space) && !isInPlay)
        {
            isInPlay = true; //the ball is in play
            Move();//move the ball
        }//end if (Input.GetKeyUp(KeyCode.Space) && !isInPlay)

    }//end Update()

    private void LateUpdate()
    {
        //if the ball is in play 
        if (isInPlay)
        {
            rb.velocity = speed * (rb.velocity.normalized); //normalize the velocity by a constant speed
        }//end if (isInPlay)

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

    private void Move()
    {
        rb.AddForce(intialForce); //move up times the force
    }//end Move()

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.Play(); //play audio source

        Debug.Log("hit");

        GameObject otherGO = collision.gameObject; //get the other game object

        //if we hit a brick
        if(otherGO.tag == "Brick")
        {
            score += 100; //add to score
            Destroy(otherGO); //destory other object

        }//end if(otherGO.tag == "Brick")

    }//end OnCollisionEnter()

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "OutBounds")
        {
            Debug.Log("Lost Ball");
            numberOfBalls--; //number of balls (lives)

            //if we have run out of lives
            if(numberOfBalls > 0)
            {
                Invoke("SetStartingPos", 2); //restart the level
            }

        }//end if(numberOfBalls > 0)
    }//end OnTriggerEnter()

}
