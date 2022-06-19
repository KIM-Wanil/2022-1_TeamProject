using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpPanel : MonoBehaviour
{
    Player player;
    public GameObject leveluppanel;
    public Text choose1;
    public Text choose2;
    public Text choose3;

    int c1, c2, c3;
    bool temp;

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();

        ShuffleNum();
        Debug.Log("c1 : " + c1);
        Debug.Log("c2 : " + c2);
        Debug.Log("c3 : " + c3);
    }


    void Update()
    {
        if (player.is_levelup)
        {
            ShuffleNum();
            choose1.text = printText(c1);
            choose2.text = printText(c2);
            choose3.text = printText(c3);
            Time.timeScale = 0;
            leveluppanel.SetActive(true);
            player.is_levelup = false;
        }

    }

    public void Choose1()
    {
        temp = Upgrade(c1);
        if (temp == false)
            c1 = 6;
        Time.timeScale = 1;
        leveluppanel.SetActive(false);

    }

    public void Choose2()
    {
        temp = Upgrade(c2);
        if (temp == false)
            c2 = 6;
        Time.timeScale = 1;
        leveluppanel.SetActive(false);
    }

    public void Choose3()
    {
        temp = Upgrade(c3);
        if (temp == false)
            c3 = 6;
        Time.timeScale = 1;
        leveluppanel.SetActive(false);
    }

    string printText(int temp)
    {
        if (temp == 1)
            return "IceRing\n강화\n" + "LV:" + player.Ringlv.ToString();
        else if (temp == 2)
        {
            if (player.Wheellv == 0)
                return "IceWheel\n강화\n" + "LV:" + player.Wheellv.ToString() + "\n(새로운 무기!)";
            else
                return "IceWheel\n강화\n" + "LV:" + player.Wheellv.ToString();
        }
        else if (temp == 3)
        {
            if (player.Fieldlv == 0)
                return "IceField\n강화\n" + "LV:" + player.Fieldlv.ToString() + "\n(새로운 무기!)";
            else
                return "IceField\n강화\n" + "LV:" + player.Fieldlv.ToString();
        }
        else if (temp == 4)
            return "공격력\n증가\n" + "LV: " + player.AttackBonuslv.ToString();
        else if (temp == 5)
            return "최대 체력\n증가\n" + "LV: " + player.Hplv.ToString();
        else
            return "nothing";
    }

    void ShuffleNum()
    {
        c1 = Random.Range(1, 6);
        c2 = Random.Range(1, 6);
        c3 = Random.Range(1, 6);
        while (true)
        {
            if (c1 == c2 || c1 == c3)
            {
                c1 = Random.Range(1, 6);
            }
            else if (c2 == c3)
            {
                c2 = Random.Range(1, 6);
            }
            else
                break;
        }
        Debug.Log("c1 : " + c1 + " c2 : " + c2 + " c3 : " + c3);
    }

    bool Upgrade(int num)
    {
        Debug.Log("upgradework");
        if (num == 1)
        {
            if (player.Ringlv < player.MaxUpgradelv)
            {
                player.Ringlv += 1;
                player.isRingLvUp = true;
                Debug.Log("icering : " + player.Ringlv);
                return true;
            }
            else
                return false;
        }

        else if (num == 2)
            if (player.Wheellv < player.MaxUpgradelv)
            {
                player.IceWheel = true;
                player.Wheellv += 1;
                player.isWheelLvUp = true;
                Debug.Log("icewheel : " + player.Wheellv);
                return true;
            }
            else
                return false;

        else if (num == 3)
        {
            if (player.Fieldlv < player.MaxUpgradelv)
            {
                player.IceField = true;
                player.Fieldlv += 1;
                player.isFieldLvUp = true;
                Debug.Log("icefield : " + player.Fieldlv);
                return true;
            }
            else
                return false;
        }

        else if (num == 4)
        {
            if (player.AttackBonuslv < player.MaxUpgradelv)
            {
                player.AttackBonus = true;
                player.AttackBonuslv += 1;
                player.isAttackBonusLvUp = true;

                Debug.Log("attackbonus : " + player.AttackBonuslv);
                return true;
            }
            else
                return false;
        }

        else if (num == 5)
        {
            if (player.Hplv < player.MaxUpgradelv)
            {
                player.HpBonus = true;
                player.Hplv += 1;
                player.isHpBonusLvUp = true;
                Debug.Log("Hplv : " + player.Hplv);
                return true;
            }
            else
                return false;
        }

        else if (player.Ringlv == player.MaxUpgradelv && player.Wheellv == player.MaxUpgradelv && player.Fieldlv == player.MaxUpgradelv
                && player.AttackBonuslv == player.MaxUpgradelv && player.Hplv == player.MaxUpgradelv)
        {
            return false;
        }

        else
            return false;
    }
}