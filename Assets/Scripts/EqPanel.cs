using System.Collections.Generic;
using UnityEngine;
using Homebrew;
using System;
using TMPro;

public class EqPanel : MonoBehaviour {
	//Some basic necesities for things to work well
	[SerializeField] private CCharacter chara;
	private int[] iCurrent = new int[9];
	//Debilitations
	#region
	private TextMeshProUGUI[] Debilitations = new TextMeshProUGUI[13];
	[Foldout("Debilitations")] [SerializeField]private TextMeshProUGUI petrify;
	[Foldout("Debilitations")] [SerializeField]private TextMeshProUGUI possession;
	[Foldout("Debilitations")] [SerializeField]private TextMeshProUGUI sleep;
	[Foldout("Debilitations")] [SerializeField]private TextMeshProUGUI silence;
	[Foldout("Debilitations")] [SerializeField]private TextMeshProUGUI skillStiff;
	[Foldout("Debilitations")] [SerializeField]private TextMeshProUGUI torpor;
	[Foldout("Debilitations")] [SerializeField]private TextMeshProUGUI poison;
	[Foldout("Debilitations")] [SerializeField]private TextMeshProUGUI blind;
	[Foldout("Debilitations")] [SerializeField]private TextMeshProUGUI curse;
	[Foldout("Debilitations")] [SerializeField]private TextMeshProUGUI strLow;
	[Foldout("Debilitations")] [SerializeField]private TextMeshProUGUI magLow;
	[Foldout("Debilitations")] [SerializeField]private TextMeshProUGUI defLow;
	[Foldout("Debilitations")] [SerializeField]private TextMeshProUGUI mDefLow;
	#endregion
	//Dropdowns of pain and suffering
	#region
	private TMP_Dropdown[] Equipment;
	[Foldout("Equipment")] [SerializeField] public GameObject hArmor;
	[Foldout("Equipment")] [SerializeField] public GameObject tClothing;
	[Foldout("Equipment")] [SerializeField] public GameObject tArmor;
	[Foldout("Equipment")] [SerializeField] public GameObject aArmor;
	[Foldout("Equipment")] [SerializeField] public GameObject lClothing;
	[Foldout("Equipment")] [SerializeField] public GameObject lArmor;
	[Foldout("Equipment")] [SerializeField] public GameObject cloak;
	//Rings get special treatment
	private TMP_Dropdown[] Rings = new TMP_Dropdown[2];
	[Foldout("Equipment")] [SerializeField] private TMP_Dropdown Ring1;
	[Foldout("Equipment")] [SerializeField] private TMP_Dropdown Ring2;
	#endregion
	//Lists of pain and suffering
	#region
	List<string> Head = new List<string>();
	List<string> TCloth = new List<string>();
	List<string> Chest = new List<string>();
	List<string> Arms = new List<string>();
	List<string> LCloth = new List<string>();
	List<string> Legs = new List<string>();
	List<string> Cloak = new List<string>();
	List<string> Ringz = new List<string>();
	#endregion

	void Start() {
		//filling debilitationsarray
		#region
		Debilitations[0] = petrify;
		Debilitations[1] = possession;
		Debilitations[2] = sleep;
		Debilitations[3] = silence;
		Debilitations[4] = skillStiff;
		Debilitations[5] = torpor;
		Debilitations[6] = poison;
		Debilitations[7] = blind;
		Debilitations[8] = curse;
		Debilitations[9] = strLow;
		Debilitations[10] = magLow;
		Debilitations[11] = defLow;
		Debilitations[12] = mDefLow;
		#endregion
		EquipmentSetup1();
		ListsOfPainAndSuffering();
		EquipmentSetup2();
	}

	//Basic Setup
	private void EquipmentSetup1() {
		//Ringarray
		Rings[0] = Ring1;
		Rings[1] = Ring2;
		Equipment = new TMP_Dropdown[]{
			hArmor.GetComponent<TMP_Dropdown>(),tClothing.GetComponent<TMP_Dropdown>(),
			tArmor.GetComponent<TMP_Dropdown>(),aArmor.GetComponent<TMP_Dropdown>(),
			lClothing.GetComponent<TMP_Dropdown>(),lArmor.GetComponent<TMP_Dropdown>(),
			cloak.GetComponent<TMP_Dropdown>()
		};
		//Getting the Dropdowns
		for(int i = 0; i < 7; i++) {
			//Clearing Dropdowns
			Equipment[i].options.Clear();
			//Adding empty option
			Equipment[i].options.Add(new TMP_Dropdown.OptionData() { text = " - " });
			//Rings
			if (i < 2) {
				Rings[i].options.Clear();
				Rings[i].options.Add(new TMP_Dropdown.OptionData() { text = " - " });
	}	}	}

	//Putting the Lists to use
	private void EquipmentSetup2() {
		//Rings
		#region
		foreach (string Ringz in Ringz) {
			for (int i = 0; i < 2; i++) {
				Rings[i].options.Add(new TMP_Dropdown.OptionData() { text = Ringz });
		}	}
		Rings[0].onValueChanged.AddListener(delegate { SwitchRing(0); });
		Rings[1].onValueChanged.AddListener(delegate { SwitchRing(1); });
		#endregion
	}

	private void ListsOfPainAndSuffering() {
		//Rings
		#region
		Ringz.Add("Baleful Nails");
		Ringz.Add("Barbed Nails");
		Ringz.Add("Benevolent Earring");
		Ringz.Add("Bloody Knuckle");
		Ringz.Add("Blue Star Earring");
		Ringz.Add("Blue Star Ring");
		Ringz.Add("Cleansing Earring");
		Ringz.Add("Dignified Earring");
		Ringz.Add("Dragonblood");
		Ringz.Add("Exurbant Earring");
		Ringz.Add("Faithfull Earring");
		Ringz.Add("Free-Spoken Earring");
		Ringz.Add("Golden Ring");
		Ringz.Add("Green Star Earring");
		Ringz.Add("Green Star Ring");
		Ringz.Add("Harmonious Earring");
		Ringz.Add("Indomitable Earring");
		Ringz.Add("Iris Ring");
		Ringz.Add("Nimble Earring");
		Ringz.Add("Noble Earring");
		Ringz.Add("Ogrebone");
		Ringz.Add("Platinum Ring");
		Ringz.Add("Premium Earring");
		Ringz.Add("Premium Ring");
		Ringz.Add("Red Star Earring");
		Ringz.Add("Red Star Ring");
		Ringz.Add("Restless Earring");
		Ringz.Add("Ring of Amethyst");
		Ringz.Add("Ring of Argent");
		Ringz.Add("Ring of Azure");
		Ringz.Add("Ring of Desiccation");
		Ringz.Add("Ring of Gules");
		Ringz.Add("Ring of Onyx");
		Ringz.Add("Ring of Pearl");
		Ringz.Add("Ring of Perseverance");
		Ringz.Add("Ring of Purpose");
		Ringz.Add("Ring of Ruby");
		Ringz.Add("Ring of Sable");
		Ringz.Add("Ring of Saphire");
		Ringz.Add("Rose Ring");
		Ringz.Add("Savior Ring");
		Ringz.Add("Sight Earring");
		Ringz.Add("Silver Ring");
		Ringz.Add("Stalwart Earring");
		Ringz.Add("Stonewall Ring");
		Ringz.Add("Vandal's Ring");
		Ringz.Add("Violet Ring");
		Ringz.Add("Wanderlust Ring");
		#endregion
	}

	private void SetDebilitationRes(int iPercent,int iDebilitation) {
		 string s = Debilitations[iDebilitation].text;
		s = s.Remove(s.Length - 1);
		Debilitations[iDebilitation].text = (Int32.Parse(s) + iPercent).ToString() + "%";
	}

	public void SetAll(int iPercent) {
		for(int i = 0; i < 13; i++) {
			SetDebilitationRes(iPercent, i);
		}
	}

	//Functions for switching equipmentpieces
	#region
	private void SwitchRing(int iRing) {
		//Subtract here
		switch (iCurrent[iRing + 7]-1) {
			case 2:
				SetDebilitationRes(-60, 8);
				break;
			case 6:
				SetDebilitationRes(-60, 6);
				break;
			case 7:
				SetDebilitationRes(-60, 0);
				break;
			case 8:
				SetAll(-25);
				break;
			case 9:
				SetDebilitationRes(-60, 4);
				break;
			case 10:
				SetDebilitationRes(-60, 1);
				break;
			case 11:
				SetDebilitationRes(-60, 3);
				break;
			case 15:
				SetDebilitationRes(-60, 10);
				break;
			case 16:
				SetDebilitationRes(-60, 9);
				break;
			case 18:
				SetDebilitationRes(-60, 5);
				break;
			case 19:
				SetDebilitationRes(-60, 12);
				break;
			case 26:
				SetDebilitationRes(-60, 2);
				break;
			case 40:
				chara.SetHp(-500);
				chara.SetSp(-500);
				break;
			case 41:
				SetDebilitationRes(-60, 7);
				break;
			case 43:
				SetDebilitationRes(-60, 11);
				break;
		}
		//Maths
		iCurrent[iRing + 7] = Rings[iRing].value;
		//Add here
		switch (iCurrent[iRing + 7]-1) {
			case 2:
				SetDebilitationRes(60, 8);
				break;
			case 6:
				SetDebilitationRes(60, 6);
				break;
			case 7:
				SetDebilitationRes(60, 0);
				break;
			case 8:
				SetAll(25);
				break;
			case 9:
				SetDebilitationRes(60, 4);
				break;
			case 10:
				SetDebilitationRes(60, 1);
				break;
			case 11:
				SetDebilitationRes(60, 3);
				break;
			case 15:
				SetDebilitationRes(60, 10);
				break;
			case 16:
				SetDebilitationRes(60, 9);
				break;
			case 18:
				SetDebilitationRes(60, 5);
				break;
			case 19:
				SetDebilitationRes(60, 12);
				break;
			case 26:
				SetDebilitationRes(60, 2);
				break;
			case 40:
				chara.SetHp(500);
				chara.SetSp(500);
				break;
			case 41:
				SetDebilitationRes(60, 7);
				break;
			case 43:
				SetDebilitationRes(60, 11);
				break;
		}
	}
	#endregion
}
