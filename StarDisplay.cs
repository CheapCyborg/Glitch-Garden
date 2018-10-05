using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour
{
	public enum Status {SUCCESS, FAILURE};

	private int amountOfStars = 100;
	private Text starText;

	// Use this for initialization
	void Start () {
		starText = GetComponent<Text>();
		UpdateDisplay();
	}

	public void AddStars(int amount)
	{
		amountOfStars += amount;
		UpdateDisplay();
		print(amount + " Stars added to display");
	}

	public Status UseStars(int amount)
	{
		if (amountOfStars >= amount)
		{
			amountOfStars -= amount;
			UpdateDisplay();
			return Status.SUCCESS;
		}
		return Status.FAILURE;
	}
	
	private void UpdateDisplay()
	{
		starText.text = amountOfStars.ToString();
	}
}
