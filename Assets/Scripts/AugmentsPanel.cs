using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class AugmentsPanel : MonoBehaviour {

	//Objects just for the Dropdown Selections
	private TMP_Dropdown[] Dropdowns = new TMP_Dropdown[6];
	[SerializeField] private GameObject ADd1;
	[SerializeField] private GameObject ADd2;
	[SerializeField] private GameObject ADd3;
	[SerializeField] private GameObject ADd4;
	[SerializeField] private GameObject ADd5;
	[SerializeField] private GameObject ADd6;
	List<string> Augment = new List<string>();
	private int[] iIndexes = new int[7];

	//Anything else
	[SerializeField] private TextMeshProUGUI SBoost;
	[SerializeField] private TextMeshProUGUI MBoost;
	[SerializeField] private CCharacter chara;
	public bool bArisen = false;


	void Start() {
		int i;
		//Emptying out all the Dropdowns
		Dropdowns[0] = ADd1.GetComponent<TMP_Dropdown>();
		Dropdowns[1] = ADd2.GetComponent<TMP_Dropdown>();
		Dropdowns[2] = ADd3.GetComponent<TMP_Dropdown>();
		Dropdowns[3] = ADd4.GetComponent<TMP_Dropdown>();
		Dropdowns[4] = ADd5.GetComponent<TMP_Dropdown>();
		Dropdowns[5] = ADd6.GetComponent<TMP_Dropdown>();
		for(i = 0; i < 6; i++) { Dropdowns[i].options.Clear(); }
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
			Debug.Log("Augments[50]: 100 SP");
			Augment.Add("Entrancement (Assassin)");
			Debug.Log("Augments[51]: 100 HP");
			Augment.Add("Sanguinity (Assassin)");
			Debug.Log("Augments[52]: 20% SBoost und MBoost");
			Augment.Add("Bloodlust (Assassin)");
			Augment.Add("Preemption (Assassin)");
			Augment.Add("Toxicity (Assassin)");
			Debug.Log("Augments[55]: 20% SBoost und Mboost");
			Augment.Add("Autonomy (Assassin)");
			Augment.Add("Detection (M. Archer)");
			Debug.Log("Augments[57]: 100 SP");
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
		//Preventing Doubleselection
		iIndexes[6] = Dropdowns[iDdown].value;
		bool bAlarm = false;
		for (int i = 0; i < 6; i++) {
			Debug.Log("Cycle " + (i + 1));
			if(iIndexes[i] == iIndexes[6]) {
				Dropdowns[iDdown].RefreshShownValue();
				Debug.Log("This shouldn't be possible");
				bAlarm = true;
			}
		}
		if (!bAlarm) {
			//Removing Stats and Boosts
            switch (iIndexes[iDdown]) {
				case 1:
                    if (Check(1)) {
						Debug.Log("Augments[1]: 100 HP");
						chara.SetHp(-100);
					}
					break;
				case 4:
                    if (Check(4)) {
						Debug.Log("Augments[4]: 35% SBoost");
					}
					break;
				case 6:
                    if (Check(6)) {
						Debug.Log("Augments[6]: 10% SBoost");
					}
					break;
				case 8:
                    if (Check(8)) {
						Debug.Log("Augments[8]: 100 SP");
						chara.SetSp(-100);
					}
					break;
				case 10:
                    if (Check(10)) {
						Debug.Log("Augments[10]: 30% SBoost");
					}
					break;
				case 14:
                    if (Check(14)) {
						Debug.Log("Augments[14]: 20% MBoost");
					}
					break;
				case 19:
                    if (Check(19)) {
						Debug.Log("Augements[19]: 10% SBoost");
					}
					break;
				case 22:
					if (Check(22)) {
						Debug.Log("Augments[22]: 10% SBoost 10% MBoost");
					}
					break;
				case 26:
					if (Check(26)) {
						Debug.Log("Augments[26]: 20% SBoost");
					}
					break;
				case 28:
                    if (Check(28)) {
						Debug.Log("Augments[28]: 100 HP");
						chara.SetHp(-100);
					}
					break;
				case 40:
                    if (Check(40)) {
						Debug.Log("Augments[40]: 20% MBoost");
					}
					break;
			}
			iIndexes[iDdown] = iIndexes[6];
		}			
	}

	bool Check(int iIndex) {
		for(int i = 0; i < 6; i++) {
            if (iIndex == iIndexes[i]) { return true; }
        } return false;
    }
}
