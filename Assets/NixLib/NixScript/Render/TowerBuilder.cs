using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour {
    public GameObject towerBase;
    public Sprite[] topSprites;
    public Sprite[] midSprites;
    public Sprite[] baseSprites;
    float highOffset = 0.3f;
    const int MaxMidHeight = 0;
    List<int> spriteDat = new List<int>();

    public void Init()
    {
        spriteDat.Clear();
        for(int i = 0; i < 3; i++)
        {
            spriteDat.Add(0);
        }
    }

    public void RandomTower()
    {
        spriteDat.Clear();
        int midHeight = Random.Range(1, MaxMidHeight);
        spriteDat.Add(Random.Range(0, baseSprites.Length - 1));
        for(int i = 0; i < midHeight; i++)
        {
            spriteDat.Add(Random.Range(0, midSprites.Length - 1));
        }
        spriteDat.Add(Random.Range(0, topSprites.Length - 1));
    }

    public void Draw()
    {
        UCS.ClearChild(towerBase.transform);
        float renderZ = 0.0f;
        Vector2 orgPos = new Vector2(0, 0.3f);
        for (int i = 0; i < spriteDat.Count; i++)
        {
            GameObject go = new GameObject("towerPart");
            var render = go.AddComponent<SpriteRenderer>();
            if(i == 0)
            {
                render.sprite = baseSprites[spriteDat[i]];
            }
            else
            {
                if(i == spriteDat.Count - 1)
                {
                    render.sprite = topSprites[spriteDat[i]];
                }
                else
                {
                    render.sprite = midSprites[spriteDat[i]];
                }
            }
            go.transform.SetParent(towerBase.transform);
            Vector2 pos = orgPos + i * new Vector2(0, 0.3f);
            go.transform.localPosition = new Vector3(pos.x, pos.y, renderZ-1);
            //go.transform.SetPositionAndRotation(new Vector3(pos.x, pos.y, renderZ), new Quaternion());
            renderZ -= 0.001f;
        }
    }

    public void SelfTest()
    {
        RandomTower();
        Draw();
    }
}
