using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public string skillName;
    public Sprite skillSprite;
    public int abilityId;

    [TextArea(1, 3)]
    public string skillexplain;
    public bool isUpgrade;

    public SkillManager[] previouseAbility;

    public int skillLv;
    public int requireLv;
    public int maxLv;
}
