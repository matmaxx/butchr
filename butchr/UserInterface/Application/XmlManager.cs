using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.IO;

namespace Matmaxx.Toolbox
{
  /// <summary>
  /// Handles all serialization issues for reading and writing object models from/to xml.
  /// </summary>
  /// <typeparam name="SerializationType">The type that shall be serialized.</typeparam>
  public class XmlManager<SerializationType> where SerializationType : new()
  {
    #region properties
    /// <summary>
    /// the model
    /// </summary>
    private SerializationType model;
    /// <summary>
    /// Gets or sets the model.
    /// </summary>
    /// <value>The model.</value>
    public SerializationType Model
    {
      get { return model; }
      set { model = value; }
    }
    /// <summary>
    /// The path from where to read the xml file.
    /// </summary>
    private string inputPath;
    /// <summary>
    /// Gets or sets the input path.
    /// </summary>
    /// <value>The input path.</value>
    public string InputPath
    {
      get { return inputPath; }
      set { inputPath = value; }
    }
    /// <summary>
    /// The path where to write the xml file to.
    /// </summary>
    private string outputPath;
    /// <summary>
    /// Gets or sets the output path.
    /// </summary>
    /// <value>The output path.</value>
    public string OutputPath
    {
      get { return outputPath; }
      set { outputPath = value; }
    }
    #endregion  

    #region members
    /// <summary>
    /// The serializer object to automatically transform the xml file.
    /// </summary>
    private XmlSerializer serializer;
    /// <summary>
    /// The reader to access the filessystem for readjobs.
    /// </summary>
    private TextReader reader;
    /// <summary>
    /// The writer to access the filessystem for writejobs.
    /// </summary>
    private TextWriter writer;
    /// <summary>
    /// The namespace container
    /// </summary>
    private XmlSerializerNamespaces namespaces;
    #endregion

    #region lifecycle code
    /// <summary>
    /// Initializes a new instance of the <see cref="XmlManager&lt;SerializationType&gt;"/> class.
    /// </summary>
    public XmlManager():this("","")
    {
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="XmlManager&lt;SerializationType&gt;"/> class.
    /// </summary>
    /// <param name="oneFilePath">The one file path.</param>
    public XmlManager(string oneFilePath):this(oneFilePath,oneFilePath)
    {
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="XmlManager&lt;SerializationType&gt;"/> class.
    /// </summary>
    /// <param name="inputPath">The input path.</param>
    /// <param name="outputPath">The output path.</param>
    public XmlManager(string inputPath, string outputPath)
    {
      try
      {
        //backup the file paths
        InputPath = inputPath;
        OutputPath = outputPath;
        //init the model
        model = new SerializationType();
        //create the xml serializer
        serializer = new XmlSerializer(typeof(SerializationType));
        // Create an XmlSerializerNamespaces object.
        namespaces = new XmlSerializerNamespaces();
      }
      catch(Exception ex)
      {
        //marshal the exception and rethrow
        throw new SerializationException("Cannot create an instance of the XmlManager<" + typeof(SerializationType).ToString() + ">.",ex);
      }
    }
    #endregion

    #region namespacing
    /// <summary>
    /// Adds a new namespace with shortcut to the namespacecontainer.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    public void AddNamespace(string key, string value)
    {
      namespaces.Add(key, value);
    }
    #endregion

    #region deserialization
    /// <summary>
    /// Deserializes the object model from the path that was specified during construction.
    /// </summary>
    public void Deserialize()
    {
      //check for a valid input file
      if(File.Exists(inputPath).Equals(false)) 
      {
        //file not found -> throw the corresponding exception
        throw new FileNotFoundException("The input file for the XmlDeserialization<" + typeof(SerializationType).ToString() + "> could not be found at: " + inputPath);
      }
      //now try to read the file
      try
      {
        //create a text reader for the file on the harddisk
        reader = new StreamReader(inputPath,Encoding.Default);
        //read the file from the disk to the internal datamodel
        model = (SerializationType)serializer.Deserialize(reader);
      }
      catch(Exception ex)
      {
        //marshal the exception and rethrow
        throw new SerializationException("XmlManager<" + typeof(SerializationType).ToString() + "> cannot deserialize from the input file at: " + inputPath,ex);
      }
      finally
      {
        //finally close the reader
        reader.Close();
      }

    }
    /// <summary>
    /// Deserializes the object model from the specified path instead of the one that was specified during construction.
    /// </summary>
    /// <param name="path">The new path for deserialization.</param>
    public void Deserialize(string path)
    {
      //update the input path
      inputPath = path;
      //and call the deserialization method
      this.Deserialize();
    }
    #endregion

    #region serialization
    /// <summary>
    /// Serializes the object model to the path that was specified during construction.
    /// </summary>
    public void Serialize()
    {
      //check for a nonempty output path
      if(outputPath.Trim().Equals(String.Empty))
      {
        //output path empty -> throw the corresponding exception
        throw new InvalidDataException("The output file for the XmlSerialization<" + typeof(SerializationType).ToString() + "> is not specified.");
      }
      try
      {
        //create an instance of the textwriter
        writer = new StreamWriter(OutputPath,false,Encoding.Default);
        //output the xml file to the disk
        serializer.Serialize(writer,(object)model,namespaces);
      }
      catch(Exception ex)
      {
        //marshal the exception and rethrow
        throw new SerializationException("XmlManager<" + typeof(SerializationType).ToString() + "> cannot serialize to the output file at: " + outputPath,ex);
      }
      finally
      {
        //finally close the writer again
        writer.Close();
      }
    }
    /// <summary>
    /// Serializes the object model to the specified path instead of the one that was specified during construction.
    /// </summary>
    /// <param name="path">The new path for serialization.</param>
    public void Serialize(string path)
    {
      //update the output path
      outputPath = path;
      //and call the serialization method
      this.Serialize();
    }
  	#endregion
  }

}

