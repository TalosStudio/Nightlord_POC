
using UnityEngine;

public class Player_movement : MonoBehaviour 
{	

	public Transform center_point, moveHelper;
	public float rotation_speed, horizAxis, vertAxis;
	float vdest, hdest, movement;
	bool forward, back, left, right, slow_walk, sprint;
	int angle_to_rotate;
	Animator anim;
	Input_Manager im;

	void Awake ()
	{
		anim = GetComponent <Animator> ();
		im = GameObject.Find ("GameManager").GetComponent <Input_Manager> ();
	}
	void Update ()
	{
		CalculateMovement ();
		CalcucalteVertAxis ();
		CalcucalteHorizAxis ();
		forward = im.Pressed ("Forward");
		back = im.Pressed ("Backward");
		left = im.Pressed ("Left");
		right = im.Pressed ("Right");
		if (im.PressedDown ("Walk")) 
		{
			slow_walk = !slow_walk;
		}

		if (im.Pressed ("Sprint")) 
		{
			sprint = true;
			movement = movement * 1.75f;
		}
		else
			sprint = false;
		anim.SetBool ("sprint", sprint);
		anim.SetBool ("slow_walk", slow_walk);
		calculate_angle ();
		anim.SetFloat ("movement", (movement));
		anim.SetFloat ("angle", Mathf.DeltaAngle (transform.eulerAngles.y, center_point.eulerAngles.y + angle_to_rotate));
		if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("turnable"))
			transform.eulerAngles += new Vector3 (0, Mathf.DeltaAngle (transform.eulerAngles.y, center_point.eulerAngles.y + angle_to_rotate) * Time.deltaTime * rotation_speed, 0);

		moveHelper.position = transform.position + transform.forward * movement * .75f + new Vector3 (0,.45f,0);
		if (slow_walk == false) 
		{
			movement = 1f;
		}
	}
	void calculate_angle ()
	{
		if (forward && !back)
		{
			if (left && !right)
				angle_to_rotate = -45;
			else if (!left && right)
				angle_to_rotate = 45;
			else
				angle_to_rotate = 0;
		} 
		else if (!forward && back)
		{
			if (left && !right)
				angle_to_rotate = -135;
			else if (!left && right)
				angle_to_rotate = 135;
			else
				angle_to_rotate = 180;
		} 
		else
		{
			if (left && !right)
				angle_to_rotate = -90;
			else if (right && !left)
				angle_to_rotate = 90;
			else
				angle_to_rotate = 0;
		}
	}
	void CalcucalteVertAxis ()
	{
		if (im.Pressed ("Forward"))
			vdest = 1;
		else
			vdest = 0;
		if (vdest == 1 && Mathf.Abs (vertAxis - 1)<= 0.01f)
			vertAxis = 1;
		else if (vdest == 0 && Mathf.Abs (vertAxis)<= 0.01f)
			vertAxis = 0;
		else
			vertAxis = Mathf.Lerp (vertAxis, vdest, Time.deltaTime * 8f);
		if (im.Pressed ("Backward"))
			vertAxis = 0f;
	
	}
	void CalcucalteHorizAxis ()
	{
		if (im.Pressed ("Left") ^ im.Pressed ("Right"))
			hdest = 1;
		else
			hdest = 0;
		if (hdest == 1 && Mathf.Abs (horizAxis - 1)<= 0.01f)
			horizAxis = 1;
		else if (hdest == 0 && Mathf.Abs (horizAxis)<= 0.01f)
			horizAxis = 0;
		else
			horizAxis = Mathf.Lerp (horizAxis, hdest, Time.deltaTime * 8f);
	}
	void CalculateMovement ()
	{
		movement = Mathf.Max (horizAxis, vertAxis);
	}
}