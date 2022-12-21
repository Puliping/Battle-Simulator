using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralController : MonoBehaviour
{
    public enum Team
    {
        Blue,
        Red
    }
    public Team team;

    public enum MachineState
    {
        TemAlgumaTropaEmPerigo,
        TemAlgumaTropaPerto,
        TemAjudaParaOsArqueiros,
        TemAjudaParaAInfantaria,
        Recuar,
        InfantariaPedirAjudaArqueiros,
        InfantariaPedirAjudaCavalaria,
        ArqueiroPedirAjudaCavalaria,
        IrAtéInfantaria,
    }
    public MachineState state;
    public enum MachineStateRecuando
    {
        AlgumaTropaAindaBrigando,
        Desistir,
        AlgumaTropaPerdendo,
        AjudarTropaGanhando,
        TropaPerdendoComAjudaGanha,
        AjudarTropaPerdendo,
    }
    public MachineStateRecuando stateRecuando;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void EstouEmPerigo(int perigoint)
    {
        DecisionMake(perigoint);
    }
    public void DecisionMake(int perigoint)
    {
        switch (state)
        {
            case MachineState.TemAlgumaTropaEmPerigo:
                if (perigoint == 0)
                {
                    return;
                }
                else if (perigoint == 1)
                {
                    /*Arqueiros*/
                    state = MachineState.TemAjudaParaOsArqueiros;
                }
                else if (perigoint == 2)
                {
                    /*Infantaria*/
                    state = MachineState.TemAjudaParaAInfantaria;
                }
                else if (perigoint == 3)
                {
                    /*Cavaleiro*/
                    state = MachineState.Recuar;
                }
                state = MachineState.Recuar;
                DecisionMake(perigoint);
                break;
            case MachineState.TemAlgumaTropaPerto:
                break;
            case MachineState.TemAjudaParaOsArqueiros:
                break;
            case MachineState.TemAjudaParaAInfantaria:
                break;
            case MachineState.Recuar:
                break;
            case MachineState.InfantariaPedirAjudaArqueiros:
                break;
            case MachineState.InfantariaPedirAjudaCavalaria:
                break;
            case MachineState.ArqueiroPedirAjudaCavalaria:
                break;
            case MachineState.IrAtéInfantaria:
                break;
        }
    }
    public void DecisionMakeRecuado()
    {
        switch (stateRecuando)
        {
            case MachineStateRecuando.AlgumaTropaAindaBrigando:
                break;
            case MachineStateRecuando.Desistir:
                break;
            case MachineStateRecuando.AlgumaTropaPerdendo:
                break;
            case MachineStateRecuando.AjudarTropaGanhando:
                break;
            case MachineStateRecuando.TropaPerdendoComAjudaGanha:
                break;
            case MachineStateRecuando.AjudarTropaPerdendo:
                break;
        }
    }
    public void TemAlgumaTropaPerto()
    {

    }
    public void TemAjudaParaOsArqueiros()
    {

    }
    public void TemAjudaParaAInfantaria()
    {

    }
    public void Recuar()
    {

    }
    public void InfantariaPedirAjudaArqueiros()
    {

    }
    public void InfantariaPedirAjudaCavalaria()
    {

    }
    public void ArqueiroPedirAjudaCavalaria()
    {

    }
    public void IrAtéInfantaria()
    {

    }
    public void AlgumaTropaAindaBrigando()
    {

    }
    public void Desistir()
    {

    }
    public void AlgumaTropaPerdendo()
    {

    }
    public void AjudarTropaGanhando()
    {

    }
    public void TropaPerdendoComAjudaGanha()
    {

    }
    public void AjudarTropaPerdendo()
    {

    }

}
