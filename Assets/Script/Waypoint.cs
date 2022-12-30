using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waypoint : MonoBehaviour
{
    public RectTransform prefab;

    private RectTransform waypoint;

    private Transform player;
    private Text distanceText;
    public Vector3 offset = new Vector3(0, 1.25f, 0);

    void Start()
    {
        var canvas = GameObject.Find("Waypoints").transform;

        waypoint = Instantiate(prefab, canvas);
        distanceText = waypoint.GetComponentInChildren<Text>();
        player = GameObject.Find("Truck").transform;
    }

    // Update is called once per frame
    void Update()
    {
        var screenPos = Camera.main.WorldToScreenPoint(transform.position+ offset);
        waypoint.position = screenPos;

        waypoint.gameObject.SetActive(screenPos.z > 0);

        distanceText.text = Vector3.Distance(player.position, transform.position).ToString("0") + " m";
    }
}
