using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ArrayCompiler : MonoBehaviour {

	public List<Material> DisplayList = new List<Material>();
	bool check = false;
	int ListLength;
	public Material alt;
	Material Display;

	// Use this for initialization
	void Start () {
		Debug.Log("start the compilation");

		var loadedObjects = Resources.LoadAll("Displays", typeof(Material));

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
				DisplayList.Add(DisplayToBe as Material);
            }
        }

		ListLength = DisplayList.Count;
		//DisplayList.Add(alt);
	}
	
	public Material GetListPoint(int PointOfArray)
    {
		if(ListLength > 1)
        {
			Debug.Log("list greater than one");
			while (PointOfArray > (ListLength-1))
			{
				PointOfArray -= ListLength;
			}

			while (PointOfArray < 0)
			{
				PointOfArray += ListLength;
			}
		}
        else
        {
			Debug.Log("list at one");
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