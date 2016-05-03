using UnityEngine;
using System.Collections;
using SocketIO;

public class NetCode : MonoBehaviour {
    private SocketIOComponent socket;
    public string nic = "";
    static string gameInfoString = "{\"gameID\":123456,\"turn\":1,\"gameStart\":true,\"players\":[{\"uid\":\"#NrJ6wYR9JK_IBFCGAAAA\",\"playerNumber\":1,\"nicname\":\"Aaron\",\"posX\":0,\"posY\":0,\"maxHealth\":100,\"health\":100},{\"uid\":\"#NrJ6wYR9JK_IBFCGAAAA\",\"playerNumber\":2,\"nicname\":\"steve\",\"posX\":17.64,\"posY\":0,\"maxHealth\":100,\"health\":100}]}";
    static string playerObjectString = "{\"uid\":\"#NrJ6wYR9JK_IBFCGAAAA\",\"playerNumber\":1,\"nicname\":\"Aaron\",\"posX\":0,\"posY\":0,\"maxHealth\":100,\"health\":100}";
    JSONObject gameInfo = new JSONObject(gameInfoString);
    JSONObject playerObject = new JSONObject(playerObjectString);

    // Use this for initialization
    void Start () {
        GameObject go = GameObject.Find("SocketIO");
        socket = go.GetComponent<SocketIOComponent>();
        socket.On("open", OnSocketOpen);
        socket.On("playerJoined", spawnPlayer);
        socket.On("gameStarted", spawnEnemies);

        Debug.Log(playerObject.list.Count);

        for (int i = 0; i < playerObject.list.Count; i++)
        {
            Debug.Log(playerObject.keys[i] +":"+ playerObject.list[i]);
        }

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

    void accessData(JSONObject obj)
    {
        switch (obj.type)
        {
            case JSONObject.Type.OBJECT:
                for (int i = 0; i < obj.list.Count; i++)
                {
                    string key = (string)obj.keys[i];
                    JSONObject j = (JSONObject)obj.list[i];
                    Debug.Log(key);
                    accessData(j);
                }
                break;
            case JSONObject.Type.ARRAY:
                foreach (JSONObject j in obj.list)
                {
                    accessData(j);
                }
                break;
            case JSONObject.Type.STRING:
                Debug.Log(obj.str);
                break;
            case JSONObject.Type.NUMBER:
                Debug.Log(obj.n);
                break;
            case JSONObject.Type.BOOL:
                Debug.Log(obj.b);
                break;
            case JSONObject.Type.NULL:
                Debug.Log("NULL");
                break;

        }
    }
}
