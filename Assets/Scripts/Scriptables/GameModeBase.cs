using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameMode base", menuName = "Tower Defense/Gamemode")]
public class GameModeBase : ScriptableObject
{
    public Pawn DefaultPawn;
    public HUD DefaultHUD;

}
