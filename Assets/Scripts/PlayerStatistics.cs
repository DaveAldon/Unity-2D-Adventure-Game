using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

[System.Serializable]
public class PlayerStatistics {
	public int SceneID;
	public float PositionX, PositionY, PositionZ;
	public float HP;
	public string characterName;
	public List<int> unlockedCheckpointList = new List<int>();
}