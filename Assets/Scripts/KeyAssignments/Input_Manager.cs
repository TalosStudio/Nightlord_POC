using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Input_Manager : MonoBehaviour 
{
	public List <Button> game_buttons = new List<Button>();

	public float mouseX, mouseY, mouseXSpeed, mouseYSpeed;
	public bool XInverted, YInverted;
	string search_name;
	int idx;

	void Start ()
	{
		if (IO.File_exist ("input_data.bin"))
			Load_Input ();
		else
			Debug.LogWarning ("No Player Data Found");
	} 
	void Update ()
	{
		mouseX = Input.GetAxis ("Mouse X") * mouseXSpeed * 2;
		if (XInverted)
			mouseX *= -1;
		mouseY = Input.GetAxis ("Mouse Y") * mouseYSpeed * 2;
		if (YInverted)
			mouseY *= -1;

	}
	public bool Pressed (string button_name)
	{
		search_name = button_name;
		idx = game_buttons.FindIndex (IsName);
		if (Input.GetKey (game_buttons [idx].keyBinding))
			return true;
		else
			return false;
	}
	public bool PressedDown (string button_name)
	{
		search_name = button_name;
		idx = game_buttons.FindIndex (IsName);
		if (Input.GetKeyDown (game_buttons [idx].keyBinding))
			return true;
		else
			return false;
	}
	public bool PressedUp (string button_name)
	{
		search_name = button_name;
		idx = game_buttons.FindIndex (IsName);
		if (Input.GetKeyUp (game_buttons [idx].keyBinding))
			return true;
		else
			return false;
	}
	bool IsName (Button bu)
	{
		return bu.b_name == search_name;
	}
	public void Save_Input ()
	{
		Input_Data input_data = new Input_Data ();
		//Assigning Everything
		input_data.game_button_data = game_buttons;
		input_data.x_inverted_data = XInverted;
		input_data.mouse_x_sensitivity_data = mouseXSpeed;
		input_data.y_inverted_data = YInverted;
		input_data.mouse_y_sensitivity_data = mouseYSpeed;
		//
		IO.Save<Input_Data>(input_data, "input_data.bin");
		Debug.Log ("Input Saved");
	}
	public void Load_Input ()
	{
		Input_Data input_data = IO.Load<Input_Data>("input_data.bin");
		Debug.Log("Input was loaded.");
		//assign everything
		game_buttons = input_data.game_button_data;
		XInverted = input_data.x_inverted_data;
		YInverted = input_data.y_inverted_data;
		mouseXSpeed = input_data.mouse_x_sensitivity_data;
		mouseYSpeed = input_data.mouse_y_sensitivity_data;
	}
}
