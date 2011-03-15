using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public class DefaultCriteriaFactory<ItemToFilter, ReturnType> : CriteriaFactory<ItemToFilter, ReturnType>
    {
        PropertyAccessor<ItemToFilter, ReturnType> property_accessor;

        public DefaultCriteriaFactory(PropertyAccessor<ItemToFilter, ReturnType> property_accessor)
        {
            this.property_accessor = property_accessor;
        }

        public Criteria<ItemToFilter> equal_to(ReturnType value_to_equal)
        {
            return equal_to_any(value_to_equal);
        }

        public Criteria<ItemToFilter> equal_to_any(params ReturnType[] values)
        {
            return create_from(new IsEqualToAny<ReturnType>(values));
        }

        public Criteria<ItemToFilter> not_equal_to(ReturnType value)
        {
            return equal_to(value).not();
        }

        public Criteria<ItemToFilter> create_from(Criteria<ReturnType> property_criteria)
        {
            return new PropertyCriteria<ItemToFilter, ReturnType>(property_accessor,
                                                                  property_criteria);
        }

        public NotCriteriaFactory<ItemToFilter, ReturnType> not
        {
            get { return new NotCriteriaFactory<ItemToFilter, ReturnType>(this); }
        }
    }

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