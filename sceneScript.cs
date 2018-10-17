using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Codigo escrito por: Henrique Monteiro
//Projeto: Jogo da Memoria - Teste Huddle
//Função: Este codigo é o responsavel peltroca de cenas do jogo 
//Linguagem: C#
//Ultima revisão: 17/10/2018

public class sceneScript : MonoBehaviour {

	public void sceneTo(string scene)
	{
		//Carrega a cena em que foi recebido o valor da função
		SceneManager.LoadScene (scene);
	}
}
