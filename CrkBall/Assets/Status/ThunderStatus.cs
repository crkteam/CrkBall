using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderStatus : BaseStatus {

	public void blockStart(GameObject gameObject)
	{
	}

	public void blockBeatean(GameObject gameObject)
	{
	}

	public void ballStart(GameObject gameObject)
	{
	}

	public void ballCollision(GameObject gameObject, Collision2D other)
	{
		if (other.gameObject.name == "Block(Clone)")
		{
			Block[] thunder = other.gameObject.GetComponentInParent<LineCreator>().GetComponentsInChildren<Block>();

			foreach (var block in thunder)
			{
				block.Beaten();
			}
		}
	}

	public void ballTrigger(GameObject gameObject, Collider2D other)
	{
	}
}
