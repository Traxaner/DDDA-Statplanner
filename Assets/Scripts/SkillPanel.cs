using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Homebrew;
using TMPro;

public class SkillPanel : MonoBehaviour, IDataPersistance {
	//everything for setting up the panels right
	#region
	[Foldout("Basic")] [SerializeField] private CCharacter chara;
	[Foldout("Basic")] [SerializeField] private GameObject Fighter;
	[Foldout("Basic")] [SerializeField] private GameObject Strider;
	[Foldout("Basic")] [SerializeField] private GameObject Mage;
	[Foldout("Basic")] [SerializeField] private GameObject Warrior;
	[Foldout("Basic")] [SerializeField] private GameObject Ranger;
	[Foldout("Basic")] [SerializeField] private GameObject Sorcerer;
	[Foldout("Basic")] [SerializeField] private GameObject Assassin;
	[Foldout("Basic")] [SerializeField] private GameObject MArcher;
	[Foldout("Basic")] [SerializeField] private GameObject MKinght;
	private string sVocation="a", pVocation = "s";
	private bool bArisen;
	private int[] iSave;
	#endregion

	//Basic skilllists
	#region
	List<string> sword = new List<string>();
	List<string> shield= new List<string>();
	List<string> dagger= new List<string>();
	List<string> sbow= new List<string>();
	List<string> spells= new List<string>();
	List<string> twohand= new List<string>();
	List<string> lbow= new List<string>();
	List<string> mbow= new List<string>();
	List<string> mshield= new List<string>();
	#endregion

	//Pain and Suffering 1
	//Fighter
	#region
	private DropDownController[] FDDC1 = new DropDownController[3];
	private DropDownController[] FDDC2 = new DropDownController[3];
	private TMP_Dropdown[] FDD1 = new TMP_Dropdown[3];
	private TMP_Dropdown[] FDD2 = new TMP_Dropdown[3];
	[Foldout("Fighter")] [SerializeField] private GameObject FS1;
	[Foldout("Fighter")] [SerializeField] private GameObject FS2;
	[Foldout("Fighter")] [SerializeField] private GameObject FS3;
	[Foldout("Fighter")] [SerializeField] private GameObject FS4;
	[Foldout("Fighter")] [SerializeField] private GameObject FS5;
	[Foldout("Fighter")] [SerializeField] private GameObject FS6;
	#endregion
	//Strider
	#region
	private DropDownController[] SDDC1 = new DropDownController[3];
	private DropDownController[] SDDC2 = new DropDownController[3];
	private TMP_Dropdown[] SDD1 = new TMP_Dropdown[3];
	private TMP_Dropdown[] SDD2 = new TMP_Dropdown[3];
	[Foldout("Strider")] [SerializeField] private GameObject SS1;
	[Foldout("Strider")] [SerializeField] private GameObject SS2;
	[Foldout("Strider")] [SerializeField] private GameObject SS3;
	[Foldout("Strider")] [SerializeField] private GameObject SS4;
	[Foldout("Strider")] [SerializeField] private GameObject SS5;
	[Foldout("Strider")] [SerializeField] private GameObject SS6;
	#endregion
	//Mage
	#region
	private DropDownController[] MDDC = new DropDownController[6];
	private TMP_Dropdown[] MDD = new TMP_Dropdown[6];
	[Foldout("Mage")] [SerializeField] private GameObject MS1;
	[Foldout("Mage")] [SerializeField] private GameObject MS2;
	[Foldout("Mage")] [SerializeField] private GameObject MS3;
	[Foldout("Mage")] [SerializeField] private GameObject MS4;
	[Foldout("Mage")] [SerializeField] private GameObject MS5;
	[Foldout("Mage")] [SerializeField] private GameObject MS6;
	#endregion
	//Warrior
	#region
	private DropDownController[] WDDC = new DropDownController[3];
	private TMP_Dropdown[] WDD = new TMP_Dropdown[3];
	[Foldout("Warrior")] [SerializeField] private GameObject WS1;
	[Foldout("Warrior")] [SerializeField] private GameObject WS2;
	[Foldout("Warrior")] [SerializeField] private GameObject WS3;
	#endregion
	//Ranger
	#region
	private DropDownController[] RDDC1 = new DropDownController[3];
	private DropDownController[] RDDC2 = new DropDownController[3];
	private TMP_Dropdown[] RDD1 = new TMP_Dropdown[3];
	private TMP_Dropdown[] RDD2 = new TMP_Dropdown[3];
	[Foldout("Ranger")] [SerializeField] private GameObject RS1;
	[Foldout("Ranger")] [SerializeField] private GameObject RS2;
	[Foldout("Ranger")] [SerializeField] private GameObject RS3;
	[Foldout("Ranger")] [SerializeField] private GameObject RS4;
	[Foldout("Ranger")] [SerializeField] private GameObject RS5;
	[Foldout("Ranger")] [SerializeField] private GameObject RS6;
	#endregion
	//Sorcerer
	#region
	private DropDownController[] SoDDC = new DropDownController[6];
	private TMP_Dropdown[] SoDD = new TMP_Dropdown[6];
	[Foldout("Sorcerer")] [SerializeField] private GameObject SoS1;
	[Foldout("Sorcerer")] [SerializeField] private GameObject SoS2;
	[Foldout("Sorcerer")] [SerializeField] private GameObject SoS3;
	[Foldout("Sorcerer")] [SerializeField] private GameObject SoS4;
	[Foldout("Sorcerer")] [SerializeField] private GameObject SoS5;
	[Foldout("Sorcerer")] [SerializeField] private GameObject SoS6;
	#endregion
	//Assassin
	#region
	private DropDownController[] ADDC1 = new DropDownController[3];
	private DropDownController[] ADDC2 = new DropDownController[3];
	private DropDownController[] ADDC3 = new DropDownController[3];
	private DropDownController[] ADDC4 = new DropDownController[3];
	private TMP_Dropdown[] ADD1 = new TMP_Dropdown[3];
	private TMP_Dropdown[] ADD2 = new TMP_Dropdown[3];
	private TMP_Dropdown[] ADD3 = new TMP_Dropdown[3];
	private TMP_Dropdown[] ADD4 = new TMP_Dropdown[3];
	[Foldout("Assassin")] [SerializeField] private GameObject AS1;
	[Foldout("Assassin")] [SerializeField] private GameObject AS2;
	[Foldout("Assassin")] [SerializeField] private GameObject AS3;
	[Foldout("Assassin")] [SerializeField] private GameObject AS4;
	[Foldout("Assassin")] [SerializeField] private GameObject AS5;
	[Foldout("Assassin")] [SerializeField] private GameObject AS6;
	[Foldout("Assassin")] [SerializeField] private GameObject AS7;
	[Foldout("Assassin")] [SerializeField] private GameObject AS8;
	[Foldout("Assassin")] [SerializeField] private GameObject AS9;
	[Foldout("Assassin")] [SerializeField] private GameObject AS10;
	[Foldout("Assassin")] [SerializeField] private GameObject AS11;
	[Foldout("Assassin")] [SerializeField] private GameObject AS12;
	#endregion
	//Magick Archer
	#region
	private DropDownController[] MADDC1 = new DropDownController[3];
	private DropDownController[] MADDC2 = new DropDownController[3];
	private DropDownController[] MADDC3 = new DropDownController[3];
	private TMP_Dropdown[] MADD1 = new TMP_Dropdown[3];
	private TMP_Dropdown[] MADD2 = new TMP_Dropdown[3];
	private TMP_Dropdown[] MADD3 = new TMP_Dropdown[3];
	[Foldout("Magick Archer")] [SerializeField] private GameObject MAS1;
	[Foldout("Magick Archer")] [SerializeField] private GameObject MAS2;
	[Foldout("Magick Archer")] [SerializeField] private GameObject MAS3;
	[Foldout("Magick Archer")] [SerializeField] private GameObject MAS4;
	[Foldout("Magick Archer")] [SerializeField] private GameObject MAS5;
	[Foldout("Magick Archer")] [SerializeField] private GameObject MAS6;
	[Foldout("Magick Archer")] [SerializeField] private GameObject MAS7;
	[Foldout("Magick Archer")] [SerializeField] private GameObject MAS8;
	[Foldout("Magick Archer")] [SerializeField] private GameObject MAS9;
	#endregion
	//Mystic Knight
	#region
	private DropDownController[] MKDDC1 = new DropDownController[3];
	private DropDownController[] MKDDC2 = new DropDownController[3];
	private DropDownController[] MKDDC3 = new DropDownController[3];
	private TMP_Dropdown[] MKDD1 = new TMP_Dropdown[3];
	private TMP_Dropdown[] MKDD2 = new TMP_Dropdown[3];
	private TMP_Dropdown[] MKDD3 = new TMP_Dropdown[3];
	[Foldout("Mystic Knight")] [SerializeField] private GameObject MKS1;
	[Foldout("Mystic Knight")] [SerializeField] private GameObject MKS2;
	[Foldout("Mystic Knight")] [SerializeField] private GameObject MKS3;
	[Foldout("Mystic Knight")] [SerializeField] private GameObject MKS4;
	[Foldout("Mystic Knight")] [SerializeField] private GameObject MKS5;
	[Foldout("Mystic Knight")] [SerializeField] private GameObject MKS6;
	[Foldout("Mystic Knight")] [SerializeField] private GameObject MKS7;
	[Foldout("Mystic Knight")] [SerializeField] private GameObject MKS8;
	[Foldout("Mystic Knight")] [SerializeField] private GameObject MKS9;
	#endregion

	// Start is called before the first frame update
	void Start() {
		if (chara.gameObject.CompareTag("Arisen")) {
			bArisen = true;
			iSave=new int[63];
		} else {
			bArisen = false;
			iSave = new int[33];
		}
		PanelsUpdate();
		TheLists();
		Pain();
	}

	private void Pain() {
		//Fighter
		#region
		FDD1[0] = FS1.GetComponent<TMP_Dropdown>();
		FDD1[1] = FS2.GetComponent<TMP_Dropdown>();
		FDD1[2] = FS3.GetComponent<TMP_Dropdown>();
		FDD2[0] = FS4.GetComponent<TMP_Dropdown>();
		FDD2[1] = FS5.GetComponent<TMP_Dropdown>();
		FDD2[2] = FS6.GetComponent<TMP_Dropdown>();
		FDDC1[0] = FS1.GetComponent<DropDownController>();
		FDDC1[1] = FS2.GetComponent<DropDownController>();
		FDDC1[2] = FS3.GetComponent<DropDownController>();
		FDDC2[0] = FS4.GetComponent<DropDownController>();
		FDDC2[1] = FS5.GetComponent<DropDownController>();
		FDDC2[2] = FS6.GetComponent<DropDownController>();
		#endregion
		//Strider
		#region
		SDD1[0] = SS1.GetComponent<TMP_Dropdown>();
		SDD1[1] = SS2.GetComponent<TMP_Dropdown>();
		SDD1[2] = SS3.GetComponent<TMP_Dropdown>();
		SDD2[0] = SS4.GetComponent<TMP_Dropdown>();
		SDD2[1] = SS5.GetComponent<TMP_Dropdown>();
		SDD2[2] = SS6.GetComponent<TMP_Dropdown>();
		SDDC1[0] = SS1.GetComponent<DropDownController>();
		SDDC1[1] = SS2.GetComponent<DropDownController>();
		SDDC1[2] = SS3.GetComponent<DropDownController>();
		SDDC2[0] = SS4.GetComponent<DropDownController>();
		SDDC2[1] = SS5.GetComponent<DropDownController>();
		SDDC2[2] = SS6.GetComponent<DropDownController>();
		#endregion
		//Mage
		#region
		MDD[0] = MS1.GetComponent<TMP_Dropdown>();
		MDD[1] = MS2.GetComponent<TMP_Dropdown>();
		MDD[2] = MS3.GetComponent<TMP_Dropdown>();
		MDD[3] = MS4.GetComponent<TMP_Dropdown>();
		MDD[4] = MS5.GetComponent<TMP_Dropdown>();
		MDD[5] = MS6.GetComponent<TMP_Dropdown>();
		MDDC[0] = MS1.GetComponent<DropDownController>();
		MDDC[1] = MS2.GetComponent<DropDownController>();
		MDDC[2] = MS3.GetComponent<DropDownController>();
		MDDC[3] = MS4.GetComponent<DropDownController>();
		MDDC[4] = MS5.GetComponent<DropDownController>();
		MDDC[5] = MS6.GetComponent<DropDownController>();
		#endregion
		//Warrior
		#region
		WDD[0] = WS1.GetComponent<TMP_Dropdown>();
		WDD[1] = WS2.GetComponent<TMP_Dropdown>();
		WDD[2] = WS3.GetComponent<TMP_Dropdown>();
		WDDC[0] = WS1.GetComponent<DropDownController>();
		WDDC[1] = WS2.GetComponent<DropDownController>();
		WDDC[2] = WS3.GetComponent<DropDownController>();
		#endregion
		//Ranger
		#region
		RDD1[0] = RS1.GetComponent<TMP_Dropdown>();
		RDD1[1] = RS2.GetComponent<TMP_Dropdown>();
		RDD1[2] = RS3.GetComponent<TMP_Dropdown>();
		RDD2[0] = RS4.GetComponent<TMP_Dropdown>();
		RDD2[1] = RS5.GetComponent<TMP_Dropdown>();
		RDD2[2] = RS6.GetComponent<TMP_Dropdown>();
		RDDC1[0] = RS1.GetComponent<DropDownController>();
		RDDC1[1] = RS2.GetComponent<DropDownController>();
		RDDC1[2] = RS3.GetComponent<DropDownController>();
		RDDC2[0] = RS4.GetComponent<DropDownController>();
		RDDC2[1] = RS5.GetComponent<DropDownController>();
		RDDC2[2] = RS6.GetComponent<DropDownController>();
		#endregion
		//Sorcerer
		#region
		SoDD[0] = SoS1.GetComponent<TMP_Dropdown>();
		SoDD[1] = SoS2.GetComponent<TMP_Dropdown>();
		SoDD[2] = SoS3.GetComponent<TMP_Dropdown>();
		SoDD[3] = SoS4.GetComponent<TMP_Dropdown>();
		SoDD[4] = SoS5.GetComponent<TMP_Dropdown>();
		SoDD[5] = SoS6.GetComponent<TMP_Dropdown>();
		SoDDC[0] = SoS1.GetComponent<DropDownController>();
		SoDDC[1] = SoS2.GetComponent<DropDownController>();
		SoDDC[2] = SoS3.GetComponent<DropDownController>();
		SoDDC[3] = SoS4.GetComponent<DropDownController>();
		SoDDC[4] = SoS5.GetComponent<DropDownController>();
		SoDDC[5] = SoS6.GetComponent<DropDownController>();
		#endregion
		//Assassin
		#region
		ADD1[0] = AS1.GetComponent<TMP_Dropdown>();
		ADD1[1] = AS2.GetComponent<TMP_Dropdown>();
		ADD1[2] = AS3.GetComponent<TMP_Dropdown>();
		ADD2[0] = AS4.GetComponent<TMP_Dropdown>();
		ADD2[1] = AS5.GetComponent<TMP_Dropdown>();
		ADD2[2] = AS6.GetComponent<TMP_Dropdown>();
		ADD3[0] = AS7.GetComponent<TMP_Dropdown>();
		ADD3[1] = AS8.GetComponent<TMP_Dropdown>();
		ADD3[2] = AS9.GetComponent<TMP_Dropdown>();
		ADD4[0] = AS10.GetComponent<TMP_Dropdown>();
		ADD4[1] = AS11.GetComponent<TMP_Dropdown>();
		ADD4[2] = AS12.GetComponent<TMP_Dropdown>();
		ADDC1[0] = AS1.GetComponent<DropDownController>();
		ADDC1[1] = AS2.GetComponent<DropDownController>();
		ADDC1[2] = AS3.GetComponent<DropDownController>();
		ADDC2[0] =AS4.GetComponent<DropDownController>();
		ADDC2[1] = AS5.GetComponent<DropDownController>();
		ADDC2[2] =AS6.GetComponent<DropDownController>();
		ADDC3[0] = AS7.GetComponent<DropDownController>();
		ADDC3[1] = AS8.GetComponent<DropDownController>();
		ADDC3[2] = AS9.GetComponent<DropDownController>();
		ADDC4[0] =AS10.GetComponent<DropDownController>();
		ADDC4[1] = AS11.GetComponent<DropDownController>();
		ADDC4[2] =AS12.GetComponent<DropDownController>();
		#endregion
		//Magick Archer
		#region
		MADD1[0] = MAS1.GetComponent<TMP_Dropdown>();
		MADD1[1] = MAS2.GetComponent<TMP_Dropdown>();
		MADD1[2] = MAS3.GetComponent<TMP_Dropdown>();
		MADD2[0] = MAS4.GetComponent<TMP_Dropdown>();
		MADD2[1] = MAS5.GetComponent<TMP_Dropdown>();
		MADD2[2] = MAS6.GetComponent<TMP_Dropdown>();
		MADD3[0] = MAS7.GetComponent<TMP_Dropdown>();
		MADD3[1] = MAS8.GetComponent<TMP_Dropdown>();
		MADD3[2] = MAS9.GetComponent<TMP_Dropdown>();
		MADDC1[0] = MAS1.GetComponent<DropDownController>();
		MADDC1[1] = MAS2.GetComponent<DropDownController>();
		MADDC1[2] = MAS3.GetComponent<DropDownController>();
		MADDC2[0] = MAS4.GetComponent<DropDownController>();
		MADDC2[1] = MAS5.GetComponent<DropDownController>();
		MADDC2[2] = MAS6.GetComponent<DropDownController>();
		MADDC3[0] = MAS7.GetComponent<DropDownController>();
		MADDC3[1] = MAS8.GetComponent<DropDownController>();
		MADDC3[2] = MAS9.GetComponent<DropDownController>();
		#endregion
		//Mystic Knight
		#region
		MKDD1[0] = MKS1.GetComponent<TMP_Dropdown>();
		MKDD1[1] = MKS2.GetComponent<TMP_Dropdown>();
		MKDD1[2] = MKS3.GetComponent<TMP_Dropdown>();
		MKDD2[0] = MKS4.GetComponent<TMP_Dropdown>();
		MKDD2[1] = MKS5.GetComponent<TMP_Dropdown>();
		MKDD2[2] = MKS6.GetComponent<TMP_Dropdown>();
		MKDD3[0] = MKS7.GetComponent<TMP_Dropdown>();
		MKDD3[1] = MKS8.GetComponent<TMP_Dropdown>();
		MKDD3[2] = MKS9.GetComponent<TMP_Dropdown>();
		MKDDC1[0] = MKS1.GetComponent<DropDownController>();
		MKDDC1[1] = MKS2.GetComponent<DropDownController>();
		MKDDC1[2] = MKS3.GetComponent<DropDownController>();
		MKDDC2[0] = MKS4.GetComponent<DropDownController>();
		MKDDC2[1] = MKS5.GetComponent<DropDownController>();
		MKDDC2[2] = MKS6.GetComponent<DropDownController>();
		MKDDC3[0] = MKS7.GetComponent<DropDownController>();
		MKDDC3[1] = MKS8.GetComponent<DropDownController>();
		MKDDC3[2] = MKS9.GetComponent<DropDownController>();
		#endregion

		for (int i = 0; i < 6; i++) {
			//Mage
			#region
			MDD[i].options.Clear();
			MDD[i].options.Add(new TMP_Dropdown.OptionData() { text = " - " });
			#endregion
			//Sorcerer
			#region
			SoDD[i].options.Clear();
			SoDD[i].options.Add(new TMP_Dropdown.OptionData() { text = " - " });
			#endregion
			if (i < 3) {
				//Figther
				#region
				FDD1[i].options.Clear();
				FDD2[i].options.Clear();
				FDD1[i].options.Add(new TMP_Dropdown.OptionData() { text = " - " });
				FDD2[i].options.Add(new TMP_Dropdown.OptionData() { text = " - " });
				#endregion
				//Strider
				#region
				SDD1[i].options.Clear();
				SDD2[i].options.Clear();
				SDD1[i].options.Add(new TMP_Dropdown.OptionData() { text = " - " });
				SDD2[i].options.Add(new TMP_Dropdown.OptionData() { text = " - " });
				#endregion
				//Warrior
				#region
				WDD[i].options.Clear();
				WDD[i].options.Add(new TMP_Dropdown.OptionData() { text = " - " });
				foreach (string twohand in twohand) {
					WDD[i].options.Add(new TMP_Dropdown.OptionData() { text = twohand });
				}
				#endregion
				//Ranger
				#region
				RDD1[i].options.Clear();
				RDD2[i].options.Clear();
				RDD1[i].options.Add(new TMP_Dropdown.OptionData() { text = " - " });
				RDD2[i].options.Add(new TMP_Dropdown.OptionData() { text = " - " });
				foreach (string lbow in lbow) {
					RDD2[i].options.Add(new TMP_Dropdown.OptionData() { text = lbow });
				}
				#endregion
				//Assassin
				#region
				ADD1[i].options.Clear();
				ADD2[i].options.Clear();
				ADD3[i].options.Clear();
				ADD4[i].options.Clear();
				ADD1[i].options.Add(new TMP_Dropdown.OptionData() { text = " - " });
				ADD2[i].options.Add(new TMP_Dropdown.OptionData() { text = " - " });
				ADD3[i].options.Add(new TMP_Dropdown.OptionData() { text = " - " });
				ADD4[i].options.Add(new TMP_Dropdown.OptionData() { text = " - " });
				#endregion
				//Magick Archer
				#region
				MADD1[i].options.Clear();
				MADD2[i].options.Clear();
				MADD3[i].options.Clear();
				MADD1[i].options.Add(new TMP_Dropdown.OptionData() { text = " - " });
				MADD2[i].options.Add(new TMP_Dropdown.OptionData() { text = " - " });
				MADD3[i].options.Add(new TMP_Dropdown.OptionData() { text = " - " });
				foreach (string mbow in mbow) {
					MADD3[i].options.Add(new TMP_Dropdown.OptionData() { text = mbow });
				}
				#endregion
				//Mystic Knight
				#region
				MKDD1[i].options.Clear();
				MKDD2[i].options.Clear();
				MKDD3[i].options.Clear();
				MKDD1[i].options.Add(new TMP_Dropdown.OptionData() { text = " - " });
				MKDD2[i].options.Add(new TMP_Dropdown.OptionData() { text = " - " });
				MKDD3[i].options.Add(new TMP_Dropdown.OptionData() { text = " - " });
				foreach (string mshield in mshield) {
					MKDD3[i].options.Add(new TMP_Dropdown.OptionData() { text = mshield });
				}
				#endregion
				//Applying the not unique Basic Lists
				//Sword
				foreach (string sword in sword) {
					FDD1[i].options.Add(new TMP_Dropdown.OptionData() { text = sword });
					ADD1[i].options.Add(new TMP_Dropdown.OptionData() { text = sword });
					MKDD1[i].options.Add(new TMP_Dropdown.OptionData() { text = sword });
				}
				//Shield
				foreach (string shield in shield) {
					FDD2[i].options.Add(new TMP_Dropdown.OptionData() { text = shield });
					ADD4[i].options.Add(new TMP_Dropdown.OptionData() { text = shield });
				}
				//Dagger
				foreach (string dagger in dagger) {
					SDD1[i].options.Add(new TMP_Dropdown.OptionData() { text = dagger });
					RDD1[i].options.Add(new TMP_Dropdown.OptionData() { text = dagger });
					ADD2[i].options.Add(new TMP_Dropdown.OptionData() { text = dagger });
					MADD1[i].options.Add(new TMP_Dropdown.OptionData() { text = dagger });
				}
				//Shortbow
				foreach (string sbow in sbow) {
					SDD2[i].options.Add(new TMP_Dropdown.OptionData() { text = sbow });
					ADD3[i].options.Add(new TMP_Dropdown.OptionData() { text = sbow });
			}	}
			//Spells
			foreach (string spells in spells) {
				MDD[i].options.Add(new TMP_Dropdown.OptionData() { text = spells });
				SoDD[i].options.Add(new TMP_Dropdown.OptionData() { text = spells });
				if (i > 3) { break; }
				MADD2[i].options.Add(new TMP_Dropdown.OptionData() { text = spells });
				MKDD2[i].options.Add(new TMP_Dropdown.OptionData() { text = spells });
	}	}	}

	private void TheLists() {
		//sword
		#region
		sword.Add("Dash Strike");
		sword.Add("Broad Attack");
		sword.Add("Toss");
		sword.Add("Spinslash");
		sword.Add("Downstab");
		#endregion
		//shield
		#region
		shield.Add("Shield Drum");
		shield.Add("Shield Attack");
		shield.Add("Shield Launch");
		#endregion
		//dagger
		#region
		dagger.Add("Kisses");
		dagger.Add("Wind");
		dagger.Add("Trigger");
		dagger.Add("Dazzle");
		dagger.Add("Reset");
		#endregion
		//shortbow
		#region
		lbow.Add("3/5fold");
		lbow.Add("Spread Shot");
		lbow.Add("Bend");
		#endregion
		//spells
		#region
		spells.Add("Ingle");
		spells.Add("Frazil");
		spells.Add("Levin");
		spells.Add("Comestion");
		spells.Add("Frigor");
		spells.Add("Brontide");
		#endregion
		//twohanded
		#region
		twohand.Add("Lash");
		twohand.Add("Pommel");
		twohand.Add("Upward/Whirlwind");
		twohand.Add("Escape/Exodus Slash");
		twohand.Add("Bounce Blade");
		twohand.Add("Lunge");
		twohand.Add("Spin Slash");
		twohand.Add("Act");
		twohand.Add("Cry");
		twohand.Add("Arc");
		#endregion
		//longbow
		#region
		lbow.Add("Strong Arrow");
		lbow.Add("Spread Shot");
		lbow.Add("Binder");
		lbow.Add("6/10fold");
		lbow.Add("Snipe Shot");
		lbow.Add("Stun Shot");
		lbow.Add("Spin Arrow");
		lbow.Add("Debuff Arrow");
		lbow.Add("Gamble");
		#endregion
		if (!bArisen) { return; }
		//Magick Bow
		#region
		mbow.Add("3/6/9fold");
		mbow.Add("Hunter Bolt");
		mbow.Add("Flashbang");
		mbow.Add("Ricochet");
		mbow.Add("Vortex Trail");
		mbow.Add("Explosive Rivet");
		mbow.Add("Great Bracer Arrow");
		mbow.Add("Great Ward Arrow");
		mbow.Add("Great Sacrifice");
		#endregion
		//Magick Shield
		#region
		mshield.Add("Fire Counter");
		mshield.Add("Dark Counter");
		mshield.Add("Holy Counter");
		mshield.Add("Ice Counter");
		mshield.Add("Thunder Counter");
		mshield.Add("Demonswrath");
		mshield.Add("Holy Fortress");
		mshield.Add("Holy Grace");
		mshield.Add("Dark Enchant");
		mshield.Add("Holy Enchant");
		mshield.Add("Flame Enchant");
		mshield.Add("Frost Enchant");
		mshield.Add("Lightning Enchant");
		mshield.Add("Dark Anguish");
		mshield.Add("Holy Furor");
		#endregion
	}

	public void PanelsUpdate() {
		sVocation = chara.GetVocation();
		if (pVocation.Equals(sVocation)) { return; } else { pVocation = sVocation; }
		Fighter.SetActive(false);
		Strider.SetActive(false);
		Mage.SetActive(false);
		Warrior.SetActive(false);
		Ranger.SetActive(false);
		Sorcerer.SetActive(false);
		Assassin.SetActive(false);
		MArcher.SetActive(false);
		MKinght.SetActive(false);
		switch (sVocation) {
			case "Fighter":
				Fighter.SetActive(true);
				break;
			case "Strider":
				Strider.SetActive(true);
				break;
			case "Mage":
				Mage.SetActive(true);
				break;
			case "Warrior":
				Warrior.SetActive(true);
				break;
			case "Ranger":
				Ranger.SetActive(true);
				break;
			case "Sorcerer":
				Sorcerer.SetActive(true);
				break;
			case "Assassin":
				Assassin.SetActive(true);
				break;
			case "M. Archer":
				MArcher.SetActive(true);
				break;
			case "M. Knight":
				MKinght.SetActive(true);
				break;
		}
	}

	public void SaveData(GameData data) {
		if (bArisen) {
			for(int i = 0; i < 63; i++) { data.aSkills[i] = iSave[i]; }
		} else {
			for (int i = 0; i < 33; i++) { data.pSkills[i] = iSave[i]; }
	}	}

	public void LoadData(GameData data) {
		throw new System.NotImplementedException();
	}
}