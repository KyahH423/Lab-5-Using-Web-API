# Lab-5-Using-Web-API
Problem 1:
  Error using JsonSerializer.Deserialize<Character>(json, options);
Solutions:
  Switched to using JsonConvert.DeserializeObject<List<SupernaturalData>>(json, options); (Wouldn't accept two argument)
  Switched to using JsonConvert.DeserializeObject<CharacterMeta>(json); (Worked)
Explanation:
  The character data json needed to be pulled into my program using an additional class called "CharacterMeta" using an IList.   The json was pulling in all of the data into a single array value assigned to the key "data".

Problem 2:
  Difficulty calling on individual items returned by API
Solution:
  d = JsonConvert.DeserializeObject<CharacterMeta>(json);
  List<Character> list = new List<Character>();
  list = d.data.ToList();
Explanation:
  I need to allow users to access specific characters base on the name or actor value. By converting the data to a list of all responses I could sort through and select individual ones.

Problem 3:
  API defaults to returning a max of 10 responses per call, not returning all responses that I needed.
Solution:
  Changing https://supernatural-quotes-api.cyclic.app/characters?{searchBy}={userInput} to
  https://supernatural-quotes-api.cyclic.app/characters?size=1105&{searchBy}={userInput}
Explanation: 
  By adding the "size=1105" to the url the API will now return as many responses as available from the user input. 1105 is     the total number of characters stored in the API.
