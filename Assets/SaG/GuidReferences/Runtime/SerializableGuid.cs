using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[System.Serializable]
public class SerializableGuid : ISerializationCallbackReceiver
{
    public Guid Guid
    {
        get
        {
            return guid;
        }
    }

    public SerializableGuid(Guid guid)
    {
        this.guid = guid;
        byteArray = guid.ToByteArray();
    }

    public SerializableGuid()
    {
        this.guid = Guid.NewGuid();
        byteArray = guid.ToByteArray();
    }

    private Guid guid;
    [SerializeField]
    private byte[] byteArray;

    public void OnAfterDeserialize()
    {
        guid = new Guid(byteArray);
    }

    public void OnBeforeSerialize()
    {
        byteArray = guid.ToByteArray();
    }

    public static bool operator ==(SerializableGuid guid0, SerializableGuid guid1)
    {
        return guid0.Guid == guid1.Guid;
    }
    public static bool operator !=(SerializableGuid guid0, SerializableGuid guid1)
    {
        return guid0.Guid != guid1.Guid;
    }
    public override bool Equals(object obj)
    {
        if (!(obj is SerializableGuid))
            return false;

        var g = (SerializableGuid)obj;

        return g == this;
    }

    public override int GetHashCode()
    {
        return Guid.GetHashCode();
    }
}