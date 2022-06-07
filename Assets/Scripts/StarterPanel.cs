using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class StarterPanel : MonoBehaviour, IDataPersistance {

	[SerializeField] private TMP_Dropdown DropDown;
	[SerializeField] private Toggle tFighter, tStrider, tMage;
	[SerializeField] private ToggleGroup Toggles;
	[SerializeField] private CCharacter chara;

	private int iHP = 0, iAT = 0, iDE = 0, iMA = 0, iMD = 0;
	private bool bArisen;

	void Awake() {
		if (this.CompareTag("Arisen")) { bArisen = true; } else { bArisen = false; }
		UpdateToggle();
		UpdateVocation();
	}

	public void UpdateVocation() {
        switch (DropDown.captionText.text) {
			case "Magick Archer":
				chara.SetVocation("M. Archer");
				break;
			case "Mystic Knight":
				chara.SetVocation("M. Knight");
				break;
			default:
				chara.SetVocation(DropDown.captionText.text);
				break;
        }
    }

	public void UpdateToggle() {
		chara.SetHp(-iHP);
		chara.SetAtk(-iAT);
		chara.SetDef(-iDE);
		chara.SetMAtk(-iMA);
		chara.SetMDef(-iMD);
		if (tFighter.isOn) {
			iHP = 450;
			iAT = 80;
			iDE = 80;
			iMA = 60;
			iMD = 60;
		}else  if (tStrider.isOn) {
			iHP = 430;
			iAT = 70;
			iDE = 70;
			iMA = 70;
			iMD = 70;
		}else if (tMage.isOn) {
			iHP = 410;
			iAT = 60;
			iDE = 60;
			iMA = 80;
			iMD = 80;
		}
		chara.SetHp(iHP);
		chara.SetAtk(iAT);
		chara.SetDef(iDE);
		chara.SetMAtk(iMA);
		chara.SetMDef(iMD);
	}

	public void SaveData(GameData data) {
		int iSVoc = 0;
		if (tFighter.isOn) { iSVoc = 1; }
		if (tStrider.isOn) { iSVoc = 2; }
		if (tMage.isOn) { iSVoc = 3; }
		if (bArisen) { 
			data.aVoc = DropDown.value;
			data.aSVoc = iSVoc;
		} else {
			data.pVoc = DropDown.value;
			data.pSVoc = iSVoc;
		}
	}

	public void LoadData(GameData data) {
		int iSVoc;
		if (bArisen) {
			DropDown.value = data.aVoc;
			iSVoc = data.aSVoc;
		} else {
			DropDown.value = data.pVoc;
			iSVoc = data.pSVoc;
		}
		Toggles.allowSwitchOff = true;
		Toggles.SetAllTogglesOff();
		switch (iSVoc) {
			case 1:
				tFighter.isOn = true;
				break;
			case 2:
				tStrider.isOn = true;
				break;
			case 3:
				tMage.isOn = true;
				break;
		}
		Toggles.allowSwitchOff = false;
		UpdateVocation();
		UpdateToggle();
	}
}