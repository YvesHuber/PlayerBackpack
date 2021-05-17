using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material : MonoBehaviour
{
        public string DisplayTitle;
        public string Description;
        public double Worth;
        public int StackSize;
        public int MaxStackSize;
        public enum raritys {Common,Uncommon,Rare,Epic,Legendary,Void};
        public string Itemtype = "Material";
        public raritys rarity;
        public int id;
        public Sprite UiIcon;
}
