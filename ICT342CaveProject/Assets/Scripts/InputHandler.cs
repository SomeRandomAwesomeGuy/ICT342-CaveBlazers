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
            var vid = GetComponent<UnityEngine.Video.VideoPlayer>();
            //determine what type of media to show, image or video
            if (TypeCheck() == "Video")
            {
                //set video and remove image
                vid.url = arrayCompiler.Getvideolist(ArrayPoint++);
                vid.isLooping = true;
                rend.material.SetTexture("_MainTex", null);
            }
            else if (TypeCheck() == "Image")
            {
                //set image and remove video
                Display = arrayCompiler.GetListPoint(ArrayPoint++);
                rend.material.SetTexture("_MainTex", Display);                
                vid.url = null;
            }
                
            //stop code from repeating
			BTNDown = true;

		}
		else if (Input.GetAxisRaw("Vertical") < 0 && BTNDown == false)
		{
            var vid = GetComponent<UnityEngine.Video.VideoPlayer>();
            //determine what type of media to show, image or video
            if (TypeCheck() == "Video")
            {
                // set video and remove image
                vid.url = arrayCompiler.Getvideolist(ArrayPoint--);
                vid.isLooping = true;
                rend.material.SetTexture("_MainTex", null);
            }
            else if (TypeCheck() == "Image")
            {
                //set image and remove video
                Display = arrayCompiler.GetListPoint(ArrayPoint--);
                rend.material.SetTexture("_MainTex", Display);
                vid.url = null;
            }

            //stop code from repeating
			BTNDown = true;
		}
		else if (Input.GetAxisRaw("Vertical") == 0 && BTNDown == true)
        {
            //allow use of "W" and "S"
			BTNDown = false;
		}

        // end the use of this application and exit by using "esc" or controller "X"
		if (Input.GetAxisRaw("Exit") > 0)
        {
			Application.Quit();
        }
	}

    //calculates whether the type of media displayed should be a video or an image 
    public string TypeCheck()
    {
        string VariableType = "";
        int ArrayPointHolder = ArrayPoint;

        //while the point in the array is less than 0 add the length of both arrays to it repeatedly
        while (ArrayPointHolder < 0)
        {
            ArrayPointHolder += arrayCompiler.TotalLength;
        }

        //while the point in the array is greather than the length of both arrays to it repeatedly minus that length repeatedly
        while (ArrayPointHolder > (arrayCompiler.TotalLength))
        {
            ArrayPointHolder -= arrayCompiler.TotalLength;
        }

        //if the point in the array is less than the length of the image list the type of media to be returned will be an image
        if (ArrayPointHolder < arrayCompiler.ListLength)
        {
            VariableType = "Image";
        }
        //if the point in the array is greater than the length of the image list but less than the length of both lists combined then the type of media to be returned will be a video
        else if (ArrayPointHolder >= arrayCompiler.ListLength && ArrayPointHolder < arrayCompiler.TotalLength)
        {
            VariableType = "Video";
        }

        return VariableType;
    }
}