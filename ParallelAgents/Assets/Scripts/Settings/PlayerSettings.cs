using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "Settings/Player", order = 1)]
public class PlayerSettings : ScriptableObject
{
    public float maxJumpTime = 1;
    public float jumpSpeed = 1;

    
}
