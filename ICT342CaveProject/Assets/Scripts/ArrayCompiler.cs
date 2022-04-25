using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayCompiler : MonoBehaviour {

	object[] List;
	bool check = false;
	int ArrayLength;
	// Use this for initialization
	void Start () {
		//loads all objects in the folder and goes through each
		foreach (object Display in Resources.LoadAll("Assets/Displays"))
        {
			//resets variables for each iteration of the loop
			ArrayLength = List.Length;
			check = false;

			//check that the object is not already in the array
			foreach (object Saved in List)
            {
				if (Display == Saved)
                {
					check = true;
					break;
                }
            }

			//if object is not in the array then add it
			if (check == false)
            {
				List[ArrayLength++] = Display;
            }
        }
    }
	
	public object GetListPoint(int PointOfArray)
    {
		while (PointOfArray >= ArrayLength)
        {
			PointOfArray -= ArrayLength;
        }

		while (PointOfArray < 0)
        {
			PointOfArray += ArrayLength;
		}
		return PointOfArray;
    }
}
