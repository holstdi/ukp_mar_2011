using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public static class CriteriaExtensions
    {

        public static Criteria<ItemToMatch> as_criteria<ItemToMatch>(this MatchingCondition<ItemToMatch> condition)
        {
            return new ConditionalCriteria<ItemToMatch>(condition);
        }

        public static Criteria<ItemToMatch> or<ItemToMatch>(this Criteria<ItemToMatch> left,
                                                            Criteria<ItemToMatch> right)
        {
            return new OrCriteria<ItemToMatch>(left, right);
        }

        public static Criteria<ItemToMatch> not<ItemToMatch>(this Criteria<ItemToMatch> toInvert)
        {
            return new NotCriteria<ItemToMatch>(toInvert);
        }
    }

    public class NotCriteria<ItemToMatch> : Criteria<ItemToMatch>
{
        private readonly Criteria<ItemToMatch> _toInvert;

        public NotCriteria(Criteria<ItemToMatch> toInvert)
        {
            _toInvert = toInvert;
        }

        public bool matches(ItemToMatch item)
        {
            return !_toInvert.matches(item);
        }
}
}