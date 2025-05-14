using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spell", menuName = "A2A/Light Spell Attack")]
public class SpellLightAttack : SpellSO
{
    public override GameObject CastSpell(Vector3 position, Vector3 direction, Quaternion rotation)
    {
        GameObject go = Instantiate(spellPrefab, position, rotation);
        go.GetComponent<Rigidbody>().AddForce(direction * force, ForceMode.Impulse);
        go.GetComponent<ImpactCntrl>().Set(impactPrefab);
        Destroy(go, duration);

        return(go);
    }
}
