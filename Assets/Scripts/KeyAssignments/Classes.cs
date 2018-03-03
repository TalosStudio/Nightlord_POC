using UnityEngine;
using System.Collections.Generic;

public class Classes
{
}

[System.Serializable]
public class Button 
{
	public string b_name;
	public KeyCode keyBinding;
}
	
//Classes That We Use To Save Data
[System.Serializable]
public class Input_Data
{
	//Input Manager Save Data
	public List<Button> game_button_data;
	public float mouse_x_sensitivity_data, mouse_y_sensitivity_data;
	public bool x_inverted_data, y_inverted_data;
}
