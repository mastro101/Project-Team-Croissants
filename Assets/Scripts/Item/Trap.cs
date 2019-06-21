using UnityEngine;
using UnityEditor;
using System.Collections;
using DG.Tweening;

public class Trap : Slowing
{
    [Range(0, 1)]
    [SerializeField]
    float fadeValue;
    [SerializeField]
    float fadeSecond;

    [HideInInspector]
    public IPlayer PlayerOfTrap;

    public void SetPlayer(IPlayer player)
    {
        PlayerOfTrap = player;
    }

    public override void Effect(IPlayer _player)
    {
        PlayerPunk playerPunk = PlayerOfTrap.gameObject.GetComponent<PlayerPunk>();
        Instantiate(playerPunk.VFXEffectTrap, transform.position, Quaternion.Euler(Vector3.zero));
        if (PlayerOfTrap != _player)
        {
            base.Effect(_player);
            FindObjectOfType<AudioManager>().Play("PunkActivatedAbility");
            gameplaySM.endBattle -= OnSpawn;
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        StartCoroutine(ActiveCollider());
        meshRenderer.material.DOFade(fadeValue, fadeSecond);
    }

    //private void FixedUpdate()
    //{
    //    transform.position += Vector3.down * 9.81f * Time.deltaTime;
    //}

    IEnumerator ActiveCollider()
    {
        yield return new WaitForSeconds(fadeSecond);
        collider.enabled = true;
    }

    public override void OnSpawn()
    {
        base.OnSpawn();
        Destroy(gameObject);
    }
}