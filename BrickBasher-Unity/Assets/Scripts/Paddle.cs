/**** 
 * Created by: Akram Taghavi-Burris
 * Date Created: April 20, 2022
 * 
 * Last Edited by: 
 * Last Edited:
 * 
 * Description: Paddle controler on Horizontal Axis
****/

/*** Using Namespaces ***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 10; //speed of paddle


    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        //Change the transform based on the axis

        Vector3 pos = transform.position; //get the position

        pos.x += xAxis * speed * Time.deltaTime; //change x by speed
        transform.position = pos; //set new position
    }//end Update()
}
