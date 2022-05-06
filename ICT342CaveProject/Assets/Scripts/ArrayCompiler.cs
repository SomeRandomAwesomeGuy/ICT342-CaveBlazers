using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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

		var loadedObjects = Resources.LoadAll("Displays");

		//loads all objects in the folder and goes through each
		foreach (Material DisplayToBe in loadedObjects)
        {
			Debug.Log("run array fill");

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
				DisplayList.Add(DisplayToBe);
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

		Debug.Log("searching for image number" + PointOfArray.ToString());

        Display = DisplayList[PointOfArray];

		if (Display == null)
		{
			Display = alt;
		}

		return Display;
    }
}