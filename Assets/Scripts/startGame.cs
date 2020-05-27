using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class startGame : MonoBehaviour
{

	public int[,] gameBoard = new int[7,6];
	public int move = 1 ;//odd is red, even is blue
	public GameObject redButton;
	public GameObject yellowButton;
	public GameObject endScreen;
	float piecePosx, piecePosy;
	string test;
	bool win = false, tie=false;
	public int winner = 0;
    // Start is called before the first frame update
	
    void Awake()
    {
		endScreen.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null && !win && !tie) 
		{ //raycast; object must have a 2D Box Collider with Is Trigger checked.
			test = (hit.collider.gameObject.name);
			if (Input.GetMouseButtonDown(0))
			{
				test = test.TrimStart('b','o','a','r','d','S','e','c');
				int num = int.Parse(test);

				for (int i=0; i<6; i++)
				{
					if (gameBoard[num,i] == 0)
					{
						piecePosx = (float)((transform.position.x - (3*90)) + (num*90));
						piecePosy = (float)((transform.position.y + (0.5 * 80) - (3*80)) + (i*80));
						Vector3 piecePos = new Vector3(piecePosx, piecePosy, 0f);
						gameBoard[num,i] = move;
						if (move%2 == 1)
						{
							GameObject redClone = Instantiate (redButton, piecePos, transform.rotation) as GameObject;
							redClone.transform.localScale = new Vector3(105f,105f,0f);
						}
						else 
						{
							GameObject yellowClone = Instantiate (yellowButton, piecePos, transform.rotation) as GameObject;
							yellowClone.transform.localScale = new Vector3 (105f, 105f, 0f);
						}
						
						//check if board is winning
						int winCount=0;
							for (int m=0; m < 4; m++)
							{ //check for win to right 
								if ((gameBoard[num+m, i] % 2) == (move % 2) && (gameBoard[num+m, i]) !=0)
								{
									winCount++;
								}
								else 
								{
									break;
								}							
								if (num+m == 6)
								{
									break;
								}
							}
							if (winCount == 4)
							{
								Debug.Log("Win from Right-Left");
								win = true;
							}
							else if (num-1 != -1)
							{
								for (int m=1; m < 5; m++)
								{ //go left 
									if ((gameBoard[num-m, i] % 2 == (move % 2)) && (winCount != 4)&&(gameBoard[num-m, i] !=0))
									{
										winCount++;
									}
									else 
									{
										break;
									}	
									if (winCount == 4)
									{
										Debug.Log("Win from Left - Right");
										win = true;
									}
									if (num-m == 0)
									{
										break;
									}
								}
							}
									
							
						winCount=0;
							for (int m=i; m > i-4; m--)
							{ //downwards c4
								if ((gameBoard[num,m] % 2) == (move % 2)&&(gameBoard[num,m]) != 0)
								{
									winCount++;
								}
								else
								{
									break;
								}
								if (winCount==4)
								{
									Debug.Log("Win from Down");
									win = true;
									break;
								}	
								if (m==0)
								{
									break;
								}
							}
						
						winCount=0;
							for (int m=0; m < 4; m++)
							{ //wincon for downwards right
								if ((gameBoard[num+m,i-m] % 2) == (move % 2) && (gameBoard[num+m,i-m])!=0)
								{
									winCount++;
								}
								else
								{
									break;
								}
								if (num+m==6 || i-m==0)
								{
									break;
								}
							}
							if (winCount == 4)
							{
								win = true;
								Debug.Log("Win from DR / UL");
							}
							else if (num-1 != -1 && i+1 !=6)
							{ //upwards left 
								for (int m=1; m < 5; m++)
								{
									if ((gameBoard[num-m,i+m] % 2) == (move % 2)&&(gameBoard[num-m,i+m] ) !=0)
									{
										winCount++;
									}
									else
									{
										break;
									}
									if (winCount == 4)
									{
										Debug.Log("Win from DR / UL");
										win=true;
									}
									if (num-m == 0 || i+m == 5)
									{
										break;
									}
								}
							}
							
						winCount=0;
							for (int m=0; m < 4; m++)
							{ //wincon for upwards right
								if ((gameBoard[num+m,i+m] % 2) == (move % 2)&&(gameBoard[num+m,i+m]) != 0)
								{ //check upwards right 
									winCount++;
								}
								else
								{
									break;
								}
								if (num+m==6 || i+m==5)
								{
									break;
								}
							}
							if (winCount == 4)
							{
								win = true;
								Debug.Log("Win from DL / UR");
							}
							else if (num-1 != - 1 && i-1 != -1)
							{
								for (int m=1; m < 5; m++)
								{//check downwards left
									if ((gameBoard[num-m,i-m] % 2) == (move % 2)&&(gameBoard[num-m,i-m]) !=0)
									{
										winCount++;
									}
									else
									{
										break;
									}
									if (winCount == 4)
									{
										Debug.Log("Win from DL/UR");
										win=true;
									}
									if (num-m == 0 || i-m == 0)
									{
										break;
									}
						
								}
							}
							if (i == 5)
							{
								for (int m=0; m < 7; m++)
								{
									if (gameBoard[m,5] != 0)
									{
										tie=true;
									}
									else 
									{
										tie=false;
										break;
									}
								}
							}
							
						if (win && !tie)
						{ //if game is over execute code 
							Debug.Log("winner winner chicken digger");
							if (move%2 == 1)
							{
								endScreen.SetActive(true);
								Debug.Log("red is win!");
								winner = 1;
							}
							else
							{
								endScreen.SetActive(true);
								Debug.Log("yellow is win!");
								winner = 2;
							}
							
						}
						else if (tie)
						{
							endScreen.SetActive(true);
							Debug.Log("Game has tied. Nobody won");
							winner = 0;
						}
						break;
					}
				}
				move++;
				
			}
			Vector2 board = new Vector2 (hit.collider.gameObject.transform.position.x,hit.collider.gameObject.transform.position.y);
			if (move % 2 == 1)
			{
				redButton.transform.position = new Vector2(board.x, board.y + 250);
				yellowButton.transform.position = new Vector2(20, 20);
				
			}
			else
			{
				yellowButton.transform.position = new Vector2(board.x, board.y+250);
				redButton.transform.position = new Vector2(20, 20);				
			}
			
		} //Runs code if object is detected 
		else if (!win)
		{
			
			Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if (move % 2 == 1)
			{ //redwin
				redButton.transform.position = new Vector2(cursorPos.x, cursorPos.y);
				yellowButton.transform.position = new Vector2(20, 20);
			}
			else
			{ //yellowwin
				yellowButton.transform.position = new Vector2(cursorPos.x, cursorPos.y);
				redButton.transform.position = new Vector2(20, 20);
			}
		}
    }
}
