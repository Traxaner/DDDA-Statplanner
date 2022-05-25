using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public interface IDataPersistance {
	void LoadData(GameData data);
	void SaveData(GameData data);
}