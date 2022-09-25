using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "ScriptableObject/SkillData", order = int.MaxValue)]
public class SkillScriptableObject : ScriptableObject
{
    public string skillName;
    public Sprite skillSprite;
    public int abilityId;

    [TextArea(1, 3)]
    public string skillexplain;
    public bool isUpgrade;

    public SkillScriptableObject[] previouseAbility;

    public int skillLv;
    public int requireLv;
    public int maxLv;
}
