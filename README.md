Hello!
Welcome to my holidays lookup.

As commented in the code, I converted the JSON to C# for simplicity and to avoid deserialising JSON. Hope you don't mind.

Potential further improvements.
Here are a couple of improvements to this code that I've ran out of time for...

I'm currently hard-coding how the sorting works, this could be abstracted out as we may want to change this in the future i.e. display the highest-rated hotel first instead of best-value.
There's lots of cities with multiple airports and I've only catered for what the tests cover - London. We'd need to expand this and use a data source of its own rather than a hard-coded dictionary. See AirportResolver.cs.
