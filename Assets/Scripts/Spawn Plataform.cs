using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlataform : MonoBehaviour
{

    public List<GameObject> plataforms = new List<GameObject>(); //lista de plataformas

    public int offset; //distancia entre as plataformas

    // Start is called before the first frame update
    void Start()
    {
        // Instancia as plataformas na cena
        for (int i = 0; i < plataforms.Count; i++) //loop para instanciar as plataformas
        {
            Instantiate(plataforms[i], new Vector3(0, 0, i * 22), transform.rotation); //instancia a plataforma na posicao 0,0,0
            offset += 22; //define a distancia entre as plataformas
        }

    }

    public GameObject myPlatform; //plataforma a ser reciclada

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) //se a tecla espaco for pressionada
        {
            recicle(myPlatform); //chama o metodo recicle
        }
    }

    public void recicle(GameObject platform)
    {
        platform.transform.position = new Vector3(0, 0, plataforms.Count * offset); //move a plataforma para a posicao 0,0,0
        offset += 22; //define a distancia entre as plataformas
    }
}
