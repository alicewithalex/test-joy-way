using System;

public interface IContainer 
{
    void Bind(object source, Type type);

    void Bind<T>(T source);

    void Inject(object target);

    void Inject<T>(T target);
}
