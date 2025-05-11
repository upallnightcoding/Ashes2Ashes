using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCntrl : MonoBehaviour
{
    [SerializeField] SpellSO spellLightAttack;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void FireLightAttack(Vector3 position, Vector3 direction)
    {
        spellLightAttack.CastSpell(position, direction);
    }
}
