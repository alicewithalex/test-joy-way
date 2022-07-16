using NoName.EditorExtended;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MonoContainer : MonoBehaviour
{
    [SerializeField]
    private List<Binder> _binders;

    private bool _initialized;
    private Container _container;

    public IContainer Container => _container;

    public void Initialize()
    {
        if (_initialized) return;
        _initialized = true;

        _container = new Container();

        foreach (var binder in _binders)
        {
            binder.Bind(Container);
        }
    }

#if UNITY_EDITOR

    [Button("Collect")]
    private void Collect()
    {
        _binders = GetComponentsInChildren<Binder>().ToList();
    }

#endif
}
