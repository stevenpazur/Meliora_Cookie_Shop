namespace Meliora.BusinessLayer.shared
{
    public abstract class BaseRequestModel<T>
    {
        public IEnumerable<OptionListValue<RequestErrors>>? ValidationErrors => DoValidation();
        protected abstract IEnumerable<OptionListValue<RequestErrors>>? DoValidation();
        public abstract IEnumerable<OptionListValue<RequestErrors>> GetPossibleRequestErrors();
        public abstract T Map();
    }
}
