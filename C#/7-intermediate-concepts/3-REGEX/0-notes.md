--LITERALS: exact text


-- MAIN METHODS IN C#
- Regex.IsMatch(text, pattern) = check if the text has a pattern
- Regex.Match(text, pattern) = return first match
- Regex.Matches(text, pattern) = return all matches
- Regex.Replace(text, pattern, replacement) = replace the matches
- Regex.Split(text, pattern) = splits the text by a pattern


-- METACHARACTES: rules-syntax, not literal text

- . = any character (except a line break)
- ^ = start of text
- $ = end of text
- * = 0 or more repeticions
- + = 1 or more repeticions
- ? = 0 or 1
- { } = exact amount or range
- [ ] = set of characters
- \ = scape character - something special or literal
- | = or
- ( ) = 


-- CHARACTERS CLASSES
- [abc] = any of these
- [^abc] = all execept these 
- [a-z] or [0-9] = range of letters or numbers


-- SHORTCUTS
- \d = digid (0-9)
- \w = word character (a-z, A-Z, 0-9, _)
- \s = whitespace (space, tab)

-- INVERSOS
- \D = no digit
- \W = no word character
- \S = no whitespace


-- ANCHORS 
- ^
- $
- \b = word boundary


-- GROUP AND ALTERNATION
- (pattern) = save the patters in a group
- (?:pattern) = group but don't save

