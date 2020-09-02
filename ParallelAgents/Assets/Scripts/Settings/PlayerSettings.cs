using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "Settings/Player", order = 1)]
public class PlayerSettings : ScriptableObject
{
    public float maxJumpTime = 1;
    public float jumpSpeed = 1;

    public float fallSpeed = 2;
    public float fallSpeedChange = 10;

    public float jetpackSpeed = 1.5f;
    public float jetpackSpeedChange = 5;
}
