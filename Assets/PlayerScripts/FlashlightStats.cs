using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Flashlight Statistics", menuName = "Flashlight/FlashlightStats", order = 1)]
public class FlashlightStats : ScriptableObject {
    public int range;
    public int spotAngle;
    public float intensity;
    public float yPosition;
    public float zPosition;
}
