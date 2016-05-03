using UnityEngine;
using System.Collections;
using SocketIO;

public class NetCode : MonoBehaviour {
    private SocketIOComponent socket;
    public string nic = "";
	// Use this for initialization
	void Start () {
        GameObject go = GameObject.Find("SocketIO");
        socket = go.GetComponent<SocketIOComponent>();
        socket.On("open", OnSocketOpen);
        socket.On("playerJoined", logMe);
        socket.On("gameStarted", spawnEnimies);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("s"))
        {
            Debug.Log("Starting Game");
            startGame();
        }
        else if (Input.GetKeyDown("j"))
        {
            Debug.Log("joining game with username "+nic);
            socket.Emit("join", nic);
        }
	}

    void spawnEnimies(SocketIOEvent e)
    {
        Debug.Log(string.Format("[name: {0}, data: {1}]", e.name, e.data));
    }

    void startGame()
    {
        socket.Emit("start", "something");
    }

    public void logMe(SocketIOEvent e)
    {
        Debug.Log(string.Format("[name: {0}, data: {1}]", e.name, e.data));
    }
    public void OnSocketOpen(SocketIOEvent ev)
    {
        Debug.Log("updated socket id " + socket.sid);
    }

}
