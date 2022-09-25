using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public string abilityName;

    [TextArea(1, 3)]
    public string abilityDes;
    public Ability[] abilities;
}
