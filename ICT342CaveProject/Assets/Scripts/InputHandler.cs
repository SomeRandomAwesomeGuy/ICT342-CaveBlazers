using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour {

	public float RotationSpeed = 1;
	public ArrayCompiler arrayCompiler;
	Material Display;
	Renderer rend;
	

	int ArrayPoint = 0;
	// Use this for initialization
	void Start () {
		Display = arrayCompiler.GetListPoint(ArrayPoint);

		rend = GetComponent<Renderer>();
		rend.enabled = true;
		Display = arrayCompiler.GetListPoint(0);
		rend.sharedMaterial = Display;

		
		//IMGComponent.sprite = Display;
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
			Display = arrayCompiler.GetListPoint(ArrayPoint++);
			rend.sharedMaterial = Display;

		}
		else if (Input.GetAxisRaw("Vertical") < 0)
		{
			Display = arrayCompiler.GetListPoint(ArrayPoint--);
			rend.sharedMaterial = Display;
		}

		if (Input.GetAxisRaw("Exit") > 0)
        {
			Application.Quit();
        }
	}
}
