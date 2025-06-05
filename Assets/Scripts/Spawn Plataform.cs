using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlataform : MonoBehaviour
{

    public List<GameObject> plataforms = new List<GameObject>(); //lista de plataformas, de prefabs, a serem instanciadas
    public List<Transform> currentPlatforms = new List<Transform>(); //lista de pontos de spawn, de objectos, onde as plataformas serao instanciadas
    public int offset; //distancia entre as plataformas

    private Transform player;
    private Transform currentPlatformPoint;
    private int platformIndex; //indice da plataforma atual

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; //encontra o jogador na cena

        // Instancia as plataformas na cena
        for (int i = 0; i < plataforms.Count; i++) //loop para instanciar as plataformas
        {
            Transform p = Instantiate(plataforms[i], new Vector3(0, 0, i * 22), transform.rotation).transform; //instancia a plataforma na posicao 0,0,0
            currentPlatforms.Add(p); //adiciona a plataforma instanciada na lista de plataformas
            offset += 22; //define a distancia entre as plataformas
        }

        currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Plataform>().point; //define o ponto de spawn da primeira plataforma, no codigo Plataform.cs
    }


    // Update is called once per frame
    void Update()
    {
        float distance = player.position.z - currentPlatformPoint.position.z; //calcula a distancia entre o jogador e o ponto de spawn da plataforma atual
        Debug.Log("Distance: " + distance);
    }

    public void recicle(GameObject platform)
    {
        platform.transform.position = new Vector3(0, 0, plataforms.Count * offset); //move a plataforma para a posicao 0,0,0
        offset += 22; //define a distancia entre as plataformas
    }
}
