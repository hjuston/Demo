using UnityEngine;
using System.Collections;

public class AncientRuneMonumentActivator : MonoBehaviour {

    public GameObject Monument;

	void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Monument.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
