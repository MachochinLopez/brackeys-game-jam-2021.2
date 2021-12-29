using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
		{
			transform.root.GetComponent<RagdollBehaviour>().HandleCollisions();
		}
	}
}
