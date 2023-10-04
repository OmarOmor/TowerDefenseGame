using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Descriptor", menuName = "Tower Defense/Weapon Descriptor")]
public class WeaponDescriptor : ScriptableObject
{
    public Sprite WeaponUI_Icon;
    public float FireRate;
    public float Damage;

    public GameObject WeaponVisualPrefab;
    public Projectile ProjectilePrefab;

    public AudioClip WeaponFireAudioClip;
    
    
}
