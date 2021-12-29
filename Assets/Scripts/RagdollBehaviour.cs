using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody2D[] limbs;
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void HandleCollisions()
	{
        EnableRagdollLimbs();
	}

	public void DisableRagdollLimbs()
	{
        foreach (Rigidbody2D limb in limbs)
		{
            limb.bodyType = RigidbodyType2D.Kinematic;
            limb.useFullKinematicContacts = true;
        }
	}

    public void EnableRagdollLimbs()
    {
        anim.SetBool("isRagdoll", true);
        anim.enabled = false;

        foreach (Rigidbody2D limb in limbs)
        {
            limb.bodyType = RigidbodyType2D.Dynamic;
            limb.useFullKinematicContacts = false;
        }
    }
}
