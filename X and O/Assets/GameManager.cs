using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject X, O;
    int turn = 1,round=0,winner=0;
    int[] square = new int[9];
    public Text result;
    public Image panel;


    //Exit the application if the user presses "escape"
    private void Update()
    {
        if (Input.GetKeyDown("escape") == true)
                Application.Quit();

    }

    //Places the apropiate symbol on the square that has been cliked and checks if someone has won or if it is a draw
    public void Click(GameObject square1)
    {
        int square_number = square1.GetComponent<Clicked>().number;

        SpawnPrefab(square1.transform.position);
        square[square_number] = turn;
        Check_win();
        NextTurn();

        if (round == 9 && winner == 0)
         Win(); 
    }

    //Spawns the symbol on the square at the "positon" coordonates
    void SpawnPrefab(Vector3 position)
    {
        if(turn == 1)
        Instantiate(X, position, Quaternion.identity);
        else
        Instantiate(O, position, Quaternion.identity);
    }

    //Confiugres the turn variable such that if 1 then it is X's turn and if 2 then it is O's
    void NextTurn()
    {
        turn++;round++;
        if (turn == 3)
            turn = 1;
    }

    //Checks if someone won
    void Check_win()
    {
        if ((square[0] == 1 && square[1] == 1 && square[2] == 1) || (square[4] == 1 && square[5] == 1 && square[3] == 1))
         winner = 1; 

        if ((square[6] == 1 && square[7] == 1 && square[8] == 1) || (square[0] == 1 && square[4] == 1 && square[8] == 1))
         winner = 1; 

        if ((square[2] == 1 && square[4] == 1 && square[6] == 1) || (square[0] == 1 && square[3] == 1 && square[6] == 1))
        winner = 1;

        if ((square[1] == 1 && square[4] == 1 && square[7] == 1) || (square[2] == 1 && square[5] == 1 && square[8] == 1))
         winner = 1; 



        if ((square[0] == 2 && square[1] == 2 && square[2] == 2) || (square[4] == 2 && square[5] == 2 && square[3] == 2))
         winner = 2; 

        if ((square[6] == 2 && square[7] == 2 && square[8] == 2) || (square[0] == 2 && square[4] == 2 && square[8] == 2))
        winner = 2; 

        if ((square[2] == 2 && square[4] == 2 && square[6] == 2) || (square[0] == 2 && square[3] == 2 && square[6] == 2))
        winner = 2; 

        if ((square[1] == 2 && square[4] == 2 && square[7] == 2) || (square[2] == 2 && square[5] == 2 && square[8] == 2))
         winner = 2;

        if (winner != 0)
            Win();

    }

    //If the game has reached an end state then display an apropiate message and restart 
    void Win()
    {
        panel.enabled = true;

        if (winner == 0)
            result.text = "DRAW";

        if (winner == 1)
            result.text = "X WINS";

        if (winner == 2)
            result.text = "O WINS";

        Invoke("Restart", 3);
        
    }

    //Restarts the game
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
