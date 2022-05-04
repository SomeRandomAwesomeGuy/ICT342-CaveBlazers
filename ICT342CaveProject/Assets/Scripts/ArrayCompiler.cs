using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayCompiler : MonoBehaviour {

	public Material[] List;
	bool check = false;
	int ArrayLength;
	Material Display;

	// Use this for initialization
	void Start () {
		//loads all objects in the folder and goes through each
		foreach (Material DisplayToBe in Resources.LoadAll("Assets/Displays"))
        {
			//resets variables for each iteration of the loop
			ArrayLength = List.Length;
			check = false;

			//check that the object is not already in the array
			foreach (Material Saved in List)
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
				List[ArrayLength++] = DisplayToBe;
            }
        }

		Display = GetListPoint(0);
		this.GetComponent<Renderer>().material = Display;
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
			
		return List[PointOfArray];
    }
}