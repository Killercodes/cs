public string ApplyXsltTransformation(string messageToConvert,string strXstFil,string strxsltnamespacefile,string logfile)
{
    try
    {
        if (strxsltnamespacefile != string.Empty)
        {

            messageToConvert = RemoveNameSpacesTransformation(messageToConvert, strxsltnamespacefile,logfile);
        }
       
        var sReader = new StringReader(messageToConvert);
        var xReader = new XmlTextReader(sReader);
        var doc = new XPathDocument(xReader);

        // Load the style sheet.
        var xslt = new XslCompiledTransform();

        xslt.Load(strXstFil);
        var ms = new MemoryStream();
        var writer = new XmlTextWriter(ms, Encoding.UTF8);
        var rd = new StreamReader(ms);

        //Arguments to StyleSheet
        var argList = new XsltArgumentList();

        xslt.Transform(doc, argList, writer);
        ms.Position = 0;
        var transformedMessage = rd.ReadToEnd();
        rd.Close();
        ms.Close();

        return transformedMessage;
    }
    catch (Exception exception)
    {
        string message = "Exception: " + exception.Message;
        WriteLog(message, logfile);
        throw;
    }
}
