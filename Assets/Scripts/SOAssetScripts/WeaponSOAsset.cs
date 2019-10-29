using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/WeaponSOAsset", order = 1)]
public class WeaponSOAsset : ScriptableObject {
	// Anything specific to ONE weapon
	public GameObject weaponPrefab;
    public Sprite weaponSprite;

	[Header("Weapon Effect")]
	public string weaponScriptName;
}
