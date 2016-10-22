using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SpawnAlgorithm : MonoBehaviour {
	//TODO: Pensar en una condición de spawn (cada 2 segundos, etc...)
	public int TiempoSpawn = 2;
	public int tiempoInicial;
	private List <Vector2> ListaPuntos;
	private List <Vector2> PuntosPersonajes;
	// TODO: Plantear crear más de un alimento a la vez
	public GameObject alimento;

	// Use this for initialization
	void Start () {
		tiempoInicial = System.DateTime.Now.Second;

		// Inicializamos los puntos de los personajes
		GameObject[]puntos = GameObject.FindGameObjectsWithTag("Player");
		PuntosPersonajes = new List<Vector2> ();
		foreach (GameObject punto in puntos) {
			if (GameObject.FindGameObjectsWithTag ("Comida")
				.Where (x => x.transform.position == punto.transform.position).ToList().Count <= 0) {
				PuntosPersonajes.Add (punto.transform.position);
			}
		}

		// Inicializamos los puntos de spawn
		puntos = GameObject.FindGameObjectsWithTag ("Spawn");
		ListaPuntos = new List<Vector2> ();
		foreach (GameObject punto in puntos) {
			ListaPuntos.Add (punto.transform.position);
		}
	}

	// Método que devuelve el punto en el que realizar el spawn
	private Vector2 GetPuntoSpawn() {
		Dictionary<Vector2, float> diccionarioPuntos = new Dictionary<Vector2, float>();
		foreach (Vector2 punto in ListaPuntos) {
			diccionarioPuntos.Add (
				punto,
				Mathf.Abs (
					Vector2.Distance (punto, PuntosPersonajes[0]) - Vector2.Distance (punto, PuntosPersonajes[1])
				)
			);
		}
		float heuristico = float.MaxValue;
		
		for (int i = 0; i < ListaPuntos.Count; i++) {
			if (diccionarioPuntos [ListaPuntos [i]] < heuristico) {
				heuristico = diccionarioPuntos [ListaPuntos [i]];
			}
		}
		return diccionarioPuntos.FirstOrDefault (x => x.Value == heuristico).Key;
	}

	// Método que spawnea un alimento
	private void Spawn() {
		GameObject.Instantiate (
			alimento,
			GameObject.FindGameObjectsWithTag("Spawn").Where(x => ((Vector2)x.transform.position) == GetPuntoSpawn()).First().transform
		);
	}

	// Update is called once per frame
	void Update () {
		if (tiempoInicial - System.DateTime.Now.Second >= TiempoSpawn) {
			Spawn ();
			tiempoInicial = System.DateTime.Now.Second;
		}
	}
}