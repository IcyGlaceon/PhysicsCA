using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
	[SerializeField] protected AmmoData ammoData;

	public void OnDamage(GameObject target)
	{
		// create impact prefab
		if (ammoData.impactPrefab != null)
		{
			Instantiate(ammoData.impactPrefab, transform.position, transform.rotation);
		}

		// destroy game object
		if (ammoData.destroyOnImpact)
		{
			Destroy(gameObject);
		}
	}
}
