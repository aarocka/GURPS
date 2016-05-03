using UnityEngine;
using System.Collections;
using SocketIO;

public class NetCode : MonoBehaviour {
    private SocketIOComponent socket;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public string nic = "";
    static string gameInfoString = "{\"gameID\":123456,\"turn\":1,\"gameStart\":true,\"players\":[{\"uid\":\"#NQwErTy\",\"playerNumber\":1,\"nicname\":\"Aaron\",\"posX\":0,\"posY\":0,\"maxHealth\":100,\"health\":100},{\"uid\":\"#NrJ6wYR9JK_IBFCGAAAA\",\"playerNumber\":2,\"nicname\":\"steve\",\"posX\":17.64,\"posY\":0,\"maxHealth\":100,\"health\":100}]}";
    static string playerObjectString = "{\"uid\":\"#NQwErTy\",\"playerNumber\":1,\"nicname\":\"Aaron\",\"posX\":0,\"posY\":0,\"maxHealth\":100,\"health\":100}";
    public JSONObject gameInfo = new JSONObject(gameInfoString);
    public JSONObject playerObject = new JSONObject(playerObjectString);
	public float playerTurn;
	public float playerNumber;
    // Use this for initialization
    void Start () {
        GameObject go = GameObject.Find("SocketIO");
        socket = go.GetComponent<SocketIOComponent>();
        socket.On("playerJoined", spawnPlayerFromSocket);
        socket.On("gameStarted", spawnEnemiesFromSocket);
        socket.On("turnEnded", updatePlayerPositions);
        //spawnPlayer(playerObject);
        //spawnEnemies(gameInfo);
        

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("s"))
        {
            Debug.Log("Starting Game");
            socket.Emit("start", "something");
        }
        else if (Input.GetKeyDown("j"))
        {
            Debug.Log("joining game with username "+nic);
            socket.Emit("join", nic);
        }
		else if (Input.GetKeyDown("e"))
        {
			GameObject player = GameObject.FindGameObjectWithTag ("Player");
			player.GetComponent<Unit> ().moveCounter = 0;
			playerObject.list [3].n = player.transform.position.x;
			playerObject.list [4].n = player.transform.position.z;
			socket.Emit ("playerUpdate", playerObject);
        }
	}

    void spawnEnemies(JSONObject e)
    {
        //Debug.Log(string.Format("[name: {0}, data: {1}]", e.name, e.data));
        JSONObject players = (JSONObject)e.list[3];
        //Debug.Log(players.list[0]);

        foreach (JSONObject j in players.list)
        {
            if (j.list[1].n != playerObject.list[1].n)
            {
                Debug.Log("Spawned enemy:"+j);
                float tempX = j.list[3].n;
                float tempY = j.list[4].n;

                Instantiate(enemyPrefab, new Vector3(tempX, 0, tempY), Quaternion.identity);
            }
        }

    }


    public void spawnPlayer(JSONObject e)
    {
        //Debug.Log(string.Format("[name: {0}, data: {1}]", e.name, e.data));
        Debug.Log("You are player number" + e.list[1]);
        float tempX = e.list[3].n;
        float tempY = e.list[4].n;
        Instantiate(playerPrefab, new Vector3(tempX, 0, tempY), Quaternion.identity);
    }

    void spawnEnemiesFromSocket(SocketIOEvent e)
    {
        //Debug.Log(string.Format("[name: {0}, data: {1}]", e.name, e.data));
        JSONObject players = (JSONObject)e.data.list[3];
		playerTurn = e.data.list [1].n;
        //Debug.Log(players.list[0]);

        foreach (JSONObject j in players.list)
        {
            if (j.list[1].n != playerObject.list[1].n)
            {
                Debug.Log("Spawned enemy:" + j);
                float tempX = j.list[3].n;
                float tempY = j.list[4].n;

                GameObject temp = (GameObject)Instantiate(enemyPrefab, new Vector3(tempX, 0, tempY), Quaternion.identity);
                temp.name = j.list[2].str;
            }
        }

    }


    public void spawnPlayerFromSocket(SocketIOEvent e)
    {
        //Debug.Log(string.Format("[name: {0}, data: {1}]", e.name, e.data));
        playerObject = e.data;
        Debug.Log("You are player number" + e.data.list[1]);
		playerNumber = e.data.list[1].n;
        float tempX = e.data.list[3].n;
        float tempY = e.data.list[4].n;
        GameObject temp = (GameObject)Instantiate(playerPrefab, new Vector3(tempX, 0, tempY), Quaternion.identity);
        temp.name = e.data.list[2].str;
        Camera.main.GetComponent<Mouse>().setPlayer();
    }

    public void updatePlayerPositions(SocketIOEvent e) {
        JSONObject players = (JSONObject)e.data.list[3];

		playerTurn = e.data.list [1].n;

        foreach (JSONObject j in players.list)
        {
            if (j.list[1].n != playerObject.list[1].n)
            {
                Unit temp = GameObject.Find(j.list[2].str).GetComponent<Unit>();
                temp.destination = new Vector3(j.list[3].n,0,j.list[4].n);
            }
        }


    }
    public void OnSocketOpen(SocketIOEvent ev)
    {
        Debug.Log("updated socket id " + socket.sid);
    }
}
