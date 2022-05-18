using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour {

	public float RotationSpeed = 1;
	public ArrayCompiler arrayCompiler;
	Texture Display;
	Renderer rend;
    var vid;
	bool BTNDown;

	int ArrayPoint = 0;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		rend.enabled = true;
		Display = arrayCompiler.GetListPoint(0);
		rend.material.SetTexture("_MainTex", Display);
        vid = GetComponent<UnityEngine.Video.VideoPlayer>();
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
            if (typecheck() == "Video")
            {
                vid.videoplayer = arrayCompiler.Getvideolist(ArrayPoint++);
                vid.isLooping = true;
                rend.material.SetTexture("_MainTex", null);
            }
            else if (typecheck() == "Image")
            {
                Display = arrayCompiler.GetListPoint(ArrayPoint++);
                rend.material.SetTexture("_MainTex", Display);                
                vid.VideoPlayer = null;
            }
                
            Debug.Log("Searching for next image");
			BTNDown = true;

		}
		else if (Input.GetAxisRaw("Vertical") < 0 && BTNDown == false)
		{
            if (typecheck() == "Video")
            {
                vid.videoplayer = arrayCompiler.Getvideolist(ArrayPoint--);
                vid.isLooping = true;
                rend.material.SetTexture("_MainTex", null);
            }
            else if (typecheck() == "Image")
            {
                Display = arrayCompiler.GetListPoint(ArrayPoint--);
                rend.material.SetTexture("_MainTex", Display);
                vid.VideoPlayer = null;
            }

            Debug.Log("Searching for previous image");
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

    public string typecheck()
    {
        string variabletype = "";
        int arraypointholder = ArrayPoint;
        while (arraypointholder < 0)
        {
            arraypointholder += arrayCompiler.totallength;

            if (arraypointholder >= arrayCompiler.ListLength && arraypointholder < arrayCompiler.totallength)
            {
                arraypointholder -= arrayCompiler.ListLength;
                variabletype = "Video";
            }
        }

        while (arraypointholder > (arrayCompiler.totallength - 1))
        {
            if (arraypointholder > arrayCompiler.totallength)
            {
                arraypointholder -= arrayCompiler.totallength;
            }

            else if (arraypointholder < arrayCompiler.ListLength)
            {
                variabletype = "Image";
            }

            else if (arraypointholder >= arrayCompiler.ListLength && arraypointholder < arrayCompiler.totallength)
            {
                arraypointholder -= arrayCompiler.ListLength;
                variabletype = "Video";
            }
        }
        return variabletype;
    }
}