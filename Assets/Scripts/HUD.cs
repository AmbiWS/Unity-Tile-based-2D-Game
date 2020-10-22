using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Sprite[] HearthSprites;
    public Image HeartUI;

    private Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Hero").GetComponent<Player>();
    }

    private void Update()
    {
        if (player.curHealth < 2)
        {
            HeartUI.sprite = HearthSprites[0];
            return;
        }
        HeartUI.sprite = HearthSprites[(int)player.curHealth / 2];
    }


}
