using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butt : MonoBehaviour
{
    public GameObject panel_start;
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Button_leftPressed()
    {
        Snake.b_left = true;
		//Snake.restart = true;
		panel_start.SetActive(false);
    }
    public void Button_rightPressed()
    {
        Snake.b_right = true;
		//Snake.restart = true;
		panel_start.SetActive(false);
    }
    public void Button_upPressed()
    {
        Snake.b_up = true;
		//Snake.restart = true;
		panel_start.SetActive(false);
    }
    public void Button_downPressed()
    {
        Snake.b_down = true;
		//Snake.restart = true;
		panel_start.SetActive(false);
    }
}
