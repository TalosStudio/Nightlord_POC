using UnityEngine;

public class Pause_Menu : MonoBehaviour 
{
	public GameObject menu;
	Input_Manager im;
	void Awake ()
	{
		im = GameObject.Find ("GameManager").GetComponent<Input_Manager> ();
	}
	void Update ()
	{
		if (im.PressedDown ("Pause"))
		if (menu.activeInHierarchy == true) 
		{
			menu.SetActive  (false);

		}
			else
		{
			menu.SetActive  (true);
		}
	}
}
