using System.Collections;
using UnityEngine;
using Zenject;

namespace Frame.Views
{
    public class View<T> : View where T : View<T>
    {
        private ViewController _ViewController;
        [Inject]
        public void Construct(ViewController viewController)
        {
            _ViewController = viewController;
            _ViewController.AddView(this);
        }
        public virtual void Awake()
        {

        }

        public virtual void Start()
        {

        }
        public virtual void OnEnable()
        {

        }

        public virtual void OnDisable()
        {

        }


        public T GoToView<T>() where T : View
        {
            var view = _ViewController.GotoView<T>();
            view.Open();
            return view;
        }


        public override void Open()
        {
            this.gameObject.SetActive(true);
        }

        public override void Close()
        {
            this.gameObject.SetActive(false);
        }

        public override void OnDeviceBackButtonPressed()
        {

        }
    }

    public abstract class View : MonoBehaviour
    {
        public abstract void Open();

        public abstract void Close();
        public abstract void OnDeviceBackButtonPressed();
    }
}