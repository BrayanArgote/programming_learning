# Creation
Dictionary<key, value> name = new Dictionary<key, value>();

# Add 
dictionaryName.Add(key, value);
dictionaryName.TryAdd(key, value);

# Modify
dictionaryName[key] = value;

# Get value
variable = dictionaryName[key];
dictionaryName.TryGetValue(key, out variable);

# Check existence
dictionaryName.ContainsKey(key);
dictionaryName.ContainsValue(value);

# Delete
dictionaryName.Remove(key);
dictionaryName.Clear();

# Utils
dictionaryName.Count;
dictionaryName.Keys;
dictionaryName.Values;


