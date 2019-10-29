using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

	[SerializeField]
	private float _speed = 5.0f;
	[SerializeField]
	private float _fireRate = 0.25f;

	private float _nextFire = 0.0f;

	public delegate void VoidWithNoArguments();
	public event VoidWithNoArguments AttackEvent;

	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		movement();

		if (Input.GetKeyDown(KeyCode.R)) {
			if (AttackEvent != null) {
				foreach (Delegate d in AttackEvent.GetInvocationList()) {
					AttackEvent -= (VoidWithNoArguments)d;
				}
			}
		}

		if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) {
			shoot();
		}
	}

	public void EquipItem(ItemBehavior item) {
		if (item.weaponSOAsset.weaponScriptName != null && item.weaponSOAsset.weaponScriptName != "") {
			WeaponEffect weaponEffect = System.Activator.CreateInstance(System.Type.GetType(item.weaponSOAsset.weaponScriptName), new System.Object[] { this, item }) as WeaponEffect;
			weaponEffect.RegisterEventEffect();
		}
	}

	private void shoot() {
		if (Time.time > _nextFire) {
			if (AttackEvent != null) {
				AttackEvent.Invoke();
			}
			_nextFire = Time.time + _fireRate;
		}
	}

	private void movement() {
		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");

		transform.Translate(Vector3.right * _speed * horizontalInput * Time.deltaTime);
		transform.Translate(Vector3.up * _speed * verticalInput * Time.deltaTime);

		if (transform.position.y < -4.2f) {
			transform.position = new Vector3(transform.position.x, -4.2f, 0);
		}

		if (transform.position.x > 8.9f) {
			transform.position = new Vector3(-8.9f, transform.position.y, 0);
		} else if (transform.position.x < -8.9f) {
			transform.position = new Vector3(8.9f, transform.position.y, 0);
		}
	}
}
