using UnityEngine;
using System.Collections;

/*
Script responsável por controlar a mudança de tempo no simRio.
Versão: 2.5.0
 

    Ao inicializar, o script procura pelos objetos com as tags "tagDoPassado" e "tagDopresente" e os organiza nos arrays
"objetosDoPassado" e "objetosDoPresente" respectivamente. Em seguida ele passa por cada um (foreach) dos objetos em 
"objetosDoPassado" e os coloca como inativos. É importante que todos os objetos estejam ativos ao inicializar o jogo, pois
a função "FindGameObjectsWithTag" não funciona em objetos inativos.

    Em cada frame do jogo o script vai esperar pelo input do usuário e vai agir de acordo; pressionando a tecla "e" 
todos os objetos em "objetosDoPassado" vão ser definidos como inativos e os em "objetosDoPresente" como ativos. Ou seja
o jogador vai para o presente. Já se a tecla "r" for pressionada o oposto acontece e o jogador vai para o passado.  
        
Obs importantes: 
1ª: O game-designer tem que definir previamente o nome das tags "tagDoPassado" e tagDoPresente" e taggear os objetos de acordo com seus
tempos.  
2ª: Ao compilar o jogo, todos os objetos que irão ser controlados pelo script devem estar marcados como ativos. 


*/


public class mudarTempo : MonoBehaviour {
    //Variaveis globais definidas pelo game-designer;
    public string tagDoPassado;
    public string tagDoPresente;

    //Controla a condição temporal do jogo
    bool noPassado;
    bool noPresente;

    //Arrays que irão receber os objetos taggeados 
    GameObject[] objetosDoPassado;
    GameObject[] objetosDoPresente;

  /* Ao inicializar */
    void Start()
    {
        //Preencher os arrays "objetosDoPassado" com os objetos com a "tagDoPassado".
        objetosDoPassado = GameObject.FindGameObjectsWithTag(tagDoPassado);

        //Preencher os arrays "objetosDoPresente" com os objetos com a "tagDoPresente". 
        objetosDoPresente = GameObject.FindGameObjectsWithTag(tagDoPresente);

        //Para cada objeto em objetosDoPassado.
        foreach (GameObject objeto in objetosDoPassado)
        {
            //Definir determinado objeto como inativo. 
            objeto.active = false;
            noPassado = false;
            noPresente = true;
        }
    }

    /* Em cada frame*/
    void Update () {

        //Caso o usuário aperte a tecla 'e'.
        if (Input.GetKeyDown("e") && noPassado)
        {
            //Para cada objeto em objetosDoPassado.
            foreach (GameObject objeto in objetosDoPassado)
            {
                //Difinir determinado objeto como inativo.
                objeto.active = false;
            }
            //Para cada objeto em objetosDoPresente.
            foreach (GameObject objeto in objetosDoPresente)
            {
                //Definir determinado objeto como ativo.
                objeto.active = true;
            }
            noPassado = false;
            noPresente = true;  
        }

        //Caso o usuário aperte a tecla 'r'.
        if (Input.GetKeyDown("r") && noPresente)
        {
            //Para cada objeto em objetosDoPassado.
            foreach (GameObject objeto in objetosDoPassado)
            {
                //Definir determinado objeto como ativo.
                objeto.active = true;
            }
            //Para cada objeto em objetosDoPresente.
            foreach (GameObject objeto in objetosDoPresente)
            {
                //Definir determinado objeto como ativo.
                objeto.active = false;
            }
            noPassado = true;
            noPresente = false;
        }
	
	}
}
