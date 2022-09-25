using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    public Image skillnode;
    
    public Text skillNameText; //스킬 클릭시 스킬 이름 나오게 할 text
    public Text skillDesText; //스킬 클릭시 스킬 설명 나오게 할 text

    public int skillButtonId; //스킬 선택 시 배열에 사용할 변수

    public Image LevelIcon; // 스킬레벨 UI

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

        Debug.Log("버튼 눌림");
        //skillnode.color = new Color(1f, 1f, 1f, 1f);

        Skilll.instance.DisplaySkillLevel();
    }
}
