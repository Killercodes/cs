GrammarBuilder
===

Provides a mechanism for programmatically building the constraints for a speech recognition grammar.

The following example uses GrammarBuilder and Choices objects to construct a grammar that can recognize either of the two phrases, "Make background colorChoice" or "Set background to colorChoice".

The example uses a Choices object to create a list of acceptable values for colorChoice from an array of String objects. A Choices object is analogous to the one-of element in the SRGS specification, and contains a set of alternate phrases, any of which can be recognized when spoken. The example also uses a Choices object to group an array of two GrammarBuilder objects into a pair of alternative phrases that the resultant grammar can recognize. Alternate words or phrases are a component of most grammars, and the Choices object provides this functionality for grammars constructed with GrammarBuilder.

The example finally creates a Grammar object from a GrammarBuilder constructed from a Choices object.

```cs
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
```

Speech recognition grammars are commonly authored in the XML format defined by the Speech Recognition Grammar Specification (SRGS) Version 1.0. If you are familiar with SRGS but want to generate the grammars programmatically, you can use the System.Speech.Recognition.SrgsGrammar namespace, whose members correspond closely to the elements and attributes defined by SRGS. If you are unfamiliar with SRGS, or you want a lightweight, programmatic approach to authoring grammars with which you can efficiently accomplish many common scenarios; you can use the GrammarBuilder and Choices classes.

Use GrammarBuilder objects to build a hierarchical tree composed of Choices objects that contain alternate phrases, interspersed with preamble and post-amble phrases at each node, and seeded with semantic values that convey meaning back to the application.

To use a GrammarBuilder to create a Grammar object, use the following steps.

1. Create a GrammarBuilder object.
2. Append constraints to the GrammarBuilder, such as String objects, Choices, SemanticResultKey, SemanticResultValue, DictationGrammar, and other GrammarBuilder objects that define the constraints for the grammar.
3. Use one of the Grammar constructors to create a Grammar object from the completed GrammarBuilder grammar.

Authoring with GrammarBuilder is best suited to grammars that have a single rule containing lists, or perhaps lists of lists. To programmatically build grammars that have multiple rules, or that need to make internal rule references, use the classes of the System.Speech.Recognition.SrgsGrammar namespace.

Instances of GrammarBuilder can also be obtained by implicit conversions from certain other classes or by combining a GrammarBuilder with a second object that contains constraints for a grammar.. For more information, see the Implicit and Addition operators and the Add methods.
