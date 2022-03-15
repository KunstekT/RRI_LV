using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] List<Sprite> sprites;

    // Start is called before the first frame update
    void Start()
    {
        sprites = new List<Sprite>();
        sprites.Clear();
        sprites.Add(Resources.Load<Sprite>("Sprites/alienraid"));
        sprites.Add(Resources.Load<Sprite>("Sprites/bathroom"));
        sprites.Add(Resources.Load<Sprite>("Sprites/default"));
        sprites.Add(Resources.Load<Sprite>("Sprites/dogman"));
        sprites.Add(Resources.Load<Sprite>("Sprites/hallway"));
        sprites.Add(Resources.Load<Sprite>("Sprites/power_battery"));
        sprites.Add(Resources.Load<Sprite>("Sprites/weapons"));
        sprites.Add(Resources.Load<Sprite>("Sprites/window"));
        sprites.Add(Resources.Load<Sprite>("Sprites/mouthwash"));
        sprites.Add(Resources.Load<Sprite>("Sprites/translator"));
        sprites.Add(Resources.Load<Sprite>("Sprites/spaceship"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAndShowImage(int SpriteIndex, bool power)
    {
        if(power==true){
            image.sprite = sprites[SpriteIndex];
            image.color = Color.white;
        }else{
            // TODO - lower image brightness            
            image.sprite = sprites[SpriteIndex];
            image.color = Color.grey;
        }
    }
}
