using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Battle", menuName = "Utilities/Battle", order = 1)]
public class Battle : ScriptableObject
{
    public BattleParticipant enemy;
    public BattleParticipant ally;

}
