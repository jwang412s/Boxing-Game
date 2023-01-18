using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ObjectHit : MonoBehaviour
{
    public GameObject explosion;
    public GameObject instantiatedExplosion;
    public Vector3 transformValues;

    [System.Obsolete]
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Obstacle") {
            transformValues = Main.tempB.transform.position;
            Destroy(Main.tempB);
            SteamVR_Actions.default_Haptic[SteamVR_Input_Sources.LeftHand].Execute(0, 1, 10, 1);
            SteamVR_Actions.default_Haptic[SteamVR_Input_Sources.RightHand].Execute(0, 1, 10, 1);
            instantiatedExplosion = Instantiate(explosion) as GameObject;
            instantiatedExplosion.transform.position = transformValues;
            ParticleSystem parts = instantiatedExplosion.GetComponent<ParticleSystem>();
            float totalDuration = parts.duration + parts.startLifetime;
            Destroy(instantiatedExplosion, totalDuration);
            
        }

    }
}
