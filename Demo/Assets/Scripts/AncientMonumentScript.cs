using UnityEngine;
using System.Collections;

public class AncientMonumentScript : MonoBehaviour {

    public GameObject ParticlePrefab;

	void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "World")
        {
            float ShakeStrenght = 0.1f;

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if(player != null)
            {
                ShakeStrenght = 1f - (Vector3.Distance(gameObject.transform.position, player.transform.position) / 4);

                Animator anim = player.GetComponentInChildren<Animator>();
                if(anim != null)
                {
                    anim.CrossFade("HumanoidCrouchIdle", 0.1f, 0, Time.deltaTime * 10);
                }
            }

            CameraShaker.Shake(1.2f, ShakeStrenght);

            GameObject particle = Instantiate(ParticlePrefab);
            particle.transform.position = coll.contacts[0].point;
        }
    }
}
