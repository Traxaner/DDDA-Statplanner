using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;
using TMPro;

public class EqPanel : MonoBehaviour {
    private TextMeshProUGUI[] Debilitations = new TextMeshProUGUI[13];
    [SerializeField]private TextMeshProUGUI petrify;
    [SerializeField]private TextMeshProUGUI possession;
    [SerializeField]private TextMeshProUGUI sleep;
    [SerializeField]private TextMeshProUGUI silence;
    [SerializeField]private TextMeshProUGUI skillStiff;
    [SerializeField]private TextMeshProUGUI torpor;
    [SerializeField]private TextMeshProUGUI poison;
    [SerializeField]private TextMeshProUGUI blind;
    [SerializeField]private TextMeshProUGUI curse;
    [SerializeField]private TextMeshProUGUI strLow;
    [SerializeField]private TextMeshProUGUI magLow;
    [SerializeField]private TextMeshProUGUI defLow;
    [SerializeField]private TextMeshProUGUI mDefLow;
    // Start is called before the first frame update
    void Start() {
        //filling array
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

	}

    public void SetAll(int iPercent) {
        string s;
        for(int i = 0; i < 13; i++) {
            s = Debilitations[i].text;
            s = s.Remove(s.Length - 1);
            Debilitations[i].text = (Int32.Parse(s)+iPercent).ToString()+"%";
		}
	}

	// Update is called once per frame
	void Update() {
        
    }
}
