/*
 * Assignment: Monster Brawl
 * 
 * Objective:
 * Implement a battle simulation in the Start method. You are given five monsters, each with a name, attack stat, health stat and speed stat. 
 *      Attack determines how much damage it does when it attacks. Health determines how much damage it can take before dying.
 *      Speed determines how often a monster attacks (1 means it attacks every turn, 2 means every 2 turns, 3 means every 3 turns, and so on)
 *  
 *  Print the roster
 *      1. Loop through the monsters and print each one in this exact format:
 *      Goblin | ATK: 8 | HP: 30 | SPD: 1
 *  
 *  Simulate every unique 1v1 fight
 *      1. Every monster should fight every other monster exactly once.
 *          Goblin vs Orc and Orc vs Goblin are the same fight — only one should occur.
 *      2. A monster should never fight itself.
 *      3. In each fight, both monsters attack simultaneously each turn.
 *      4. A monster only attacks on turns that are a multiple of its speed.
 *          E.g. a monster with speed 2 attacks on turns 2, 4, 6, etc. A monster with speed 3 attacks on turns 3, 6, 9, etc.
 *      5. The fight ends when one or both monsters reach 0 HP or below.
 *      6. Print each fight result in this exact format:
 *          Goblin vs Orc | Winner: Orc | Turns: 12 | Remaining HP: 24
 *      7. If both monsters die on the same turn, print:
 *          Goblin vs Orc | Draw | Turns: 8
 *  Instructions:
 *      Attach the script to any active GameObject in your Unity scene.
 *      Observe the results in the Console after hitting the Play button.
 */

using UnityEngine;

public class MonsterBrawl : MonoBehaviour
{
    void Start()
    {
        string[] monsterNames = { "Goblin", "Orc", "Troll", "Skeleton", "Ogre" };
        int[] attackStats = { 8, 20, 35, 12, 50 };
        int[] healthStats = { 30, 80, 200, 50, 250 };
        int[] speedStats = { 1, 2, 3, 1, 4 };

        int numMonsters = monsterNames.Length;

        //Print the roster
        //1.Loop through the monsters and print each one in this exact format:
        //Goblin | ATK: 8 | HP: 30 | SPD: 1
        for (int i = 0; i < monsterNames.Length; i++)
        {
            Debug.Log($"{monsterNames[i]} | ATK: {attackStats[i]} | HP: {healthStats[i]} | SPD: {speedStats[i]}");
        }

        //outer 2 loops go through monsters
        //i from 1 to length
        for (int i = 0; i < numMonsters - 1; i++)
        {
            //Debug.Log($"outer monster is: {monsterNames[i]}");

            //inner loop is opponent
            //j from i + 1 to length so we don't double fight
            for (int j = i + 1; j < numMonsters; j++)
            {
                //Debug.Log($"inner monster is: {monsterNames[j]}");
                //Debug.Log($"{monsterNames[i]} fighting {monsterNames[j]}");

                int outerMonsterHealth = healthStats[i];
                int innerMonsterHealth = healthStats[j];

                int turn = 0;

                //while monsters are not dead, fight turn by turn.
                while (outerMonsterHealth > 0 && innerMonsterHealth > 0) {

                    turn++;
                    
                    //if turn num mod speed is 0, then do attack

                    //outer monster attacks
                    if (turn % speedStats[i] == 0)
                    {
                        //Debug.Log($"{monsterNames[i]} is attacking");
                        innerMonsterHealth -= attackStats[i];
                    }
                    //inner monster attacks
                    if (turn % speedStats[j] == 0)
                    {
                        //Debug.Log($"{monsterNames[j]} is attacking");
                        outerMonsterHealth -= attackStats[j];
                    }

                    //Debug.Log($"healths are now: {outerMonsterHealth} and {innerMonsterHealth}");

                }

                //we exited the loop, at least one monster must be dead
                //prepare result string
                string fighters = $"{monsterNames[i]} vs {monsterNames[j]}";

                //if both dead, draw
                if (outerMonsterHealth <= 0 && innerMonsterHealth <= 0)
                {
                    //e.g. Goblin vs Orc | Draw | Turns: 8
                    Debug.Log($"{fighters} | Draw | Turns: {turn}");
                } 
                else
                {
                    //else, one must be dead. so higher health is the winner
                    string winner;
                    int winnerHealth;
                    if (outerMonsterHealth > innerMonsterHealth)
                    {
                        winner = monsterNames[i];
                        winnerHealth = outerMonsterHealth;
                    } else
                    {
                        winner = monsterNames[j];
                        winnerHealth = innerMonsterHealth;
                    }

                    //e.g. Goblin vs Orc | Winner: Orc | Turns: 12 | Remaining HP: 24
                    Debug.Log($"{fighters} | Winner: {winner} | Turns: {turn} | Remaining HP: {winnerHealth}");
                }
            }
        }





    }
}

