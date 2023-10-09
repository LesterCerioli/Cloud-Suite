namespace CloudSuite.Modules.Common.Helpers.Backbone
{
    public static class XMLHelper
    {
        #region Serialization with custom encoding

        public static string ToXmlUnicode<T>(T instance, bool emptyNamespace)
        {
            return ToXml(instance, Encoding.Unicode, emptyNamespace);
        }

        public static string ToXmlUtf8<T>(T instance, bool emptyNamespace)
        {
            return ToXml(instance, Encoding.UTF8, emptyNamespace);
        }

        public static string ToXmlIso88591<T>(T instance, bool emptyNamespace)
        {
            return ToXml(instance, Encoding.GetEncoding("ISO-8859-1"), emptyNamespace);
        }

        public static string ToXmlUnicode(object instance, bool emptyNamespace)
        {
            return ToXml(instance, Encoding.Unicode, emptyNamespace);
        }

        public static string ToXmlUtf8(object instance, bool emptyNamespace)
        {
            return ToXml(instance, Encoding.UTF8, emptyNamespace);
        }

        public static string ToXmlIso88591(object instance, bool emptyNamespace)
        {
            return ToXml(instance, Encoding.GetEncoding("ISO-8859-1"), emptyNamespace);
        }

        public static string ToXml<T>(T instance, Encoding encoding, bool emptyNamespace)
        {
            return ToXml(typeof(T), instance, encoding, emptyNamespace);
        }

        public static string ToXml(object instance, Encoding encoding, bool emptyNamespace)
        {
            return ToXml(instance.GetType(), instance, encoding, emptyNamespace);
        }

        public static string ToXml(Type type, object instance, Encoding encoding, bool emptyNamespace)
        {
            var serializer = new XmlSerializer(type);
            return ToXml(instance, encoding, serializer, emptyNamespace);
        }

        public static string ToXml(object instance, Encoding encoding, XmlSerializer serializer, bool emptyNamespace)
        {
            try
            {
                byte[] bytes;
                using (var memoryStream = new MemoryStream())
                {
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    var xmlTextWriter = new XmlTextWriter(memoryStream, encoding);
                    if (emptyNamespace)
                        serializer.Serialize(xmlTextWriter, instance, ns);
                    else
                        serializer.Serialize(xmlTextWriter, instance);

                    bytes = memoryStream.ToArray();
                }
                String XmlizedString = encoding.GetString(bytes);

                return XmlizedString;
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception(String.Format("Unable to serialize type {0}: {1}",
                                                  instance.GetType().Name, ex.Message));
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Unknown error of type {0} while serializing {1}: {2}",
                                                  ex.GetType().Name, instance.GetType().Name, ex.Message));
            }
        }

        #endregion

        #region Serialization with default encoding (UTF-16 / unicode)

        public static string ToXml<T>(T instance)
        {
            return ToXml(typeof(T), instance);
        }

        public static string ToXml(object instance)
        {
            return ToXml(instance.GetType(), instance);
        }

        public static string ToXml<T>(T instance, XmlSerializer serializer, bool emptyNamespace)
        {
            return ToXml(instance, Encoding.Unicode, serializer, emptyNamespace);
        }

        public static string ToXml<T>(T instance, bool stripNamespaces)
        {
            return ToXml(typeof(T), instance);
        }

        private static string ToXml(Type type, object instance)
        {
            if (instance == null)
                return null;

            string xml;
            var serializer = new XmlSerializer(type);

            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, instance);
                writer.Close();
                xml = writer.ToString();
            }
            return xml;
        }

        private static string GetNamespaceForType(Type t)
        {
            foreach (object attribute in t.GetCustomAttributes(true))
            {
                if (attribute is XmlElementAttribute)
                    return (attribute as XmlElementAttribute).Namespace;
                if (attribute is XmlTypeAttribute)
                    return (attribute as XmlTypeAttribute).Namespace;
                if (attribute is XmlRootAttribute)
                    return (attribute as XmlRootAttribute).Namespace;
            }
            return String.Empty;
        }
        #endregion

        public static XmlElement ToXmlElement<T>(T instance)
        {
            string xml = ToXml(instance);
            var doc = new XmlDocument();
            doc.LoadXml(xml);
            return doc.DocumentElement;
        }

        public static T FromXml<T>(string xml)
        {
            return (T)FromXml(xml, new XmlSerializer(typeof(T)));
        }

        public static T FromXml<T>(string xml, Type[] extraTypes)
        {
            return (T)FromXml(xml, new XmlSerializer(typeof(T), extraTypes));
        }

        public static object FromXml(Type type, string xml)
        {
            return FromXml(xml, new XmlSerializer(type));
        }

        public static object FromXml(Type type, string xml, XmlAttributeOverrides overrides)
        {
            return FromXml(xml, new XmlSerializer(type, overrides));
        }

        public static T FromXml<T>(string xml, XmlSerializer serializer)
        {
            return (T)FromXml(xml, serializer);
        }

        public static object FromXml(string xml, XmlSerializer serializer)
        {
            if (string.IsNullOrEmpty(xml) || serializer == null)
                return null;

            object instance;
            using (var xmlReader = new XmlTextReader(xml, XmlNodeType.Document, null))
                instance = serializer.Deserialize(xmlReader);
            return instance;
        }
        
    }
}