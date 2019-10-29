using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{
	public WeaponSOAsset weaponSOAsset;
	private float speed;
	private Vector3 direction;

	// Start is called before the first frame update
	void Start()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
		transform.position += transform.up * speed * Time.deltaTime;
    }

	public void SetSOAsset(ItemBehavior item) {
		weaponSOAsset = item.weaponSOAsset;
		gameObject.GetComponent<SpriteRenderer>().sprite = weaponSOAsset.weaponSprite;
	}

	public void SetDetails(float speed, Vector3 direction) {
		this.speed = speed;
		transform.up = direction;
	}
}
