private Grammar CreateColorGrammar()  
{  

  // Create a set of color choices.  
  Choices colorChoice = new Choices(new string[] {"red", "green", "blue"});  
  GrammarBuilder colorElement = new GrammarBuilder(colorChoice);  

  // Create grammar builders for the two versions of the phrase.  
  GrammarBuilder makePhrase = new GrammarBuilder("Make background");  
  makePhrase.Append(colorElement);  
  GrammarBuilder setPhrase = new GrammarBuilder("Set background to");  
  setPhrase.Append(colorElement);  

  // Create a Choices for the two alternative phrases, convert the Choices  
  // to a GrammarBuilder, and construct the grammar from the result.  
  Choices bothChoices = new Choices(new GrammarBuilder[] {makePhrase, setPhrase});  
  Grammar grammar = new Grammar((GrammarBuilder)bothChoices);  
  grammar.Name = "backgroundColor";  
  return grammar;  
}  
