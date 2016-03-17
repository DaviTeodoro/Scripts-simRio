using UnityEngine;
using System.Collections;

public class MudarTempo : MonoBehaviour {
    GameObject[] objetosMudaveis;
    int anoPresente = 1890;
    // Use this for initialization

    void Start () {
        objetosMudaveis =  GameObject.FindGameObjectsWithTag("mudavel");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("e"))
        {
            print("eu estou em " + anoPresente);
            foreach (GameObject objeto in objetosMudaveis)
            {
                objeto.SetActive(existoNoAno(objeto, anoPresente));
            }
        }
	
	}

    public bool existoNoAno(GameObject objeto, int anoPresente)
    {
        
        string nomeDoObjeto = objeto.transform.name;
        //guarda o ano de construcao objeto.transform.name;
        int anoContrucao = System.Int32.Parse(nomeDoObjeto.Substring(nomeDoObjeto.IndexOf("@")+1, 4)); 
        int anoDemolicao = System.Int32.Parse(nomeDoObjeto.Substring(nomeDoObjeto.IndexOf("@") + 6, 4));
        //print(nomeDoObjeto.Substring(nomeDoObjeto.IndexOf("@") + 6, 4));
        //return false;

        if (anoPresente <= anoContrucao)
        {
            return false;
        }
        else if (anoPresente > anoContrucao && anoPresente < anoDemolicao )
        {
            return true;
        }
        else if (anoPresente >= anoDemolicao)
        {
            return false;
        }
       else
        {
            print("@DEBUG: Aconteceu alguma coisa errada!");
            return false;
        }
    }


}


