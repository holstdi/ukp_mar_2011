namespace nothinbutdotnetprep.utility.filtering
{
    public static class ConditionalCriteriaFactory
    {
        public static ConditionalCriteria<ItemToFilter> Create<ItemToFilter>(MatchingCondition<ItemToFilter> condition)
        {
            return new ConditionalCriteria<ItemToFilter>(condition);
        }
    }
}