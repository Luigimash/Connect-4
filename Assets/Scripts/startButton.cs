using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//scene 0 is this, scene 1 is the game, scene 2 is the end game screen


public class startButton : MonoBehaviour
{
    // Start is called before the first frame update
	public Button playGame, quitGame;

	
    void Start()
    {
		//start.GetComponent<startGame>().enabled=false; usable code for future reference
		playGame.onClick.AddListener(initiateGame);
		quitGame.onClick.AddListener(endGame);
    }


	void initiateGame()
	{
		//start.GetComponent<startGame>().enabled=true; usable code 
		SceneManager.LoadScene(1);
		Debug.Log("sss");
	}
	
	void endGame()
	{ //quits the game if you clikc the "exit the game" button
		Application.Quit();
		Debug.Log("quit");
	}
}
