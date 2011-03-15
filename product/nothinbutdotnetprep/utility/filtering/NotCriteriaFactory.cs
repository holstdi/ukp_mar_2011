namespace nothinbutdotnetprep.utility.filtering
{
    public class NotCriteriaFactory<ItemToFilter,ReturnType>:CriteriaFactory<ItemToFilter,ReturnType>
    {
        private readonly DefaultCriteriaFactory<ItemToFilter, ReturnType> _defaultCriteriaFactory;

        public NotCriteriaFactory(DefaultCriteriaFactory<ItemToFilter, ReturnType> defaultCriteriaFactory)
        {
            _defaultCriteriaFactory = defaultCriteriaFactory;
        }

        public Criteria<ItemToFilter> create_from(Criteria<ReturnType> property_criteria)
        {
            return _defaultCriteriaFactory.create_from(property_criteria).not();
        }

        public Criteria<ItemToFilter> equal_to(ReturnType value_to_equal)
        {
            return _defaultCriteriaFactory.equal_to(value_to_equal).not();
        }

        public Criteria<ItemToFilter> equal_to_any(params ReturnType[] values)
        {
            return _defaultCriteriaFactory.equal_to_any(values).not();
        }
    }
}