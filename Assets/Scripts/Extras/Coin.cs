using UnityEngine;

public class Coin : MonoBehaviour {

    bool collected = false;
    float speed = 1;
    float riseSpeed = 12;
    float rise = 2;

    Collider trigger;
    AudioSource sound;

    // Use this for initialization
    void Start() {
        trigger = GetComponent<Collider>();
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(90 * speed * Time.deltaTime, 0, 0);
        if (collected) transform.Translate(rise * Time.deltaTime, 0, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        DestroyObject(trigger);
        sound.Play();
        Game.AddScore(1);
        speed = riseSpeed;
        collected = true;
        DestroyObject(this.gameObject, 0.5f);
    }

}
