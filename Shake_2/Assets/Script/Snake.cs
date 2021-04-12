// NULLcode Studio © 2015
// null-code.ru

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour {

	public KeyCode left = KeyCode.A;
	public KeyCode right = KeyCode.D;
	public KeyCode up = KeyCode.W;
	public KeyCode down = KeyCode.S;

	public int size = 32;
	public float shift = 1;
	public float timeoutMove = 0.5f;
	public float timeoutBonus = 5;
	public GameObject _tail;
	public GameObject _bonus;
	private float curTimeout;
	private Vector3[,] pos;
	private List<GameObject> tail;
	private Vector3 tail_pos;
	private Vector3 tail_last;
	private int t_Count;
	private float h, v;

	public UnityEngine.UI.Text Text;
	public UnityEngine.UI.Text TextLevel;
	public static int scoreValue = 0;
	public static int levelValue = 1;
	public GameObject Wall;
	public GameObject RandomWall;
	public static int tailCount;
	public static bool lose;
	
	
	public static bool b_up = false;
	public static bool b_down = false;
	public static bool b_right = false;
	public static bool b_left = false;
	
	public static bool restart = true;

	void Start () 
	{
		Wall.SetActive(false);
		lose = false;
		tailCount = 1;
		t_Count = tailCount;
		tail = new List<GameObject>();
		tail.Add(this.gameObject);
		float posX = -shift*size/2-shift;
		float posY = Mathf.Abs(posX);
		float Xreset = posX;
		pos = new Vector3[size, size];
		for(int y = 0; y < size; y++)
		{
			posY -= shift;
			for(int x = 0; x < size; x++)
			{
				posX += shift;
				pos[x,y] = new Vector3(posX, posY, 0);
			}
			posX = Xreset;
		}

		tail[0].transform.position = pos[size/2, size/2];
		StartCoroutine (AddBonus());
	}

	IEnumerator AddBonus()
	{
		GameObject clone = Instantiate(_bonus) as GameObject;
		clone.transform.position = pos[Random.Range(0, size), Random.Range(0, size)];
		yield return new WaitForSeconds (timeoutBonus);
		if(!lose) StartCoroutine (AddBonus());
	}

	void Move(int count)
	{
		tail_last = tail[tail.Count-1].transform.position;

		tail_pos = tail[0].transform.position;
		tail[0].transform.position = new Vector3(tail_pos.x + h, tail_pos.y + v, 0);

		Vector3 tmp = Vector3.zero;

		for(int j = 1; j < count; j++)
		{
			tmp = tail[j].transform.position;
			tail[j].transform.position = tail_pos;
			tail_pos = tmp;
		}
	}

	IEnumerator AddWalls()
	{
		GameObject clone = Instantiate(RandomWall) as GameObject;
		clone.transform.position = pos[Random.Range(0, size), Random.Range(0, size)];
		yield return new WaitForSeconds(timeoutBonus);
		if (!lose) StartCoroutine(AddWalls());
	}

	void Update () 
	{
		//if (restart == true)
		//{
			
			if (scoreValue == 10)
			{
				//levelValue = 5;
				Wall.SetActive(false);
				levelValue += 1;
				TextLevel.text = levelValue.ToString();
				scoreValue = 0;
				Text.text = scoreValue.ToString();
				timeoutMove = 0.05f;
				if (levelValue == 2)
				{
					Wall.SetActive(true);
					//timeoutMove = 0.02f;
					timeoutMove = 0.05f;
				}
				if (levelValue == 3)
				{
					Wall.SetActive(false);
					//timeoutMove = 0.05f;
					timeoutMove = 0.02f;
				}
				if (levelValue == 4)
				{
					Wall.SetActive(true);
					timeoutMove = 0.02f;
				}
				if (levelValue == 5)
				{
					Wall.SetActive(false);
					StartCoroutine(AddWalls());
					timeoutMove = 0.02f;
				}
				if (levelValue == 6)
				{
					SceneManager.LoadScene(3);
					levelValue = 1;
				}
				
			}

			curTimeout += Time.deltaTime;
			if (curTimeout > timeoutMove) 
			{
				curTimeout = 0;
				Move(tailCount);
			}

			if(t_Count != tailCount)
			{
				scoreValue += 1;
				Text.text = scoreValue.ToString();
				GameObject clone = Instantiate(_tail) as GameObject;
				clone.name = "Tail_" + tail.Count;
				clone.transform.position = tail_last;
				tail.Add(clone);
			}
			t_Count = tailCount;

			if(b_left == true)
			{
				h = -shift;
				v = 0;
				b_left = !b_left;
			}
			else if(b_right == true) 
			{
				h = shift;
				v = 0;
				b_right = !b_right;
			}
			else if(b_down == true) 
			{
				v = -shift;
				h = 0;
				b_down = !b_down;
			}
			else if(b_up == true) 
			{
				v = shift;
				h = 0;
				b_up = !b_up;
			}

			if(lose)
			{
				Debug.Log("Вы проиграли!");
				enabled = false;
			}
		//}
	}

	void OnCollisionEnter2D(Collision2D other) 
	{
		if(other.collider.tag == "Player")
		{
			lose = true;
			//restart = false;
			SceneManager.LoadScene(2);
			levelValue = 1;
		}
	}
}
