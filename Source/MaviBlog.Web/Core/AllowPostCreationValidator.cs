using System.Web;
using System.Web.Util;

namespace MaviBlog.Web.Core
{
    public class AllowPostCreationValidator : RequestValidator
    {
        protected override bool IsValidRequestString(HttpContext context, string value, RequestValidationSource requestValidationSource, string collectionKey, out int validationFailureIndex)
        {
            if (IsContentCreationRequest(context, requestValidationSource, collectionKey))
            {
                validationFailureIndex = -1;
                return true;
            }

            return base.IsValidRequestString(context, value, requestValidationSource, collectionKey, out validationFailureIndex);
        }

        private bool IsContentCreationRequest(HttpContext context, RequestValidationSource requestValidationSource, string collectionKey)
        {
            if (context.Request.HttpMethod != "POST") return false;
            if (context.Request.Path != "/post") return false;
            if (requestValidationSource != RequestValidationSource.Form) return false;
            return collectionKey == "Content";
        }
    }
}