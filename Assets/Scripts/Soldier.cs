using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    public enum MachineState
    {
        QualInimigoMaisProximo,
        AtacarArqueiros,
        SerAgressivo,
        SerDefensivo,
        OndeEstaNaFormacaoContraCavalos,
        OndeEstaNaFormacaoContraSoldado,
        ProtegerFlancos
    }
    public MachineState state = MachineState.QualInimigoMaisProximo;
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
    public Troop troop;
    public Troop trooToAtack;
    public void DecisionMake()
    {
        switch (state)
        {
            case MachineState.QualInimigoMaisProximo:
                Enemy enemyToAttackTemp = InimigoMaisProximo();
                switch (enemyToAttackTemp)
                {
                    case Enemy.Soldier:
                        state = MachineState.OndeEstaNaFormacaoContraSoldado;
                        break;
                    case Enemy.Knights:
                        state = MachineState.OndeEstaNaFormacaoContraCavalos;
                        break;
                    case Enemy.Archer:
                        state = MachineState.AtacarArqueiros;
                        break;
                }
                DecisionMake();
                break;
            case MachineState.AtacarArqueiros:
                AtacarArqueiros();
                break;
            case MachineState.SerAgressivo:
                SerAgressivo();
                break;
            case MachineState.SerDefensivo:
                SerDefensivo();
                break;
            case MachineState.OndeEstaNaFormacaoContraCavalos:
                if (EstaNoCentro())
                {
                    state = MachineState.SerDefensivo;
                }
                else
                {
                    state = MachineState.SerAgressivo;
                }
                DecisionMake();
                break;
            case MachineState.OndeEstaNaFormacaoContraSoldado:
                if (EstaNoCentro())
                {
                    state = MachineState.SerDefensivo;
                }
                else
                {
                    state = MachineState.ProtegerFlancos;
                }
                DecisionMake();
                break;
            case MachineState.ProtegerFlancos:
                break;
        }
    }
    public Enemy InimigoMaisProximo()
    {
        enemyToAttack = Enemy.Knights;
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
    public void AtacarArqueiros()
    {
        troop.Move(transformToAttack);
        troop.Target(trooToAtack);
        troop.attackDamage = troop.baseAttackDamage;
        troop.defense = troop.baseDefense;
    }
    public void SerAgressivo()
    {
        troop.Move(transformToAttack);
        troop.Target(trooToAtack);
        troop.attackDamage *= 2;
        troop.defense /= 2;
    }
    public void SerDefensivo()
    {
        troop.Move(transformToAttack);
        troop.Target(trooToAtack);
        troop.attackDamage /= 2;
        troop.defense *= 4;
    }
    public bool EstaNoCentro()
    {
        return true;
    }
    public void ProtegerFlancos()
    {

    }
    private void Update()
    {
        if (Time.timeScale == 0)
        {
            troop.inCombat = false;
        }
        else
        {
            state = MachineState.QualInimigoMaisProximo;
            DecisionMake();
            if (!troop.inCombat)
            {
                state = MachineState.QualInimigoMaisProximo;
                DecisionMake();
            }
        }
    }
}
