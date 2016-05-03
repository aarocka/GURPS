using UnityEngine;
using System.Collections;
using SocketIO;

public class NetCode : MonoBehaviour {
    private SocketIOComponent socket;
    public string nic = "";
    string encodedData = "{\"gameID\":123456,\"turn\":1,\"gameStart\":true,\"players\":[{\"uid\":\"#NrJ6wYR9JK_IBFCGAAAA\",\"playerNumber\":1,\"nicname\":\"Aaron\",\"posX\":0,\"posY\":0,\"maxHealth\":100,\"health\":100},{\"uid\":\"#NrJ6wYR9JK_IBFCGAAAA\",\"playerNumber\":2,\"nicname\":\"steve\",\"posX\":17.64,\"posY\":0,\"maxHealth\":100,\"health\":100}]}";
	// Use this for initialization
	void Start () {
        GameObject go = GameObject.Find("SocketIO");
        socket = go.GetComponent<SocketIOComponent>();
        socket.On("open", OnSocketOpen);
        socket.On("playerJoined", spawnPlayer);
        socket.On("gameStarted", spawnEnemies);
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

    void spawnEnemies(SocketIOEvent e)
    {
        Debug.Log(string.Format("[name: {0}, data: {1}]", e.name, e.data));
        
    }

    void startGame()
    {
        socket.Emit("start", "something");
    }

    public void spawnPlayer(SocketIOEvent e)
    {
        Debug.Log(string.Format("[name: {0}, data: {1}]", e.name, e.data));
        
    }
    public void OnSocketOpen(SocketIOEvent ev)
    {
        Debug.Log("updated socket id " + socket.sid);
    }

}
