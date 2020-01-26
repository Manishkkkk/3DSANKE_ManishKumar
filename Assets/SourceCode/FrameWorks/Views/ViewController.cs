using System.Collections.Generic;
using UnityEngine;
namespace Frame.Views
{
    public class ViewController
    {
        private readonly List<View> views = new List<View>();

        public ViewController(List<View> views)
        {
            this.views = views;
        }

        public T GotoView<T>() where T : View
        {
            return (T)views.Find(t => t.GetType().Name == typeof(T).Name);
        }

        public void AddView(View view)
        {
            views.Add(view);
        }
    }
}
