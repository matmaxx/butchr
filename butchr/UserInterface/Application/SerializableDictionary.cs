using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Matmaxx.Toolbox
{
  /// <summary>
  /// Implementation of an xml serializable Dictionary.
  /// </summary>
  /// <typeparam name="TKey">The type of the key.</typeparam>
  /// <typeparam name="TValue">The type of the value.</typeparam>
  [XmlRoot("dictionary")]
  public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable
  {
    #region IXmlSerializable Members
    /// <summary>
    /// This method is reserved and should not be used. 
    /// When implementing the IXmlSerializable interface, you should return null from this method, 
    /// and instead, if specifying a custom schema is required, 
    /// apply the <see cref="T:System.Xml.Serialization.XmlSchemaProviderAttribute"/> to the class.
    /// </summary>
    /// <returns>
    /// An <see cref="T:System.Xml.Schema.XmlSchema"/> that describes the XML representation of the object that 
    /// is produced by the <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)"/> 
    /// method and consumed by the <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)"/> method.
    /// </returns>
    public System.Xml.Schema.XmlSchema GetSchema()
    {
      //do as you are told by the ghostdoc comment
      return null;
    }
    /// <summary>
    /// Generates an object from its XML representation.
    /// </summary>
    /// <param name="reader">The <see cref="T:System.Xml.XmlReader"/> stream from which the object is deserialized.</param>
    public void ReadXml(System.Xml.XmlReader reader)
    {
      //serializer for the keys
      XmlSerializer keySerializer   = new XmlSerializer(typeof(TKey));
      //serializer for the values
      XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));
      //check for empty elements
      bool wasEmpty = reader.IsEmptyElement;
      //perform the read 
      reader.Read();
      //don't go on with an empty dictionary
      if(wasEmpty) return;
      //loop up to the end of the element
      while(reader.NodeType != System.Xml.XmlNodeType.EndElement)
      {
        //read the top level tag ('item') for this entry
        reader.ReadStartElement("item");
        //read the key part of this entry
        reader.ReadStartElement("key");
        //deserialize the content of the key
        TKey key = (TKey)keySerializer.Deserialize(reader);
        //consume the endtag of the key
        reader.ReadEndElement();
        //read the key part of this entry
        reader.ReadStartElement("value");
        //deserialize the content of the value part
        TValue value = (TValue)valueSerializer.Deserialize(reader);
        //consume the endtag of the value
        reader.ReadEndElement();
        //add the key-value pair to this dictionary
        this.Add(key, value);
        //consume the item's end element
        reader.ReadEndElement();
        //advance the reader once more
        reader.MoveToContent();
      }
      //and a lst read to get the reader in position for the next call
      reader.ReadEndElement();
    }
    /// <summary>
    /// Converts an object into its XML representation.
    /// </summary>
    /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized.</param>
    public void WriteXml(System.Xml.XmlWriter writer)
    {
      //serializer for the keys
      XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
      //serializer for the values
      XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));
      //loop all keys in this dictionary
      foreach(TKey key in this.Keys)
      {
        //write the item start tag for this entry
        writer.WriteStartElement("item");
        //write the key start tag for this entry
        writer.WriteStartElement("key");
        //serialize the contents of this entry's key
        keySerializer.Serialize(writer, key);
        //write the key end tag for this entry
        writer.WriteEndElement();
        //write the value start tag for this entry
        writer.WriteStartElement("value");
        //get the value for the current key
        TValue value = this[key];
        //serialize the contents of this entry's value
        valueSerializer.Serialize(writer, value);
        //write the value end tag for this entry
        writer.WriteEndElement();
        //write the item end tag for this entry
        writer.WriteEndElement();
      }
    }
    #endregion
  }
}