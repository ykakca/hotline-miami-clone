using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteArrayController : MonoBehaviour
{
    public Sprite[] spriteLegs, spriteAttack, spriteUnarmed,
                    spriteWalkWithAxe, spriteAttackWithAxe, spritePunch,
                    spriteWalkWithUzi, spriteAttackWithUzi;
                    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Sprite[] GetSpriteLegs() 
    {
        return spriteLegs;
    }

    public Sprite[] GetSpriteUnarmed()
    {
        return spriteUnarmed;
    }

    public Sprite[] GetSpriteWalkWithAxe()
    {
        return spriteWalkWithAxe;
    }

    public Sprite[] GetSpriteAttackWithAxe()
    {
        return spriteAttackWithAxe;
    }

    public Sprite[] GetSpriteWalkWithUzi()
    {
        return spriteWalkWithUzi;
    }

    public Sprite[] GetSpriteAttackWithUzi()
    {
        return spriteAttackWithUzi;
    }

    public Sprite[] GetSpritePunch()
    {
        return spritePunch;
    }
}
