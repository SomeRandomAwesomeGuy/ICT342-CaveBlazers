using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrayCompiler : MonoBehaviour {

	public Sprite[] List;
	bool check = false;
	int ArrayLength;
	public Sprite alt;
	Sprite Display;

	// Use this for initialization
	void Start () {

		List[0] = alt;
		
		//loads all objects in the folder and goes through each
		foreach (Sprite DisplayToBe in Resources.LoadAll("Assets/Displays"))
        {
			Debug.Log("run array fill");

			//resets variables for each iteration of the loop
			ArrayLength = List.Length - 1;
			check = false;

			//check that the object is not already in the array
			foreach (Sprite Saved in List)
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
	}
	
	public Sprite GetListPoint(int PointOfArray)
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

        Display = List[PointOfArray];

		if (Display == null)
		{
			Display = alt;
		}

		return Display;
    }
}