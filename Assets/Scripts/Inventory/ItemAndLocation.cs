using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[System.Serializable]
public class ItemAndLocation
{
    /// <summary>
    /// One item in the inventory
    /// </summary>
    public Item Item;
    /// <summary>
    /// The cells in the inventory that this item occupies
    /// </summary>
    public List<XY> CellsOccupied;
}
