using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knights : MonoBehaviour
{
    public enum MachineState
    {
        ConsegueVerArqueiros,
        ConsegueVerCavalaria,
        TemAliadosProximos,
        TemComoFlanquearInimigos,
        AtacarInfantaria,
        FlanquearInfantaria,
        TemInimigosNoCaminho,
        AtacarCavalaria,
        AtacarArqueiros,
        TemComoDesviarDainfantria,
        FlanquearArqueiros,
    }
    public MachineState state = MachineState.ConsegueVerArqueiros;
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
    public Troop troop;
    public Troop trooToAtack;

    public void DecisionMake()
    {
        switch (state)
        {
            case MachineState.ConsegueVerArqueiros:
                if (team == Team.Blue)
                {
                    if (GameController.Instance.archersTeamBlue.Count > 0)
                    {
                        state = MachineState.TemInimigosNoCaminho;
                    }
                    else
                    {
                        state = MachineState.ConsegueVerCavalaria;
                    }
                }
                else
                {
                    if (GameController.Instance.archersTeamRed.Count > 0)
                    {
                        state = MachineState.TemInimigosNoCaminho;
                    }
                    else
                    {
                        state = MachineState.ConsegueVerCavalaria;
                    }
                }
                DecisionMake();
                break;
            case MachineState.ConsegueVerCavalaria:
                if (team == Team.Blue)
                {
                    if (GameController.Instance.knightsTeamBlue.Count > 0)
                    {
                        state = MachineState.AtacarCavalaria;
                    }
                    else
                    {
                        state = MachineState.TemAliadosProximos;
                    }
                }
                else
                {
                    if (GameController.Instance.knightsTeamRed.Count > 0)
                    {
                        state = MachineState.AtacarCavalaria;
                    }
                    else
                    {
                        state = MachineState.TemAliadosProximos;
                    }
                }
                DecisionMake();
                break;
            case MachineState.TemAliadosProximos:
                if (TemAliadosProximos())
                {
                    state = MachineState.AtacarInfantaria;
                }
                else
                {
                    state = MachineState.TemComoFlanquearInimigos;
                }
                DecisionMake();
                break;
            case MachineState.TemComoFlanquearInimigos:
                state = MachineState.AtacarInfantaria;
                DecisionMake();
                break;
            case MachineState.AtacarInfantaria:
                AtacarInfantaria();
                break;
            case MachineState.FlanquearInfantaria:
                break;
            case MachineState.TemInimigosNoCaminho:
                if (TemInimigosNoCaminho())
                {
                    state = MachineState.AtacarCavalaria;
                }
                else
                {
                    state = MachineState.AtacarArqueiros;
                }
                DecisionMake();
                break;
            case MachineState.AtacarCavalaria:
                if (team == Team.Red)
                {
                    if (GameController.Instance.knightsTeamBlue.Count > 0)
                    {
                        AtacarCavalaria();
                    }
                }
                else
                {
                    if (GameController.Instance.knightsTeamRed.Count > 0)
                    {
                        AtacarCavalaria();
                    }
                }
                break;
            case MachineState.AtacarArqueiros:
                AtacarArqueiros();
                break;
            case MachineState.TemComoDesviarDainfantria:
                break;
            case MachineState.FlanquearArqueiros:
                break;
        }
    }
    public void ConsegueVerArqueiros()
    {

    }
    public void ConsegueVerCavalaria()
    {

    }
    public bool TemAliadosProximos()
    {
        return false;
    }
    public void TemComoFlanquearInimigos()
    {

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
    }
    public bool TemInimigosNoCaminho()
    {
        return false;
    }
    public void AtacarCavalaria()
    {
        float distTemp = 0;
        if (team == Team.Red)
        {
            distTemp = (GameController.Instance.knightsTeamBlue[0].gameObject.transform.position - this.transform.position).sqrMagnitude;
            transformToAttack = this.transform;
            enemyToAttack = (Enemy)GameController.Instance.knightsTeamBlue[0].troopClass;
            trooToAtack = GameController.Instance.knightsTeamBlue[0];
        }
        else
        {
            distTemp = (GameController.Instance.knightsTeamRed[0].gameObject.transform.position - this.transform.position).sqrMagnitude;
            transformToAttack = this.transform;
            enemyToAttack = (Enemy)GameController.Instance.knightsTeamRed[0].troopClass;
            trooToAtack = GameController.Instance.knightsTeamRed[0];
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
        troop.Move(transformToAttack);
        troop.Target(trooToAtack);
    }
    public void AtacarArqueiros()
    {
        float distTemp = 0;
        if (team == Team.Red)
        {
            distTemp = (GameController.Instance.archersTeamBlue[0].gameObject.transform.position - this.transform.position).sqrMagnitude;
            transformToAttack = this.transform;
            enemyToAttack = (Enemy)GameController.Instance.archersTeamBlue[0].troopClass;
            trooToAtack = GameController.Instance.archersTeamBlue[0];
        }
        else
        {
            distTemp = (GameController.Instance.archersTeamRed[0].gameObject.transform.position - this.transform.position).sqrMagnitude;
            transformToAttack = this.transform;
            enemyToAttack = (Enemy)GameController.Instance.archersTeamRed[0].troopClass;
            trooToAtack = GameController.Instance.archersTeamRed[0];
        }
        if (team == Team.Red)
        {
            for (int i = 0; i < GameController.Instance.archersTeamBlue.Count; i++)
            {
                if ((GameController.Instance.archersTeamBlue[i].gameObject.transform.position - this.transform.position).sqrMagnitude < distTemp)
                {
                    if ((Enemy)GameController.Instance.archersTeamBlue[i].troopClass == Enemy.Knights)
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
                    if ((Enemy)GameController.Instance.archersTeamRed[i].troopClass == Enemy.Knights)
                    {
                        distTemp = (GameController.Instance.archersTeamRed[i].gameObject.transform.position - this.transform.position).sqrMagnitude;
                        transformToAttack = this.transform;
                        enemyToAttack = (Enemy)GameController.Instance.archersTeamRed[i].troopClass;
                        trooToAtack = GameController.Instance.archersTeamRed[i];
                    }
                }
            }
        }
        troop.Move(transformToAttack);
        troop.Target(trooToAtack);
    }
    public void TemComoDesviarDainfantria()
    {

    }
    public void FlanquearArqueiros()
    {

    }
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Update()
    {
        if (!troop.inCombat)
        {
            state = MachineState.ConsegueVerArqueiros;
            DecisionMake();
        }
    }
}
