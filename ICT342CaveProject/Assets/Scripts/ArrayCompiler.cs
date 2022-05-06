﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrayCompiler : MonoBehaviour {

	List<Material> DisplayList = new List<Material>();
	bool check = false;
	int ArrayLength;
	public Material alt;
	Material Display;

	// Use this for initialization
	void Start () {
		Debug.Log("start the compilation");

		DisplayList.Insert(0, alt);
		
		//loads all objects in the folder and goes through each
		foreach (Material DisplayToBe in Resources.LoadAll("Assets/Displays"))
        {
			Debug.Log("run array fill");

			//resets variables for each iteration of the loop
			ArrayLength = DisplayList.Count - 1;
			check = false;

			//check that the object is not already in the array
			foreach (Material Saved in DisplayList)
            {
				if (DisplayToBe == Saved)
                {
					check = true;
					break;
                }
            }

			//if object is not in the array then add it
			if (check == false)
            {
				DisplayList.Insert(ArrayLength++, DisplayToBe);
            }
        }
	}
	
	public Material GetListPoint(int PointOfArray)
    {
		if(ArrayLength > 1)
        {
			while (PointOfArray > ArrayLength)
			{
				PointOfArray -= ArrayLength;
			}

			while (PointOfArray < 0)
			{
				PointOfArray += ArrayLength;
			}
		}
        else
        {
			PointOfArray = 0;
        }

        Display = DisplayList[PointOfArray];

		if (Display == null)
		{
			Display = alt;
		}

		return Display;
    }
}