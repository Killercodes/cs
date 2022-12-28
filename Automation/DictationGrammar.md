DictationGrammar
===

Represents a speech recognition grammar used for free text dictation.

The following example creates three dictation grammars, adds them to a new SpeechRecognitionEngine object, and returns the new object. The first grammar is the default dictation grammar. The second grammar is the spelling dictation grammar. 

The third grammar is the default dictation grammar that includes a context phrase. The SetDictationContext method is used to associate the context phrase with the dictation grammar after it is loaded to the SpeechRecognitionEngine object.

```cs
private SpeechRecognitionEngine LoadDictationGrammars()  
{  

  // Create a default dictation grammar.  
  DictationGrammar defaultDictationGrammar = new DictationGrammar();  
  defaultDictationGrammar.Name = "default dictation";  
  defaultDictationGrammar.Enabled = true;  

  // Create the spelling dictation grammar.  
  DictationGrammar spellingDictationGrammar =  
    new DictationGrammar("grammar:dictation#spelling");  
  spellingDictationGrammar.Name = "spelling dictation";  
  spellingDictationGrammar.Enabled = true;  

  // Create the question dictation grammar.  
  DictationGrammar customDictationGrammar =  
    new DictationGrammar("grammar:dictation");  
  customDictationGrammar.Name = "question dictation";  
  customDictationGrammar.Enabled = true;  

  // Create a SpeechRecognitionEngine object and add the grammars to it.  
  SpeechRecognitionEngine recoEngine = new SpeechRecognitionEngine();  
  recoEngine.LoadGrammar(defaultDictationGrammar);  
  recoEngine.LoadGrammar(spellingDictationGrammar);  
  recoEngine.LoadGrammar(customDictationGrammar);  

  // Add a context to customDictationGrammar.  
  customDictationGrammar.SetDictationContext("How do you", null);  

  return recoEngine;  
}
```

This class provides applications with a predefined language model that can process spoken user input into text. This class supports both default and custom DictationGrammar objects. For information about selecting a dictation grammar, see the DictationGrammar(String) constructor.

By default, the DictationGrammar language model is context free. It does not make use of specific words or word order to identify and interpret audio input. To add context to the dictation grammar, use the SetDictationContext method.

And here is how to use it
```cs
void Main()
{
	SpeechRecognitionEngine recognizer =  new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-IN"));
	recognizer.LoadGrammar(new DictationGrammar());
	 
	// Create a default dictation grammar.  
	DictationGrammar defaultDictationGrammar = new DictationGrammar();  
	defaultDictationGrammar.Name = "default dictation";  
	defaultDictationGrammar.Enabled = true;  

	// Create the spelling dictation grammar.  
	DictationGrammar spellingDictationGrammar =  
	new DictationGrammar("grammar:dictation#spelling");  
	spellingDictationGrammar.Name = "spelling dictation";  
	spellingDictationGrammar.Enabled = true;  

	// Create the question dictation grammar.  
	DictationGrammar customDictationGrammar =  
	new DictationGrammar("grammar:dictation");  
	customDictationGrammar.Name = "question dictation";  
	customDictationGrammar.Enabled = true;
	
	recognizer.LoadGrammar(defaultDictationGrammar);
	recognizer.LoadGrammar(spellingDictationGrammar);
	recognizer.LoadGrammar(customDictationGrammar);

    // Add a handler for the speech recognized event.  
    recognizer.SpeechRecognized +=  new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);  
	recognizer.SetInputToDefaultAudioDevice();  
	
	// Add a context to customDictationGrammar.  
	customDictationGrammar.SetDictationContext("How do you", null);  

    // Start asynchronous, continuous speech recognition.  
    recognizer.RecognizeAsync(RecognizeMode.Multiple);  

    // Keep the console window open.  
    while (true)  
    {  
      Console.ReadLine();  
    }  
}

// Define other methods and classes here
static void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)  
{  
  Console.WriteLine(" :" + e.Result.Text);  
}
```
