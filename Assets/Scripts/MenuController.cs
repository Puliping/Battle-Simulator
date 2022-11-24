using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    public enum Terrains
    {
        florestas,
        campoAberto,
        colinas,
        desertos,
        montanhas,
        pântanos,
        estepes,
        praias,
        desfiladeiros
    };
    public Terrains terreno;

    public enum Civs
    {
        impérioromano,
        dinastiaHan,
        hunos,
        cidadedeEsparta,
        impérioPérsa,
        impérioMacedônico,
        impérioCartaginês
    }
    public Civs civA;
    public Civs civB;
    public TextMeshProUGUI textCivA;
    public TextMeshProUGUI textCivB;
    public TextMeshProUGUI textTerrain;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void SetGame()
    {

    }
    public void Info()
    {

    }
    public void Quit()
    {
        Application.Quit();
    }
    public void ClearSelections()
    {

    }
    public void SelectTerrain(TMP_Dropdown terrainNumber)
    {
        terreno = (Terrains)terrainNumber.value;
        LevelManager.Instance.terrenos = terreno;
        switch (terrainNumber.value)
        {
            case 0:
                textTerrain.text = "Quando há florestas, as árvores diminuem a visibilidade dos exércitos e também oferecem maior proteção contra ataques à distância, dependendo da densidade destas. Vale ressaltar que, em selvas mais tropicais, a umidade presente no ar acelera o processo de infecção de feridas, assim como o processo de decomposição dos corpos. "
                    + "\n" + "- visibilidade " 
                    + "\n" + "- range" 
                    + "\n" + "- speed";
                break;
            case 1:
                textTerrain.text = "Em terrenos montanhosos, há maior possibilidade de emboscadas, devido à existência de cavernas e à verticalidade do campo de batalha. Além disso, quanto maior a altitude, menor a densidade do ar, podendo causar falta de oxigênio em soldados menos preparados. Vale notar também a possibilidade de desastres, como avalanches e deslizamentos, mesmo não existindo planos para a implementação destes."
                    + "\n" + "+/-speed "
                    + "\n" + "+/-range"
                    + "\n" + "+/-visibilidade";
                break;
            case 2:
                textTerrain.text = "Em desertos, a falta de umidade pode afetar a moral das tropas, assim como o consumo de suprimentos. Equipamentos também podem ser afetados em batalhas mais longas. Quando são desertos de areia, geralmente o terreno é plano, mas podem haver dunas móveis ou mesmo montanhas."
                    + "\n" + "+cansaço"
                    + "\n" + "+fome"
                    + "\n" + "+equipamento";
                break;
            case 3:
                textTerrain.text = "Em locais pantanosos ou com grande concentração de lama, a movimentação das tropas pode sofrer uma diminuição de velocidade, ou mesmo ser parada por completo."
                    + "\n" + "--speed";
                break;
            case 4:
                textTerrain.text = "eeeee";
                break;
            case 5:
                textTerrain.text = "fffff";
                break;
            case 6:
                textTerrain.text = "ggggg";
                break;
            case 7:
                textTerrain.text = "hhhhhh";
                break;
            case 8:
                textTerrain.text = "iiiii";
                break;
            case 9:
                textTerrain.text = "jjjjjj";
                break;
        }
    }
    public void SelectCivA(TMP_Dropdown civNumber)
    {
        civA = (Civs)civNumber.value;
        LevelManager.Instance.civA = civA;
        textCivA.text = civA.ToString();
    }
    public void SelectCivB(TMP_Dropdown civNumber)
    {
        civB = (Civs)civNumber.value;
        LevelManager.Instance.civB = civB;
        textCivB.text = civB.ToString();
    }
    public void SelectTeam()
    {

    }
    public void CancelCiv()
    {

    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
