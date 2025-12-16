using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemColleactableCoin : ItemCollectableBase
{
  public Collider collider;

  protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddCoins();
        collider.enabled = false;
    }
}
