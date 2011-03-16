using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.filtering
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> one_at_a_time<T>(this IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }

        public static IEnumerable<ItemToMatch> all_items_matching<ItemToMatch>(this IEnumerable<ItemToMatch> items,
                                                                               Criteria<ItemToMatch> criteria)
        {
            return items.all_items_matching(criteria.matches);
        }

        static IEnumerable<ItemToMatch> all_items_matching<ItemToMatch>(this IEnumerable<ItemToMatch> items,
                                                                               MatchingCondition<ItemToMatch> criteria)
        {
            foreach (var item_to_match in items)
            {
                if (criteria(item_to_match)) yield return item_to_match;
            }
        }

        public static Jos<ItemToMatch, ReturnType> where<ItemToMatch, ReturnType>(this IEnumerable<ItemToMatch> items,
            PropertyAccessor<ItemToMatch, ReturnType> property_accessor)
        {
            return new Jos<ItemToMatch,ReturnType>(items, property_accessor);
        }
    }

    public class Jos<ItemToMatch,ReturnType>
    {
        public IEnumerable<ItemToMatch> items { get; private set; }
        public PropertyAccessor<ItemToMatch, ReturnType> property_accessor { get; private set; }

        public Jos(IEnumerable<ItemToMatch> items, PropertyAccessor<ItemToMatch,ReturnType> property_accessor)
        {
            this.items = items;
            this.property_accessor = property_accessor;
        }

    }

    public static class JosExtensions
{
   public static IEnumerable<ItemToMatch> equal_to_any<ItemToMatch,ReturnType>(this Jos<ItemToMatch,ReturnType> jos, params ReturnType[] values)
   {
       return jos.items.all_items_matching(Where<ItemToMatch>.has_a(jos.property_accessor).equal_to_any(values));
   }
}
}