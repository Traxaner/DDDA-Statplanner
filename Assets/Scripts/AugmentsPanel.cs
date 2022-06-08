using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class AugmentsPanel : MonoBehaviour, IDataPersistance {

	//Objects just for the Dropdown Selections
	private DropDownController[] DDownCon = new DropDownController[6];
	private TMP_Dropdown[] Dropdowns = new TMP_Dropdown[6];
	[SerializeField] private GameObject ADd1;
	[SerializeField] private GameObject ADd2;
	[SerializeField] private GameObject ADd3;
	[SerializeField] private GameObject ADd4;
	[SerializeField] private GameObject ADd5;
	[SerializeField] private GameObject ADd6;
	List<string> Augment = new List<string>();

	//Anything else
	[SerializeField] private TextMeshProUGUI SBoost;
	[SerializeField] private TextMeshProUGUI MBoost;
	[SerializeField] private CCharacter chara;
	[SerializeField] private EqPanel butWhy;
	private float fSBoost = 1, fMBoost = 1;
	private int[] iIndexes = new int[7];
	private bool bArisen;


	void Start() {
		if (this.CompareTag("Arisen")) { bArisen = true; } else { bArisen = false; }
		int i;
		//Filling Arrays for less duplicate writing
		#region
		Dropdowns[0] = ADd1.GetComponent<TMP_Dropdown>();
		Dropdowns[1] = ADd2.GetComponent<TMP_Dropdown>();
		Dropdowns[2] = ADd3.GetComponent<TMP_Dropdown>();
		Dropdowns[3] = ADd4.GetComponent<TMP_Dropdown>();
		Dropdowns[4] = ADd5.GetComponent<TMP_Dropdown>();
		Dropdowns[5] = ADd6.GetComponent<TMP_Dropdown>();
		DDownCon[0] = ADd1.GetComponent<DropDownController>();
		DDownCon[1] = ADd2.GetComponent<DropDownController>();
		DDownCon[2] = ADd3.GetComponent<DropDownController>();
		DDownCon[3] = ADd4.GetComponent<DropDownController>();
		DDownCon[4] = ADd5.GetComponent<DropDownController>();
		DDownCon[5] = ADd6.GetComponent<DropDownController>();
		#endregion
		//Emptying out and refilling all the Dropdowns
		for (i = 0; i < 6; i++) { Dropdowns[i].options.Clear(); }
		FillList();
		foreach(string Augment in Augment) {
			for (i = 0; i < 6; i++) {
				Dropdowns[i].options.Add(new TMP_Dropdown.OptionData() { text = Augment });
		}	}

		for (i = 0; i < 6; i++) {
			DropdownItemSelected(i);
			Dropdowns[i].RefreshShownValue();
		}

		Dropdowns[0].onValueChanged.AddListener(delegate { DropdownItemSelected(0); });
		Dropdowns[1].onValueChanged.AddListener(delegate { DropdownItemSelected(1); });
		Dropdowns[2].onValueChanged.AddListener(delegate { DropdownItemSelected(2); });
		Dropdowns[3].onValueChanged.AddListener(delegate { DropdownItemSelected(3); });
		Dropdowns[4].onValueChanged.AddListener(delegate { DropdownItemSelected(4); });
		Dropdowns[5].onValueChanged.AddListener(delegate { DropdownItemSelected(5); });
	}

	//Don't want to make Start() have 100 lines
	private void FillList() {
		Augment.Add("Fitness (Fighter)");
		Augment.Add("Vigilance (Fighter)");
		Augment.Add("Egression (Fighter)");
		Augment.Add("Sinew (Fighter)");
		Augment.Add("Exhilaration (Fighter)");
		Augment.Add("Prescience (Fighter)");
		Augment.Add("Vehemence (Fighter)");
		Augment.Add("Dexterity (Strider)");
		Augment.Add("Endurance (Strider)");
		Augment.Add("Damping (Strider)");
		Augment.Add("Eminence (Strider)");
		Augment.Add("Grit (Strider)");
		Augment.Add("Arm-Strenght (Strider)");
		Augment.Add("Leg-Strenght (Strider)");
		Augment.Add("Equanimity (Mage)");
		Augment.Add("Intervention (Mage)");
		Augment.Add("Apotopaism (Mage)");
		Augment.Add("Beatitude (Mage)");
		Augment.Add("Perpetuation (Mage)");
		Augment.Add("Attunement (Mage)");
		Augment.Add("Inflection (Mage)");
		Augment.Add("Bastion (Warrior)");
		Augment.Add("Ferocity (Warrior)");
		Augment.Add("Audacity (Warrior)");
		Augment.Add("Temerity (Warrior)");
		Augment.Add("Impact (Warrior)");
		Augment.Add("Clout (Warrior)");
		Augment.Add("Proficiency (Warrior)");
		Augment.Add("Longevity (Ranger)");
		Augment.Add("Radiance (Ranger)");
		Augment.Add("Efficiacy (Ranger)");
		Augment.Add("Morbidity (Ranger)");
		Augment.Add("Trajectory (Ranger)");
		Augment.Add("Precision (Ranger)");
		Augment.Add("Stability (Ranger)");
		Augment.Add("Awareness (Sorcerer)");
		Augment.Add("Emphasis (Sorcerer)");
		Augment.Add("Suasion (Sorcerer)");
		Augment.Add("Conservation (Sorcerer)");
		Augment.Add("Gravitas (Sorcerer)");
		Augment.Add("Acuity (Sorcerer)");
		Augment.Add("Articulacy (Sorcerer)");
		if (bArisen) {
			Augment.Add("Fortitude (M. Knight)");
			Augment.Add("Adamance (M. Knight)");
			Augment.Add("Periphery (M. Knight)");
			Augment.Add("Reinforcement (M. Knight)");
			Augment.Add("Retribution (M. Knight)");
			Augment.Add("Restoration (M. Knight)");
			Augment.Add("Sanctuary (M. Knight)");
			Augment.Add("Watchfullness (Assassin)");
			Augment.Add("Entrancement (Assassin)");
			Augment.Add("Sanguinity (Assassin)");
			Augment.Add("Bloodlust (Assassin)");
			Augment.Add("Preemption (Assassin)");
			Augment.Add("Toxicity (Assassin)");
			Augment.Add("Autonomy (Assassin)");
			Augment.Add("Detection (M. Archer)");
			Augment.Add("Potential (M. Archer)");
			Augment.Add("Resilience (M. Archer)");
			Augment.Add("Allure (M. Archer)");
			Augment.Add("Regeneration (M. Archer)");
			Augment.Add("Magnitude (M. Archer)");
			Augment.Add("Resistance (M. Archer)");
		}
		Augment.Add("Acquisition (BBI)");
		Augment.Add("Adhesion (BBI)");
		Augment.Add("Athleticism (BBI)");
		Augment.Add("Conveyance (BBI)");
		Augment.Add("Facility (BBI)");
		Augment.Add("Flow (BBI)");
		Augment.Add("Fortune (BBI)");
		Augment.Add("Grace (BBI)");
		Augment.Add("Mettle (BBI)");
		Augment.Add("Opportunism (BBI)");
		Augment.Add("Predation (BBI)");
		Augment.Add("Prolongation (BBI)");
		Augment.Add("Recuperation (BBI)");
		Augment.Add("Tenacity (BBI)");
	}

	//Preventing Doubleselection and Calculating Stats/Boosts
	void DropdownItemSelected(int iDdown) {
		iIndexes[6] = Dropdowns[iDdown].value;
		//Preventing Doubleselection
		for (int i = 0; i < 6; i++) {
			DDownCon[i].EnableOption(iIndexes[iDdown], true);
			DDownCon[i].EnableOption(iIndexes[6], false);
		}
		//Removing Stats and Boosts
		switch (iIndexes[iDdown]){
				case 1:
					if (Check(1)) { chara.SetHp(-100); }
					break;
				case 4:
					if (Check(4)) { ApplySBoost(-35); }
					break;
				case 6:
					if (Check(6)) { ApplySBoost(-10); }
					break;
				case 8:
					if (Check(8)) { chara.SetSp(-100); }
					break;
				case 10:
					if (Check(10)) { ApplySBoost(-30); }
					break;
				case 14:
					if (Check(14)) { ApplyMBoost(-20); }
					break;
				case 19:
					if (Check(19)) { ApplyMBoost(-10); }
					break;
				case 22:
					if (Check(22)) {
						ApplySBoost(-10);
						ApplyMBoost(-10);
					}
					break;
				case 26:
					if (Check(26)) { ApplySBoost(-20); }
					break;
				case 28:
					if (Check(28)) { chara.SetHp(-100); }
					break;
				case 40:
					if (Check(40)) { ApplyMBoost(-20); }
					break;
				case 50:
					if (bArisen && Check(50)) { chara.SetSp(-100); }
					break;
				case 51:
					if (bArisen && Check(51)) { chara.SetHp(-100); }
					break;
				case 52:
					if (bArisen && Check(52)) {
						ApplySBoost(-20);
						ApplyMBoost(-20);
					}
					break;
				case 55:
					if (bArisen && Check(55)) { 
						ApplySBoost(-20);
						ApplyMBoost(-20);
					}
					break;
				case (57):
					if (bArisen && Check(57)) { chara.SetSp(-100); }
					break;
				case (62):
					if (bArisen && Check(62)) { butWhy.SetAll(-15); }
					break;
			}
		iIndexes[iDdown] = iIndexes[6];
		//Applying Stats and Boosts
		switch (iIndexes[6]) {
				case 1:
					if (Check(1)) { chara.SetHp(100); }
					break;
				case 4:
					if (Check(4)) { ApplySBoost(35); }
					break;
				case 6:
					if (Check(6)) { ApplySBoost(10); }
					break;
				case 8:
					if (Check(8)) { chara.SetSp(100); }
					break;
				case 10:
					if (Check(10)) { ApplySBoost(30); }
					break;
				case 14:
					if (Check(14)) { ApplyMBoost(20); }
					break;
				case 19:
					if (Check(19)) { ApplyMBoost(10); }
					break;
				case 22:
					if (Check(22)) {
						ApplySBoost(10);
						ApplyMBoost(10);
					}
					break;
				case 26:
					if (Check(26)) { ApplySBoost(20); }
					break;
				case 28:
					if (Check(28)) { chara.SetHp(100); }
					break;
				case 40:
					if (Check(40)) { ApplyMBoost(20); }
					break;
				case 50:
					if (bArisen && Check(50)) { chara.SetSp(100); }
					break;
				case 51:
					if (bArisen && Check(51)) { chara.SetHp(100); }
					break;
				case 52:
					if (bArisen && Check(52)) {
						ApplySBoost(20);
						ApplyMBoost(20);
					}
					break;
				case 55:
					if (bArisen && Check(55)) {
						ApplySBoost(20);
						ApplyMBoost(20);
					}
					break;
				case (57):
					if (bArisen && Check(57)) { chara.SetSp(100); }
					break;
				case (62):
					if (bArisen && Check(62)) { butWhy.SetAll(15); }
					break;
			}
		UpdateVisuals();
	}
	
	private bool Check(int iIndex) {
		for (int i = 0; i < 6; i++) {
			if (iIndex == iIndexes[i]) { return true; }
		}
		return false;
	}
	
	//Applying the Boosts from Augments multiplicatively
	private void ApplySBoost(int iSBoost) {
		if (iSBoost > 0) {
			fSBoost *= (1 + ((float)iSBoost / 100));
		} else {
			fSBoost /= (1 + ((float)-iSBoost / 100));
		}
	}
	private void ApplyMBoost(int iMBoost) {
		if (iMBoost > 0) { 
			fMBoost *= (1 + ((float)iMBoost / 100));
		} else {
			fMBoost /= (1 + ((float)-iMBoost / 100));
		}
	}

	private void UpdateVisuals() {
		int iCalc = (int)((fSBoost - 1) * 100);
		if (iCalc > 80) {
			SBoost.text = "80%";
			SBoost.color = new Color32(255, 75, 0, 200);
		} else {
			SBoost.text = iCalc.ToString() + "%";
			SBoost.color = new Color32(0, 0, 255, 200);
		}
		iCalc = (int)((fMBoost - 1) * 100);
		if (iCalc > 80) {
			MBoost.text = "80%";
			MBoost.color = new Color32(255, 75, 0, 200);
		} else {
			MBoost.text = iCalc.ToString() + "%";
			MBoost.color = new Color32(0, 0, 255, 200);
		}
    }

	public void SaveData(GameData data) {
		for(int i = 0; i < 6; i++) {
			if (bArisen) { data.aAug[i] = this.iIndexes[i]; } else { data.pAug[i] = this.iIndexes[i]; }
	}	}

	public void LoadData(GameData data) {
		for (int i = 0; i < 6; i++) {
			if (bArisen) { this.Dropdowns[i].value = data.aAug[i]; }
			else { this.Dropdowns[i].value = data.pAug[i]; }
			DropdownItemSelected(i);
	}	}
}
