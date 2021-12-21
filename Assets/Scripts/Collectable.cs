using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectableType
{
    HealthPotion,
    ManaPotion,
    Money
}
public class Collectable : MonoBehaviour
{
    public CollectableType type = CollectableType.Money;
    private SpriteRenderer sprite;
    private CircleCollider2D itemCollider;
    bool hasBeenCollected = false;
    public int value = 1;
    
    GameObject player;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        itemCollider = GetComponent<CircleCollider2D>();
    }

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Show()
    {
        sprite.enabled = true;
        itemCollider.enabled = true;
        hasBeenCollected = false;
    }

    private void Hide()
    {
        sprite.enabled = false;
        itemCollider.enabled = false;
        
        switch(this.type)
        {
            case CollectableType.Money:
                GameManager.SharedInstance.CollectObject(this);
                GetComponent<AudioSource>().Play();
                break;
            case CollectableType.HealthPotion:
                this.player.GetComponentInChildren<PlayerController>().CollectHealth(this.value);
                break;
            case CollectableType.ManaPotion:
                this.player.GetComponentInChildren<PlayerController>().CollectMana(this.value);
                break;
            default:
                break;
        }
    }

    private void Collect()
    {
        Hide();
        hasBeenCollected = true;
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            Collect();
        }
    }
}
