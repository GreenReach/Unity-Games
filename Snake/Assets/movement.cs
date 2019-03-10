using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour {

    int direction = 0;
    public Transform head;
    public GameObject fruit;
    public Text points;
    public int score=0;
    public GameObject GameM;
    int l=1;

    //Snake moves at a pace of 1 square/ 0.5 seconds
    void Start () {
        InvokeRepeating("Move", 0, 0.5f);
	}
	
    //When a key is pressed it's value it's memorised
	void Update () {

        if (Input.GetKey("w"))
            direction = 0;

        if (Input.GetKey("s"))
            direction = 1;

        if (Input.GetKey("d"))
            direction = 2;

        if (Input.GetKey("a"))
            direction = 3;

        if (Input.GetKey("escape"))
            direction = -1;

    }

    //When the snake moves it check's which key has last been pressed and moves accordingly
     void Move()
    {
      
        switch (direction)
        {
            case 0:
                {
                    head.position += new Vector3(0, 1 , 0);
                    break;
                }

            case 1:
                {
                    head.position += new Vector3(0, -1, 0);
                    break;
                }

            case 2:
                {
                    head.position += new Vector3(1, 0, 0);
                    break;
                }

            case 3:
                {
                    head.position += new Vector3(-1, 0, 0);
                    break;
                }

            case -1:
                {
                   Application.Quit();
                    break;
                }
        }

        //If the snake head is on top of a fruit the fruit is replaced on another square and the score goes up
        if (head.position == fruit.transform.position)
        {
            l++;
            score += 10;
            points.text = "SCORE: " + score;

            GameM.GetComponent<GameManager1>().Place_fruit();
            GameM.GetComponent<GameManager1>().Tailplus();
            
        }

         GameM.GetComponent<GameManager1>().Draw_tail();
    }

    //Destroys the script when the games end
  public void Destroy()
    { Destroy(this); }

   
}
