using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class SpawnAlgorithm : MonoBehaviour {

	public float TiempoSpawn = 2;
	public float TiempoCambioSpawn = 10;
	private float tiempoInicial;
	private float tiempoInicialCambioSpawn;

	private List <Vector2> ListaPuntos;
	private List <Vector2> PuntosPersonajes;
	// TODO: Plantear crear más de un alimento a la vez
	public GameObject alimento;

	// Use this for initialization
	void Start () {
		tiempoInicial = Time.timeSinceLevelLoad;
		tiempoInicialCambioSpawn = Time.timeSinceLevelLoad;
	}

	// Inicializa las listas de puntos
	private void InicializarListas() {
		// Inicializamos los puntos de los personajes
		GameObject[]puntos = GameObject.FindGameObjectsWithTag("Player");
		PuntosPersonajes = new List<Vector2> ();
		foreach (GameObject punto in puntos) {
			PuntosPersonajes.Add (punto.transform.position);
		}

		// Inicializamos los puntos de spawn
		puntos = GameObject.FindGameObjectsWithTag ("Spawn");
		ListaPuntos = new List<Vector2> ();
		foreach (GameObject punto in puntos) {
			if (GameObject.FindGameObjectsWithTag ("Comida")
				.Where (x => x.transform.position == punto.transform.position).ToList ().Count <= 0) {
				ListaPuntos.Add (punto.transform.position);
			}
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
		InicializarListas ();
		GameObject comida = (GameObject) GameObject.Instantiate (
			GetComponent<FoodSpriteSelector>().giveRandomFood(),
        	GetPuntoSpawn(),
			Quaternion.identity
		);
		comida.transform.parent = GameObject.Find ("Food").transform;
	}

	// Método que cambia el Tiempo de Spawn
	private void CambiarTiempoSpawn() {
		if (Mathf.Abs(Time.timeSinceLevelLoad - tiempoInicialCambioSpawn) >= TiempoCambioSpawn) {
			TiempoSpawn += (2 / Mathf.PI) * Mathf.Atan (Time.timeSinceLevelLoad / 10);
			tiempoInicialCambioSpawn = Time.timeSinceLevelLoad;
		}
	}

	// Update is called once per frame
	void Update () {
		CambiarTiempoSpawn ();
		if (Mathf.Abs(Time.timeSinceLevelLoad - tiempoInicial) >= TiempoSpawn) {
			Spawn ();
			tiempoInicial = Time.timeSinceLevelLoad;
		}
	}
}