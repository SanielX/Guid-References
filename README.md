### Fork note
For original documentation read: https://github.com/Unity-Technologies/guid-based-reference

It turned out that changing `GameObject` type to just `UnityEngine.Object` doesn't seem to break the tests so I added functionality for references directly to components.

What I have done is that for each GuidComponent I added SerializableDictionary (https://github.com/azixMcAze/Unity-SerializableDictionary) which contains every component of a GameObject.

What you do is adding new attribute to GuidReference:
```csharp
[GuidReferenceType(typeof(*YOUR TYPE*))]
public GuidReference MyReference;
```

And now you should be able to drag and drop cross scene object. Code is written kinda poorly, because I just wanted to see if it's going to work. And seems like it does.

In Demo scene you can see how light references appears as level loads

For GuidComponents you need to press `Update Components` in order to get them updated, obviously.