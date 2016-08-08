using UnityEngine;
using System.Collections;

public class WeatherSpawner : MonoBehaviour {
		// these values hold grid coordinates for each corner of the room
	public int x1;
	public int x2;
	public int y1;
	public int y2;

		// width and height of room in terms of grid
	public int w;
	public int h;

		// center point of the room
	public Vector3 center;

		// constructor for creating new rooms
	public WeatherSpawner(int x, int y, int w, int h) {
			x1 = x;
			x2 = x + w;
			y1 = y;
			y2 = y + h;
			//this.x = x * Main.TILE_WIDTH;
			//this.y = y * Main.TILE_HEIGHT;
			this.w = w;
			this.h = h;
			//center = new Point(Math.floor((x1 + x2) / 2),Math.floor((y1 + y2) / 2));
	}
}
