using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;

public class VocationTools : MonoBehaviour {

	[SerializeField] private TextMeshProUGUI ModeDisplay;
	[SerializeField] private TextMeshProUGUI StepDisplay;

	Color32 white = new Color32(255, 255, 255, 255);
	Color32 orange = new Color32(255, 75, 0, 255);
	Color32 blue = new Color32(0, 0, 255, 255);

	private int iMode = 0;
	private int iSteps = 1;

	// Start is called before the first frame update
	void Start() {
		SwitchMode();
		SetSteps(1);
	}

	//Cycle between 3 different modes
	public void SwitchMode() {
		iMode+=1;
		switch (iMode) {
			case 1:
				ModeDisplay.text = "Nor";
				ModeDisplay.color = white;
				break;
			case 2:
				ModeDisplay.text = "100";
				ModeDisplay.color = blue;
				break;
			case 3:
				iMode = 0;
				ModeDisplay.text = "200";
				ModeDisplay.color = orange;
				break;
		}
		Debug.Log(iMode);
	}

	//Changes how often a button gets pressed
	public void SetSteps(int iStepN) {
		iSteps = iStepN;
		if (iSteps != 190) {
			StepDisplay.text = iSteps.ToString();
		} else {
			StepDisplay.text = "Cap";
		}
	}

	public int GetMode() { return iMode; }
	public int GetSteps() { return iSteps; }
}