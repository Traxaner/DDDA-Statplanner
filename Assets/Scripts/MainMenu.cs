using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour {

	[SerializeField] private GameObject aPanel, aSPanel, aVPanel,aAPanel,aEPanel,aSkPanel;
	[SerializeField] private GameObject pPanel, pSPanel, pVPanel,pAPanel,pEPanel,pSkPanel;
	[SerializeField] private GameObject mainMenu, menuMode, saveMode;
	[SerializeField] private TextMeshProUGUI information;
	[SerializeField] private Button SAV;

	private float fTimer = 0f, fPos0, fPos1, fPos2, fPosY;
	private int iState = 0, iMessage = 0, cPos = 0;

	// Start is called before the first frame update
	void Start() {
		fPosY = mainMenu.transform.position.y;
		fPos0 = mainMenu.transform.position.x;
		fPos1 = aPanel.transform.position.x;
		fPos2 = pPanel.transform.position.x;
	}

	void FixedUpdate() {
		if (Time.time >= fTimer) {
			fTimer = Time.time + 5;
			Infotext();
		}
	}

	//Changes the Infotext based on Context
	private void Infotext() {
		switch (iMessage) {
			case 0:
				iMessage = 1;
				switch (iState) {
					case 0:
						information.text = "You can Edit the name of your Arisen\nand Main Pawn by clicking on them";
						break;
					case 1:
						information.text = "Here you can configure the Basic things\nand the first 10 Levels of your character";
						break;
					case 2:
						information.text = "Here you can configure all the\nremaining 190 Levels of your Character";
						break;
					case 3:
						information.text = "Here you can pick 6 augments\nfrom all available Vocations";
						break;
					case 4:
						information.text = "Here you can select all the\nequipment pieces you want to have";
						break;
					case 5:
						information.text = "Here you can select your skills\nbased on chosen weapons";
						break;
					case 6:
						iMessage = 2;
						information.text = "TODO";
						break;
				}
				break;
			case 1:
				if (iState == 0) {
					iMessage = 0;
				} else { iMessage = 2; }
				information.text = "A is for changes to the Arisen\nP is for changes to your Main Pawn";
				break;
			case 2:
				iMessage = 0;
                if (iState != 6) {
					information.text = "Press here to close the editing Options\nSaving and Loading is only possible then";
				} else { 
					information.text = "Press here to return to the main menu";
				}
				break;
	}	}

	//Moves the main menu to the right position
	public void Move(int tPos) {
		//Stop if already there
		if (tPos == cPos) { return; }
		Vector3 Pos = new Vector3() ;
		switch (tPos) {
			case 0:
				Pos.Set(fPos0,fPosY,0f);
				break;
			case 1:
				Pos.Set(fPos1,fPosY,0f);
				break;
			case 2:
				Pos.Set(fPos2,fPosY,0f);
				break;
        }
		mainMenu.transform.SetPositionAndRotation(Pos, new Quaternion());
		//Update saved placement
		cPos = tPos;
    }

	//Reset the Information given by the main menu
	public void SetState(int iState) {
		//Stop if already in this state
        if (this.iState == iState) { return; }
		//Changing main menu if needed
		if (iState == 0) {
			menuMode.SetActive(true);
			saveMode.SetActive(false);
			aPanel.SetActive(false);
			pPanel.SetActive(false);
			SAV.interactable = true;
		} else { SAV.interactable = false; }
		if (iState == 6) {
			menuMode.SetActive(false);
			saveMode.SetActive(true);
		}
		this.iState = iState;
		fTimer = Time.time;
		iMessage = 0;
	}

	//Enable the right Areas; odd Pawn, even Arisen
	public void Display(int index) {
        if (index % 2 == 1) {
			aPanel.SetActive(false);
			pPanel.SetActive(true);
        } else {
			aPanel.SetActive(true);
			pPanel.SetActive(false);
		}
		aSPanel.SetActive(false);
		pSPanel.SetActive(false);
		aVPanel.SetActive(false);
		pVPanel.SetActive(false);
		aAPanel.SetActive(false);
		pAPanel.SetActive(false);
		aEPanel.SetActive(false);
		pEPanel.SetActive(false);
		aSkPanel.SetActive(false);
		pSkPanel.SetActive(false);
		if (index < 2) {
			aSPanel.SetActive(true);
			pSPanel.SetActive(true);
		} else if (index < 4) {
			aVPanel.SetActive(true);
			pVPanel.SetActive(true);
		} else if (index < 6) {
			aAPanel.SetActive(true);
			pAPanel.SetActive(true);
		} else if (index < 8) {
			aEPanel.SetActive(true);
			pEPanel.SetActive(true);
		} else if (index < 10) {
			aSkPanel.SetActive(true);
			pSkPanel.SetActive(true);
		}
	}
}