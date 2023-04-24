using UnityEngine;
using Zenject;

public class SceneContextInstaller : MonoInstaller
{
    [SerializeField] private GameObject _objectWithItemManipulator;
    public override void InstallBindings()
    {
        Container.Bind<ItemManipulator>().FromComponentOn(_objectWithItemManipulator).AsSingle();
    }
}