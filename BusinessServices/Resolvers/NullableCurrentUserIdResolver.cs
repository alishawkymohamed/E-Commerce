using AutoMapper;
using System;

namespace BusinessServices.Resolvers
{
    public class NullableCurrentUserIdResolver : AutoMapper.IValueResolver<object, object, int?>
    {
        public int? Resolve(object source, object destination, int? destMember, ResolutionContext context)
        {
            var CurrentUserIdString = Convert.ToString(context.Items["CurrentUserId"]);
            return string.IsNullOrEmpty(CurrentUserIdString) ? (int?)null : int.Parse(CurrentUserIdString);
        }
    }
}