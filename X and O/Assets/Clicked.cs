using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicked : MonoBehaviour {

    public int number = 0;

    //If a square is clicked call the "Click" method from GameManager
    private void OnMouseDown()
    {
        GameObject.Find("GameManager").SendMessage("Click",gameObject);
        Destroy(this);
    }
}
