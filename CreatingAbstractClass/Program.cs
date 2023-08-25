using System;
using System.Reflection;

var type = typeof(Foo);
var constructor = type.GetConstructor(Type.EmptyTypes); 
var typeRuntimeMethodHandle = typeof(RuntimeMethodHandle);

var invokeMethod = typeRuntimeMethodHandle.GetMethod("InvokeMethod", BindingFlags.Static | BindingFlags.NonPublic); 

var signatureProperty = constructor.GetType().GetProperty("Signature", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance); 
var abstractObject = (Foo)invokeMethod.Invoke(null, new object[] { null, null, signatureProperty.GetValue(constructor), true, null });

abstractObject.Print();
Console.WriteLine(abstractObject.GetType().ToString());

public abstract class Foo
{
    public Foo()
    {
    }

    public void Print()
    {
        Console.WriteLine("Я абстрактый класс");
    }

}