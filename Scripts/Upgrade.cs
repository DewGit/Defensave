using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrade : MonoBehaviour
{
    public TextMeshProUGUI curMaxHp_text;
    public TextMeshProUGUI curGold_text;
    public TextMeshProUGUI curDmg_text;
    public TextMeshProUGUI curCharge_text;
    public TextMeshProUGUI speed_text;

    public TextMeshProUGUI[] price_texts;

    int needGold = 100;
    Player player;
    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        curMaxHp_text.text = player.maxHp.ToString(); 
        curGold_text.text = player.bonus.ToString();
        curDmg_text.text = player.dmg.ToString();
        curCharge_text.text = player.fullCharingTime.ToString();
        speed_text.text = player.speed.ToString();
    }
    public void UpgradeStats(string name)
    {
        if (player.gold >= needGold)
        {
            
            switch (name)
            {
                case "maxhp":
                    player.maxHp += 50;
                    player.curHp += 50;
                    break;
                case "gold":
                    player.bonus += 1;
                    break;
                case "dmg":
                    player.dmg += 1.5f;
                    break;
                case "charging":
                    player.fullCharingTime -= 0.15f;
                    break;
                case "speed":
                    player.speed += 1f;
                    break;
                default:
                    break;
            }
            player.gold -= needGold;
            needGold += 100;
            ModifyText(name);
        }

        
    }

    void ModifyText(string name)
    {
        for (int i = 0; i < price_texts.Length; i++)
        {
            price_texts[i].text = "$" + needGold;
        }
        
    }
}
