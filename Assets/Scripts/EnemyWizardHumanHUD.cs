using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyWizardHumanHUD : MonoBehaviour {

    public Sprite[] HearthSprites;
    public Image HeartUI;

    private EnemyAI_WizardHuman enemy;

    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("EnemyHumanWizard").GetComponent<EnemyAI_WizardHuman>();
    }

    private void Update()
    {
        HeartUI.sprite = HearthSprites[(int)enemy.curHealth];
    }
}
