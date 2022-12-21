using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archers : MonoBehaviour
{

    public enum MachineState
    {
        InimigoMaisProximo,
        AtacarInfantaria,
        AtacarCavalaria,
        AtacarArqueiros,
        TemSoldadosAliadosPerto,
        MoverParaSoldados,
    }
    public MachineState state = MachineState.InimigoMaisProximo;
    public enum Team
    {
        Blue,
        Red
    }
    public Team team;
    public enum Enemy
    {
        Soldier,
        Knights,
        Archer
    }
    public Enemy enemyToAttack;
    private Transform transformToAttack;
    private Transform transformToProtect;
    private float enemyKnightDistance;
    public Troop troop;
    public Troop trooToAtack;

    public void DecisionMake()
    {
        switch (state)
        {
            case MachineState.InimigoMaisProximo:
                Enemy enemyToAttackTemp = InimigoMaisProximo();
                switch (enemyToAttackTemp)
                {
                    case Enemy.Soldier:
                        state = MachineState.AtacarInfantaria;
                        break;
                    case Enemy.Knights:
                        state = MachineState.TemSoldadosAliadosPerto;
                        enemyKnightDistance = (transformToAttack.position - this.transform.position).sqrMagnitude;
                        break;
                    case Enemy.Archer:
                        state = MachineState.AtacarArqueiros;
                        break;
                }
                DecisionMake();
                break;
            case MachineState.AtacarInfantaria:
                AtacarInfantaria();
                break;
            case MachineState.AtacarCavalaria:
                AtacarCavalaria();
                break;
            case MachineState.AtacarArqueiros:
                AtacarArqueiros();
                break;
            case MachineState.TemSoldadosAliadosPerto:
                if (TemSoldadosAliadosPerto())
                {
                    state = MachineState.MoverParaSoldados;
                }
                else
                {
                    state = MachineState.AtacarCavalaria;
                }
                DecisionMake();
                break;
            case MachineState.MoverParaSoldados:
                MoverParaSoldados();
                break;
        }
    }
    public Enemy InimigoMaisProximo()
    {
        enemyToAttack = Enemy.Soldier;
        float distTemp = 10000;
        if (team == Team.Red)
        {
            for (int i = 0; i < GameController.Instance.soldiersTeamBlue.Count; i++)
            {
                if ((GameController.Instance.soldiersTeamBlue[i].gameObject.transform.position - this.transform.position).sqrMagnitude < distTemp)
                {
                    if ((Enemy)GameController.Instance.soldiersTeamBlue[i].troopClass == Enemy.Soldier)
                    {
                        distTemp = (GameController.Instance.soldiersTeamBlue[i].gameObject.transform.position - this.transform.position).sqrMagnitude;
                        transformToAttack = this.transform;
                        enemyToAttack = (Enemy)GameController.Instance.soldiersTeamBlue[i].troopClass;
                        trooToAtack = GameController.Instance.soldiersTeamBlue[i];
                    }
                }
            }
        }
        if (team == Team.Blue)
        {
            for (int i = 0; i < GameController.Instance.soldiersTeamRed.Count; i++)
            {
                if ((GameController.Instance.soldiersTeamRed[i].gameObject.transform.position - this.transform.position).sqrMagnitude < distTemp)
                {
                    if ((Enemy)GameController.Instance.soldiersTeamRed[i].troopClass == Enemy.Soldier)
                    {
                        distTemp = (GameController.Instance.soldiersTeamRed[i].gameObject.transform.position - this.transform.position).sqrMagnitude;
                        transformToAttack = this.transform;
                        enemyToAttack = (Enemy)GameController.Instance.soldiersTeamRed[i].troopClass;
                        trooToAtack = GameController.Instance.soldiersTeamRed[i];
                    }
                }
            }
        }
        if (team == Team.Red)
        {
            for (int i = 0; i < GameController.Instance.archersTeamBlue.Count; i++)
            {
                if ((GameController.Instance.archersTeamBlue[i].gameObject.transform.position - this.transform.position).sqrMagnitude < distTemp)
                {
                    if ((Enemy)GameController.Instance.archersTeamBlue[i].troopClass == Enemy.Archer)
                    {
                        distTemp = (GameController.Instance.archersTeamBlue[i].gameObject.transform.position - this.transform.position).sqrMagnitude;
                        transformToAttack = this.transform;
                        enemyToAttack = (Enemy)GameController.Instance.archersTeamBlue[i].troopClass;
                        trooToAtack = GameController.Instance.archersTeamBlue[i];
                    }
                }
            }
        }
        if (team == Team.Blue)
        {
            for (int i = 0; i < GameController.Instance.archersTeamRed.Count; i++)
            {
                if ((GameController.Instance.archersTeamRed[i].gameObject.transform.position - this.transform.position).sqrMagnitude < distTemp)
                {
                    if ((Enemy)GameController.Instance.archersTeamRed[i].troopClass == Enemy.Archer)
                    {
                        distTemp = (GameController.Instance.archersTeamRed[i].gameObject.transform.position - this.transform.position).sqrMagnitude;
                        transformToAttack = this.transform;
                        enemyToAttack = (Enemy)GameController.Instance.archersTeamRed[i].troopClass;
                        trooToAtack = GameController.Instance.archersTeamRed[i];
                    }
                }
            }
        }
        if (team == Team.Red)
        {
            for (int i = 0; i < GameController.Instance.knightsTeamBlue.Count; i++)
            {
                if ((GameController.Instance.knightsTeamBlue[i].gameObject.transform.position - this.transform.position).sqrMagnitude < distTemp)
                {
                    if ((Enemy)GameController.Instance.knightsTeamBlue[i].troopClass == Enemy.Knights)
                    {
                        distTemp = (GameController.Instance.knightsTeamBlue[i].gameObject.transform.position - this.transform.position).sqrMagnitude;
                        transformToAttack = this.transform;
                        enemyToAttack = (Enemy)GameController.Instance.knightsTeamBlue[i].troopClass;
                        trooToAtack = GameController.Instance.knightsTeamBlue[i];
                    }
                }
            }
        }
        if (team == Team.Blue)
        {
            for (int i = 0; i < GameController.Instance.knightsTeamRed.Count; i++)
            {
                if ((GameController.Instance.knightsTeamRed[i].gameObject.transform.position - this.transform.position).sqrMagnitude < distTemp)
                {
                    if ((Enemy)GameController.Instance.knightsTeamRed[i].troopClass == Enemy.Knights)
                    {
                        distTemp = (GameController.Instance.knightsTeamRed[i].gameObject.transform.position - this.transform.position).sqrMagnitude;
                        transformToAttack = this.transform;
                        enemyToAttack = (Enemy)GameController.Instance.knightsTeamRed[i].troopClass;
                        trooToAtack = GameController.Instance.knightsTeamRed[i];
                    }
                }
            }
        }
        return enemyToAttack;
    }
    public void AtacarInfantaria()
    {
        float distTemp = 0;
        if (team == Team.Red)
        {
            distTemp = (GameController.Instance.soldiersTeamBlue[0].gameObject.transform.position - this.transform.position).sqrMagnitude;
            transformToAttack = this.transform;
            enemyToAttack = (Enemy)GameController.Instance.soldiersTeamBlue[0].troopClass;
            trooToAtack = GameController.Instance.soldiersTeamBlue[0];
        }
        else
        {
            distTemp = (GameController.Instance.soldiersTeamRed[0].gameObject.transform.position - this.transform.position).sqrMagnitude;
            transformToAttack = this.transform;
            enemyToAttack = (Enemy)GameController.Instance.soldiersTeamRed[0].troopClass;
            trooToAtack = GameController.Instance.soldiersTeamRed[0];
        }
        if (team == Team.Red)
        {
            for (int i = 0; i < GameController.Instance.soldiersTeamBlue.Count; i++)
            {
                if ((GameController.Instance.soldiersTeamBlue[i].gameObject.transform.position - this.transform.position).sqrMagnitude < distTemp)
                {
                    if ((Enemy)GameController.Instance.soldiersTeamBlue[i].troopClass == Enemy.Knights)
                    {
                        distTemp = (GameController.Instance.soldiersTeamBlue[i].gameObject.transform.position - this.transform.position).sqrMagnitude;
                        transformToAttack = this.transform;
                        enemyToAttack = (Enemy)GameController.Instance.soldiersTeamBlue[i].troopClass;
                        trooToAtack = GameController.Instance.soldiersTeamBlue[i];
                    }
                }
            }
        }
        if (team == Team.Blue)
        {
            for (int i = 0; i < GameController.Instance.soldiersTeamRed.Count; i++)
            {
                if ((GameController.Instance.soldiersTeamRed[i].gameObject.transform.position - this.transform.position).sqrMagnitude < distTemp)
                {
                    if ((Enemy)GameController.Instance.soldiersTeamRed[i].troopClass == Enemy.Knights)
                    {
                        distTemp = (GameController.Instance.soldiersTeamRed[i].gameObject.transform.position - this.transform.position).sqrMagnitude;
                        transformToAttack = this.transform;
                        enemyToAttack = (Enemy)GameController.Instance.soldiersTeamRed[i].troopClass;
                        trooToAtack = GameController.Instance.soldiersTeamRed[i];
                    }
                }
            }
        }
        troop.Move(transformToAttack);
        troop.Target(trooToAtack);
        troop.Move(transformToAttack);
        troop.Target(trooToAtack);
    }
    public void AtacarCavalaria()
    {
        troop.Move(transformToAttack);
        troop.Target(trooToAtack);
    }
    public void AtacarArqueiros()
    {
        troop.Move(transformToAttack);
        troop.Target(trooToAtack);
    }
    public bool TemSoldadosAliadosPerto()
    {
        enemyToAttack = Enemy.Knights;
        float distTemp = 0;
        bool hasSoldierNear = false;
        if (team == Team.Red)
        {
            distTemp = (GameController.Instance.archersTeamBlue[0].gameObject.transform.position - this.transform.position).sqrMagnitude;
            transformToProtect = this.transform;
        }
        else
        {
            distTemp = (GameController.Instance.archersTeamRed[0].gameObject.transform.position - this.transform.position).sqrMagnitude;
            transformToProtect = this.transform;
        }
        for (int i = 0; i < GameController.Instance.troopList.Count; i++)
        {
            if (GameController.Instance.troopList[i].troopClass == Troop.Class.Soldier)
            {
                if (GameController.Instance.troopList[i].gameObject.layer == LayerMask.NameToLayer("TroopBlue"))
                {
                    if (team == Team.Blue)
                    {
                        if ((GameController.Instance.troopList[i].gameObject.transform.position - this.transform.position).sqrMagnitude < enemyKnightDistance)
                        {
                            distTemp = (GameController.Instance.troopList[i].gameObject.transform.position - this.transform.position).sqrMagnitude;
                            transformToProtect = this.transform;
                            enemyToAttack = (Enemy)GameController.Instance.troopList[i].troopClass;
                            hasSoldierNear = true;
                        }
                    }
                }
                else
                {
                    if (team == Team.Red)
                    {
                        if ((GameController.Instance.troopList[i].gameObject.transform.position - this.transform.position).sqrMagnitude < enemyKnightDistance)
                        {
                            distTemp = (GameController.Instance.troopList[i].gameObject.transform.position - this.transform.position).sqrMagnitude;
                            transformToProtect = this.transform;
                            enemyToAttack = (Enemy)GameController.Instance.troopList[i].troopClass;
                            hasSoldierNear = true;
                        }
                    }
                }
            }
        }
        return hasSoldierNear;
    }
    public void MoverParaSoldados()
    {
        troop.Move(transformToProtect);
    }
    private void Update()
    {
        if (!troop.inCombat)
        {
            state = MachineState.InimigoMaisProximo;
            DecisionMake();
        }
    }
}
