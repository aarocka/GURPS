using UnityEngine;
using System.Collections;
using SocketIO;

public class NetCode : MonoBehaviour {
    private SocketIOComponent socket;

	// Use this for initialization
	void Start () {
        GameObject go = GameObject.Find("SocketIO");
        socket = go.GetComponent<SocketIOComponent>();
        socket.Emit("join", "aaron");

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void spawnEnimies()
    {

    }
}
