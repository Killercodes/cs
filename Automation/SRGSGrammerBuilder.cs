void Main()
{
	var doc = CreateSrgsDocumentGrammar();
	
	 
}

// Define other methods and classes here
private static Grammar CreateSrgsDocumentGrammar()  
{  
  
  SrgsOneOf cityChoice = new SrgsOneOf();  
  cityChoice.Add(new SrgsItem("Seattle"));  
  cityChoice.Add(new SrgsItem("Los Angeles"));  
  cityChoice.Add(new SrgsItem("New York"));  
  cityChoice.Add(new SrgsItem("Miami"));  

// Create the Cities rule and add it to the document.  
  SrgsRule citiesRule = new SrgsRule("Cities"); 
  citiesRule.Add(cityChoice);  
  
  // Create the SrgsDocument.  
  SrgsDocument document = new SrgsDocument();  
  document.Rules.Add(citiesRule);  

  // Create the Main rule and add it to the document.  
  SrgsRule mainRule = new SrgsRule("Main");  
  mainRule.Scope = SrgsRuleScope.Public;  

  SrgsItem item = new SrgsItem("I would like to fly from");  
  item.Add(new SrgsRuleRef(citiesRule));  
  item.Add(new SrgsText("to"));  
  item.Add(new SrgsRuleRef(citiesRule));  

  mainRule.Add(item);
    
  //==================================================
	SrgsOneOf weponsChoice = new SrgsOneOf();  
	weponsChoice.Add(new SrgsItem("primary"));  
	weponsChoice.Add(new SrgsItem("secondary"));  
	weponsChoice.Add(new SrgsItem("grenade"));  
	weponsChoice.Add(new SrgsItem("reload"));
  
   	SrgsRule wepRule = new SrgsRule("Wepons"); 
  	wepRule.Add(weponsChoice); 
	document.Rules.Add(wepRule);
  
	SrgsItem gitem = new SrgsItem("buddy");
	gitem.Add(new SrgsText("give me"));
	gitem.Add(new SrgsRuleRef(wepRule));
   
	mainRule.Add(gitem);
   

//mainRule.Add(item);  
  document.Rules.Add(mainRule);
  // Set the root rule.  
  document.Root = mainRule;  
  
  	StringBuilder xml = new StringBuilder();
    XmlWriter xmlWriter = XmlWriter.Create(xml);
	document.WriteSrgs(xmlWriter);
	xmlWriter.Close();
	XElement.Parse(xml.ToString()).Dump();
	

  // Create the Grammar object.  
  Grammar citiesGrammar = new Grammar(document);  
  citiesGrammar.Name = "SrgsDocument Cities Grammar";  

  return citiesGrammar;  
}  
