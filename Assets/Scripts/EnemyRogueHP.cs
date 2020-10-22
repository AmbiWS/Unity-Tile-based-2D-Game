using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyRogueHP : MonoBehaviour {

    public Sprite[] HearthSprites;
    public Image HeartUI;
    public Image HeartUI2;

    private EnemyAI_Rogue enemy1;
    private EnemyAI_Rogue enemy2;

    private void Start()
    {
        enemy1 = GameObject.FindGameObjectsWithTag("EnemyRogue")[0].GetComponent<EnemyAI_Rogue>();
        enemy2 = GameObject.FindGameObjectsWithTag("EnemyRogue")[1].GetComponent<EnemyAI_Rogue>();
    }

    private void Update()
    {
        HeartUI.sprite = HearthSprites[(int)enemy1.curHealth];
        HeartUI2.sprite = HearthSprites[(int)enemy2.curHealth];
    }
}
