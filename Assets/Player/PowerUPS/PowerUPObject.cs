using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUPObject : MonoBehaviour
{
    public PowerUpEnum powerUp;
    public float rotationSpeed = 10;
    private void Update()
    {
        transform.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, (transform.rotation.eulerAngles.y + rotationSpeed % 360), transform.rotation.eulerAngles.z);
    }
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collided");
        CharacterInformation ci;
        if (other.gameObject.TryGetComponent<CharacterInformation>(out ci))
        {
            if (ci._character == CharacterENUM.TILDA)
            {
                if (powerUp == PowerUpEnum.FASTTAG)
                {
                    ci.GetComponent<MovementScript>().PowerUp1 = true;
                    UIManager.UI.SetPowerUpImage(UIManager.UI.tildaImage1, true);
                    Destroy(gameObject);
                }
                else if (powerUp == PowerUpEnum.DOUBLEJUMP)
                {
                    ci.GetComponent<MovementScript>().PowerUp2 = true;
                    UIManager.UI.SetPowerUpImage(UIManager.UI.tildaImage2, true);
                    Destroy(gameObject);
                }
            }
            else if (ci._character == CharacterENUM.MORT)
            {
                if (powerUp == PowerUpEnum.SPEEDYCLEAN)
                {
                    ci.GetComponent<MovementScript>().PowerUp1 = true;
                    UIManager.UI.SetPowerUpImage(UIManager.UI.mortImage1, true);
                    Destroy(gameObject);
                }
                else if (powerUp == PowerUpEnum.NOTAGS)
                {
                    ci.GetComponent<MovementScript>().PowerUp2 = true;
                    UIManager.UI.SetPowerUpImage(UIManager.UI.mortImage2, true);
                    Destroy(gameObject);
                }
            }
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        CharacterInformation ci;
        if (other.gameObject.TryGetComponent<CharacterInformation>(out ci))
        {
            if (ci._character == CharacterENUM.TILDA)
            {
                if (powerUp == PowerUpEnum.FASTTAG)
                {
                    ci.GetComponent<MovementScript>().PowerUp1 = true;
                    UIManager.UI.SetPowerUpImage(UIManager.UI.tildaImage1, true);
                    Destroy(gameObject);
                }
                else if (powerUp == PowerUpEnum.DOUBLEJUMP)
                {
                    ci.GetComponent<MovementScript>().PowerUp2 = true;
                    UIManager.UI.SetPowerUpImage(UIManager.UI.tildaImage2, true);
                    Destroy(gameObject);
                }
            }
            else if (ci._character == CharacterENUM.MORT)
            {
                if (powerUp == PowerUpEnum.SPEEDYCLEAN)
                {
                    ci.GetComponent<MovementScript>().PowerUp1 = true;
                    UIManager.UI.SetPowerUpImage(UIManager.UI.mortImage1, true);
                    Destroy(gameObject);
                }
                else if (powerUp == PowerUpEnum.NOTAGS)
                {
                    ci.GetComponent<MovementScript>().PowerUp2 = true;
                    UIManager.UI.SetPowerUpImage(UIManager.UI.mortImage2, true);
                    Destroy(gameObject);
                }
            }
        }
    }
}
public enum PowerUpEnum
{
    DOUBLEJUMP, FASTTAG, NOTAGS, SPEEDYCLEAN
}