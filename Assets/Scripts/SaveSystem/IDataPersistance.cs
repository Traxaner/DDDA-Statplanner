using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public interface IDataPersistance {
	void SaveData(GameData data);
	void LoadData(GameData data);
}