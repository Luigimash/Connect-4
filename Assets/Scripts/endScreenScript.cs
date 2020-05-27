using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class endScreenScript : MonoBehaviour
{
	public Button restartGame, quitGame;
	public Image background;
	public GameObject winner;

    // Start is called before the first frame update
    void Start()
    {
        restartGame.onClick.AddListener(Redo);
		quitGame.onClick.AddListener(endGame);
		Sprite redWin = Resources.Load<Sprite>("redWin");
		Sprite yellowWin = Resources.Load<Sprite>("yellowWin");
		Sprite noWin = Resources.Load<Sprite>("nobodyWon");
		
		int won = winner.GetComponent<startGame>().winner;
		
		if (won == 1)
		{
			background.GetComponent<Image>().sprite = redWin;
		}
		else if (won==2)
		{
			background.GetComponent<Image>().sprite = yellowWin;
		}
		else if (won==0)
		{
			background.GetComponent<Image>().sprite = noWin;
		}
    }
	
    
	void Redo()
	{
		SceneManager.LoadScene(1);
	}
	
	void endGame()
	{
		Application.Quit();
		Debug.Log("quit");
	}
}
