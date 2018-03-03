using UnityEngine;

public class Inventory_Menu : MonoBehaviour 
{
	public GameObject Imenu;
	Input_Manager im;
	void Awake ()
	{
		im = GameObject.Find ("GameManager").GetComponent<Input_Manager> ();
	}
	void Update ()
	{
		if (im.PressedDown ("Inventory"))
		if (Imenu.activeInHierarchy == true) 
		{
			Imenu.SetActive  (false);

		}
		else
		{
			Imenu.SetActive  (true);
		}
	}
}