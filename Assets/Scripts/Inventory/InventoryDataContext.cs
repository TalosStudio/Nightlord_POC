using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEditor;

public class InventoryDataContext : MonoBehaviour
{
    public static List<ItemAndLocation> LoadTextFile(TextAsset textFile, bool inTown)
    {
        if (textFile != null)
        {
            string[] rows = textFile.text.Split('\n');
            string[][] grid = new string[rows.Length - 2][];
            // Remove the header row and the last empty row
            for (int i = 1; i < rows.Length - 1; i++)
            {
                
                if (rows[i] == rows.First() || rows[i] == rows.Last())
                {
                    continue;
                }
                grid[i - 1] = rows[i].Split(',');
            }

            List<ItemAndLocation> containerContents = new List<ItemAndLocation>();
            foreach(var g in grid)
            {
                ItemAndLocation il = new ItemAndLocation {
                    Item = new Item {
                        Name = g[0],
                        Modification = System.Convert.ToInt32(g[1])
                    },
                    CellsOccupied = new List<XY>()
                };
                il.CellsOccupied.Add(new XY { x = System.Convert.ToInt32(g[2]), y = System.Convert.ToInt32(g[2]) });
                containerContents.Add(il);
            }
            if(inTown)
            {
                foreach (var item in containerContents)
                {
                    item.Item.OnEquip();
                }
            }
            return containerContents;
        }
        else
        {
            Debug.Log("File does not exist.");
            return null;
        }
    }

    public static void WriteToCsv(List<ItemAndLocation> items, TextAsset textFile)
    {
        string text = "name,mod,location\n";
        if(textFile != null)
        {
            foreach(var item in items)
            {
                // Probably need to save location as their own comma separated list of XY values
                text += item.Item.gameObject.name + "," + item.Item.Modification + "," + "00" + "\n";
            }
            File.WriteAllText(AssetDatabase.GetAssetPath(textFile), text);
        }
        else
        {
            Debug.Log("File does not exist.");
        }
    }
}
