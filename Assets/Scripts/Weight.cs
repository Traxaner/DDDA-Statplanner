using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Weight : MonoBehaviour, IDataPersistance {
	
	[SerializeField] private TextMeshProUGUI CarryCap, WeightDis, WeightCl;
	[SerializeField] private Slider WeightSlider;
	public CCharacter chara;

	private int iWeight, iStamBase = 0;
	private char cWeightClass;
	private bool bArisen;

	void Awake() {
		if (this.CompareTag("Arisen")) { bArisen = true; } else { bArisen = false; }
		UpdateVisuals();
	}

	public void UpdateVisuals() {
		iWeight = (int)WeightSlider.value;
		WeightDis.text = iWeight.ToString() + " kg";
		if (iWeight > 109) {
			CarryCap.text = "100 kg";
			WeightCl.text = "LL";
			cWeightClass = 'x';
		} else if (iWeight >= 90) {
			CarryCap.text = "75 kg";
			WeightCl.text = "L";
			cWeightClass = 'l';
		} else if (iWeight >= 70) {
			CarryCap.text = "65 kg";
			WeightCl.text = "M";
			cWeightClass = 'm';
		}else if (iWeight >= 50) {
			CarryCap.text = "50 kg";
			WeightCl.text = "S";
			cWeightClass = 's';
        } else {
			CarryCap.text = "40 kg";
			WeightCl.text = "SS";
			cWeightClass = 't';
		}
		UpdateStaminaBase();
	}

	private void UpdateStaminaBase() {
		int iCheck = 0;
        switch (cWeightClass) {
			case 'x':
				iCheck = 580;
				break;
			case 'l':
				iCheck = 560;
				break;
			case 'm':
				iCheck = 540;
				break;
			case 's':
				iCheck = 520;
				break;
			case 't':
				iCheck = 500;
				break;
		}
        if (iCheck != iStamBase) {
			chara.SetSp(-iStamBase);
			iStamBase = iCheck;
			chara.SetSp(iStamBase);
        }
    }

	public void SaveData(GameData data) {
		Debug.Log("em...."+(int)WeightSlider.value);
		if (bArisen) { data.aWeight = (int)WeightSlider.value; } else { data.pWeight = iWeight; }
	}

	public void LoadData(GameData data) {
		int iWeight;
		if (bArisen) { iWeight = data.aWeight; } else { iWeight = data.pWeight; }
		WeightSlider.value = iWeight;
		UpdateVisuals();
		Debug.Log(this.iWeight);
	}
}