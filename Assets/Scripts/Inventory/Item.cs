using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // May make sense to eventually split this into two classes:
    // One for armor and one for weapons
    #region Stats
    public int NumberOfColumns = 1;
    public int NumberOfRows = 1;
    public int Modification;
    public string Name;
    public ItemType Type;

    // Is ItemSize even needed?
    /// <summary>
    /// List of XY values to represent the size of the item.
    /// This is essentially just a helper for calculating item size.
    /// </summary>
    [HideInInspector]
    public List<XY> ItemSize;
    public bool Equipped;
    #endregion


    // Use this for initialization
    void Start ()
    {
        ItemSize = new List<XY>();
        for(int x = 1; x <= NumberOfColumns; x++)
        {
            for(int y = 1; y <= NumberOfRows; y++)
            {
                ItemSize.Add(new XY { x = x, y = y });
            }
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Test purposes only. This will probably life somewhere else and broadcast a message
		if(Input.GetKeyDown(KeyCode.W))
        {
            if(Equipped)
            {
                OnUnEquip();
            }
            if(!Equipped)
            {
                OnEquip();
            }
        }
	}

    public void OnEquip()
    {
        //var character = GetComponent<Character>();
        //character.Modification = character.Modification + Modification;
    }

    public void OnUnEquip()
    {
        //var character = GetComponent<Character>();
        //character.Modification = character.Modification - Modification;
    }

    public enum ItemType
    {
        Helmet,
        Shoulders,
        Chest,
        Sword // Should weapons be a separate item type?
    }
}
