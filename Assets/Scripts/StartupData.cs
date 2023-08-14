using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Startup Data", menuName = "Custom/StartupData")]
public class StartupData : ScriptableObject
{
    public Vector3 PlayerStartingPos = Vector3.zero;
    public Quaternion PlayerStartingRot = Quaternion.identity;
}