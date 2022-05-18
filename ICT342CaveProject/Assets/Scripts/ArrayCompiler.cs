using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;

public class ArrayCompiler : MonoBehaviour {

	public List<Texture> DisplayList = new List<Texture>();
    public List<string> DisplayListVideo = new List<string>();
    bool check = false;
	public int ListLength;
    int VideoListLength;
    public int totallength;
    public Texture alt;
	Texture Display;
    string VideoDisplay;

	// Use this for initialization
	void Start () {
		Debug.Log("start the compilation");

		var loadedObjects = Resources.LoadAll("Displays", typeof(Texture));
        var loadedObjectsVideo = Directory.GetFiles("Assets/Resources/VideoDisplay");

        //loads all objects in the folder and goes through each
        foreach (var DisplayToBe in loadedObjects)
        {
			Debug.Log("run loop");
			Debug.Log("add" + DisplayToBe.name);

			//resets variables for each iteration of the loop
			check = false;

			//check that the object is not already in the array
			/*foreach (Material Saved in DisplayList)
            {
				if (DisplayToBe == Saved)
                {
					check = true;
					break;
                }
            }*/

			//if object is not in the array then add it
			if (check == false)
            {
				DisplayList.Add(DisplayToBe as Texture);
            }
        }

		ListLength = DisplayList.Count;
        //DisplayList.Add(alt);

        foreach (string DisplayVideobe in loadedObjectsVideo)
        {
            Debug.Log("run loop");
            //Debug.Log("add" + DisplayVideobe.name);

            //resets variables for each iteration of the loop
            check = false;

            //check that the object is not already in the array
            /*foreach (Material Saved in DisplayList)
            {
				if (DisplayToBe == Saved)
                {
					check = true;
					break;
                }
            }*/

            //if object is not in the array then add it
            if (check == false)
            {
                DisplayListVideo.Add(DisplayVideobe);
            }
        }

        VideoListLength = DisplayListVideo.Count;
    }

    public Texture GetListPoint(int PointOfArray)
    {
        totallength = ListLength + VideoListLength;
        if (totallength > 1)
        {
            Debug.Log("list greater than one");
            while (PointOfArray < 0)
            {
                PointOfArray += totallength;

                if (PointOfArray >= ListLength && PointOfArray < totallength)
                {
                    PointOfArray -= ListLength;
                }
            }

            while (PointOfArray > (totallength - 1))
            {
                if (PointOfArray > totallength) 
                {
                    PointOfArray -= totallength;
                }

                else if (PointOfArray < ListLength)
                {
                    Display = DisplayList[PointOfArray];
                }

                else if (PointOfArray >= ListLength && PointOfArray < totallength)
                {
                    PointOfArray -= ListLength;
                }                       
            }
                        
        }
        else
        {
            Debug.Log("list at one");
            PointOfArray = 0;
        }

        Debug.Log("searching for image number" + PointOfArray.ToString());

        if (Display == null)
        {
            Display = alt;
        }

        return Display;
    }

    public string Getvideolist(int PointOfArray)
    {
        totallength = ListLength + VideoListLength;
        if (totallength > 1)
        {
            Debug.Log("list greater than one");
            while (PointOfArray < 0)
            {
                PointOfArray += totallength;

                if (PointOfArray >= ListLength && PointOfArray < totallength)
                {
                    PointOfArray -= ListLength;
                    VideoDisplay = DisplayListVideo[PointOfArray];
                }
            }

            while (PointOfArray > (totallength - 1))
            {
                if (PointOfArray > totallength)
                {
                    PointOfArray -= totallength;
                }

                else if (PointOfArray < ListLength)
                {
                    //Display = DisplayList[PointOfArray];
                }

                else if (PointOfArray >= ListLength && PointOfArray < totallength)
                {
                    PointOfArray -= ListLength;
                    VideoDisplay = DisplayListVideo[PointOfArray];
                }
            }

        }
        else
        {
            Debug.Log("list at one");
            PointOfArray = 0;
        }

        Debug.Log("searching for image number" + PointOfArray.ToString());
        
        return VideoDisplay;
    }
}