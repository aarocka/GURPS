using UnityEngine;
using System.Collections;
using SocketIO;

public class NetCode : MonoBehaviour {
    private SocketIOComponent socket;
    public string nic = "";
    static string gameInfoString = "{\"gameID\":123456,\"turn\":1,\"gameStart\":true,\"players\":[{\"uid\":\"#NQwErTy\",\"playerNumber\":1,\"nicname\":\"Aaron\",\"posX\":0,\"posY\":0,\"maxHealth\":100,\"health\":100},{\"uid\":\"#NrJ6wYR9JK_IBFCGAAAA\",\"playerNumber\":2,\"nicname\":\"steve\",\"posX\":17.64,\"posY\":0,\"maxHealth\":100,\"health\":100}]}";
    static string playerObjectString = "{\"uid\":\"#NQwErTy\",\"playerNumber\":1,\"nicname\":\"Aaron\",\"posX\":0,\"posY\":0,\"maxHealth\":100,\"health\":100}";
    JSONObject gameInfo = new JSONObject(gameInfoString);
    JSONObject playerObject = new JSONObject(playerObjectString);

    // Use this for initialization
    void Start () {
        GameObject go = GameObject.Find("SocketIO");
        socket = go.GetComponent<SocketIOComponent>();
        //socket.On("open", OnSocketOpen);
        //socket.On("playerJoined", spawnPlayer);
        //socket.On("gameStarted", spawnEnemies);
        spawnPlayer(playerObject);
        spawnEnemies(gameInfo);
        

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

    void spawnEnemies(JSONObject e)
    {
        //Debug.Log(string.Format("[name: {0}, data: {1}]", e.name, e.data));
        JSONObject players = (JSONObject)e.list[3];
        //Debug.Log(players.list[0]);

        foreach (JSONObject j in players.list)
        {

            Debug.Log(j.list[1]);
            Debug.Log(playerObject.list[1]);
            if (j.list[1].n == playerObject.list[1].n)
            {
                Debug.Log("This one is the player");
            }
            else
            {
                Debug.Log("spawned the enemy");
            }
        }

    }

    void startGame()
    {
        socket.Emit("start", "something");
    }

    public void spawnPlayer(JSONObject e)
    {
        //Debug.Log(string.Format("[name: {0}, data: {1}]", e.name, e.data));
        Debug.Log("You are player number" + e.list[1]);
        Debug.Log(e.keys[3] + ":" +e.list[3].n);
        Debug.Log(e.keys[4] + ":" + e.list[4].n);
        int tempX = (int)e.list[3].n;
        int tempY = (int)e.list[4].n;        

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
