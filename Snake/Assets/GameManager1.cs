using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager1 : MonoBehaviour {

    public GameObject fruit, snake,tail;
    public int[] poz_y = new int[135];
    public Text text;
    public int[] poz_x = new int[135];
    public int l = 0;
    public GameObject[] coada = new GameObject[135];
    int i;

    //At the start of the game a fruit is placed
    void Start () {
        Place_fruit();
    }

    //Method to place fruit
    public void Place_fruit()
    {
        fruit.GetComponent<Placement>().Place_new(l,poz_x,poz_y);
    }

    //Draw the tail of the snake from 2 arrays representing the coordinates of the tail
   public void Draw_tail()
    {
       
        for (i = l;i>0;i--)
        {
            poz_x[i] = poz_x[i-1];
            poz_y[i] = poz_y[i-1];
        }

        poz_x[0] = (int)snake.transform.position.x;
        poz_y[0] = (int)snake.transform.position.y;

        for (i = 0; i < l; i++)
        {
            Vector3 p = new Vector3(poz_x[i+1], poz_y[i+1], -1);
            coada[i].transform.position = p;
        }

        Check_death();    

    }

    //When a fruit is eaten the tail grows until it has 134 length, then the game is won
   public void Tailplus()
    {
       
        Vector3 p = new Vector3(0, 0, 0);
        coada[l] = Instantiate(tail, p, Quaternion.identity);
        l += 1;
        if (l == 134)
        { text.text = "CONGRATULATIONS, YOU WON!";
            snake.GetComponent<movement>().Destroy();
            Invoke("nothing", 10);
            
        }
            

    }

    //If the head if the snake is outside the bounds of play or inside his tail then the snake is dead and the game lost
    void Check_death()
    {
        Vector3 cap = snake.transform.position;
        for(int i=0;i<l;i++)
        {
            if (cap == coada[i].transform.position)
            {
                text.text = "YOU LOST";
                snake.GetComponent<movement>().Destroy();
                Invoke("Restart", 3);
               
                
            }
        }
        if (cap.x > 5 || cap.x < -5 || cap.y > 6 || cap.y < -6)
        {
            text.text = "YOU LOST";
            snake.GetComponent<movement>().Destroy();
            Invoke("Restart", 3);
            
            
        }

    }

    //Restart the game when the snake dies
    void Restart()
    {
        SceneManager.LoadScene("Snake");
        
    }

   
}
