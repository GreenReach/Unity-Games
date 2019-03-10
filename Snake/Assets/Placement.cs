using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour {

    public GameObject fruit;

    //Places the fruit in a new random square and checks to not place it inside the snake's tail
    public void Place_new(int l,int[] poz_x , int[] poz_y)
    {
        int i,ok;
        Vector3 poz;

        do
        {
            ok = 1;

            poz = new Vector3(Random.Range(-4, 4), Random.Range(-6, 6), -1);
            for (i = 0; i < l; i++)
                if (poz_x[i] == poz.x && poz_y[i] == poz.y)
                    ok = 0;
                
        } while (ok == 0);

        fruit.transform.position = poz;
    }
    

}
