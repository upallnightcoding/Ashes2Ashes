using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class SpellSO : ScriptableObject
{
    [Header("Basic Attributes ...")]
    public string spellName;
    public Image image;
    public float baseDamage;
    public float duration;

    [Header("Spell FX ...")]
    public float force;
    public GameObject flashPrefab = null;
    public GameObject spellPrefab = null;
    public GameObject impactPrefab = null;

    public abstract GameObject CastSpell(Vector3 position, Vector3 direction, Quaternion rotation);
}
