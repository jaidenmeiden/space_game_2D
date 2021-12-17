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

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        itemCollider = GetComponent<CircleCollider2D>();
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
                break;
            case CollectableType.HealthPotion:
                //TODO: Money Health potion
                break;
            case CollectableType.ManaPotion:
                //TODO: Money Mana potion
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
