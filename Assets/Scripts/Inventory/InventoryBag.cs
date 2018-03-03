using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[System.Serializable]
public class InventoryBag : MonoBehaviour 
{
	Texture2D image;
	public Rect position;

	public int columns, rows;
	public int xWidth, yWidth;

	public Cells[,] cells;


	public 

	void Awake ()
	{
		addSlots ();

	}

	void addSlots ()
	{
		cells = new Cells [columns,rows];

		for (int x = 0; x < columns; x++) 
		{
			for (int y = 0; y < columns; y++) 
			{
				Debug.Log ("NewCell");
			}
		}
	}
}


