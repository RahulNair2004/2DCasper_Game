using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallexController : MonoBehaviour
{
    Transform cam;
    Vector3 camStartPos;
    float distance;

    GameObject[] backgrounds;
    Material[] mat;
    float[] backspeed;

    float farthestBack;

    [Range(0.01f,0.05f)]
    public float parallexSpeed;
 
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
        camStartPos = cam.position;

        int backCount = transform.childCount;
        mat=new Material[backCount];
        backspeed = new float[backCount];
        backgrounds= new GameObject[backCount];

        for (int i=0; i<backCount;i++){
            backgrounds[i] = transform.GetChild(i).gameObject;
            mat[i] = backgrounds[i].GetComponent<Renderer>().material;
        }
        BackSpeedCalculate(backCount);
    }

    void BackSpeedCalculate(int backCount){
        for(int i=0;i<backCount;i++){
            if((backgrounds[i].transform.position.z - cam.position.z)>farthestBack){
                farthestBack=backgrounds[i].transform.position.z - cam.position.z;
            }
        }

        for(int i=0;i<backCount;i++){
            backspeed[i] = 1-(backgrounds[i].transform.position.z - cam.position.z)/farthestBack;
        }
    }
    private void LateUpdate(){
        distance = cam.position.x - camStartPos.x;
        transform.position=new Vector3(cam.position.x,cam.position.y,0);

        for(int i=0;i<backgrounds.Length;i++){
            float speed = backspeed[i]*parallexSpeed;
            mat[i].SetTextureOffset("_MainTex" , new Vector2(distance,0)*speed);
        }
    }
} 
    // Update is called once per frame
    
