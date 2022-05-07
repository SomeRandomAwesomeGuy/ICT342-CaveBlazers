using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour {

	public float RotationSpeed = 1;
	public ArrayCompiler arrayCompiler;
	Texture Display;
	Renderer rend;
	bool BTNDown;

	int ArrayPoint = 0;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		rend.enabled = true;
		Display = arrayCompiler.GetListPoint(0);
		rend.material.SetTexture("_MainTex", Display);
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
		if (Input.GetAxisRaw("Vertical") > 0 && BTNDown == false)
		{
			Debug.Log("Searching for next image");
			Display = arrayCompiler.GetListPoint(ArrayPoint++);
			rend.material.SetTexture("_MainTex", Display);
			BTNDown = true;

		}
		else if (Input.GetAxisRaw("Vertical") < 0 && BTNDown == false)
		{
			Debug.Log("Searching for previous image");
			Display = arrayCompiler.GetListPoint(ArrayPoint--);
			rend.material.SetTexture("_MainTex", Display);
			BTNDown = true;
		}
		else if (Input.GetAxisRaw("Vertical") == 0 && BTNDown == true)
        {
			BTNDown = false;
		}

		if (Input.GetAxisRaw("Exit") > 0)
        {
			Application.Quit();
        }
	}
}
