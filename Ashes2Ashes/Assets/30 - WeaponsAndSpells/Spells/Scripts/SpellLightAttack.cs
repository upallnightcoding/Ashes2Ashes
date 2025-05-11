using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spell", menuName = "A2A/Light Spell Attack")]
public class SpellLightAttack : SpellSO
{
    public override GameObject CastSpell(Vector3 position, Vector3 direction)
    {
        GameObject go = Instantiate(spellPrefab, position, Quaternion.identity);
        go.GetComponent<Rigidbody>().AddForce(direction * force, ForceMode.Impulse);
        Destroy(go, duration);

        return(go);
    }
}
