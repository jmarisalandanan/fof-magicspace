using System.Collections.Generic;
using System.Linq;
using Doozy.Engine.UI;
using UnityEngine;

namespace MagicSpace.LS
{
    public class BaseScreen : MonoBehaviour
    {
        private List<UIView> childrenViews = new List<UIView>();
        private void Awake()
        {
            childrenViews = transform.GetComponentsInChildren<UIView>().Where(go => go.gameObject != this.gameObject)
                .ToList();
        }

        public virtual void ShowAllViews()
        {
            foreach (var view in childrenViews)
            {
                view.Show();
            }
        }

        public virtual void HideAllViews()
        {
            foreach (var view in childrenViews)
            {
                view.Hide();
            }
        }
    }
}
