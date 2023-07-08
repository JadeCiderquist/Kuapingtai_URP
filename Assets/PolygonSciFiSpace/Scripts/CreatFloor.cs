using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatFloor : MonoBehaviour
{
    public GameObject player;
    public List<Transform> prefabFloor;
    public List<Transform> floors;
    float Cam_positionz;
    Transform lastFloor;
    Transform firstFloor;
    float twice_lastfloor = 399.155f;
    bool doOnce = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CreatDestroyFloor();
        
    }

    void CreatDestroyFloor()
    {
        Cam_positionz = player.transform.position.z;

        if (doOnce)
        {
            if (twice_lastfloor < Cam_positionz + 300)
            {
                Transform prefab = prefabFloor[0];
                Transform newFloor = Instantiate(prefab, null);
                newFloor.position = new Vector3(0, 0, twice_lastfloor) + new Vector3(0, 0, 10);
                floors.Add(newFloor);
            }
            doOnce = false;
        }
        else
        {
            if (player.transform.position.z <= 3000)//����С��3000ʱ������������
            {
                //����Floor
                lastFloor = floors[floors.Count - 1];
                if (lastFloor.position.z < Cam_positionz + 300)
                {
                    Transform prefab = prefabFloor[Random.Range(0, 11)];
                    Transform newFloor = Instantiate(prefab, null);
                    newFloor.position = lastFloor.position + new Vector3(0, 0, 10);
                    floors.Add(newFloor);
                }

                //���ٵذ�
                firstFloor = floors[0];
                if (firstFloor.position.z < Cam_positionz - 30)
                {
                    floors.RemoveAt(0);
                    Destroy(firstFloor.gameObject);
                }
            }else if(player.transform.position.z > 3000 && player.transform.position.z <= 5000)//�����յغͰڴ�����
            {
                lastFloor = floors[floors.Count - 1];
                if (lastFloor.position.z < Cam_positionz + 300)
                {
                    Transform prefab = prefabFloor[Random.Range(0, 13)];
                    Transform newFloor = Instantiate(prefab, null);
                    newFloor.position = lastFloor.position + new Vector3(0, 0, 10);
                    floors.Add(newFloor);
                }

                //���ٵذ�
                firstFloor = floors[0];
                if (firstFloor.position.z < Cam_positionz - 30)
                {
                    floors.RemoveAt(0);
                    Destroy(firstFloor.gameObject);
                }
            }
            else//����ȫ������
            {
                //����Floor
                lastFloor = floors[floors.Count - 1];
                if (lastFloor.position.z < Cam_positionz + 300)
                {
                    Transform prefab = prefabFloor[Random.Range(0, prefabFloor.Count)];
                    Transform newFloor = Instantiate(prefab, null);
                    newFloor.position = lastFloor.position + new Vector3(0, 0, 10);
                    floors.Add(newFloor);
                }

                //���ٵذ�
                firstFloor = floors[0];
                if (firstFloor.position.z < Cam_positionz - 30)
                {
                    floors.RemoveAt(0);
                    Destroy(firstFloor.gameObject);
                }
            }
            
        }   
    }
}
