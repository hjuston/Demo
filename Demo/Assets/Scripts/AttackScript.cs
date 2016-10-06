using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour
{
    public GameObject Player;
    private Animator animator;

    void Start()
    {
        animator = Player.GetComponent<Animator>();
    }

	// Update is called once per frame
	void Update () {
	    if(Input.GetMouseButtonDown(0))
        {
            animator.SetInteger("Punch", 1);
        }
        else
        {
            animator.SetInteger("Punch", 0);
        }
	}
}
