using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEffect {
	protected PlayerBehavior player;
	protected ItemBehavior item;

	public WeaponEffect(PlayerBehavior player, ItemBehavior item) {
		this.player = player;
		this.item = item;
	}

	public virtual void RegisterEventEffect() { }

	public virtual void CauseEventEffect() { }
}
