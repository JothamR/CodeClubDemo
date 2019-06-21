using UnityEngine;

public class Bullet : MonoBehaviour {

    private float lifetime;
    private Material mat;
    private Color color;
    //private bool isAltered;
    //private Vector3 scale;

	// Use this for initialization
	void Awake () {
        var renderer = this.GetComponent<MeshRenderer>();
        mat = renderer.material;
        color = mat.color;
        //scale = this.transform.localScale;
    }

    void OnEnable()
    {
        //Reset
        lifetime = 3f;
        mat.color = color;
        //isAltered = false;
        //this.transform.localScale = scale;
    }

    // Update is called once per frame
    void Update () {
        lifetime -= Time.deltaTime;
        if (lifetime < 0.5f)
        {
            //isAltered = true;
            float c = lifetime;// 0.5f + lifetime;
            mat.color = new Color(color.r + c, color.g+c, color.b+c, c);
            //float s = lifetime;
            //this.transform.localScale = new Vector3(s, s, s);
        }
    }
}
