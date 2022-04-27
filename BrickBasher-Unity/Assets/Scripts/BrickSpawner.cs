/**** 
 * Created by: Akram Taghavi-Burris
 * Date Created: April 20, 2022
 * 
 * Last Edited by: 
 * Last Edited:
 * 
 * Description: Spawns bircks
****/

/*** Using Namespaces ***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
   
    public GameObject brickPrefab; //brick prefab
    public float paddingBetweenBricks = 0.25f; //space between bricks
    private Vector2 brickPadding = new Vector2(0,0); //the brick padding x and y 


    // Start is called before the first frame update
    void Start()
    {

       //brick padding is the width/height of the brick plust the padding between
       brickPadding.x = brickPrefab.transform.localScale.x + paddingBetweenBricks;
       brickPadding.y = brickPrefab.transform.localScale.y + paddingBetweenBricks;


        for (int y=0; y < 7; y++)
        {
            for(int x=0; x < 7; x++)
            {
                Vector3 pos = new Vector3(x * brickPadding.x , y * brickPadding.y, 0); //set new position multipled by the padding

                GameObject brickGo = Instantiate<GameObject>(brickPrefab); //instancate the brick
                brickGo.transform.parent = transform; //set the parent transform to this (brick spwaner) transform
                brickGo.transform.localPosition = pos; //set the local position of the brick 

            }//end for(int x=0; x < 9; x++)
        }//end for (int y=0; y < 9; y++)
    }

}
