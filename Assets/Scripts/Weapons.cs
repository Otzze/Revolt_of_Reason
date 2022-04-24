using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class Weapons : MonoBehaviourPunCallbacks
{
    //player equipment
    public Gun[] loadout;
    //weapon coordinates
    public Transform WeaponParent;
    //currently equiped weapon
    private GameObject currentWeapon;
    public GameObject Compteur;

    private int currentIndex;

    public GameObject BulletHolePrefab;
    public LayerMask CanBeShot;

    //firerate
    private float CurrentCoolDown;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (!photonView.IsMine)
            return;

        if (Input.GetKeyDown(KeyCode.E))
            photonView.RPC("Equip", RpcTarget.All, 0);

        if (currentWeapon != null)
        {
            Aim(Input.GetMouseButton(1));
            if (Input.GetMouseButtonDown(0) && CurrentCoolDown <= 0)
            {
                photonView.RPC("Shoot", RpcTarget.All);
            }


            //si on ne tire pas, faire baisser le cooldown time de l'arme
            if (CurrentCoolDown > 0)
                CurrentCoolDown -= Time.deltaTime;

            //faire revenir l'arme � une position normale quoiqu'il arrive
            currentWeapon.transform.localPosition = Vector3.Lerp(currentWeapon.transform.localPosition, Vector3.zero, Time.deltaTime * 4f);
            currentWeapon.transform.localRotation = Quaternion.Lerp(currentWeapon.transform.localRotation, Quaternion.identity, Time.deltaTime * 4f);
        }

                
        //si on scroll vers le haut 
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            //prendre l'arme avant
            if (currentIndex != loadout.Length - 1)
            {
                photonView.RPC("Equip", RpcTarget.All, currentIndex + 1);
            }

        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            //prendre l'arme apr�s
            if (currentIndex > 0)
            {
                photonView.RPC("Equip", RpcTarget.All, currentIndex - 1);
            }
                
        }
    }


    [PunRPC]
    void Equip(int p_ind)
    {
        if (currentWeapon != null)
            Destroy(currentWeapon);
        
        currentIndex = p_ind;

        GameObject t_newEquipment = Instantiate(loadout[p_ind].prefab, WeaponParent.position, WeaponParent.rotation, WeaponParent) as GameObject;
        t_newEquipment.transform.localPosition = Vector3.zero;
        t_newEquipment.transform.localEulerAngles = Vector3.zero;
        t_newEquipment.GetComponent<Sway>().IsMine = photonView.IsMine;
        currentWeapon = t_newEquipment;
    }

    void Aim(bool p_isAiming)
    {
        Transform t_anchor = currentWeapon.transform.Find("Anchor");
        Transform t_state_ads = currentWeapon.transform.Find("States/ADS");
        Transform t_state_hips = currentWeapon.transform.Find("States/hips");

        if (p_isAiming)
        {
            t_anchor.position = Vector3.Lerp(t_anchor.position, t_state_ads.position, Time.deltaTime * loadout[currentIndex].aimSpeed);
        }
        else
        {
            t_anchor.position = Vector3.Lerp(t_anchor.position, t_state_hips.position, Time.deltaTime * loadout[currentIndex].aimSpeed);
        }
    }


    [PunRPC]
    void Shoot()
    {
        //depart du raycast
        Transform t_spawn = transform.Find("Main Camera");

        //CoolDown
        if (photonView.IsMine)
            CurrentCoolDown = loadout[currentIndex].firerate; 

        RaycastHit t_hit = new RaycastHit();

        if (Physics.Raycast(t_spawn.position, t_spawn.forward, out t_hit, 1000f, CanBeShot))
        {
            GameObject t_newhole = Instantiate(BulletHolePrefab, t_hit.point + t_hit.normal * 0.001f, Quaternion.identity) as GameObject;
            t_newhole.transform.LookAt(t_hit.point + t_hit.normal);
            Destroy(t_newhole, 5f);


            //dealing damages
            if (photonView.IsMine)
            {
                if (t_hit.collider.transform.tag == "enemy")
                {
                    Debug.Log("HitEnemy");
                    ennemi ennemiScript = t_hit.transform.GetComponent<ennemi>();
                    bool IsDead = ennemiScript.Damage(loadout[currentIndex].damage);

                    if (IsDead)
                        gameObject.GetComponent<PlayerMoney>().Money += 1000;
                }

                if (t_hit.collider.transform.tag == "cibles")
                {
                    t_hit.collider.gameObject.GetComponent<TargetScript>().AddTarget();
                    Debug.Log("Hitcibles");
                    Destroy(t_hit.collider.gameObject);
                }
            }
        }

        //recoil
        currentWeapon.transform.Rotate(-loadout[currentIndex].recoil, 0, 0);
        
        //kickback
        currentWeapon.transform.position -= currentWeapon.transform.forward * loadout[currentIndex].kickback;
        
    }


}
