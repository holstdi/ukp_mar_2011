using System;
//todo : Get Rid Of This
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.utility.filtering
{
    public static class Where<ItemToFilter>
    {
        public static Factory<ItemToFilter,ReturnType> has_a<ReturnType>(PropertyAccessor<ItemToFilter, ReturnType> property_accessor)
        {
            return new Factory<ItemToFilter, ReturnType>(property_accessor);
        }
    }

    public class Factory<ItemToMatch, PropertyType>{
        private readonly PropertyAccessor<ItemToMatch, PropertyType> _propertyAccessor;

        public Factory(PropertyAccessor<ItemToMatch, PropertyType> propertyAccessor)
        {
            _propertyAccessor = propertyAccessor;
        }

        public Criteria<ItemToMatch> equal_to(ProductionStudio value)
        {
            MatchingCondition<ItemToMatch> condition =
                (movie) => _propertyAccessor.Invoke(movie).Equals(value);
            return new ConditionalCriteria<ItemToMatch>(condition);
        }
    }

}