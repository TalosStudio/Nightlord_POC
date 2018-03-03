using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


public class Key_Assignment_Menu : MonoBehaviour 
{
	public GameObject button_frame, press_any_key;
	List<Key_Assignment_Button> buttons = new List<Key_Assignment_Button>();
	//public float button_offest;
	RectTransform bf_rt, tmp_rt;
	GameObject tmp;
	Input_Manager im;

	public bool setting_button;
	public int button_set_nr;

	void Awake()
	{
		im = GameObject.Find("GameManager").GetComponent<Input_Manager>();
		bf_rt = button_frame.GetComponent<RectTransform>();
	}
	void Start()
	{
		for (int i = 0; i < im.game_buttons.Count; ++i)
		{
			tmp = GameObject.Instantiate(button_frame);
			tmp.transform.SetParent(gameObject.transform);
			tmp.name = im.game_buttons[i].b_name + "_button";
			tmp_rt = tmp.GetComponent<RectTransform>();
			tmp_rt.localScale = bf_rt.localScale;
			tmp_rt.anchoredPosition = bf_rt.anchoredPosition;
			tmp_rt.anchoredPosition += new Vector2(0, bf_rt.rect.height * -i);
			buttons.Add(tmp.GetComponent<Key_Assignment_Button>());
			buttons [i].nr = i;
			buttons [i].key_name.text = im.game_buttons [i].b_name;
			Refresh_GUI_Button (buttons [i]);
		}
		GameObject.Destroy(button_frame);
	}
	void OnGUI ()
	{
		if (setting_button) 
		{
			Event e; e = Event.current;
			if (Input.GetKey (KeyCode.LeftShift))
				e.keyCode = KeyCode.LeftShift;
			else if (Input.GetKey (KeyCode.RightShift))
				e.keyCode = KeyCode.RightShift;
			if ((e.isKey && e.keyCode != KeyCode.None) || e.keyCode == KeyCode.LeftShift|| e.keyCode == KeyCode.RightShift)
			{
				Check_For_Keycodes (e.keyCode);
				im.game_buttons [button_set_nr].keyBinding = e.keyCode;
				Refresh_GUI_Button (buttons[button_set_nr]);
			
				setting_button = false;
				press_any_key.SetActive (false);
			}
		}
	}
	void Refresh_GUI_Button (Key_Assignment_Button k_b)
	{
		if (im.game_buttons [k_b.nr].keyBinding == KeyCode.None)
			k_b.key_binding.text = "";
		else
		k_b.key_binding.text = im.game_buttons [k_b.nr].keyBinding.ToString ();
	}

	public void Refresh_All_Buttons()
	{
		for (int i = 0; i < im.game_buttons.Count; ++i)
		{
			Refresh_GUI_Button (buttons[i]);
		}
	}

	void Check_For_Keycodes (KeyCode just_pressed)
	{
		for (int i = 0; i < im.game_buttons.Count; ++i) 
		{
			if (im.game_buttons [i].keyBinding == just_pressed) 
			{
				im.game_buttons [i].keyBinding = KeyCode.None;
				Refresh_GUI_Button (buttons [i]);
			}
		}
	}
}