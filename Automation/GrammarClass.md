Grammar Class
===

A runtime object that references a speech recognition grammar, which an application can use to define the constraints for speech recognition.

The following example constructs a Grammar object from a speech recognition grammar defined in a XML file (cities.xml). The content of the cities.xml file appears in the following XML example.

```cs
// Load a cities grammar from a local file and return the grammar object.   
private static Grammar CreateGrammarFromFile()  
{  
  Grammar citiesGrammar = new Grammar(@"c:\temp\cities.xml");  
  citiesGrammar.Name = "SRGS File Cities Grammar";  
  return citiesGrammar;  
}
```


```xml
<?xml version="1.0" encoding="UTF-8" ?>  
<grammar version="1.0" xml:lang="en-US"  
         xmlns="http://www.w3.org/2001/06/grammar"  
         tag-format="semantics/1.0" root="Main">  

  <!-- cities.xml:   
    Defines an SRGS grammar for requesting a flight. This grammar includes  
    a Cities rule that lists the cities that can be used for departures  
    and destinations. -->  

  <rule id="Main">  
    <item>  
      I would like to fly from <ruleref uri="#Cities"/>  
      to <ruleref uri="#Cities"/>  
    </item>  
  </rule>  

  <rule id="Cities" scope="public">  
    <one-of>  
      <item> Seattle </item>  
      <item> Los Angeles </item>  
      <item> New York </item>  
      <item> Miami </item>  
    </one-of>  
  </rule>  
</grammar>
```

A speech recognition grammar is a set of rules or constraints that define what a speech recognition engine can recognize as meaningful input. For more information about creating and using speech recognition grammars, see Speech Recognition, and Create Grammars Using SrgsGrammar.

After you author a grammar, you must build it into a Grammar object that a speech recognition engine can load and that your application can use at runtime to manage speech recognition. You can use a Grammar constructor to create a Grammar instance from a GrammarBuilder or a SrgsDocument object, or from a file or a Stream that contains a description of a grammar in a supported format. Supported formats include the following:

- XML-format files that conform to the W3C Speech Recognition Grammar Specification (SRGS) Version 1.0

- Grammars that have been compiled to a binary file with a .cfg file extension

Grammar constructors that accept XML-format grammar files in their arguments compile the XML grammars to a binary format to optimize them for loading and consumption by a speech recognition engine. You can reduce the amount of time required to construct a Grammar object from an XML-format grammar by compiling the grammar in advance, using one of the Compile methods.

An application's speech recognition engine, as managed by a SpeechRecognizer or SpeechRecognitionEngine object, can load multiple speech recognition grammars. The application can independently enable or disable individual grammars by setting the Enabled property, and modify recognition behavior through Grammar properties, such as the Priority and Weight properties.

The grammar's SpeechRecognized event is raised when input matches a path through the grammar.
