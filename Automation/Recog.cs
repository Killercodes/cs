void Main()
{
	
	Choices choice1 = new Choices("grenade","pipe","molotov","rock","attractor bomb");
	GrammarBuilder throwable = new GrammarBuilder("throw");
  	throwable.Append(choice1);
	
	GrammarBuilder reload = new GrammarBuilder("reload");
	reload.Append(new Choices("primary","secondary","sidearm"));
	
	GrammarBuilder plant = new GrammarBuilder("plant");
	reload.Append(new Choices("mine","remote bomb","attractor"));
	
	
	GrammarBuilder jarvis = new GrammarBuilder("jarvis");
	jarvis.Append(throwable);
	jarvis.Append(reload);
	jarvis.Append(plant);
	

	
	Grammar gram = new Grammar(jarvis);
	gram.Priority = 1;
	
	
	
	SrgsDocument doc = new SrgsDocument(jarvis);
	XmlWriter xWriter = XmlWriter.Create(@"grammer.xml");	 
	// Write and close the document
	doc.WriteSrgs(xWriter);
	xWriter.Close();
	XElement.Load("grammer.xml").Dump();
	
	
	
	Recog(gram,(s) => { 
		$"{s.Result.Text} [{s.Result.Confidence}]".Dump("OK");
		
		//s.Result.Dump(); 		
	},50);
		
	//Console.ReadLine();
}

// Define other methods and classes here
private SpeechRecognitionEngine Recog(Grammar grammer,Action<SpeechRecognizedEventArgs> CallBack,int timeout = 1000 )  
{  
	bool completed = false;

  	SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-IN"));
	recognizer.MaxAlternates = 1;
	//recognizer.InitialSilenceTimeout = TimeSpan.FromSeconds(3);  
    //recognizer.BabbleTimeout = TimeSpan.FromSeconds(2);  
    //recognizer.EndSilenceTimeout = TimeSpan.FromSeconds(1);  
    //recognizer.EndSilenceTimeoutAmbiguous = TimeSpan.FromSeconds(1.5); 
	
  	recognizer.LoadGrammar(grammer);
  
  	recognizer.SpeechRecognized +=  (s,o) => { 	 
		CallBack(o);
		completed = true;
	};
	
	recognizer.SetInputToDefaultAudioDevice();
	recognizer.RecognizeAsync(RecognizeMode.Single); 
	
	while (!completed)  
    {  
      Thread.Sleep(timeout);  
    }
	
    Console.WriteLine("Done.");  
	
	return recognizer;
}
