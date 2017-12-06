using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	public int HP;
	public int currentHP;
	int damage = 10;


	void start()
	{
		currentHP = HP;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		PlayerScript hp = collision.GetComponent<PlayerScript> ();
		if(hp)
		{
			hp.TakeDamage (damage);
		}
	}
}
