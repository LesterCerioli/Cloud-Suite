namespace CloudSuite.Modules.Fiscal.Domain.Models.IcmsContext
{
    public abstract class Icms
    {
        private readonly OrigemMercadiria _origem;

        public OrigemMercadiria Origem
        {
            get => _origem;
            set
            {
                //ValidationUtil.ValidateEnum(value, "Origem");
                //_origem = value;
            }
        }

        public virtual SituacaoTributariaICMS CST { get; protected set; }

        //public void Serializar(XmlWriter writer, INFe nfe)
        //{
        //SerializeInternal(writer, nfe);
        //}

        //protected abstract void SerializeInternal(XmlWriter writer, INFe nfe);
        
    }
}