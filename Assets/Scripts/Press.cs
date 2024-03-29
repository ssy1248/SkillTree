using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace MoveEffectTool
{
    public class Press : BasePress
    {
        protected override void Effect()
        {
            base.Effect();
            transform.DOPunchPosition(new Vector3(0, -20, 0), 0.2f, 4, 0.5f);
            transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0), 0.2f, 4, 0.5f);
        }
    }
}