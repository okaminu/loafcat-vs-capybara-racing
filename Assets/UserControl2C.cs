using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// For user multiplatform control.
/// </summary>
[RequireComponent(typeof(CarController))]
public class UserControl2C : MonoBehaviour
{

	CarController ControlledCar;

	public float Horizontal { get; private set; }
	public float Vertical { get; private set; }
	public bool Brake { get; private set; }

	public static MobileControlUI CurrentUIControl { get; set; }

	private void Awake()
	{
		ControlledCar = GetComponent<CarController>();
		CurrentUIControl = FindObjectOfType<MobileControlUI>();
	}

	void Update()
	{
		if (CurrentUIControl != null && CurrentUIControl.ControlInUse)
		{
			//Mobile control.
			Horizontal = CurrentUIControl.GetHorizontalAxis;
			Vertical = CurrentUIControl.GetVerticalAxis;
		}
		else
		{
			//Standart input control (Keyboard or gamepad).
			Horizontal = Input.GetAxis("Horizontal2");
			Vertical = Input.GetAxis("Vertical2");
			Brake = Input.GetButton("Jump2");
		}

		//Apply control for controlled car.
		ControlledCar.UpdateControls(Horizontal, Vertical, Brake);
	}
}
