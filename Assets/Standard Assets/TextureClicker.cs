using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureClicker : MonoBehaviour
{
    //[SerializeField] Material material;
    private float _currentPower;
    private bool _isMouseUp;
    private bool _isNeedStarCoroutine;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentPower = 0;
            _isMouseUp = false;
            _isNeedStarCoroutine = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isMouseUp = true;
        }

        if (Input.GetMouseButton(0))
        {

            RaycastHit hit;
            if (!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                return;

            Renderer rend = hit.transform.GetComponent<Renderer>();
            Collider Collider = hit.collider as Collider;

            if (rend == null || rend.sharedMaterial == null || rend.sharedMaterial.mainTexture == null || Collider == null)
                return;

            _currentPower += Time.deltaTime * 4;
            if (_currentPower > 1.5f) _currentPower = 1.5f;

            for (int i = 0; i < rend.materials.Length; i++)
            {
                Material currentMat = rend.materials[i];

                //print(hit.textureCoord);
                currentMat.SetVector(name: "_MousePos", hit.textureCoord); 
                currentMat.SetVector(name: "_MousePosGlobal", hit.point); 
                currentMat.SetFloat(name: "_currentPower", _currentPower);

                if (_isNeedStarCoroutine)
                {
                    StartCoroutine(PowerDecrease(currentMat));
                }
            }
            _isNeedStarCoroutine = false;

        }
        else
        {
            _currentPower -= Time.deltaTime;
        }

    }

    private IEnumerator PowerDecrease(Material material)
    {
        yield return new WaitWhile(() => _isMouseUp == false);

        do
        {
            _currentPower -= Time.deltaTime* 5;
            material.SetFloat(name: "_currentPower", _currentPower);
            yield return null;
        } while (_currentPower > -1.5f);

        yield return null;
    }

}
