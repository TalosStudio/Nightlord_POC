using UnityEngine;
using UnityEngine.UI;

public class Key_Assignment_Button : MonoBehaviour 
{
	public int nr;
	public Text key_name, key_binding;
	Key_Assignment_Menu k_m;

	void Awake ()
	{
		k_m = GameObject.Find ("Key_Assignments").GetComponent<Key_Assignment_Menu> ();
	}

	public void Set_Button()
	{
		k_m.press_any_key.SetActive (true);
		k_m.setting_button = true;
		k_m.button_set_nr = nr;

	}
}
