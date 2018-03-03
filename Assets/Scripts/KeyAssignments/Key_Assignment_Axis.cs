using UnityEngine;
using UnityEngine.UI;

public class Key_Assignment_Axis : MonoBehaviour 
{
	public bool isX;
	public Slider slider;
	public Image image;
	Input_Manager im;

	void Awake ()
	{
		im = GameObject.Find ("GameManager").GetComponent<Input_Manager> ();
	}

	void Start ()
	{
		if (isX) 
		{
			image.fillCenter = im.XInverted;
			slider.value = im.mouseXSpeed;
		} 
		else 
		{
			image.fillCenter = im.YInverted;
			slider.value = im.mouseYSpeed;
		}
	}

	public void Invert_Click ()
	{
		if (isX) 
		{
			im.XInverted = !im.XInverted;
			image.fillCenter = im.XInverted;
		} 
		else 
		{
			im.YInverted = !im.YInverted;
			image.fillCenter = im.YInverted;
		}
			
	}
	public void Change_Slider_Value ()
	{
		if (isX) 
		{
			im.mouseXSpeed = slider.value;
		} 
		else
		{
			im.mouseYSpeed = slider.value;
		}
	}

}
