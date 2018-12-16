using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "ball")
		{
			GameObject.Find("attack").GetComponent<AudioSource>().Play();
			int attack = nowAttack();;
			GameObject.Find("Main Camera").GetComponent<Game_Controller>().setAttack(++attack);
			Destroy(gameObject);
		}
	}

	private int nowAttack()
	{
		return GameObject.Find("Main Camera").GetComponent<Game_Controller>().ball_attack;
	}
}
