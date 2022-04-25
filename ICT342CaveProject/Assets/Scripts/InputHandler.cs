using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

	public float RotationSpeed = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//rotate the shape with "A" & "D"
		if (Input.GetAxisRaw("Horizontal") > 0)
        {
			transform.Rotate(0f, RotationSpeed, 0, Space.Self);
        }else if (Input.GetAxisRaw("Horizontal") < 0)
        {
			transform.Rotate(0f, RotationSpeed*-1, 0, Space.Self);
		}

		//switch image with "W" & "S"
		if (Input.GetAxisRaw("Vertical") > 0)
		{

		}
		else if (Input.GetAxisRaw("Vertical") < 0)
		{

		}

		if (Input.GetAxisRaw("Exit") > 0)
        {
			Application.Quit();
        }
	}
}
