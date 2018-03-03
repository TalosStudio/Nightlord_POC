using UnityEngine;

public class Player_Sword : MonoBehaviour 
{
	public Transform sword, sword_ueq, sword_eq;
	public bool sword_is_eq;
	Input_Manager im;
	Animator anim;

	void Awake ()
	{
		anim = GetComponent <Animator> ();
		im = GameObject.Find ("GameManager").GetComponent <Input_Manager> ();
	}

	void Update ()
	{
		if (im.PressedDown ("Sword"))
			anim.SetTrigger ("sword_e");

		if (sword_is_eq)
			{
				sword.position = sword_eq.position;
				sword.rotation = sword_eq.rotation; 
			}
		else
			{
			sword.position = sword_ueq.position;
			sword.rotation = sword_ueq.rotation;
			}
	}
	public void Sword_Equip ()
	{
		sword_is_eq = true;
	}
	public void Sword_UEQ ()
	{
		sword_is_eq = false;
	}
}
