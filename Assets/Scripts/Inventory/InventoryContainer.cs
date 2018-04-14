using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryContainer : MonoBehaviour
{
    public int SizeX = 5;
    public int SizeY = 5;
    public List<ItemAndLocation> ItemsAndCells = new List<ItemAndLocation>();
    public TextAsset Data;

    // Use this for initialization
    void Start ()
    {
        Grid = new List<XY>();
        for (int x = 0; x < SizeX; x++)
        {
            for (int y = 0; y < SizeY; y++)
            {
                Grid.Add(new XY { x = x, y = y });
            }
        }

        int totalItemSize = 0;
        foreach(var ic in ItemsAndCells)
        {
            totalItemSize += ic.Item.ItemSize.Count;
        }

        if(totalItemSize > Grid.Count)
        {
            //Eventually handle this in the UI by disallowing adding this many items
            throw new UnityException("Too many items in this container");
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.A))
        {
            Save();
        }

        // Temporary for testing purposes. This will likely not ultimately reside on the inventory
        if(Input.GetKeyDown(KeyCode.S))
        {
            InventoryDataContext.LoadTextFile(Data, true);
        }
	}

    public void AddItem(Item item)
    {
        ItemAndLocation il = new ItemAndLocation();
        il.Item = item;
        //Check if cells are already occupied
        ItemsAndCells.Add(il);
    }

    public void RemoveItem(Item item)
    {
        ItemsAndCells.Remove(ItemsAndCells.Find(i => i.Item == item));
    }

    public void Save()
    {
        InventoryDataContext.WriteToCsv(ItemsAndCells, Data);
    }

    // Probably need a KVP here for if the cells are occupied already or not
    private List<XY> Grid;
}

[System.Serializable]
public struct XY
{
    public int x;
    public int y;
}


