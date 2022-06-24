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
	private DropDownController[] EDD;
	private TMP_Dropdown[] Equipment;
	[Foldout("Equipment")] [SerializeField] public GameObject hArmor;
	[Foldout("Equipment")] [SerializeField] public GameObject tClothing;
	[Foldout("Equipment")] [SerializeField] public GameObject tArmor;
	[Foldout("Equipment")] [SerializeField] public GameObject aArmor;
	[Foldout("Equipment")] [SerializeField] public GameObject lClothing;
	[Foldout("Equipment")] [SerializeField] public GameObject lArmor;
	[Foldout("Equipment")] [SerializeField] public TMP_Dropdown cloak;
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
			lClothing.GetComponent<TMP_Dropdown>(),lArmor.GetComponent<TMP_Dropdown>(), cloak
		};
		EDD = new DropDownController[] {
			hArmor.GetComponent<DropDownController>(),tClothing.GetComponent<DropDownController>(),
			tArmor.GetComponent<DropDownController>(),aArmor.GetComponent<DropDownController>(),
			lClothing.GetComponent<DropDownController>(),lArmor.GetComponent<DropDownController>()
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
		//Headarmor
		#region
		foreach (string Head in Head) {
			Equipment[0].options.Add(new TMP_Dropdown.OptionData() { text = Head });
		}
		Equipment[0].onValueChanged.AddListener(delegate { SwitchHead(); });
		#endregion
		//Chestclothing
		#region
		foreach (string TCloth in TCloth) {
			Equipment[1].options.Add(new TMP_Dropdown.OptionData() { text = TCloth });
		}
		Equipment[1].onValueChanged.AddListener(delegate { SwitchTClothing(); });
		#endregion
		//Chestarmor
		#region
		foreach (string Chest in Chest) {
			Equipment[2].options.Add(new TMP_Dropdown.OptionData() { text = Chest });
		}
		Equipment[2].onValueChanged.AddListener(delegate { SwitchChest(); });
		#endregion
		//Armarmor
		#region
		foreach (string Arms in Arms) {
			Equipment[3].options.Add(new TMP_Dropdown.OptionData() { text = Arms });
		}
		Equipment[3].onValueChanged.AddListener(delegate { SwitchArms(); });
		#endregion
		//Legclothing
		#region
		foreach (string LCloth in LCloth) {
			Equipment[4].options.Add(new TMP_Dropdown.OptionData() { text = LCloth });
		}
		Equipment[4].onValueChanged.AddListener(delegate { SwitchLClothing(); });
		#endregion
		//Legarmor
		#region
		foreach (string Legs in Legs) {
				Equipment[5].options.Add(new TMP_Dropdown.OptionData() { text = Legs });
		}
		Equipment[5].onValueChanged.AddListener(delegate { SwitchLegs(); });
		#endregion
		//Cloaks
		#region
		foreach (string Cloak in Cloak) {
				Equipment[6].options.Add(new TMP_Dropdown.OptionData() { text = Cloak });
		}
		Equipment[6].onValueChanged.AddListener(delegate { SwitchCloak(); });
		#endregion
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
		//Chest Clothing
		#region
		TCloth.Add("Abyssinal Outfit");
		TCloth.Add("Alchemick Vest");
		TCloth.Add("Assembled Vest");
		TCloth.Add("Bandages");
		TCloth.Add("Blessed Vest");
		TCloth.Add("Bilaut");
		TCloth.Add("Braided Shirt");
		TCloth.Add("Brigandine Jerkin");
		TCloth.Add("Cassardi Shirt");
		TCloth.Add("Chain Mail");
		TCloth.Add("Chainmail Bracers");
		TCloth.Add("Cotton Tunic");
		TCloth.Add("Crimson Jerkin");
		TCloth.Add("Doublet");
		TCloth.Add("Dragonleather Vest");
		//only figtherbased [16]
		TCloth.Add("Faded Vest");
		TCloth.Add("Fine Cassardi Shirt");
		TCloth.Add("Forest Tunic");
		TCloth.Add("Gambeson");
		TCloth.Add("Hard Leather Plate");
		TCloth.Add("Hemp Shirt");
		TCloth.Add("Hunter's Shirt");
		//only Figtherbased [23]
		TCloth.Add("Iron Vest");
		TCloth.Add("Lady's Corset");
		TCloth.Add("Leather Chestguard");
		TCloth.Add("Light Outfit");
		TCloth.Add("Linen Shirt");
		TCloth.Add("Maiden's Camisole");
		TCloth.Add("Marshal's Bracers");
		TCloth.Add("Noblewomen's Corset");
		TCloth.Add("Patterned Gamberson");
		//Only Figtherbased [32]
		TCloth.Add("Plated Coat");
		TCloth.Add("Quilted Jerkin");
		TCloth.Add("Riveted Coat");
		TCloth.Add("Silver Chestplate");
		TCloth.Add("Silver Cuircas");
		//only fighterbased [37]
		TCloth.Add("Silver Vest");
		TCloth.Add("Traveler's Shirt");
		TCloth.Add("Trooper Outfit");
		TCloth.Add("Tunic");
		#endregion
		//Leg Clothing
		#region
		LCloth.Add("Alchemickal Hosen");
		LCloth.Add("Bandit Stalkers");
		LCloth.Add("Black Gaiters");
		LCloth.Add("Braided Hosen");
		LCloth.Add("Brown Laced Leggings");
		LCloth.Add("Brown Leathers");
		LCloth.Add("Cassardi Trousers");
		LCloth.Add("Cotton Hosen");
		LCloth.Add("Delta Guard");
		LCloth.Add("Denim Hosen");
		LCloth.Add("Evening Tights");
		LCloth.Add("Fine Cassadri Hosen");
		LCloth.Add("Full Chain Hosen");
		LCloth.Add("Half Chain Hosen");
		LCloth.Add("Hemp Hosen");
		LCloth.Add("Huntsman's Trousers");
		LCloth.Add("Iron Bandings");
		LCloth.Add("Laborer's Breeches");
		LCloth.Add("Laced Leggings");
		LCloth.Add("Leather Bandings");
		LCloth.Add("Seeker Thights");
		LCloth.Add("Short Pants");
		LCloth.Add("Silk Lingerie");
		LCloth.Add("Silk Tights");
		LCloth.Add("Silver Hosen");
		LCloth.Add("Traveler's Tights");
		LCloth.Add("Twisted Leathers");
		LCloth.Add("Urban Hosen");
		LCloth.Add("White Stockings");
		LCloth.Add("Worker's Pants");
		LCloth.Add("Yellow Gaiters");
		#endregion
		//Cloaks
		#region
		Cloak.Add("Adept's Mantle");
		Cloak.Add("Adventurer's Cloak");
		Cloak.Add("Alchemickal Cloak");
		Cloak.Add("Ancient Cape");
		Cloak.Add("BBI3 Cloak");
		Cloak.Add("Beastly Mantle");
		Cloak.Add("Conquerer's Mantle");
		Cloak.Add("Dignified Cape");
		Cloak.Add("Direwolf Cape");
		Cloak.Add("Divine Embrace");
		Cloak.Add("Dragon Knight's Cloak");
		Cloak.Add("Ebon Neck Wrap");
		Cloak.Add("Farewell Cloak");
		Cloak.Add("Feather Cape");
		Cloak.Add("Feral Cape");
		Cloak.Add("Gryphic Cloak");
		Cloak.Add("Harpy Cloak");
		Cloak.Add("Heresy Cloak");
		Cloak.Add("Hero's Cape");
		Cloak.Add("Knight's Mantle");
		Cloak.Add("Leather Cape");
		Cloak.Add("Lordly Cloak");
		Cloak.Add("Mahagony Cape");
		Cloak.Add("Monomi Neck Wrap");
		Cloak.Add("Nebula Cape");
		Cloak.Add("Nomad's Cloak");
		Cloak.Add("Paladin's Mantle");
		Cloak.Add("Pauldron");
		Cloak.Add("Royal Mantle");
		Cloak.Add("Scarlet Cape");
		Cloak.Add("Scholar's Cape");
		Cloak.Add("Shed Cape");
		Cloak.Add("Shoulder Cape");
		Cloak.Add("Sovereign's Mantle");
		Cloak.Add("Tattered Mantle");
		Cloak.Add("Violet Neck Wrap");
		Cloak.Add("Wyrm Hunt Mantle");
		#endregion
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

	public void OnPanelDisplay() {
		//help
		//Mage or Sorcerer
		if (chara.GetVocation().Equals("Mage") || chara.GetVocation().Equals("Mage")) {
			//Chest Clothing
			#region
			EDD[1].EnableOption(3, false);
			EDD[1].EnableOption(10, false);
			EDD[1].EnableOption(11, false);
			EDD[1].EnableOption(15, false);
			EDD[1].EnableOption(29, false);
			EDD[1].EnableOption(34, false);
			EDD[1].EnableOption(36, false);
			EDD[1].EnableOption(39, false);
			#endregion
			//Leg Clothing
			#region
			EDD[4].EnableOption(12, false);
			EDD[4].EnableOption(13, false);
			EDD[4].EnableOption(16, false);
			EDD[4].EnableOption(24, false);
			#endregion
		} else {
			//Chest Clothing
			#region
			EDD[1].EnableOption(3, true);
			EDD[1].EnableOption(10, true);
			EDD[1].EnableOption(11, true);
			EDD[1].EnableOption(15, true);
			EDD[1].EnableOption(29, true);
			EDD[1].EnableOption(34, true);
			EDD[1].EnableOption(36, true);
			EDD[1].EnableOption(39, true);
			#endregion
			//Leg Clothing
			#region
			EDD[4].EnableOption(12, true);
			EDD[4].EnableOption(13, true);
			EDD[4].EnableOption(16, true);
			EDD[4].EnableOption(24, true);
			#endregion
		}
		//Only Magick Vocation TCloth[6]

		if (!chara.GetGender()) {
			//Dissable all the female only options
			#region
			//Chest Clothing
			EDD[1].EnableOption(24, false);
			EDD[1].EnableOption(28, false);
			EDD[1].EnableOption(30, false);
			//Leg Clothing
			EDD[4].EnableOption(9, false);
			EDD[4].EnableOption(22, false);
			EDD[4].EnableOption(28, false);
			//Maiden's Petticoat
			//Berserkin
			//Flame Skirt
			//Framae Plate
			//Sultry Cowl
			//Sultry Pareo
			//Summery Cowl
			//Summery Pareo
			#endregion
		} else {
			//Enable all the female only options
			#region
			//Chest Clothing
			EDD[1].EnableOption(24, true);
			EDD[1].EnableOption(28, true);
			EDD[1].EnableOption(30, true);
			//Leg Clothing
			EDD[4].EnableOption(9, true);
			EDD[4].EnableOption(22, true);
			EDD[4].EnableOption(28, true);
			#endregion
		}
	}

	//Functions for switching equipmentpieces
	#region
	private void SwitchHead() {
	}
	private void SwitchTClothing() {
		switch (iCurrent[1]) {
			case 1:
				SetDebilitationRes(-36, 0);
				SetDebilitationRes(-33, 8);
				break;
			case 2:
				SetDebilitationRes(-35, 6);
				break;
			case 3:
				SetDebilitationRes(-24, 6);
				break;
			case 4:
				SetDebilitationRes(-15, 5);
				SetDebilitationRes(-15, 11);
				break;
			case 5:
				SetDebilitationRes(-24, 8);
				break;
			case 6:
				SetDebilitationRes(-20, 3);
				break;
			case 7:
				SetDebilitationRes(-35, 11);
				break;
			case 8:
				SetDebilitationRes(-30, 2);
				break;
			case 11:
				chara.SetAtk(-3);
				SetDebilitationRes(-28, 4);
				break;
			case 13:
				SetDebilitationRes(-30, 7);
				break;
			case 15:
				SetDebilitationRes(-36, 8);
				break;
			case 22:
				SetDebilitationRes(-40, 4);
				break;
			case 23:
				SetDebilitationRes(-21, 2);
				break;
			case 24:
				SetDebilitationRes(-30, 3);
				break;
			case 25:
				SetDebilitationRes(-20, 5);
				break;
			case 27:
				SetDebilitationRes(-15, 2);
				break;
			case 28:
				SetDebilitationRes(-40, 0);
				break;
			case 29:
				chara.SetAtk(-5);
				SetDebilitationRes(-25, 4);
				break;
			case 30:
				SetDebilitationRes(-24, 3);
				SetDebilitationRes(-24, 8);
				break;
			case 31:
				SetDebilitationRes(-24, 2);
				SetDebilitationRes(-24, 4);
				SetDebilitationRes(-6, 9);
				break;
			case 32:
				SetDebilitationRes(-35, 7);
				break;
			case 35:
				SetDebilitationRes(-20, 8);
				break;
			case 36:
				SetDebilitationRes(-21, 8);
				break;
			case 37:
				SetDebilitationRes(-32, 1);
				break;
			case 39:
				SetDebilitationRes(-35, 5);
				break;
		}
		iCurrent[1] = Equipment[1].value;
		switch (iCurrent[1]) {
			case 1:
				SetDebilitationRes(36, 0);
				SetDebilitationRes(33, 8);
				break;
			case 2:
				SetDebilitationRes(35, 6);
				break;
			case 3:
				SetDebilitationRes(24, 6);
				break;
			case 4:
				SetDebilitationRes(15, 5);
				SetDebilitationRes(15, 11);
				break;
			case 5:
				SetDebilitationRes(24, 8);
				break;
			case 6:
				SetDebilitationRes(20, 3);
				break;
			case 7:
				SetDebilitationRes(35, 11);
				break;
			case 8:
				SetDebilitationRes(30, 2);
				break;
			case 11:
				chara.SetAtk(3);
				SetDebilitationRes(28, 4);
				break;
			case 13:
				SetDebilitationRes(30, 7);
				break;
			case 15:
				SetDebilitationRes(36, 8);
				break;
			case 22:
				SetDebilitationRes(40, 4);
				break;
			case 23:
				SetDebilitationRes(21, 2);
				break;
			case 24:
				SetDebilitationRes(30, 3);
				break;
			case 25:
				SetDebilitationRes(20, 5);
				break;
			case 27:
				SetDebilitationRes(15, 2);
				break;
			case 28:
				SetDebilitationRes(40, 0);
				break;
			case 29:
				chara.SetAtk(5);
				SetDebilitationRes(25, 4);
				break;
			case 30:
				SetDebilitationRes(24, 3);
				SetDebilitationRes(24, 8);
				break;
			case 31:
				SetDebilitationRes(24, 2);
				SetDebilitationRes(24, 4);
				SetDebilitationRes(6, 9);
				break;
			case 32:
				SetDebilitationRes(35, 7);
				break;
			case 35:
				SetDebilitationRes(20, 8);
				break;
			case 36:
				SetDebilitationRes(21, 8);
				break;
			case 37:
				SetDebilitationRes(32, 1);
				break;
			case 39:
				SetDebilitationRes(35, 5);
				break;
		}
	}
	private void SwitchChest() {
	}
	private void SwitchArms() {
	}
	private void SwitchLClothing() {
		switch (iCurrent[4]) {
			case 1:
				SetDebilitationRes(-30, 6);
				break;
			case 2:
				SetDebilitationRes(-30, 4);
				break;
			case 3:
				SetDebilitationRes(-25, 7);
				break;
			case 4:
				SetDebilitationRes(-30, 11);
				break;
			case 5:
				SetDebilitationRes(-25, 5);
				break;
			case 6:
				SetDebilitationRes(-30, 6);
				break;
			case 9:
				SetDebilitationRes(-45, 0);
				SetDebilitationRes(-45, 1);
				break;
			case 10:
				SetDebilitationRes(-20, 5);
				break;
			case 11:
				SetDebilitationRes(-35, 2);
				break;
			case 16:
				SetDebilitationRes(-35, 4);
				break;
			case 17:
				SetDebilitationRes(-30, 2);
				break;
			case 18:
				SetDebilitationRes(-25, 4);
				SetDebilitationRes(-20, 2);
				break;
			case 19:
				SetDebilitationRes(-16, 5);
				break;
			case 20:
				SetDebilitationRes(-30, 5);
				SetDebilitationRes(-24, 4);
				break;
			case 21:
				SetDebilitationRes(-20, 4);
				break;
			case 23:
				SetDebilitationRes(-45, 10);
				SetDebilitationRes(-45, 12);
				break;
			case 24:
				SetDebilitationRes(-45, 3);
				SetDebilitationRes(-45, 4);
				break;
			case 25:
				SetDebilitationRes(-18, 8);
				break;
			case 26:
				SetDebilitationRes(-24, 9);
				SetDebilitationRes(-15, 4);
				break;
			case 28:
				SetDebilitationRes(-35, 0);
				break;
			case 29:
				SetDebilitationRes(-35, 7);
				break;
			case 30:
				SetDebilitationRes(-30, 3);
				break;
			case 31:
				SetDebilitationRes(-16, 2);
				break;
		}
		iCurrent[4] = Equipment[4].value;
		switch (iCurrent[4]) {
			case 1:
				SetDebilitationRes(30, 6);
				break;
			case 2:
				SetDebilitationRes(30, 4);
				break;
			case 3:
				SetDebilitationRes(25, 7);
				break;
			case 4:
				SetDebilitationRes(30, 11);
				break;
			case 5:
				SetDebilitationRes(25, 5);
				break;
			case 6:
				SetDebilitationRes(30, 6);
				break;
			case 9:
				SetDebilitationRes(45, 0);
				SetDebilitationRes(45, 1);
				break;
			case 10:
				SetDebilitationRes(20, 5);
				break;
			case 11:
				SetDebilitationRes(35, 2);
				break;
			case 16:
				SetDebilitationRes(35, 4);
				break;
			case 17:
				SetDebilitationRes(30, 2);
				break;
			case 18:
				SetDebilitationRes(25, 4);
				SetDebilitationRes(20, 2);
				break;
			case 19:
				SetDebilitationRes(16, 5);
				break;
			case 20:
				SetDebilitationRes(30, 5);
				SetDebilitationRes(24, 4);
				break;
			case 21:
				SetDebilitationRes(20, 4);
				break;
			case 23:
				SetDebilitationRes(45, 10);
				SetDebilitationRes(45, 12);
				break;
			case 24:
				SetDebilitationRes(45, 3);
				SetDebilitationRes(45, 4);
				break;
			case 25:
				SetDebilitationRes(18, 8);
				break;
			case 26:
				SetDebilitationRes(24, 9);
				SetDebilitationRes(15, 4);
				break;
			case 28:
				SetDebilitationRes(35, 0);
				break;
			case 29:
				SetDebilitationRes(35, 7);
				break;
			case 30:
				SetDebilitationRes(30, 3);
				break;
			case 31:
				SetDebilitationRes(16, 2);
				break;
		}
	}
	private void SwitchLegs() {
	}
	private void SwitchCloak() {
		//Remove
		switch (iCurrent[6]-1) {
			case 0:
				SetDebilitationRes(-56, 3);
				SetDebilitationRes(-56, 7);
				break;
			case 1:
				SetDebilitationRes(-35, 6);
				break;
			case 2:
				SetDebilitationRes(-40, 6);
				break;
			case 3:
				SetDebilitationRes(-45, 8);
				SetDebilitationRes(-40, 10);
				SetDebilitationRes(-40, 12);
				break;
			case 4:
				SetDebilitationRes(-100, 1);
				break;
			case 5:
				SetDebilitationRes(-32, 5);
				SetDebilitationRes(-32, 6);
				SetDebilitationRes(-32, 2);
				break;
			case 6:
				SetDebilitationRes(-32, 0);
				SetDebilitationRes(-32, 4);
				SetDebilitationRes(-32, 8);
				break;
			case 7:
				SetDebilitationRes(-45, 0);
				break;
			case 8:
				SetDebilitationRes(-35, 5);
				break;
			case 9:
				SetDebilitationRes(-56, 0);
				SetDebilitationRes(-56, 8);
				SetDebilitationRes(-40, 9);
				SetDebilitationRes(-40, 11);
				break;
			case 10:
				SetDebilitationRes(-48, 4);
				SetDebilitationRes(-45, 9);
				break;
			case 11:
				SetDebilitationRes(-35, 7);
				break;
			case 12:
				SetDebilitationRes(-36, 6);
				SetDebilitationRes(-36, 9);
				SetDebilitationRes(-36, 10);
				break;
			case 13:
				SetDebilitationRes(-35, 3);
				break;
			case 14:
				SetDebilitationRes(-45, 5);
				break;
			case 15:
				SetDebilitationRes(-40, 7);
				break;
			case 16:
				SetDebilitationRes(-40, 2);
				break;
			case 17:
				SetDebilitationRes(-40, 8);
				SetDebilitationRes(-32, 0);
				break;
			case 18:
				SetDebilitationRes(-40, 4);
				SetDebilitationRes(-32, 8);
				break;
			case 19:
				SetDebilitationRes(-84, 8);
				SetDebilitationRes(-42, 0);
				break;
			case 20:
				SetDebilitationRes(-36, 6);
				SetDebilitationRes(-36, 10);
				SetDebilitationRes(-36, 12);
				break;
			case 21:
				SetDebilitationRes(-48, 10);
				SetDebilitationRes(-45, 7);
				break;
			case 22:
				SetDebilitationRes(-36, 10);
				SetDebilitationRes(-36, 12);
				SetDebilitationRes(-24, 9);
				SetDebilitationRes(-24, 11);
				break;
			case 23:
				SetDebilitationRes(-35, 2);
				break;
			case 24:
				SetDebilitationRes(-40, 7);
				SetDebilitationRes(-32, 6);
				break;
			case 25:
				SetDebilitationRes(-56, 1);
				break;
			case 26:
				SetDebilitationRes(-56, 5);
				SetDebilitationRes(-56, 6);
				break;
			case 27:
				SetDebilitationRes(-64, 1);
				SetDebilitationRes(-40, 8);
				break;
			case 28:
				SetDebilitationRes(-40, 4);
				break;
			case 29:
				SetDebilitationRes(-45, 8);
				break;
			case 30:
				SetDebilitationRes(-40, 5);
				break;
			case 31:
				chara.SetHp(-30);
				break;
			case 32:
				SetDebilitationRes(-48, 11);
				SetDebilitationRes(-48, 12);
				break;
			case 33:
				chara.SetSp(-30);
				break;
			case 34:
				chara.SetAtk(-10);
				SetDebilitationRes(-56, 1);
				SetDebilitationRes(-56, 4);
				break;
			case 35:
				SetAll(-15);
				SetDebilitationRes(15, 9);
				SetDebilitationRes(15, 10);
				SetDebilitationRes(15, 11);
				SetDebilitationRes(15, 12);
				break;
			case 36:
				SetDebilitationRes(-40, 4);
				break;
			case 37:
				SetDebilitationRes(-60, 7);
				SetDebilitationRes(-60, 4);
				break;
		}
		iCurrent[6] = Equipment[6].value;
		//Add
		switch (iCurrent[6] - 1) {
			case 0:
				SetDebilitationRes(56, 3);
				SetDebilitationRes(56, 7);
				break;
			case 1:
				SetDebilitationRes(35, 6);
				break;
			case 2:
				SetDebilitationRes(40, 6);
				break;
			case 3:
				SetDebilitationRes(45, 8);
				SetDebilitationRes(40, 10);
				SetDebilitationRes(40, 12);
				break;
			case 4:
				SetDebilitationRes(100, 1);
				break;
			case 5:
				SetDebilitationRes(32, 5);
				SetDebilitationRes(32, 6);
				SetDebilitationRes(32, 2);
				break;
			case 6:
				SetDebilitationRes(32, 0);
				SetDebilitationRes(32, 4);
				SetDebilitationRes(32, 8);
				break;
			case 7:
				SetDebilitationRes(45, 0);
				break;
			case 8:
				SetDebilitationRes(35, 5);
				break;
			case 9:
				SetDebilitationRes(56, 0);
				SetDebilitationRes(56, 8);
				SetDebilitationRes(40, 9);
				SetDebilitationRes(40, 11);
				break;
			case 10:
				SetDebilitationRes(48, 4);
				SetDebilitationRes(45, 9);
				break;
			case 11:
				SetDebilitationRes(35, 7);
				break;
			case 12:
				SetDebilitationRes(36, 6);
				SetDebilitationRes(36, 9);
				SetDebilitationRes(36, 10);
				break;
			case 13:
				SetDebilitationRes(35, 3);
				break;
			case 14:
				SetDebilitationRes(45, 5);
				break;
			case 15:
				SetDebilitationRes(40, 7);
				break;
			case 16:
				SetDebilitationRes(40, 2);
				break;
			case 17:
				SetDebilitationRes(40, 8);
				SetDebilitationRes(32, 0);
				break;
			case 18:
				SetDebilitationRes(40, 4);
				SetDebilitationRes(32, 8);
				break;
			case 19:
				SetDebilitationRes(84, 8);
				SetDebilitationRes(42, 0);
				break;
			case 20:
				SetDebilitationRes(36, 6);
				SetDebilitationRes(36, 10);
				SetDebilitationRes(36, 12);
				break;
			case 21:
				SetDebilitationRes(48, 10);
				SetDebilitationRes(45, 7);
				break;
			case 22:
				SetDebilitationRes(36, 10);
				SetDebilitationRes(36, 12);
				SetDebilitationRes(24, 9);
				SetDebilitationRes(24, 11);
				break;
			case 23:
				SetDebilitationRes(35, 2);
				break;
			case 24:
				SetDebilitationRes(40, 7);
				SetDebilitationRes(32, 6);
				break;
			case 25:
				SetDebilitationRes(56, 1);
				break;
			case 26:
				SetDebilitationRes(56, 5);
				SetDebilitationRes(56, 6);
				break;
			case 27:
				SetDebilitationRes(64, 1);
				SetDebilitationRes(40, 8);
				break;
			case 28:
				SetDebilitationRes(40, 4);
				break;
			case 29:
				SetDebilitationRes(45, 8);
				break;
			case 30:
				SetDebilitationRes(40, 5);
				break;
			case 31:
				chara.SetHp(30);
				break;
			case 32:
				SetDebilitationRes(48, 11);
				SetDebilitationRes(48, 12);
				break;
			case 33:
				chara.SetSp(30);
				break;
			case 34:
				chara.SetAtk(10);
				SetDebilitationRes(56, 1);
				SetDebilitationRes(56, 4);
				break;
			case 35:
				SetAll(15);
				SetDebilitationRes(-15, 9);
				SetDebilitationRes(-15, 10);
				SetDebilitationRes(-15, 11);
				SetDebilitationRes(-15, 12);
				break;
			case 36:
				SetDebilitationRes(40, 4);
				break;
			case 37:
				SetDebilitationRes(60, 7);
				SetDebilitationRes(60, 4);
				break;
		}
	}
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
