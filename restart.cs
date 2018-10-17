using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Codigo escrito por: Henrique Monteiro
//Projeto: Jogo da Memoria - Teste Huddle
//Função: Este codigo faz o replay/restart do jogo
//Linguagem C#
//Ultima revisão: 17/10/2018

public class restart : MonoBehaviour {

	//Função que carrega a cena novamente, fazendo o restart do jogo
	public void Restart()
	{
		//Carrega a cena que já está ativa, fazendo o restart
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
