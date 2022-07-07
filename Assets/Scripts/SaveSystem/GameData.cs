[System.Serializable]
public class GameData {
	//CCharacter
	public bool aSex, pSex;
	public string aName, pName;
	public int aL, aC0, aC1, aC2, pL, pC0, pC1, pC2;
	//Weight
	public int aWeight, pWeight;
	//StarterPanel
	public int aVoc, pVoc, aSVoc, pSVoc;
	//AugmentsPanel
	public int[] aAug, pAug;
	//Vocations
	public SerializeableDictionary<string, int> L10, L100, L200;
	//Equipment
	public int[] aEq, pEq;
	//SkillPanel
	public int[] aSkills, pSkills;

	public GameData() {
		aName = "Arisen";
		pName = "Main Pawn";
		aC0 = 0;
		aC1 = 0;
		aC2 = 0;
		pC0 = 0;
		pC1 = 0;
		pC2 = 0;
		aWeight = 75;
		pWeight = 75;
		aL = 1;
		pL = 1;
		aVoc = 1;
		aSVoc = 1;
		pVoc = 2;
		pSVoc = 2;
		aAug = new int[6];
		pAug = new int[6];
		aEq = new int[9];
		pEq = new int[9];
		aSkills = new int[63];
		pSkills = new int[33];
		L10 = new SerializeableDictionary<string, int>();
		L100 = new SerializeableDictionary<string, int>();
		L200 = new SerializeableDictionary<string, int>();
	}
}