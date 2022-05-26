using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;

public class ArrayCompiler : MonoBehaviour {

	public List<Texture> DisplayList = new List<Texture>();
    public List<string> DisplayListVideo = new List<string>();
    bool Check = false;
	public int ListLength;
    int VideoListLength;
    public int TotalLength;
    public Texture alt;
	Texture Display;
    string VideoDisplay;

	// Use this for initialization
	void Start () {
		var loadedObjects = Resources.LoadAll("Displays", typeof(Texture));
        var loadedObjectsVideo = Directory.GetFiles("Assets/Resources/VideoDisplay");

        //loads all objects in the folder and goes through each
        foreach (var DisplayToBe in loadedObjects)
        {
			//resets variables for each iteration of the loop
			Check = false;

			//if object is not in the array then add it
			if (Check == false)
            {
				DisplayList.Add(DisplayToBe as Texture);
            }
        }

		ListLength = DisplayList.Count;

        foreach (string DisplayVideoBe in loadedObjectsVideo)
        {
            Debug.Log("run loop");

            //resets variables for each iteration of the loop
            Check = false;

            //if object is not in the array then add it
            if (Check == false)
            {
                DisplayListVideo.Add(DisplayVideoBe);
            }
        }

        VideoListLength = DisplayListVideo.Count;
    }

    //retrive the image from the array to be displayed
    public Texture GetListPoint(int PointOfArray)
    {
        TotalLength = ListLength + VideoListLength;
        if (TotalLength > 1)
        {
            Debug.Log("list greater than one");
            while (PointOfArray < 0)
            {
                PointOfArray += TotalLength;
            }

            while (PointOfArray > TotalLength)
            {
               PointOfArray -= TotalLength;                     
            }

            if (PointOfArray < ListLength)
            {
                Display = DisplayList[PointOfArray];
            }

        }
        else
        {
            Debug.Log("list at one");
            PointOfArray = 0;
        }

        //if there is no image to display display alternative
        if (Display == null)
        {
            Display = alt;
        }

        return Display;
    }

    //retrive the video from the array to be displayed
    public string Getvideolist(int PointOfArray)
    {
        TotalLength = ListLength + VideoListLength;
        if (TotalLength > 1)
        {
            Debug.Log("list greater than one");
            while (PointOfArray < 0)
            {
                PointOfArray += TotalLength; 
            }

            while (PointOfArray > (TotalLength - 1))
            {
                PointOfArray -= TotalLength;
            }

            if (PointOfArray >= ListLength && PointOfArray < TotalLength)
            {
                PointOfArray -= ListLength;
                VideoDisplay = DisplayListVideo[PointOfArray];
            }

        }
        else
        {
            Debug.Log("list at one");
            PointOfArray = 0;
        }
        
        return VideoDisplay;
    }
}