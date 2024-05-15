namespace InsecureApi.Classes
{
    [XmlRoot(ElementName = "document", Namespace = "")]
    public class XmlModel
    {
        [XmlElement(DataType = "string", ElementName = "UserId")]
        public string UserId { get; set; }

        [XmlElement(DataType = "string", ElementName = "UserName")]
        public string UserName { get; set; }
    }
}