using NoName.Factory;
using UnityEngine;

[CreateAssetMenu(menuName = "Framework/Factories/Example Factory", fileName = "Example Factory")]
public class ExampleShapeFactoryProvider : FactoryProvider<ExampleShapeFactory, ShapeFactoryData>
{
    protected override ExampleShapeFactory Factory => new ExampleShapeFactory(FactoryData);
}
