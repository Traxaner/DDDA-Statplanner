using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour {
	int iLvl,iHp,iSp,iAtk,iDef,iMAtk,iMDef;
	[SerializeField] private TextMeshProUGUI hpDisplay;
	[SerializeField] private TextMeshProUGUI spDisplay;
	[SerializeField] private TextMeshProUGUI lvlDisplay;
	[SerializeField] private TextMeshProUGUI atkDisplay;
	[SerializeField] private TextMeshProUGUI defDisplay;
	[SerializeField] private TextMeshProUGUI matkDisplay;
	[SerializeField] private TextMeshProUGUI mdefDisplay;

	void UpdateStats () {
		iHp = 1;
		hpDisplay.text = iHp.ToString();
		spDisplay.text = iSp.ToString();
		lvlDisplay.text = iLvl.ToString();
		atkDisplay.text = iAtk.ToString();
		defDisplay.text = iDef.ToString();
		matkDisplay.text = iMAtk.ToString();
		mdefDisplay.text = iMDef.ToString();
	}
}