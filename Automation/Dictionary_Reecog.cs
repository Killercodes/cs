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
