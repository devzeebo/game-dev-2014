using UnityEngine;
using System.Collections;

public class TowerController : MonoBehaviour {
	public GameObject TowerBase;
	public GameObject TowerModule;
	public GameObject TowerWeapon;
	static private int screenwidth = 1365;
	static private int screenheight = 595;
	static private int buttonwidth = 30;
	private Rect RightQuarter = new Rect(3*screenwidth/4, 0, screenwidth -3*screenwidth/4, screenheight);

    public CustomTower WorkingTower;
    public GameObject WorkingTowerSpawn;

    public Vector3 WorldCenter;

    int WorkingSlot;

	// Use this for initialization
	void Start () {
        WorldCenter = Utilities.ScreenToWorld(new Vector2(this.Width(.525f), this.Height(.5f)));

        TowerBase.SetActive(true);
        TowerModule.SetActive(false);
        TowerWeapon.SetActive(false);

        SelectSlot(0);
	}

    public void SetComponent(string module, GameObject obj) {
        switch(module)
        {
            case "Base":
                WorkingTower.towerBase = obj;
                break;
            case "Module":
                WorkingTower.towerModule = obj;
                break;
            case "Weapon":
                WorkingTower.towerWeapon = obj;
                break;
        }
        if (WorkingTowerSpawn != null) {
            Destroy(WorkingTowerSpawn);
        }
        WorkingTowerSpawn = WorkingTower.Spawn(WorldCenter);
        TowerSelectionMenu.Instance[WorkingSlot] = WorkingTower;
    }

    void SelectSlot(int slot) {
        WorkingSlot = slot;
        Destroy(WorkingTowerSpawn);
        WorkingTower = TowerSelectionMenu.Instance[slot];
        WorkingTowerSpawn = WorkingTower.Spawn(WorldCenter);
    }

	void OnGUI(){
        /*
		//Edit Tower Slot Button
		if (GUI.Button(new Rect(screenwidth/3-50 , screenheight/2-50, 100, 100),"Slot 1"))
		{
            SelectSlot(0);
            Vector3 Button1 = new Vector3(screenwidth / 3 - 50, screenheight / 2 - 50, 0);
            TowerSelectionMenu.Instance[0].Spawn(Button1);
            TowerSelectionMenu.Instance[0] = WorkingTower;
		}
		if (GUI.Button(new Rect(2*screenwidth/3-50 , screenheight/2-50, 100, 100),"Slot 2"))
		{
            SelectSlot(1);
		}
        //*/
		// Use Tower Button
		if (GUI.Button(new Rect(screenwidth/2-50 , 3*screenheight/4-50, 100, 100),"Use Tower"))
			// this code refrences http://docs.unity3d.com/Documentation/ScriptReference/Rect.html
		{
			Debug.Log("Clicked the button with an image");
			Application.LoadLevel(2);

			// use get component to get the prefab info for whichever prefab is selected
		}
		// Component Selection Window
		if (GUI.Button(new Rect(3*screenwidth/4-buttonwidth , 2*screenheight/3, buttonwidth, screenheight/3), "b\na\ns\ne"))
		{
			Debug.Log("Clicked the button with an image");
			//btnTexture3=btnTexture;
            TowerBase.SetActive ( true);
            TowerModule.SetActive (false);
            TowerWeapon.SetActive (false);
		}
		if (GUI.Button(new Rect(3*screenwidth/4-buttonwidth , screenheight/3, buttonwidth, screenheight/3), "m\no\nd\nu\nl\ne"))
		{
			Debug.Log("Clicked the button with an image");
			//btnTexture3=btnTexture;
            TowerBase.SetActive(false);
            TowerModule.SetActive(true);
            TowerWeapon.SetActive(false);
		}
		if (GUI.Button(new Rect(3*screenwidth/4-buttonwidth , 0, buttonwidth, screenheight/3), "w\ne\na\np\no\nn"))
		{
			Debug.Log("Clicked the button with an image");
            TowerBase.SetActive(false);
            TowerModule.SetActive(false);
            TowerWeapon.SetActive(true);
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
