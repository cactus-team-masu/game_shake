using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butt : MonoBehaviour
{
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
    }
    public void Button_rightPressed()
    {
        Snake.b_right = true;
    }
    public void Button_upPressed()
    {
        Snake.b_up = true;
    }
    public void Button_downPressed()
    {
        Snake.b_down = true;
    }
}
