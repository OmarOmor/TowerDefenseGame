using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Weapon Descriptor", menuName = "Tower Defense/Weapon Descriptor")]
public class WeaponDescriptor : ScriptableObject
{
    public Sprite WeaponUI_Icon;

    public float FireRate;
    public int EnergyCost;


    public GameObject WeaponVisualPrefab;
    public Projectile ProjectilePrefab;

    public AudioClip WeaponFireAudioClip;
    
    
}
