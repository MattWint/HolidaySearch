### Hello!
Welcome to my holiday lookup.

Please note: This repository is on my backup GitHub.

As commented in the code, I converted the JSON to C# for simplicity and to avoid deserialising JSON. I Hope you don't mind.

Here are a couple of improvements I didn't get chance to complete:

1. I'm currently hard-coding how the sorting works, this could be abstracted out as we may want to change this in the future i.e. display the highest-rated hotel first instead of best-value.
2. There's lots of cities with multiple airports and I've only catered for what the tests cover - London. We'd need to expand this and use a data source of its own rather than a hard-coded dictionary. See AirportResolver.cs.
