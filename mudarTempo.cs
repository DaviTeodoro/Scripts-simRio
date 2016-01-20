using UnityEngine;
using System.Collections;

/*
Script responsável por controlar a mudança de tempo no simRio.
Versão: 1.0.0
    
Obs importantes: 
1ª: Todos os objetos que irão ser controlados pelo script têm que receber as devidas tags: "passado" para
objetos do passado e "presente" para objetos do presente (outros tempos podem ser adicionados).
2ª: Ao compilar o jogo todos os objetos que irão ser controlados pelo script devem estar marcados como ativos. 

*/


public class mudarTempo : MonoBehaviour {
    public GameObject[] objetosDoPassado;
    public GameObject[] objetosDoPresente;

    /* 
    Ao inicializar o script procura pelos objetos com as tags "passado" e "presente" e os organiza nos arrays
    "objetosDoPassado" e "objetosDoPresente" respectivamente". Em seguida ele passa por cada um (foreach) dos objetos em 
    "objetosDoPassado" e os coloca como inativos. É importante que todos os objetos estejam ativos ao inicializar o jogo, pois
    a função "FindGameObjectsWithTag" não funciona em objetos inativos.
    */
    void Start()
    {
        objetosDoPassado = GameObject.FindGameObjectsWithTag("passado");
        objetosDoPresente = GameObject.FindGameObjectsWithTag("presente");

        foreach (GameObject objeto in objetosDoPassado)
        {
            objeto.active = false;
        }
    }

    /*
    Em cada frame do jogo o script vai esperar pelo input do usuário e vai agir de acordo. Pressionando a tecla "e" 
    todos os objetos em "objetosDoPassado" vão ser postos em inatividade e os em "objetosDoPresente" em atividade. Ou seja
    o jogador vai para o presente. Já se a tecla "r" for pressionada o oposto acontece e o jogador vai para o passado.  
    */
    void Update () {
        if (Input.GetKeyDown("e"))
        {
            //print("quero mudar o tempo"); <--(debug)
            foreach (GameObject objeto in objetosDoPassado)
            {
                objeto.active = false;
            }
            foreach (GameObject objeto in objetosDoPresente)
            {
                objeto.active = true;
            }    
        }
        
        if (Input.GetKeyDown("r"))
        {
            //print("meu passado é meu"); <--(debug)
            foreach (GameObject objeto in objetosDoPassado)
            {
                objeto.active = true;
            }
            foreach (GameObject objeto in objetosDoPresente)
            {
                objeto.active = false;
            }
        }
	
	}
}
