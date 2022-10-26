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
        p�ntanos,
        estepes,
        praias,
        desfiladeiros
    };
    public Terrains terreno;

    public enum Civs
    {
        imp�rioromano,
        dinastiaHan,
        hunos,
        cidadedeEsparta,
        imp�rioP�rsa,
        imp�rioMaced�nico,
        imp�rioCartagin�s
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
        switch (terrainNumber.value)
        {
            case 0:
                textTerrain.text = "Quando h� florestas, as �rvores diminuem a visibilidade dos ex�rcitos e tamb�m oferecem maior prote��o contra ataques � dist�ncia, dependendo da densidade destas. Vale ressaltar que, em selvas mais tropicais, a umidade presente no ar acelera o processo de infec��o de feridas, assim como o processo de decomposi��o dos corpos. "
                    + "\n" + "- visibilidade " 
                    + "\n" + "- range" 
                    + "\n" + "- speed";
                break;
            case 1:
                textTerrain.text = "Em terrenos montanhosos, h� maior possibilidade de emboscadas, devido � exist�ncia de cavernas e � verticalidade do campo de batalha. Al�m disso, quanto maior a altitude, menor a densidade do ar, podendo causar falta de oxig�nio em soldados menos preparados. Vale notar tamb�m a possibilidade de desastres, como avalanches e deslizamentos, mesmo n�o existindo planos para a implementa��o destes."
                    + "\n" + "+/-speed "
                    + "\n" + "+/-range"
                    + "\n" + "+/-visibilidade";
                break;
            case 2:
                textTerrain.text = "Em desertos, a falta de umidade pode afetar a moral das tropas, assim como o consumo de suprimentos. Equipamentos tamb�m podem ser afetados em batalhas mais longas. Quando s�o desertos de areia, geralmente o terreno � plano, mas podem haver dunas m�veis ou mesmo montanhas."
                    + "\n" + "+cansa�o"
                    + "\n" + "+fome"
                    + "\n" + "+equipamento";
                break;
            case 3:
                textTerrain.text = "Em locais pantanosos ou com grande concentra��o de lama, a movimenta��o das tropas pode sofrer uma diminui��o de velocidade, ou mesmo ser parada por completo."
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
        textCivA.text = civA.ToString();
    }
    public void SelectCivB(TMP_Dropdown civNumber)
    {
        civB = (Civs)civNumber.value;
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
