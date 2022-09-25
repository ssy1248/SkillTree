using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

using DG.Tweening;

public class Skilll : MonoBehaviour
{
    public static Skilll instance; //싱글톤

    public SkillManager[] skills; //스킬 배열
    public SkillButton[] skillbutton; //스킬을 누를 버튼 배열
    public SkillManager activeskill;

    public int totalPoints; // 스킬 포인트 최대
    public int remainPoints; //현재 스킬 포인트
    public Text pointsText; //스킬 포인트 txt

    public Text[] abilityLevelTexts; //스킬들 바로 옆에 있는 스킬 레벨 박스
    public Text abilityLevelText; //오른쪽 스킬 박스에 있는 스킬 레벨 박스

    public bool isRest;

    public GameObject NotEnoughTxt; //스킬포인트 부족 
    public GameObject preUpgradeTxt; //선행스킬 없음
    public GameObject CombinationTxt; //위 둘다 오류

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        remainPoints = totalPoints;

        UpdateAbilityImage();
        DisplayPoints();
        DisplaySkillLevel();

        NotEnoughTxt.gameObject.SetActive(false);
        preUpgradeTxt.gameObject.SetActive(false);
        CombinationTxt.gameObject.SetActive(false);
    }

    public void DisplayPoints()
    {
        pointsText.text = remainPoints + " / 15 ";
    }

    public void PressUpgrade()
    {
        for(int i = 0; i < activeskill.previouseAbility.Length; i++)
        {
            if(activeskill.previouseAbility[i].isUpgrade && remainPoints > 0)
            {
                remainPoints -= 1;
                activeskill.isUpgrade = true;
                activeskill.skillLv++;
                break;
            }
        }

        int UpgradeNumber = 0;

        for(int i = 0; i < activeskill.previouseAbility.Length; i++)
        {
            if(activeskill.previouseAbility[i].isUpgrade)
            {
                Debug.Log("업그레이드 가능");
            }
            else
            {
                UpgradeNumber++;
            }
        }

        if (UpgradeNumber == activeskill.previouseAbility.Length && remainPoints <= 0)
        {
            StartCoroutine(ShowHintCo(CombinationTxt));
        }
        else if (remainPoints <= 0)
        {
            StartCoroutine(ShowHintCo(NotEnoughTxt));
        }
        else if (UpgradeNumber == activeskill.previouseAbility.Length)
        {
            StartCoroutine(ShowHintCo(preUpgradeTxt));
        }

        DisplayPoints();
        UpdateAbilityImage();
        DisplaySkillLevel();

        if (activeskill != null)
        {
            activeskill.transform.DOPunchPosition(new Vector3(0, -20, 0), 0.2f, 4, 0.5f);
            activeskill.transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0), 0.2f, 4, 0.5f);
        }
        else
        {
            return;
        }
    }


    void UpdateAbilityImage()
    {
        for (int i = 0; i < skills.Length; i++)
        {
            if (skills[i].isUpgrade)
            {
                skills[i].GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
            }
            else
            {
                skills[i].GetComponent<Image>().color = new Vector4(1f, 1f, 1f, 0.5f);
            }
        }

    }

    public void ResetButton()
    {
        isRest = true;

        activeskill = null;

        for (int i = 2; i < skills.Length; i++)
        {
            skills[i].isUpgrade = false;
            skills[i].skillLv = 0;
            abilityLevelTexts[i].text = "";
            remainPoints = totalPoints;
        }

        UpdateAbilityImage();
        DisplayPoints();

    }

    public void DisplaySkillLevel()
    {
        if (activeskill == null)
        {
            return;
        }
        else
        {
            for (int i = 0; i < skills.Length; i++)
            {
                if (i == 0 || i == 1)
                {
                    abilityLevelTexts[i].text = "";
                    abilityLevelText.text = "";
                }
                else
                {
                    if (skills[i].isUpgrade)
                    {
                        //show the Text
                        abilityLevelTexts[i].text = skills[i].skillLv.ToString();
                        abilityLevelText.text = activeskill.skillLv.ToString();
                    }
                    else
                    {
                        //Keep the Text Empty
                        abilityLevelTexts[i].text = "";
                    }
                }

            }
        }
    }


    IEnumerator ShowHintCo(GameObject _gameObject)
    {
        _gameObject.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        _gameObject.gameObject.SetActive(false);
    }

}

