using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//rotate the shape with "A" & "D"
		if (Input.GetAxisRaw("Horizontal") > 0)
        {

        }else if (Input.GetAxisRaw("Horizontal") < 0)
        {

        }

		//switch image with "W" & "S"
		if (Input.GetAxisRaw("Vertical") > 0)
		{

		}
		else if (Input.GetAxisRaw("Vertical") < 0)
		{

		}
	}
}
