using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class SaveGame_MEMENTO : MonoBehaviour {}

public class Memento // Memento pattern
{
    public float curHealth { get; private set; }
    public float currentX { get; private set; }
    public float currentY { get; private set; }

   // public float[] enemyHp { get; private set; }
   // public float[] enemyPosX { get; private set; }
   // public float[] enemyPosY { get; private set; }

    public float[] enemyHp = new float[EnemyAI_Rogue.roguesCount];
    public float[] enemyPosX = new float[EnemyAI_Rogue.roguesCount];
    public float[] enemyPosY = new float[EnemyAI_Rogue.roguesCount];

    public Memento(float curHealth, float curX, float curY, int enemyCount,
        float[] enemyHp, float[] enemyPosX, float[] enemyPosY)
    {
        this.curHealth = curHealth;
        this.currentX = curX;
        this.currentY = curY;

        for (int i = 0; i <= enemyCount - 1; i++)
        {
            this.enemyHp[i] = enemyHp[i];
            this.enemyPosX[i] = enemyPosX[i];
            this.enemyPosY[i] = enemyPosY[i];
        }
    }
}

public class GameHistory // Caretaker
{
    public List<Memento> History { get; private set; }

    public GameHistory()
    {
        History = new List<Memento>();
    }
}
    
    


