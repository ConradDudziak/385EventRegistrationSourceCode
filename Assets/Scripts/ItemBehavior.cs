using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
	public WeaponSOAsset weaponSOAsset;
    // Start is called before the first frame update
    void Start()
    {
		this.gameObject.GetComponent<SpriteRenderer>().sprite = weaponSOAsset.weaponSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag == "Player") {
			collision.gameObject.GetComponent<PlayerBehavior>().EquipItem(this);
			Destroy(this.gameObject);
		}
	}
}
