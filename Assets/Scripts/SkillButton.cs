using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    public Image skillnode;
    
    public Text skillNameText; //��ų Ŭ���� ��ų �̸� ������ �� text
    public Text skillDesText; //��ų Ŭ���� ��ų ���� ������ �� text

    public int skillButtonId; //��ų ���� �� �迭�� ����� ����

    public Image LevelIcon; // ��ų���� UI

    //button.onClick.AddListener(() => ButtonPress(cnt++));

    private void Start()
    {
        //skillnode = GetComponent<Image>();
        //skillnode.color = new Color(1f, 1f, 1f, 0.5f);

        if (Skilll.instance.activeskill == null)
        {
            skillNameText.text = "selected name";
            skillDesText.text = "selectd skills explain";
        }
    }

    void Update()
    {
        if(Skilll.instance.isRest)
        {
            OriginalStatus();
        }
    }

    private void OriginalStatus()
    {
        skillNameText.text = "selected name";
        skillDesText.text = "selectd skills explain";
        LevelIcon.gameObject.SetActive(false);
        Skilll.instance.isRest = false;
    }

    public void ButtonPress()
    {
        Skilll.instance.activeskill = transform.GetComponent<SkillManager>();

        skillnode.sprite = Skilll.instance.skills[skillButtonId].skillSprite;
        skillNameText.text = Skilll.instance.skills[skillButtonId].skillName;
        skillDesText.text = Skilll.instance.skills[skillButtonId].skillexplain;

        if (skillButtonId == 0)
        {
            LevelIcon.gameObject.SetActive(false);
        }
        else
        {
            LevelIcon.gameObject.SetActive(true);
        }

        Debug.Log("��ư ����");
        //skillnode.color = new Color(1f, 1f, 1f, 1f);

        Skilll.instance.DisplaySkillLevel();
    }
}
