using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrippleShot : WeaponEffect {
	public TrippleShot(PlayerBehavior player, ItemBehavior item) : base(player, item) { }

	public override void RegisterEventEffect() {
		player.AttackEvent += CauseEventEffect;
		Debug.Log("Registered tipple shot attack!");
	}

	public override void CauseEventEffect() {
		Debug.Log("Doing tripple shot Attack event");
		// Cause the event effect logically and visually
		for (int i = 0; i < 3; i++) {
			Debug.Log("Doing single shot Attack event");

			GameObject weapon = GameObject.Instantiate(item.weaponSOAsset.weaponPrefab, player.transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity) as GameObject;

			WeaponBehavior weaponBehavior = weapon.GetComponent<WeaponBehavior>();
			weaponBehavior.SetSOAsset(item);

			Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3 result = (new Vector3(p.x, p.y, 0.0f) - new Vector3(player.transform.position.x, player.transform.position.y, 0.0f)).normalized;

			if (i == 0) {
				weaponBehavior.SetDetails(5.0f, Quaternion.Euler(0, 0, -90f) * result);
			} else if (i == 2) {
				weaponBehavior.SetDetails(5.0f, Quaternion.Euler(0, 0, 90f) * result);
			} else {
				weaponBehavior.SetDetails(5.0f, result);
			}
		}
	}
}
