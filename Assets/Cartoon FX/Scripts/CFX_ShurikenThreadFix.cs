using System.Collections;
using UnityEngine;

// Drag/Drop this script on a Particle System (or an object having Particle System objects as children) to prevent a Shuriken bug
// where a system would emit at its original instantiated position before being translated, resulting in particles in-between
// the two positions.
// Possibly a threading bug from Unity (as of 3.5.4)

public class CFX_ShurikenThreadFix : MonoBehaviour
{
    private ParticleSystem[] systems;

    private void Awake()
    {
        systems = GetComponentsInChildren<ParticleSystem>();

        foreach (ParticleSystem ps in systems)
        {
            var psEmission = ps.emission;
            psEmission.enabled = false;
        }

        StartCoroutine("WaitFrame");
    }

    private IEnumerator WaitFrame()
    {
        yield return null;

        foreach (ParticleSystem ps in systems)
        {
            var psEmission = ps.emission;
            psEmission.enabled = true;
            ps.Play(true);
        }
    }
}